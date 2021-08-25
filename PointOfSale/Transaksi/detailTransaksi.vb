Imports MySql.Data.MySqlClient

Public Class detailTransaksi
    Private kodetransaksi As String

    Public Overloads Sub Show(ByVal kode As String)
        kodetransaksi = kode
        adapter = New MySqlDataAdapter("SELECT a.kode_transaksi, a.timestamps, a.nama_barang AS 'Nama Barang', a.qty, a.harga AS 'Harga Satuan', a.subtotal AS Subtotal, a.total, a.bayar, a.discount, a.kembali, a.kasir, a.nama_kasir AS 'Nama Kasir', b.id FROM struk_view a LEFT OUTER JOIN users b ON a.kasir=b.username WHERE kode_transaksi= '" & kode & "'", connection)
        Dim ds As New DataSet
        adapter.Fill(ds, "struk_view")
        With ds.Tables("struk_view")
            Dim d As Date = StringToTime(.Rows(0).Item("timestamps").ToString())
            field1.Text = d.DayOfWeek.ToString() & ", " & d.ToLongDateString & " " & d.ToLongTimeString
            field3.Text = .Rows(0).Item("kode_transaksi").ToString()
            field2.Text = .Rows(0).Item("id").ToString()
            field4.Text = .Rows(0).Item("Nama Kasir").ToString()
            Label4.Text = d.DayOfWeek.ToString() & ", " & d.ToLongDateString() & " " & d.ToLongTimeString()

            Label40.Text = "Rp." & FormatNumber(.Rows(0).Item("total").ToString() - .Rows(0).Item("discount").ToString(), 0)
            Label2.Text = "Rp." & FormatNumber(.Rows(0).Item("bayar").ToString(), 0)
            Label24.Text = "Rp." & FormatNumber(.Rows(0).Item("kembali").ToString(), 0)
            Label1.Text = "Rp." & FormatNumber(.Rows(0).Item("discount").ToString(), 0)
            Label30.Text = "Rp." & FormatNumber(.Rows(0).Item("total").ToString(), 0)
            .Columns.Remove("kode_transaksi")
            .Columns.Remove("timestamps")
            .Columns.Remove("total")
            .Columns.Remove("bayar")
            .Columns.Remove("discount")
            .Columns.Remove("kembali")
            .Columns.Remove("kasir")
            .Columns.Remove("Nama Kasir")
        End With

        dgv1.DataSource = ds.Tables("struk_view")
        Me.Show()
    End Sub

    Private Sub detailTransaksi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim struk As StrukTransaksi = New StrukTransaksi(kodetransaksi)
        struk.PrintAsync()
    End Sub
End Class