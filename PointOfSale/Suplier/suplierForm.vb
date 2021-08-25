Imports MySql.Data.MySqlClient

Public Class suplierForm
    Public Sub LoadDatabase()
        adapter = New MySqlDataAdapter("SELECT a.kode AS Kode, a.nama AS 'Nama Suplier', a.kota AS Kota, a.telp AS Telpon FROM suplier a", connection)
        Dim ds As New DataSet
        adapter.Fill(ds, "suplier")
        dgv1.DataSource = ds.Tables("suplier")
        ToolStripStatusLabel1.Text = "Total : " & ds.Tables("suplier").Rows.Count & " data suplier"
    End Sub

    Private Sub suplierForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDatabase()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If MessageBox.Show("Anda yakin ingin menghapus semua data suplier ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            command = New MySqlCommand("TRUNCATE suplier", connection)
            command.ExecuteNonQuery()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If sender.Text = "Cari" Then
            Dim k As String = ToolStripTextBox1.Text
            Dim s As String = "WHERE kode LIKE '%" + k + "%' OR nama LIKE '%" + k + "%' OR kota LIKE '%" + k + "%' OR telp LIKE '%" + k + "%' OR alamat LIKE '%" + k + "%' OR keterangan LIKE '%" + k + "%'"
            adapter = New MySqlDataAdapter("SELECT a.kode AS Kode, a.nama AS 'Nama Suplier', a.kota AS Kota, a.telp AS Telpon FROM suplier a " + s, connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "suplier")
            dgv1.DataSource = ds.Tables("suplier")
            ToolStripStatusLabel1.Text = "Hasil pencarian : " & ds.Tables("suplier").Rows.Count & " data suplier"
            sender.Text = "Reset"
        Else
            LoadDatabase()
            sender.Text = "Cari"
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim ed As editSuplier = New editSuplier
        ed.MdiParent = Me.MdiParent
        ed.TambahBaru(AddressOf Me.LoadDatabase)
    End Sub

    Private Sub HapusTerpilihToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusTerpilihToolStripMenuItem.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus " & dgv1.SelectedRows.Count & " data suplier ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For Each r As DataGridViewRow In dgv1.SelectedRows
                    command = New MySqlCommand("DELETE FROM suplier WHERE kode = '" & r.Cells("Kode").Value & "'", connection)
                    command.ExecuteNonQuery()
                Next
                LoadDatabase()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UbahToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UbahToolStripMenuItem.Click
        Try
            Dim ed As editSuplier = New editSuplier
            ed.MdiParent = Me.MdiParent
            ed.Ubah(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("Kode").Value, AddressOf Me.LoadDatabase)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LihatDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LihatDetailToolStripMenuItem.Click
        Try
            Dim ed As detailSuplier = New detailSuplier
            ed.MdiParent = Me.MdiParent
            ed.Show(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("Kode").Value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseDoubleClick
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            Try
                Dim ed As detailSuplier = New detailSuplier
                ed.MdiParent = Me.MdiParent
                ed.Show(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("Kode").Value)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub dgv1_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseDown
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            If e.Button = MouseButtons.Right Then
                dgv1.CurrentCell = dgv1.Rows(e.RowIndex).Cells(e.ColumnIndex)
            End If
        End If
    End Sub
End Class