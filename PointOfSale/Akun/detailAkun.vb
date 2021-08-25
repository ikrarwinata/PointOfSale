Imports MySql.Data.MySqlClient

Public Class detailAkun

    Private Sub detailSuplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Overloads Sub Show(ByVal kode As String)
        nik.Text = kode
        command = New MySqlCommand("SELECT * FROM users WHERE id = '" & kode & "' LIMIT 1 OFFSET 0", connection)
        reader = command.ExecuteReader()
        reader.Read()

        If reader.HasRows Then
            nik.Text = reader.Item("id")
            nama.Text = reader.Item("nama")
            usern.Text = reader.Item("username")
            passw.Text = reader.Item("password")
            lvl.Text = reader.Item("level").ToString()
        Else
            MessageBox.Show("Data tidak ditemukan", "Akun Pengguna")
        End If
        reader.Close()
        Me.Show()
    End Sub
End Class