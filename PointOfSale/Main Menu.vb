Imports System.Windows.Forms

Public Class Main_Menu
    Public tutup As Boolean = True

    Private Sub Main_Menu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If tutup Then
            If MessageBox.Show("Anda yakin ingin menutup aplikasi ?", "Tutup aplikasi", MessageBoxButtons.YesNo) = DialogResult.No Then
                e.Cancel = True
            Else
                loginForm.Close()
            End If
        Else
            loginForm.Show()
        End If
    End Sub

    Private Sub Main_Menu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case leveluser
            Case Level.kasir
                ToolStripDropDownButton1.Enabled = False
                ToolStripDropDownButton2.Enabled = True
                ToolStripDropDownButton3.Enabled = False
                ToolStripDropDownButton4.Enabled = True
            Case Level.admin
                ToolStripDropDownButton1.Enabled = True
                ToolStripDropDownButton2.Enabled = True
                ToolStripDropDownButton3.Enabled = False
                ToolStripDropDownButton4.Enabled = True
            Case Else
                ToolStripDropDownButton1.Enabled = True
                ToolStripDropDownButton2.Enabled = False
                ToolStripDropDownButton3.Enabled = True
                ToolStripDropDownButton4.Enabled = True
        End Select

        ToolStripStatusLabel.Text = nama
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        tutup = False
        loginForm.Show()
        username = ""
        nama = ""
        password = ""
        leveluser = Level.kasir
        Me.Close()
    End Sub

    Private Sub SuplierToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuplierToolStripMenuItem1.Click
        Dim supl As suplierForm = New suplierForm
        supl.MdiParent = Me
        supl.Show()
    End Sub

    Private Sub AkunPenggunaToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AkunPenggunaToolStripMenuItem2.Click
        Dim akunp As akunForm = New akunForm
        akunp.MdiParent = Me
        akunp.Show()
    End Sub

    Private Sub UbahPasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UbahPasswordToolStripMenuItem.Click
        Dim ak As editAkun = New editAkun
        ak.MdiParent = Me
        ak.Ubah(id)
    End Sub

    Private Sub DataBarangToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataBarangToolStripMenuItem1.Click
        Dim brg As masterBarangForm = New masterBarangForm
        brg.MdiParent = Me
        brg.Show()
    End Sub

    Private Sub BarcodeBarangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarcodeBarangToolStripMenuItem.Click
        Dim bc As barcodeForm = New barcodeForm
        bc.MdiParent = Me
        bc.Show()
    End Sub

    Private Sub PenjualanToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenjualanToolStripMenuItem1.Click
        Dim trn As Transaksi_Penjualan = New Transaksi_Penjualan
        trn.MdiParent = Me
        trn.Show()
    End Sub

    Private Sub TransaksiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransaksiToolStripMenuItem.Click
        Dim tr As transaksiForm = New transaksiForm
        tr.MdiParent = Me
        tr.Show()
    End Sub

    Private Sub BarangMasukToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarangMasukToolStripMenuItem1.Click
        Dim brg As barangMasukForm = New barangMasukForm
        brg.MdiParent = Me
        brg.Show()
    End Sub

    Private Sub StatistikToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatistikToolStripMenuItem.Click
        Dim l As laporanStatistik = New laporanStatistik
        l.MdiParent = Me
        l.Show()
    End Sub

    Private Sub RekapitulasiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RekapitulasiToolStripMenuItem.Click
        Dim lap As laporanRekapPenjualan = New laporanRekapPenjualan
        lap.MdiParent = Me
        lap.Show()
    End Sub

    Private Sub BarangMasukToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarangMasukToolStripMenuItem.Click
        Dim lap As laporanBarangMasuk = New laporanBarangMasuk
        lap.MdiParent = Me
        lap.Show()
    End Sub

    Private Sub StokBarangToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StokBarangToolStripMenuItem1.Click
        Dim lap As laporanBarang = New laporanBarang
        lap.MdiParent = Me
        lap.Show()
    End Sub

    Private Sub LabaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabaToolStripMenuItem.Click
        Dim lap As laporanLaba = New laporanLaba
        lap.MdiParent = Me
        lap.Show()
    End Sub
End Class
