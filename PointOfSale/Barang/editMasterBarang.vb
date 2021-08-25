Imports MySql.Data.MySqlClient

Public Class editMasterBarang
    Private func As action
    Private kode_barang As String

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

    Public Overloads Sub Show(ByVal kode As String, ByVal ref As Action)
        kode_barang = kode
        func = ref

        Dim s As String = "SELECT a.harga_beli, d.barcode AS Barcode, a.kode AS 'Kode Barang', a.nama AS 'Nama Barang', a.kadaluarsa, a.harga, b.kategori AS 'Kategori', c.satuan AS 'Satuan', a.stok AS 'Stok' FROM barang a LEFT OUTER JOIN barcodebarang d ON a.kode=d.kode_barang LEFT OUTER JOIN kategori_barang b ON a.kategori=b.id LEFT OUTER JOIN satuanbarang c ON a.satuan=c.id WHERE a.kode = '" & kode_barang & "' GROUP BY a.kode LIMIT 1 OFFSET 0"
        command = New MySqlCommand(s, connection)
        reader = command.ExecuteReader()
        reader.Read()

        If reader.HasRows Then
            Try
                With reader
                    TextBox2.Text = .Item("Kode Barang")
                    TextBox3.Text = .Item("Nama Barang")
                    ComboBox2.Text = .Item("satuan")
                    ComboBox1.Text = .Item("kategori")
                    DateTimePicker1.Value = StringToTime(.Item("kadaluarsa"))
                    NumericUpDown2.Value = .Item("harga")
                    NumericUpDown1.Value = .Item("harga_beli")
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Data tidak ditemukan", "Data barang")
            Exit Sub
        End If

        reader.Close()
        Me.Show()
        TextBox2.Focus()
    End Sub

    Private Sub editMasterBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadKategori()
        LoadSatuan()
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

        Dim date2 As Date = DateTimePicker1.Value.ToShortDateString
        Dim date1 As Date = Now
        Dim d As Long = DateDiff(DateInterval.Day, date1, date2)
        If d <= 1 Then
            MessageBox.Show("Silahkan periksa tanggal kadaluarsa sebelum menambahkan barang", "Tanggal Kadaluarsa")
            Return False
        End If

        Return True
    End Function

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
        Dim kategori, satuan As Integer
        kategori = SimpanKategori()
        satuan = SimpanSatuan()

        Dim sekarang, banding, kadaluarsa As Long
        sekarang = TimeToString(DateTimePicker1.Value)
        kadaluarsa = sekarang
        banding = AmbilData("barang", "kadaluarsa", "kode", TextBox2.Text)
        If banding > 0 Then
            kadaluarsa = Math.Min(sekarang, banding)
        End If

        command = New MySqlCommand("UPDATE barang SET nama='" & TextBox3.Text & "', kategori='" & kategori & "', satuan='" & satuan & "', harga='" & NumericUpDown2.Value & "', harga_beli='" & NumericUpDown1.Value & "',kadaluarsa='" & kadaluarsa & "' WHERE kode = '" & kode_barang & "'", connection)
        command.ExecuteNonQuery()

        command = New MySqlCommand("UPDATE barang_masuk SET nama_barang='" & TextBox3.Text & "' WHERE kode_barang = '" & kode_barang & "'", connection)
        command.ExecuteNonQuery()

        Try
            func()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Me.Close()
    End Sub
End Class