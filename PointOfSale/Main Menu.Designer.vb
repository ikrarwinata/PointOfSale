<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_Menu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main_Menu))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.MasterBarangToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataBarangToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarangMasukToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BarcodeBarangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransaksiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuplierToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AkunPenggunaToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PenjualanToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton3 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TransaksiToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatistikToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.RekapitulasiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarangMasukToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StokBarangToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton4 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.UbahPasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 398)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(983, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Nama"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripDropDownButton2, Me.ToolStripDropDownButton3, Me.ToolStripDropDownButton4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(983, 25)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterBarangToolStripMenuItem1, Me.TransaksiToolStripMenuItem, Me.SuplierToolStripMenuItem1, Me.AkunPenggunaToolStripMenuItem2})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripDropDownButton1.Text = "Master"
        '
        'MasterBarangToolStripMenuItem1
        '
        Me.MasterBarangToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataBarangToolStripMenuItem1, Me.BarangMasukToolStripMenuItem1, Me.ToolStripSeparator2, Me.BarcodeBarangToolStripMenuItem})
        Me.MasterBarangToolStripMenuItem1.Name = "MasterBarangToolStripMenuItem1"
        Me.MasterBarangToolStripMenuItem1.Size = New System.Drawing.Size(159, 22)
        Me.MasterBarangToolStripMenuItem1.Text = "Master Barang"
        '
        'DataBarangToolStripMenuItem1
        '
        Me.DataBarangToolStripMenuItem1.Name = "DataBarangToolStripMenuItem1"
        Me.DataBarangToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.DataBarangToolStripMenuItem1.Text = "Data Barang"
        '
        'BarangMasukToolStripMenuItem1
        '
        Me.BarangMasukToolStripMenuItem1.Name = "BarangMasukToolStripMenuItem1"
        Me.BarangMasukToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.BarangMasukToolStripMenuItem1.Text = "Barang Masuk"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(154, 6)
        '
        'BarcodeBarangToolStripMenuItem
        '
        Me.BarcodeBarangToolStripMenuItem.Name = "BarcodeBarangToolStripMenuItem"
        Me.BarcodeBarangToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.BarcodeBarangToolStripMenuItem.Text = "Barcode Barang"
        '
        'TransaksiToolStripMenuItem
        '
        Me.TransaksiToolStripMenuItem.Name = "TransaksiToolStripMenuItem"
        Me.TransaksiToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.TransaksiToolStripMenuItem.Text = "Transaksi"
        '
        'SuplierToolStripMenuItem1
        '
        Me.SuplierToolStripMenuItem1.Name = "SuplierToolStripMenuItem1"
        Me.SuplierToolStripMenuItem1.Size = New System.Drawing.Size(159, 22)
        Me.SuplierToolStripMenuItem1.Text = "Suplier"
        '
        'AkunPenggunaToolStripMenuItem2
        '
        Me.AkunPenggunaToolStripMenuItem2.Name = "AkunPenggunaToolStripMenuItem2"
        Me.AkunPenggunaToolStripMenuItem2.Size = New System.Drawing.Size(159, 22)
        Me.AkunPenggunaToolStripMenuItem2.Text = "Akun Pengguna"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PenjualanToolStripMenuItem1})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(67, 22)
        Me.ToolStripDropDownButton2.Text = "Transaksi"
        '
        'PenjualanToolStripMenuItem1
        '
        Me.PenjualanToolStripMenuItem1.Name = "PenjualanToolStripMenuItem1"
        Me.PenjualanToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.PenjualanToolStripMenuItem1.Text = "Penjualan"
        '
        'ToolStripDropDownButton3
        '
        Me.ToolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TransaksiToolStripMenuItem1, Me.BarangMasukToolStripMenuItem, Me.StokBarangToolStripMenuItem1, Me.LabaToolStripMenuItem})
        Me.ToolStripDropDownButton3.Image = CType(resources.GetObject("ToolStripDropDownButton3.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton3.Name = "ToolStripDropDownButton3"
        Me.ToolStripDropDownButton3.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripDropDownButton3.Text = "Laporan"
        '
        'TransaksiToolStripMenuItem1
        '
        Me.TransaksiToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatistikToolStripMenuItem, Me.ToolStripSeparator3, Me.RekapitulasiToolStripMenuItem})
        Me.TransaksiToolStripMenuItem1.Name = "TransaksiToolStripMenuItem1"
        Me.TransaksiToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.TransaksiToolStripMenuItem1.Text = "Transaksi"
        '
        'StatistikToolStripMenuItem
        '
        Me.StatistikToolStripMenuItem.Name = "StatistikToolStripMenuItem"
        Me.StatistikToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.StatistikToolStripMenuItem.Text = "Statistik"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(134, 6)
        '
        'RekapitulasiToolStripMenuItem
        '
        Me.RekapitulasiToolStripMenuItem.Name = "RekapitulasiToolStripMenuItem"
        Me.RekapitulasiToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.RekapitulasiToolStripMenuItem.Text = "Rekapitulasi"
        '
        'BarangMasukToolStripMenuItem
        '
        Me.BarangMasukToolStripMenuItem.Name = "BarangMasukToolStripMenuItem"
        Me.BarangMasukToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BarangMasukToolStripMenuItem.Text = "Barang Masuk"
        '
        'StokBarangToolStripMenuItem1
        '
        Me.StokBarangToolStripMenuItem1.Name = "StokBarangToolStripMenuItem1"
        Me.StokBarangToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.StokBarangToolStripMenuItem1.Text = "Stok Barang"
        '
        'LabaToolStripMenuItem
        '
        Me.LabaToolStripMenuItem.Name = "LabaToolStripMenuItem"
        Me.LabaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LabaToolStripMenuItem.Text = "Laba"
        '
        'ToolStripDropDownButton4
        '
        Me.ToolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UbahPasswordToolStripMenuItem, Me.ToolStripSeparator1, Me.LogoutToolStripMenuItem})
        Me.ToolStripDropDownButton4.Image = CType(resources.GetObject("ToolStripDropDownButton4.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton4.Name = "ToolStripDropDownButton4"
        Me.ToolStripDropDownButton4.Size = New System.Drawing.Size(48, 22)
        Me.ToolStripDropDownButton4.Text = "Akun"
        '
        'UbahPasswordToolStripMenuItem
        '
        Me.UbahPasswordToolStripMenuItem.Name = "UbahPasswordToolStripMenuItem"
        Me.UbahPasswordToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.UbahPasswordToolStripMenuItem.Text = "Ubah Password"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(152, 6)
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'Main_Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 420)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.Name = "Main_Menu"
        Me.Text = "Menu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents MasterBarangToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataBarangToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SuplierToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AkunPenggunaToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents PenjualanToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton3 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TransaksiToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarangMasukToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StokBarangToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton4 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents UbahPasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarcodeBarangToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransaksiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarangMasukToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StatistikToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RekapitulasiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LabaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
