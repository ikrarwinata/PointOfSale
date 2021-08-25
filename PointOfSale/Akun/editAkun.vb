Imports MySql.Data.MySqlClient

Public Class editAkun
    Private RefreshAction As Action
    Private id, username As String
    Private mode As String = "Baru"

    Public Sub TambahBaru(Optional ByVal akn As Action = Nothing)
        RefreshAction = akn
        mode = "Baru"
        Me.Text = "Tambah Akun Pengguna Baru"
        TextBox4.Enabled = False
        Label4.Enabled = False
        Me.Show()
    End Sub

    Public Sub Ubah(ByVal i As String, Optional ByVal akn As Action = Nothing)
        RefreshAction = akn
        id = i
        command = New MySqlCommand("SELECT * FROM users WHERE id = '" & i & "' LIMIT 1 OFFSET 0", connection)
        reader = command.ExecuteReader()
        reader.Read()

        If reader.HasRows Then
            username = reader.Item("username")
            TextBox1.Text = reader.Item("id")
            TextBox2.Text = reader.Item("nama")
            TextBox3.Text = reader.Item("username")
            ComboBox1.SelectedItem = reader.Item("level")
        Else
            MessageBox.Show("Data tidak ditemukan", "Akun Pengguna")
        End If
        reader.Close()
        mode = "Ubah"
        Me.Text = "Ubah Akun Pengguna"
        Me.Show()
    End Sub

    Private Sub editAkun_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Select Case leveluser
            Case Level.owner
                ComboBox1.Items.Add("owner")
                ComboBox1.Items.Add("admin")
                ComboBox1.Items.Add("kasir")
            Case Level.admin
                ComboBox1.Items.Add("admin")
                ComboBox1.Items.Add("kasir")
            Case Else
                ComboBox1.Items.Add("kasir")
        End Select

    End Sub

    Private Function MasihKosong() As Boolean
        For Each o As Object In TableLayoutPanel1.Controls
            If TypeOf (o) Is TextBox Then
                If String.IsNullOrEmpty(CType(o, TextBox).Text) Then
                    If CType(o, TextBox).Name = "TextBox4" And mode = "Baru" Then Continue For
                    ErrorProvider1.SetError(o, "Data tidak boleh kosong")
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ErrorProvider1.Clear()
        If MasihKosong() Then
            MessageBox.Show("Silahkan isi semua data", "Data masih kosong")
            TextBox1.Focus()
            Exit Sub
        End If

        If Not TextBox6.Text = TextBox5.Text Then
            MessageBox.Show("Konfirmasi password tidak cocok")
            ErrorProvider1.SetError(TextBox6, "Konfirmasi password tidak cocok")
            Exit Sub
        End If

        If mode = "Baru" Then
            If DataSudahAda("users", "id", TextBox1.Text) Then
                MessageBox.Show("NIK ini sudah digunakan", "NIK duplikat")
                TextBox1.Focus()
                Exit Sub
            End If
            If DataSudahAda("users", "username", TextBox3.Text) Then
                MessageBox.Show("Username ini sudah digunakan", "Username duplikat")
                TextBox3.Focus()
                Exit Sub
            End If

            Dim s As String = "INSERT INTO users (username, password, nama, id, level) VALUES ('" & TextBox3.Text & "', md5('" & TextBox6.Text & "'), '" & TextBox2.Text & "', '" & TextBox1.Text & "', '" & ComboBox1.SelectedItem.ToString() & "')"
            command = New MySqlCommand(s, connection)
            command.ExecuteNonQuery()
        Else
            If Not TextBox1.Text = id Then
                If DataSudahAda("users", "id", TextBox1.Text) Then
                    MessageBox.Show("NIK ini sudah digunakan", "NIK duplikat")
                    TextBox1.Focus()
                    Exit Sub
                End If
            End If
            If Not TextBox3.Text = username Then
                If DataSudahAda("users", "username", TextBox3.Text) Then
                    MessageBox.Show("Username ini sudah digunakan", "Username duplikat")
                    TextBox3.Focus()
                    Exit Sub
                End If
            End If

            If Not DataSudahAda("users", "username='" & TextBox3.Text & "' AND password=md5('" & TextBox4.Text & "')") Then
                MessageBox.Show("Password saat ini salah", "Password")
                ErrorProvider1.SetError(TextBox4, "Password saat ini salah")
                TextBox4.Focus()
                Exit Sub
            End If

            Dim s As String = "UPDATE users SET id='" & TextBox1.Text & "', nama='" & TextBox2.Text & "', username='" & TextBox3.Text & "', password=md5('" & TextBox6.Text & "'), level='" & ComboBox1.SelectedItem & "' WHERE id = '" & id & "'"
            command = New MySqlCommand(s, connection)
            command.ExecuteNonQuery()
        End If
        Try
            RefreshAction()
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class