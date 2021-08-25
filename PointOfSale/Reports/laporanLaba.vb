Imports MySql.Data.MySqlClient
Public Class laporanLaba

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rp As lapLaba = New lapLaba
        Dim st, et As String
        st = TimeToString(DateTimePicker1.Value)
        et = TimeToString(New Date(DateTimePicker2.Value.Year, DateTimePicker2.Value.Month, DateTimePicker2.Value.Day, 17, 0, 0))

        Dim ds As New DataSet
        adapter = New MySqlDataAdapter("SELECT kode_transaksi, timestamps, nama_barang, SUM(qty) AS qty, SUM(harga_beli) AS harga_beli, SUM(subtotal) AS subtotal, harga, total, bayar, discount, kembali,kasir, nama_kasir FROM struk_view a WHERE timestamps >='" & st & "' AND timestamps <='" & et & "' GROUP BY kode_transaksi", connection)
        adapter.Fill(ds, "struk_view")
        For Each ro As DataRow In ds.Tables(0).Rows
            ro.Item("timestamps") = StringToTime(ro.Item("timestamps")).ToLongDateString()
        Next

        CrystalReportViewer1.ReportSource = Nothing
        CrystalReportViewer1.Refresh()

        rp.Database.Tables(0).SetDataSource(ds.Tables(0))
        ''rp.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = rp
    End Sub

    Private Sub laporanLaba_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = New Date(Date.Now.Year - 1, Date.Now.Month, Date.Now.Day)
        DateTimePicker2.Value = New Date(Date.Now.Year, Date.Now.Month, Date.Now.Day)
    End Sub
End Class