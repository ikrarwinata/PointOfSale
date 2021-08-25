Imports MySql.Data.MySqlClient

Public Class akunForm
    Public Sub LoadDatabase()
        adapter = New MySqlDataAdapter("SELECT a.id AS 'NIK', a.Username AS Username, a.nama AS 'Nama Pengguna' FROM users a", connection)
        Dim ds As New DataSet
        adapter.Fill(ds, "users")
        dgv1.DataSource = ds.Tables("users")
        ToolStripStatusLabel1.Text = "Total : " & ds.Tables("users").Rows.Count & " akun pengguna"
    End Sub

    Private Sub akunForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDatabase()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If sender.Text = "Cari" Then
            Dim k As String = ToolStripTextBox1.Text
            Dim s As String = "WHERE id LIKE '%" + k + "%' OR username LIKE '%" + k + "%' OR nama LIKE '%" + k + "%'"
            adapter = New MySqlDataAdapter("SELECT a.id AS 'NIK', a.Username AS Username, a.nama AS 'Nama Pengguna' FROM users a " + s, connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "users")
            dgv1.DataSource = ds.Tables("users")
            ToolStripStatusLabel1.Text = "Hasil pencarian : " & ds.Tables("users").Rows.Count & " akun pengguna"
            sender.Text = "Reset"
        Else
            LoadDatabase()
            sender.Text = "Cari"
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim a As editAkun = New editAkun
        a.MdiParent = Me.MdiParent
        a.TambahBaru(AddressOf Me.LoadDatabase)
    End Sub

    Private Sub HapusTerpilihToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusTerpilihToolStripMenuItem.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus " & dgv1.SelectedRows.Count & " akun pengguna ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For Each r As DataGridViewRow In dgv1.SelectedRows
                    command = New MySqlCommand("DELETE FROM users WHERE id = '" & r.Cells("NIK").Value & "'", connection)
                    command.ExecuteNonQuery()
                Next
                LoadDatabase()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UbahToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UbahToolStripMenuItem.Click
        Try
            Dim a As editAkun = New editAkun
            a.MdiParent = Me.MdiParent
            a.Ubah(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("NIK").Value, AddressOf Me.LoadDatabase)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LihatDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LihatDetailToolStripMenuItem.Click
        Try
            Dim a As detailAkun = New detailAkun
            a.MdiParent = Me.MdiParent
            a.Show(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("NIK").Value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseDoubleClick
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            Try
                Dim ed As detailAkun = New detailAkun
                ed.MdiParent = Me.MdiParent
                ed.Show(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("NIK").Value)
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