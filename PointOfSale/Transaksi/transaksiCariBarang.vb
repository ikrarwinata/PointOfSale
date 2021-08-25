Imports MySql.Data.MySqlClient

Public Class transaksiCariBarang
    Public Delegate Sub OnFinish(ByVal value As String)
    Public RefAction As OnFinish

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

    Private Sub LoadDatabase()
        Try
            adapter = New MySqlDataAdapter("SELECT d.barcode AS Barcode, a.kode AS 'Kode Barang', a.nama AS 'Nama Barang', b.kategori AS 'Kategori', c.satuan AS 'Satuan', a.stok AS 'Stok' FROM barang a LEFT OUTER JOIN barcodebarang d ON a.kode=d.kode_barang LEFT OUTER JOIN kategori_barang b ON a.kategori=b.id LEFT OUTER JOIN satuanbarang c ON a.satuan=c.id GROUP BY a.kode", connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "barang")
            dgv1.DataSource = ds.Tables("barang")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function BuildQueurySearch() As String
        Dim k As String = TextBox1.Text
        If String.IsNullOrEmpty(k) Then Return ""
        Dim s As String = "(a.kode LIKE '%" + k + "%' OR a.nama LIKE '%" + k + "%' OR a.harga LIKE '%" + k + "%')"
        Return s
    End Function

    Private Function BuildQueuryFilter() As String
        Dim s As String = "("
        Dim adOp As Boolean = False
        Dim isEmpty As Boolean = True

        If Not ToolStripComboBox1.SelectedItem = "-" Then
            If adOp Then s &= " AND "
            adOp = True
            isEmpty = False
            s &= "b.kategori = '" & ToolStripComboBox1.SelectedItem & "'"
        End If

        If Not ToolStripComboBox2.SelectedItem = "-" Then
            If adOp Then s &= " AND "
            adOp = True
            isEmpty = False
            s &= "c.satuan = '" & ToolStripComboBox2.SelectedItem & "'"
        End If

        Select Case ToolStripComboBox3.SelectedIndex
            Case 1
                If adOp Then s &= " AND "
                adOp = True
                isEmpty = False
                s &= "a.kadaluarsa <= " & TimeToString(Now)
            Case 2
                If adOp Then s &= " AND "
                adOp = True
                isEmpty = False
                s &= "a.kadaluarsa > " & TimeToString(Now)
            Case Else

        End Select

        s &= ")"
        If isEmpty Then s = ""
        Return s
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If sender.Text = "Cari" Then
            Dim query As String = "SELECT d.barcode AS Barcode, a.kode AS 'Kode Barang', a.nama AS 'Nama Barang', b.kategori AS 'Kategori', c.satuan AS 'Satuan', a.stok AS 'Stok' FROM barang a LEFT OUTER JOIN barcodebarang d ON a.kode=d.kode_barang LEFT OUTER JOIN kategori_barang b ON a.kategori=b.id LEFT OUTER JOIN satuanbarang c ON a.satuan=c.id WHERE "
            Dim querysearch, queryfilter, op As String
            querysearch = BuildQueurySearch()
            queryfilter = BuildQueuryFilter()
            op = If(String.IsNullOrEmpty(queryfilter), "", " AND ")
            query &= querysearch & op & queryfilter

            adapter = New MySqlDataAdapter(query, connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "barang")
            dgv1.DataSource = ds.Tables("barang")
            sender.Text = "Reset"
            dgv1.Focus()
        Else
            LoadDatabase()
            sender.Text = "Cari"
            TextBox1.Focus()
        End If
    End Sub

    Private Sub Filter()
        If Button1.Text = "Reset" Then
            Dim query As String = "SELECT d.barcode AS Barcode, a.kode AS 'Kode Barang', a.nama AS 'Nama Barang', b.kategori AS 'Kategori', c.satuan AS 'Satuan', a.stok AS 'Stok' FROM barang a LEFT OUTER JOIN barcodebarang d ON a.kode=d.kode_barang LEFT OUTER JOIN kategori_barang b ON a.kategori=b.id LEFT OUTER JOIN satuanbarang c ON a.satuan=c.id WHERE "
            Dim querysearch, queryfilter, op As String
            querysearch = BuildQueurySearch()
            queryfilter = BuildQueuryFilter()

            op = If(String.IsNullOrEmpty(queryfilter) Or String.IsNullOrEmpty(querysearch), "", " AND ")
            query &= querysearch & op & queryfilter & " GROUP BY a.kode"

            adapter = New MySqlDataAdapter(query, connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "barang")
            dgv1.DataSource = ds.Tables("barang")
        Else
            Dim query As String = "SELECT d.barcode AS Barcode, a.kode AS 'Kode Barang', a.nama AS 'Nama Barang', b.kategori AS 'Kategori', c.satuan AS 'Satuan', a.stok AS 'Stok' FROM barang a LEFT OUTER JOIN barcodebarang d ON a.kode=d.kode_barang LEFT OUTER JOIN kategori_barang b ON a.kategori=b.id LEFT OUTER JOIN satuanbarang c ON a.satuan=c.id WHERE "
            Dim queryfilter As String = BuildQueuryFilter()

            query &= queryfilter & " GROUP BY a.kode"

            adapter = New MySqlDataAdapter(query, connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "barang")
            dgv1.DataSource = ds.Tables("barang")
        End If
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        If ToolStripComboBox1.SelectedIndex > 0 Then
            Filter()
        End If
    End Sub

    Private Sub ToolStripComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox2.SelectedIndexChanged
        If ToolStripComboBox1.SelectedIndex > 0 Then
            Filter()
        End If
    End Sub

    Private Sub ToolStripComboBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox3.SelectedIndexChanged
        If ToolStripComboBox1.SelectedIndex > 0 Then
            Filter()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        ToolStripComboBox1.SelectedIndex = 0
        ToolStripComboBox2.SelectedIndex = 0
        ToolStripComboBox3.SelectedIndex = 0
        LoadDatabase()
        Button1.Text = "Cari"
    End Sub

    Public Sub Pencarian(ByVal ref As OnFinish)
        RefAction = ref
        Me.Show()
    End Sub

    Private Sub transaksiCariBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDatabase()
        LoadKategori()
        LoadSatuan()
        ToolStripComboBox1.SelectedIndex = 0
        ToolStripComboBox2.SelectedIndex = 0
        ToolStripComboBox3.SelectedIndex = 0
        TextBox1.Focus()
    End Sub

    Private Sub dgv1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseDoubleClick
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            Try
                RefAction(dgv1.SelectedRows(dgv1.SelectedRows.Count - 1).Cells("Kode Barang").Value)
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
End Class