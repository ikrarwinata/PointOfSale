Imports MySql.Data.MySqlClient

Public Class transaksiForm
    Private Function BuildQueryFilter() As String
        Dim d1, d2 As Long
        d1 = TimeToString(DateTimePicker1.Value)
        d2 = TimeToString(DateTimePicker2.Value)
        If d2 <= d1 Then
            Return ""
        End If
        Return "(timestamps BETWEEN " & d1 & " AND " & d2 & ")"
    End Function

    Private Function BuildQueurySearch() As String
        Dim k As String = TextBox1.Text
        If String.IsNullOrEmpty(k) Then Return ""
        Dim s As String = "(a.kode LIKE '%" + k + "%' OR a.total LIKE '%" + k + "%' OR a.bayar LIKE '%" + k + "%' OR a.potongan LIKE '%" + k + "%' OR a.kembali LIKE '%" + k + "%')"
        Return s
    End Function

    Public Sub LoadDatabase()
        Try
            Dim queryfilter As String
            queryfilter = BuildQueryFilter()
            queryfilter = If(String.IsNullOrEmpty(queryfilter), "", "WHERE " & queryfilter & " ")

            adapter = New MySqlDataAdapter("SELECT a.kode AS 'Kode Transaksi', a.timestamps, a.total AS Total, a.bayar AS Bayar, a.discount AS Potongan, a.kembali AS Kembali, COUNT(b.id) AS Barang FROM transaksi a LEFT OUTER JOIN detail_transaksi b ON a.kode = b.kode_transaksi " & queryfilter & "GROUP BY a.kode ORDER BY a.kode DESC", connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "transaksi")
            dgv1.DataSource = ds.Tables("transaksi")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub transaksiForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = New DateTime(Date.Now.Year - 1, 1, 1)
        DateTimePicker2.Value = Now
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged, DateTimePicker2.ValueChanged
        Try
            Dim q, queryfilter, querysearch, op As String
            queryfilter = BuildQueryFilter()
            querysearch = BuildQueurySearch()
            querysearch &= If(String.IsNullOrEmpty(querysearch), "", " ")
            queryfilter &= If(String.IsNullOrEmpty(queryfilter), "", " ")
            op = If(String.IsNullOrEmpty(queryfilter) Or String.IsNullOrEmpty(querysearch), "", "AND ")
            If Not String.IsNullOrEmpty(queryfilter) Or Not String.IsNullOrEmpty(querysearch) Then
                q = "WHERE " & querysearch & op & queryfilter
            Else
                q = ""
            End If

            adapter = New MySqlDataAdapter("SELECT a.kode AS 'Kode Transaksi', a.timestamps, a.total AS Total, a.bayar AS Bayar, a.discount AS Potongan, a.kembali AS Kembali, COUNT(b.id) AS Barang FROM transaksi a LEFT OUTER JOIN detail_transaksi b ON a.kode = b.kode_transaksi " & q & "GROUP BY a.kode ORDER BY a.kode DESC", connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "transaksi")
            dgv1.DataSource = ds.Tables("transaksi")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If sender.Text = "Cari" Then
            Try
                Dim q, queryfilter, querysearch, op As String
                queryfilter = BuildQueryFilter()
                querysearch = BuildQueurySearch()
                querysearch &= If(String.IsNullOrEmpty(querysearch), "", " ")
                queryfilter &= If(String.IsNullOrEmpty(queryfilter), "", " ")
                op = If(String.IsNullOrEmpty(queryfilter) Or String.IsNullOrEmpty(querysearch), "", "AND ")
                If Not String.IsNullOrEmpty(queryfilter) Or Not String.IsNullOrEmpty(querysearch) Then
                    q = "WHERE " & querysearch & op & queryfilter
                Else
                    q = ""
                End If

                adapter = New MySqlDataAdapter("SELECT a.kode AS 'Kode Transaksi', a.timestamps, a.total AS Total, a.bayar AS Bayar, a.discount AS Potongan, a.kembali AS Kembali, COUNT(b.id) AS Barang FROM transaksi a LEFT OUTER JOIN detail_transaksi b ON a.kode = b.kode_transaksi " & q & "GROUP BY a.kode ORDER BY a.kode DESC", connection)
                Dim ds As New DataSet
                adapter.Fill(ds, "transaksi")
                dgv1.DataSource = ds.Tables("transaksi")

                sender.Text = "Reset"
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            LoadDatabase()
            sender.Text = "Cari"
        End If
    End Sub

    Private Sub dgv1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseDoubleClick
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            Try
                Dim ed As detailTransaksi = New detailTransaksi
                ed.MdiParent = Me.MdiParent
                ed.Show(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("Kode Transaksi").Value)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
End Class