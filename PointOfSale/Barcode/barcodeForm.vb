Imports MySql.Data.MySqlClient

Public Class barcodeForm
    Public Sub LoadDatabase()
        adapter = New MySqlDataAdapter("SELECT a.id AS ID, a.barcode AS Barcode, a.kode_barang AS 'Kode Barang', b.nama AS Nama FROM barcodebarang a LEFT OUTER JOIN barang b ON a.kode_barang=b.kode", connection)
        Dim ds As New DataSet
        adapter.Fill(ds, "barcodebarang")
        dgv1.DataSource = ds.Tables("barcodebarang")
        ToolStripStatusLabel1.Text = "Total : " & ds.Tables("barcodebarang").Rows.Count & " data barcode"
    End Sub

    Private Sub barcodeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDatabase()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If sender.Text = "Cari" Then
            Dim k As String = ToolStripTextBox1.Text
            Dim s As String = "WHERE a.barcode LIKE '%" + k + "%' OR a.kode_barang LIKE '%" + k + "%' OR b.nama LIKE '%" + k + "%'"
            adapter = New MySqlDataAdapter("SELECT a.id AS ID, a.barcode AS Barcode, a.kode_barang AS 'Kode Barang', b.nama AS Nama FROM barcodebarang a LEFT OUTER JOIN barang b ON a.kode_barang=b.kode " + s, connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "barcodebarang")
            dgv1.DataSource = ds.Tables("barcodebarang")
            ToolStripStatusLabel1.Text = "Hasil pencarian : " & ds.Tables("barcodebarang").Rows.Count & " data barcode"
            sender.Text = "Reset"
        Else
            LoadDatabase()
            sender.Text = "Cari"
        End If
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus " & dgv1.SelectedRows.Count & " data barcode ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For Each r As DataGridViewRow In dgv1.SelectedRows
                    command = New MySqlCommand("DELETE FROM barcodebarang WHERE id = '" & r.Cells("ID").Value & "'", connection)
                    command.ExecuteNonQuery()
                Next
                LoadDatabase()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim bc As editBarcode = New editBarcode
        bc.MdiParent = Me.MdiParent
        bc.TambahBaru(AddressOf Me.LoadDatabase)
    End Sub

    Private Sub dgv1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseDoubleClick
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            Try
                Dim ed As editBarcode = New editBarcode
                ed.MdiParent = Me.MdiParent
                ed.Ubah(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("ID").Value, AddressOf Me.LoadDatabase)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Try
            Dim ed As editBarcode = New editBarcode
            ed.MdiParent = Me.MdiParent
            ed.Ubah(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("ID").Value, AddressOf Me.LoadDatabase)
        Catch ex As Exception

        End Try
    End Sub
End Class