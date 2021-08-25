Imports MySql.Data.MySqlClient

Public Class laporanBarang

    Private Function BuildQueuryFilter() As String
        Dim s As String = ""
        Dim adOp As Boolean = False

        If Not ToolStripComboBox1.SelectedItem = "-" Then
            If adOp Then s &= " AND "
            adOp = True
            s &= "kategori = '" & ToolStripComboBox1.SelectedItem & "'"
        End If

        If Not ToolStripComboBox2.SelectedItem = "-" Then
            If adOp Then s &= " AND "
            adOp = True
            s &= "satuan = '" & ToolStripComboBox2.SelectedItem & "'"
        End If

        Select Case ToolStripComboBox3.SelectedIndex
            Case 1
                If adOp Then s &= " AND "
                adOp = True
                s &= "kadaluarsa <= " & TimeToString(Now)
            Case 2
                If adOp Then s &= " AND "
                adOp = True
                s &= "kadaluarsa > " & TimeToString(Now)
            Case Else

        End Select

        Select Case ToolStripComboBox4.SelectedIndex
            Case 1
                If adOp Then s &= " AND "
                adOp = True
                s &= "stok < " & ToolStripTextBox1.Text
            Case 2
                If adOp Then s &= " AND "
                adOp = True
                s &= "stok <= " & ToolStripTextBox1.Text
            Case 3
                If adOp Then s &= " AND "
                adOp = True
                s &= "stok = " & ToolStripTextBox1.Text
            Case 4
                If adOp Then s &= " AND "
                adOp = True
                s &= "stok >= " & ToolStripTextBox1.Text
            Case 5
                If adOp Then s &= " AND "
                adOp = True
                s &= "stok > " & ToolStripTextBox1.Text
            Case Else

        End Select

        Return s
    End Function

    Public Sub LoadDatabase()
        Try
            Dim query, filter As String
            query = "SELECT * FROM laporan_barang"
            filter = BuildQueuryFilter()
            query &= If(String.IsNullOrEmpty(filter), "", " WHERE " & filter)
            adapter = New MySqlDataAdapter(query, connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "laporan_barang")
            For Each ro As DataRow In ds.Tables(0).Rows
                ro.Item("kadaluarsa") = StringToTime(ro.Item("kadaluarsa").ToString()).ToLongDateString()
            Next
            CrystalReportViewer1.ReportSource = Nothing
            Dim srp As stokBarang = New stokBarang
            srp.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = srp
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub LoadKategori()
        Try
            adapter = New MySqlDataAdapter("SELECT kategori FROM kategori_barang", connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "kategori_barang")

            ToolStripComboBox1.Items.Clear()
            ToolStripComboBox1.Items.Add("-")
            For Each k As DataRow In ds.Tables("kategori_barang").Rows
                ToolStripComboBox1.Items.Add(k.Item("kategori"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub LoadSatuan()
        Try
            adapter = New MySqlDataAdapter("SELECT satuan FROM satuanbarang", connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "satuanbarang")

            ToolStripComboBox2.Items.Clear()
            ToolStripComboBox2.Items.Add("-")
            For Each k As DataRow In ds.Tables("satuanbarang").Rows
                ToolStripComboBox2.Items.Add(k.Item("satuan"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub laporanBarang_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadKategori()
        ToolStripComboBox1.SelectedIndex = 0
        LoadSatuan()
        ToolStripComboBox2.SelectedIndex = 0
        ToolStripComboBox3.SelectedIndex = 0
        ToolStripComboBox4.SelectedIndex = 0
    End Sub

    Private Sub ToolStripTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ToolStripTextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ToolStripComboBox4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox4.SelectedIndexChanged
        Select Case ToolStripComboBox4.SelectedIndex
            Case 0
                ToolStripTextBox1.Enabled = False
            Case Else
                ToolStripTextBox1.Enabled = True
        End Select

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        LoadDatabase()
    End Sub
End Class