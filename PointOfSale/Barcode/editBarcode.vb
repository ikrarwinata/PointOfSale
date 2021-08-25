Imports MySql.Data.MySqlClient

Public Class editBarcode
    Private refAction As Action
    Private id As Integer
    Private mode As String = "Baru"
    Private barcodescaning As Boolean = False

    Public Sub TambahBaru(Optional ByVal ref As Action = Nothing)
        refAction = ref
        mode = "Baru"

        Me.Show()
    End Sub

    Public Sub Ubah(ByVal kode As String, Optional ByVal ref As Action = Nothing)
        id = kode
        refAction = ref
        mode = "Ubah"

        Dim s As String = "SELECT a.id AS ID, a.barcode AS Barcode, a.kode_barang AS 'Kode Barang', b.nama, c.satuan, d.kategori, b.harga, b.kadaluarsa FROM barcodebarang a LEFT OUTER JOIN barang b ON a.kode_barang=b.kode LEFT OUTER JOIN satuanbarang c ON b.satuan=c.id LEFT OUTER JOIN kategori_barang d ON b.kategori=d.id WHERE a.id = '" & id & "' LIMIT 1 OFFSET 0"
        command = New MySqlCommand(s, connection)
        reader = command.ExecuteReader()
        reader.Read()

        If reader.HasRows Then
            barcodescaning = True
            Try
                With reader
                    TextBox2.Text = .Item("Barcode")
                    ComboBox1.Text = .Item("Kode Barang")
                    TextBox3.Text = .Item("nama")
                    TextBox1.Text = .Item("satuan")
                    TextBox4.Text = .Item("kategori")
                    TextBox6.Text = .Item("harga")
                    TextBox5.Text = StringToTime(.Item("kadaluarsa")).ToLongDateString()
                End With
                ComboBox1.Enabled = False
                Button1.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            barcodescaning = False
        Else
            MessageBox.Show("Data tidak ditemukan", "Barcode Data")
            reader.Close()
            Exit Sub
        End If
        reader.Close()

        Me.Show()
    End Sub

    Public Sub LoadKodeBarang()
        Try
            adapter = New MySqlDataAdapter("SELECT kode FROM barang", connection)
            Dim ds As New DataSet
            adapter.Fill(ds, "barang")

            ComboBox1.Items.Clear()
            For Each k As DataRow In ds.Tables("barang").Rows
                ComboBox1.Items.Add(k.Item("kode"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim brg As masterBarangForm = New masterBarangForm
        brg.MdiParent = Me.MdiParent
        brg.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If barcodescaning Then Exit Sub

        Dim s As String = "SELECT a.id AS ID, a.barcode AS Barcode, a.kode_barang AS 'Kode Barang', b.nama, c.satuan, d.kategori, b.harga, b.kadaluarsa FROM barcodebarang a LEFT OUTER JOIN barang b ON a.kode_barang=b.kode LEFT OUTER JOIN satuanbarang c ON b.satuan=c.id LEFT OUTER JOIN kategori_barang d ON b.kategori=d.id WHERE b.kode = '" & ComboBox1.SelectedItem & "' LIMIT 1 OFFSET 0"
        command = New MySqlCommand(s, connection)
        reader = command.ExecuteReader()
        reader.Read()

        If reader.HasRows Then
            barcodescaning = True
            Try
                With reader
                    TextBox3.Text = .Item("nama")
                    TextBox1.Text = .Item("satuan")
                    TextBox4.Text = .Item("kategori")
                    TextBox6.Text = .Item("harga")
                    TextBox5.Text = StringToTime(.Item("kadaluarsa")).ToLongDateString()
                End With
                Button1.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            barcodescaning = False
        End If
        reader.Close()
    End Sub

    Private Function MasihKosong() As Boolean
        If String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("Masukan kode barcode baru untuk produk ini", "Barcode")
            TextBox2.Focus()
            Return True
        End If
        If String.IsNullOrEmpty(ComboBox1.SelectedItem) Then
            MessageBox.Show("Pilih produk", "Produk")
            ComboBox1.Focus()
            Return True
        End If
        Return False
    End Function

    Private Sub ResetAllText(Optional ByVal clearbarcode As Boolean = False)
        If clearbarcode Then TextBox2.Text = ""
        ComboBox1.Text = ""
        TextBox3.Text = ""
        TextBox1.Text = ""
        TextBox4.Text = ""
        TextBox6.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub editBarcode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadKodeBarang()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If mode = "Baru" Then
            If MasihKosong() Then
                Exit Sub
            End If

            If DataSudahAda("barcodebarang", "barcode", TextBox2.Text) Then
                MessageBox.Show("Kode Barcode ini sudah digunakan produk lain", "Barcode")
                Exit Sub
            End If

            command = New MySqlCommand("INSERT INTO barcodebarang (kode_barang, barcode) VALUES ('" & ComboBox1.SelectedItem & "', '" & TextBox2.Text & "')", connection)
            command.ExecuteNonQuery()
        Else
            If String.IsNullOrEmpty(TextBox2.Text) Then
                MessageBox.Show("Masukan kode barcode baru untuk produk ini", "Barcode")
                TextBox2.Focus()
                Exit Sub
            End If
            command = New MySqlCommand("UPDATE barcodebarang SET barcode = '" & TextBox2.Text & "' WHERE id = '" & id & "'", connection)
            command.ExecuteNonQuery()
        End If
        Try
            refAction()
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub
End Class