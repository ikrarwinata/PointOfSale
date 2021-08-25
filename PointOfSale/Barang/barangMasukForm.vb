Imports MySql.Data.MySqlClient

Public Class barangMasukForm
    Public Sub LoadDatabase()
        dgv1.DataSource = Nothing
        Try
            adapter = New MySqlDataAdapter("SELECT a.id AS ID, d.barcode AS Barcode, a.kode_barang AS 'Kode Barang', a.nama_barang AS 'Nama Barang', concat(a.tanggal, ' - ', a.bulan, ' - ', a.tahun) AS 'Tanggal Masuk', a.qty AS 'Banyaknya', a.kode_suplier AS 'Kode Suplier', b.nama AS 'Nama Suplier', a.users AS 'Username', c.nama AS 'Nama User' FROM barang_masuk a LEFT OUTER JOIN barcodebarang d ON a.kode_barang=d.kode_barang LEFT OUTER JOIN suplier b ON a.kode_suplier=b.kode LEFT OUTER JOIN users c ON a.users=c.username GROUP BY a.kode_barang", connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "barang_masuk")
            dgv1.DataSource = ds.Tables("barang_masuk")
            dgv1.Columns("ID").Width = 30

            TextBox2.AutoCompleteCustomSource.Clear()
            For Each k As DataRow In ds.Tables("barang_masuk").Rows
                TextBox2.AutoCompleteCustomSource.Add(k.Item("Kode Barang"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub LoadKategori()
        Try
            adapter = New MySqlDataAdapter("SELECT kategori FROM kategori_barang", connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "kategori_barang")

            ComboBox1.Items.Clear()
            For Each k As DataRow In ds.Tables("kategori_barang").Rows
                ComboBox1.Items.Add(k.Item("kategori"))
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

            ComboBox2.Items.Clear()
            For Each k As DataRow In ds.Tables("satuanbarang").Rows
                ComboBox2.Items.Add(k.Item("satuan"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub LoadSuplier()
        Try
            adapter = New MySqlDataAdapter("SELECT kode FROM suplier", connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "suplier")

            ComboBox3.Items.Clear()
            For Each k As DataRow In ds.Tables("suplier").Rows
                ComboBox3.Items.Add(k.Item("kode"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub barangMasukForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolStripStatusLabel1.Text = Date.Now.ToLongDateString
        ToolStripStatusLabel2.Text = Date.Now.ToLongTimeString
        LoadDatabase()
        LoadKategori()
        LoadSatuan()
        LoadSuplier()
        Timer1.Start()

        If Not Me.WindowState = FormWindowState.Maximized Then
            Me.Width = Me.MdiParent.Width - (Me.MdiParent.Height * 0.1)
            Me.Height = Me.MdiParent.Height - (Me.MdiParent.Height * 0.2)
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel2.Text = Date.Now.ToLongTimeString
    End Sub

    Private Function MasihKosong() As Boolean
        For Each o As Object In GroupBox1.Controls
            If TypeOf (o) Is TextBox Then
                If String.IsNullOrEmpty(CType(o, TextBox).Text) Then
                    Return True
                End If
            ElseIf TypeOf (o) Is ComboBox Then
                If String.IsNullOrEmpty(CType(o, ComboBox).Text) Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Function Valid() As Boolean
        If MasihKosong() Then
            MessageBox.Show("Data barang belum lengkap", "Data tidak lengkap")
            Return False
        End If

        If ComboBox3.SelectedItem = Nothing Then
            MessageBox.Show("Silahkan pilih suplier barang", "Data tidak lengkap")
            ComboBox3.Focus()
            Return False
        End If

        Dim date2 As Date = DateTimePicker1.Value.ToShortDateString
        Dim date1 As Date = Now
        Dim d As Long = DateDiff(DateInterval.Day, date1, date2)
        If d <= 1 Then
            MessageBox.Show("Silahkan periksa tanggal kadaluarsa sebelum menambahkan barang", "Tanggal Kadaluarsa")
            Return False
        End If

        Return True
    End Function

    Private Sub SimpanBarcode()
        If Not DataSudahAda("barcodebarang", "barcode", TextBox1.Text) Then
            command = New MySqlCommand("INSERT INTO barcodebarang (kode_barang, barcode) VALUES ('" & TextBox2.Text & "', '" & TextBox1.Text & "')", connection)
            command.ExecuteNonQuery()
        End If
    End Sub

    Private Function SimpanKategori() As Long
        Dim res As Long = 1

        If DataSudahAda("kategori_barang", "kategori", ComboBox1.Text) Then
            res = AmbilData("kategori_barang", "id", "kategori", ComboBox1.Text)
        Else
            command = New MySqlCommand("SELECT MAX(id) AS id FROM kategori_barang", connection)
            reader = command.ExecuteReader()
            reader.Read()
            If reader.HasRows And Not String.IsNullOrEmpty(reader.Item("id").ToString()) Then
                res = reader.Item("id").ToString() + 1
            End If
            reader.Close()

            command = New MySqlCommand("INSERT INTO kategori_barang (id, kategori) VALUES ('" & res & "', '" & ComboBox1.Text & "')", connection)
            command.ExecuteNonQuery()
        End If

        Return res
    End Function

    Private Function SimpanSatuan() As Long
        Dim res As Long = 1

        If DataSudahAda("satuanbarang", "satuan", ComboBox2.Text) Then
            res = AmbilData("satuanbarang", "id", "satuan", ComboBox2.Text)
        Else
            command = New MySqlCommand("SELECT MAX(id) AS id FROM satuanbarang", connection)
            reader = command.ExecuteReader()
            reader.Read()
            If reader.HasRows And Not String.IsNullOrEmpty(reader.Item("id").ToString()) Then
                res = reader.Item("id").ToString() + 1
            End If
            reader.Close()

            command = New MySqlCommand("INSERT INTO satuanbarang (id, satuan) VALUES ('" & res & "', '" & ComboBox2.Text & "')", connection)
            command.ExecuteNonQuery()
        End If

        Return res
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not Valid() Then Exit Sub
        SimpanBarcode()
        Dim kategori, satuan As Integer
        kategori = SimpanKategori()
        satuan = SimpanSatuan()

        command = New MySqlCommand("INSERT INTO barang_masuk (kode_barang, nama_barang, tanggal, bulan, tahun, qty, kode_suplier, users) VALUES ('" & TextBox2.Text & "', '" & TextBox3.Text & "', " & Date.Now.Day & ", " & Date.Now.Month & ", " & Date.Now.Year & ", " & NumericUpDown1.Value & ", '" & ComboBox3.SelectedItem & "', '" & username & "')", connection)
        command.ExecuteNonQuery()

        Dim sekarang, banding, kadaluarsa As Long
        sekarang = TimeToString(DateTimePicker1.Value)
        kadaluarsa = sekarang
        If DataSudahAda("barang", "kode", TextBox2.Text) Then
            banding = AmbilData("barang", "kadaluarsa", "kode", TextBox2.Text)
            If banding > 0 Then
                kadaluarsa = Math.Min(sekarang, banding)
            End If

            command = New MySqlCommand("UPDATE barang SET harga='" & NumericUpDown2.Value & "', kadaluarsa='" & kadaluarsa & "', stok=stok+" & NumericUpDown1.Value & " WHERE kode = '" & TextBox2.Text & "'", connection)
        Else
            command = New MySqlCommand("INSERT INTO barang (kode, nama, kategori, satuan, harga_beli, harga, kadaluarsa, stok) VALUES ('" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & kategori & "', '" & satuan & "', '" & NumericUpDown3.Value & "', '" & NumericUpDown2.Value & "', '" & kadaluarsa & "', '" & NumericUpDown1.Value & "')", connection)
        End If

        command.ExecuteNonQuery()

        ResetAllText(True)

        LoadDatabase()
        LoadKategori()
        LoadSatuan()

        TextBox1.Focus()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        If DataSudahAda("suplier", "kode", ComboBox3.SelectedItem) Then
            Button5.Enabled = True

            Label8.Text = AmbilData("suplier", "nama", "kode", ComboBox3.SelectedItem)
        Else
            Button5.Enabled = False
            Label8.Text = ""
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim editsupl As editSuplier = New editSuplier
        editsupl.TambahBaru(AddressOf Me.LoadSuplier)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim detspl As detailSuplier = New detailSuplier
        detspl.Show(ComboBox3.SelectedItem)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim supl As suplierForm = New suplierForm
        supl.MdiParent = Me.MdiParent
        supl.Show()
    End Sub

    Private Sub ResetAllText(Optional ByVal clearbarcode As Boolean = False)
        If clearbarcode Then TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox2.Text = ""
        ComboBox1.Text = ""
        NumericUpDown1.Value = 1
        DateTimePicker1.Value = Now
        NumericUpDown2.Value = 1000
        NumericUpDown3.Value = 1000
        ComboBox3.Text = ""
    End Sub

    Private Function BuatKodeBarang() As String
        Dim s As String = "BRG-" & Date.Now.Year & "-"
        Try
            command = New MySqlCommand("SELECT kode_barang FROM barang_masuk ORDER BY kode_barang DESC LIMIT 1 OFFSET 0", connection)
            reader = command.ExecuteReader()
            reader.Read()
            Dim i As Integer = 1
            reader.Read()
            If reader.HasRows Then
                If Not String.IsNullOrEmpty(reader.Item("kode_barang").ToString()) Then
                    i = reader.Item("kode_barang").ToString().Split("-").Last()
                    i += 1
                End If
            End If
            s &= New String("0", 9 - i.ToString().Length) & i.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        reader.Close()
        Return s
    End Function

    Private barcodescaning As Boolean = False
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Dim s As String = "SELECT e.harga_beli, a.id AS ID, d.barcode AS Barcode, a.kode_barang AS 'Kode Barang', a.nama_barang AS 'Nama Barang', a.tanggal AS 'Tanggal Masuk', a.qty AS 'Banyaknya', a.kode_suplier AS 'Kode Suplier', e.harga, e.kadaluarsa, f.kategori, g.satuan, b.nama AS 'Nama Suplier', a.users AS 'Username', c.nama AS 'Nama User' FROM barang_masuk a LEFT OUTER JOIN barcodebarang d ON a.kode_barang=d.kode_barang LEFT OUTER JOIN suplier b ON a.kode_suplier=b.kode LEFT OUTER JOIN users c ON a.users=c.username LEFT OUTER JOIN barang e ON a.kode_barang=e.kode LEFT OUTER JOIN kategori_barang f ON e.kategori=f.id LEFT OUTER JOIN satuanbarang g ON e.satuan = g.id WHERE d.barcode = '" & TextBox1.Text & "' LIMIT 1 OFFSET 0"
            command = New MySqlCommand(s, connection)
            reader = command.ExecuteReader()
            reader.Read()

            If reader.HasRows Then
                barcodescaning = True
                Try
                    With reader
                        TextBox2.Text = .Item("Kode Barang")
                        TextBox3.Text = .Item("Nama Barang")
                        ComboBox2.Text = .Item("satuan")
                        ComboBox1.Text = .Item("kategori")
                        NumericUpDown1.Value = 1
                        NumericUpDown3.Value = .Item("harga_beli")
                        DateTimePicker1.Value = StringToTime(.Item("kadaluarsa"))
                        NumericUpDown2.Value = .Item("harga")
                        Dim kodesupl As String = .Item("Kode Suplier")
                        reader.Close()
                        ComboBox3.Text = kodesupl
                    End With
                    NumericUpDown1.Focus()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                reader.Close()
                barcodescaning = False
            Else
                reader.Close()
                ResetAllText(False)
                TextBox2.Text = BuatKodeBarang()
                TextBox3.Focus()
            End If
            reader.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ResetAllText(True)
    End Sub

    Private Sub HapusDataTerpilihToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusDataTerpilihToolStripMenuItem.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus " & dgv1.SelectedRows.Count & " data barang masuk ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For Each r As DataGridViewRow In dgv1.SelectedRows
                    command = New MySqlCommand("DELETE FROM barang_masuk WHERE id = '" & r.Cells("ID").Value & "'", connection)
                    command.ExecuteNonQuery()
                Next
                LoadDatabase()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HapusDataBulanIniToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusDataBulanIniToolStripMenuItem.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus data barang masuk bulan ini ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                command = New MySqlCommand("DELETE FROM barang_masuk WHERE bulan = " & Date.Now.Month, connection)
                command.ExecuteNonQuery()
            End If
            LoadDatabase()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HapusDataTahunIniToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusDataTahunIniToolStripMenuItem.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus data barang masuk tahun ini ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                command = New MySqlCommand("DELETE FROM barang_masuk WHERE tahun = " & Date.Now.Year, connection)
                command.ExecuteNonQuery()
            End If
            LoadDatabase()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HapusSemuaDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusSemuaDataToolStripMenuItem.Click
        Try
            If MessageBox.Show("Anda yakin ingin menghapus semua data ?", "Konfirmasi hapus", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                command = New MySqlCommand("TRUNCATE barang_masuk", connection)
                command.ExecuteNonQuery()
            End If
            LoadDatabase()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If sender.Text = "Cari" Then
            Dim k As String = ToolStripTextBox1.Text
            Dim s As String = "WHERE a.kode_barang LIKE '%" + k + "%' OR a.nama_barang LIKE '%" + k + "%' OR a.kode_suplier LIKE '%" + k + "%' OR a.users LIKE '%" + k + "%' OR b.nama LIKE '%" + k + "%' OR c.nama LIKE '%" + k + "%'"
            adapter = New MySqlDataAdapter("SELECT a.id AS ID, d.barcode AS Barcode, a.kode_barang AS 'Kode Barang', a.nama_barang AS 'Nama Barang', concat(a.tanggal, ' - ', a.bulan, ' - ', a.tahun) AS 'Tanggal Masuk', a.qty AS 'Banyaknya', a.kode_suplier AS 'Kode Suplier', b.nama AS 'Nama Suplier', a.users AS 'Username', c.nama AS 'Nama User' FROM barang_masuk a LEFT OUTER JOIN barcodebarang d ON a.kode_barang=d.kode_barang LEFT OUTER JOIN suplier b ON a.kode_suplier=b.kode LEFT OUTER JOIN users c ON a.users=c.username " + s + " GROUP BY a.kode_barang", connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "barang_masuk")
            dgv1.DataSource = ds.Tables("barang_masuk")
            sender.Text = "Reset"
        Else
            LoadDatabase()
            sender.Text = "Cari"
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If barcodescaning Then Exit Sub

        If e.KeyChar = Convert.ToChar(13) Then
            Dim s As String = "SELECT e.harga_beli, a.id AS ID, d.barcode AS Barcode, a.kode_barang AS 'Kode Barang', a.nama_barang AS 'Nama Barang', a.tanggal AS 'Tanggal Masuk', a.qty AS 'Banyaknya', a.kode_suplier AS 'Kode Suplier', e.harga, e.kadaluarsa, f.kategori, g.satuan, b.nama AS 'Nama Suplier', a.users AS 'Username', c.nama AS 'Nama User' FROM barang_masuk a LEFT OUTER JOIN barcodebarang d ON a.kode_barang=d.kode_barang LEFT OUTER JOIN suplier b ON a.kode_suplier=b.kode LEFT OUTER JOIN users c ON a.users=c.username LEFT OUTER JOIN barang e ON a.kode_barang=e.kode LEFT OUTER JOIN kategori_barang f ON e.kategori=f.id LEFT OUTER JOIN satuanbarang g ON e.satuan = g.id WHERE a.kode_barang = '" & TextBox2.Text & "' LIMIT 1 OFFSET 0"
            command = New MySqlCommand(s, connection)
            reader = command.ExecuteReader()
            reader.Read()

            If reader.HasRows Then
                Try
                    With reader
                        TextBox3.Text = .Item("Nama Barang")
                        ComboBox2.Text = .Item("satuan")
                        ComboBox1.Text = .Item("kategori")
                        NumericUpDown1.Value = 1
                        NumericUpDown3.Value = .Item("harga_beli")
                        DateTimePicker1.Value = StringToTime(.Item("kadaluarsa"))
                        NumericUpDown2.Value = .Item("harga")
                        Dim kodesupl As String = .Item("Kode Suplier")
                        reader.Close()
                        ComboBox3.Text = kodesupl
                    End With
                    NumericUpDown1.Focus()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Else
                TextBox3.Focus()
            End If
            reader.Close()
        End If
    End Sub
End Class