Imports MySql.Data.MySqlClient

Public Class loginForm
    Public percobaan As Integer = 0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(TextBox1.Text) Or String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("Username atau password masih kosong", "Field kosong")
            Exit Sub
        End If

        percobaan += 1
        If percobaan > 3 Then
            MessageBox.Show("Percobaan anda habis, silahkan tunggu 2 menit", "Username atau password salah")
            Exit Sub
        End If

        command = New MySqlCommand("SELECT * FROM users WHERE username = '" + TextBox1.Text + "' AND password = md5('" + TextBox2.Text + "') LIMIT 1 OFFSET 0", connection)
        reader = command.ExecuteReader()
        reader.Read()
        If reader.HasRows Then
            username = reader.Item("username")
            password = reader.Item("password")
            nama = reader.Item("nama")
            id = reader.Item("id")

            Select Case reader.Item("level")
                Case "kasir"
                    leveluser = Level.kasir
                Case "admin"
                    leveluser = Level.admin
                Case Else
                    leveluser = Level.owner
            End Select
            Main_Menu.Show()
            Me.Hide()
        Else
            MessageBox.Show("Username atau password yang anda masukan salah", "Username atau password salah")
        End If
        reader.Close()
        TextBox2.Text = ""
    End Sub

    Private Sub loginForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Koneksi()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub
End Class
