<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class detailSuplier
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.keterangansupl = New System.Windows.Forms.Label()
        Me.alamatsupl = New System.Windows.Forms.Label()
        Me.telpsupl = New System.Windows.Forms.Label()
        Me.kotasupl = New System.Windows.Forms.Label()
        Me.namasupl = New System.Windows.Forms.Label()
        Me.kodesupl = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.keterangansupl, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.alamatsupl, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.telpsupl, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.kotasupl, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.namasupl, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.kodesupl, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(386, 204)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'keterangansupl
        '
        Me.keterangansupl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.keterangansupl.Location = New System.Drawing.Point(118, 150)
        Me.keterangansupl.Name = "keterangansupl"
        Me.keterangansupl.Size = New System.Drawing.Size(265, 54)
        Me.keterangansupl.TabIndex = 16
        Me.keterangansupl.Text = "Keterangan"
        Me.keterangansupl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'alamatsupl
        '
        Me.alamatsupl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.alamatsupl.Location = New System.Drawing.Point(118, 100)
        Me.alamatsupl.Name = "alamatsupl"
        Me.alamatsupl.Size = New System.Drawing.Size(265, 50)
        Me.alamatsupl.TabIndex = 15
        Me.alamatsupl.Text = "Alamat"
        Me.alamatsupl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'telpsupl
        '
        Me.telpsupl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.telpsupl.Location = New System.Drawing.Point(118, 75)
        Me.telpsupl.Name = "telpsupl"
        Me.telpsupl.Size = New System.Drawing.Size(265, 25)
        Me.telpsupl.TabIndex = 14
        Me.telpsupl.Text = "Tel"
        Me.telpsupl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'kotasupl
        '
        Me.kotasupl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.kotasupl.Location = New System.Drawing.Point(118, 50)
        Me.kotasupl.Name = "kotasupl"
        Me.kotasupl.Size = New System.Drawing.Size(265, 25)
        Me.kotasupl.TabIndex = 13
        Me.kotasupl.Text = "Kota"
        Me.kotasupl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'namasupl
        '
        Me.namasupl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.namasupl.Location = New System.Drawing.Point(118, 25)
        Me.namasupl.Name = "namasupl"
        Me.namasupl.Size = New System.Drawing.Size(265, 25)
        Me.namasupl.TabIndex = 12
        Me.namasupl.Text = "Nama"
        Me.namasupl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'kodesupl
        '
        Me.kodesupl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.kodesupl.Location = New System.Drawing.Point(118, 0)
        Me.kodesupl.Name = "kodesupl"
        Me.kodesupl.Size = New System.Drawing.Size(265, 25)
        Me.kodesupl.TabIndex = 11
        Me.kodesupl.Text = "kode"
        Me.kodesupl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(3, 150)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 54)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Keterangan"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 50)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Alamat"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 25)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Telpon"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 25)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Kota"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama Suplier"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Kode Suplier"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'detailSuplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 229)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "detailSuplier"
        Me.Text = "Detail Suplier"
        Me.TopMost = True
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents keterangansupl As System.Windows.Forms.Label
    Friend WithEvents alamatsupl As System.Windows.Forms.Label
    Friend WithEvents telpsupl As System.Windows.Forms.Label
    Friend WithEvents kotasupl As System.Windows.Forms.Label
    Friend WithEvents namasupl As System.Windows.Forms.Label
    Friend WithEvents kodesupl As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
