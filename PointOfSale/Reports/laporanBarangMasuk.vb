Imports MySql.Data.MySqlClient

Public Class laporanBarangMasuk
    
    Private Sub laporanBarangMasuk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rp As barangMasuk = New barangMasuk
        CrystalReportViewer1.ReportSource = rp
        rp.Refresh()
        CrystalReportViewer1.Refresh()
    End Sub
End Class