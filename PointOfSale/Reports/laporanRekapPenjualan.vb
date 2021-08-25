Imports MySql.Data.MySqlClient

Public Class laporanRekapPenjualan

    Private Sub laporanRekapPenjualan_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub laporanRekapPenjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rp As rekapPenjualan = New rekapPenjualan
        Dim ds As New DataSet
        adapter = New MySqlDataAdapter("SELECT kode_transaksi, timestamps, nama_barang, SUM(qty) AS qty, harga_beli, harga, subtotal, total, bayar, discount, kembali,kasir, nama_kasir FROM struk_view a GROUP BY kode_transaksi", connection)
        adapter.Fill(ds, "struk_view")
        For Each ro As DataRow In ds.Tables(0).Rows
            ro.Item("timestamps") = StringToTime(ro.Item("timestamps").ToString()).ToLongDateString()
        Next
        Dim res As String = ds.Tables(0).Rows(0).Item("timestamps").ToString()
        CrystalReportViewer1.ReportSource = Nothing
        CrystalReportViewer1.Refresh()

        rp.Database.Tables(0).SetDataSource(ds.Tables(0))
        ''rp.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = rp
    End Sub
End Class