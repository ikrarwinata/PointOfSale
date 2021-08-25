Imports MySql.Data.MySqlClient

Public Class detailSuplier

    Private Sub detailSuplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Overloads Sub Show(ByVal kode As String)
        kodesupl.Text = kode
        command = New MySqlCommand("SELECT * FROM suplier WHERE kode = '" & kode & "' LIMIT 1 OFFSET 0", connection)
        reader = command.ExecuteReader()
        reader.Read()

        If reader.HasRows Then
            kodesupl.Text = reader.Item("kode")
            namasupl.Text = reader.Item("nama")
            kotasupl.Text = reader.Item("kota")
            telpsupl.Text = reader.Item("telp")
            alamatsupl.Text = reader.Item("alamat")
            keterangansupl.Text = reader.Item("keterangan")
        Else
            MessageBox.Show("Data tidak ditemukan", "Suplier Data")
        End If
        reader.Close()
        Me.Show()
    End Sub

    Private Sub alamatsupl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles alamatsupl.Click

    End Sub
End Class