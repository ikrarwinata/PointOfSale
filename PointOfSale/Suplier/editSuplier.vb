Imports MySql.Data.MySqlClient

Public Class editSuplier
    Private kode As String
    Private mode As String = "Baru"
    Private RefreshAction As Action

    Public Sub Ubah(ByVal k As String, Optional ByVal refresh As Action = Nothing)
        RefreshAction = refresh
        kode = k
        command = New MySqlCommand("SELECT * FROM suplier WHERE kode = '" & k & "' LIMIT 1 OFFSET 0", connection)
        reader = command.ExecuteReader()
        reader.Read()

        If reader.HasRows Then
            TextBox1.Text = reader.Item("kode")
            TextBox2.Text = reader.Item("nama")
            TextBox3.Text = reader.Item("kota")
            TextBox4.Text = reader.Item("telp")
            TextBox5.Text = reader.Item("alamat")
            TextBox6.Text = reader.Item("keterangan")
        Else
            MessageBox.Show("Data tidak ditemukan", "Suplier Data")
        End If
        reader.Close()
        mode = "Ubah"
        Me.Text = "Ubah Data Suplier"
        TextBox1.Text = kode
        Me.Show()
        TextBox2.Focus()
    End Sub

    Public Sub TambahBaru(Optional ByVal refresh As Action = Nothing)
        RefreshAction = refresh
        command = New MySqlCommand("SELECT kode FROM suplier ORDER BY kode DESC LIMIT 1 OFFSET 0", connection)
        reader = command.ExecuteReader()
        reader.Read()

        If reader.HasRows Then
            Dim s As String = reader.Item("kode")
            Dim sk As Integer = s.Substring(s.Length - 3) + 1
            kode = "SUPL" & Date.Now.Year & New String("0", 2 - Date.Now.Month.ToString().Length) & Date.Now.Month & New String("0", 2 - Date.Now.Day.ToString().Length) & Date.Now.Day & New String("0", 3 - sk.ToString().Length) & sk
        Else
            kode = "SUPL" & Date.Now.Year & New String("0", 2 - Date.Now.Month.ToString().Length) & Date.Now.Month & New String("0", 2 - Date.Now.Day.ToString().Length) & Date.Now.Day & "001"
        End If
        reader.Close()
        mode = "Baru"
        Me.Text = "Tambah Suplier Baru"
        TextBox1.Text = kode
        TextBox2.Focus()
        Me.Show()
    End Sub

    Private Sub editSuplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Function MasihKosong() As Boolean
        For Each o As Object In TableLayoutPanel1.Controls
            If TypeOf (o) Is TextBox Then
                If String.IsNullOrEmpty(CType(o, TextBox).Text) Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MasihKosong() Then
            MessageBox.Show("Silahkan isi semua data diatas", "Data masih kosong")
            TextBox1.Focus()
            Exit Sub
        End If

        If mode = "Baru" Then
            If DataSudahAda("suplier", "kode", TextBox1.Text) Then
                MessageBox.Show("Kode suplier ini sudah digunakan", "Kode suplier duplikat")
                TextBox1.Focus()
                Exit Sub
            End If

            Dim s As String = "INSERT INTO suplier (kode, nama, kota, telp, alamat, keterangan) VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "', '" & TextBox6.Text & "')"
            command = New MySqlCommand(s, connection)
            command.ExecuteNonQuery()
        Else
            If Not TextBox1.Text = kode Then
                If DataSudahAda("suplier", "kode", TextBox1.Text) Then
                    MessageBox.Show("Kode suplier ini sudah digunakan", "Kode suplier duplikat")
                    TextBox1.Focus()
                    Exit Sub
                End If
            End If

            Dim s As String = "UPDATE suplier SET kode='" & TextBox1.Text & "', nama='" & TextBox2.Text & "', kota='" & TextBox3.Text & "', telp='" & TextBox4.Text & "', alamat='" & TextBox5.Text & "', keterangan='" & TextBox6.Text & "' WHERE kode = '" & kode & "'"
            command = New MySqlCommand(s, connection)
            command.ExecuteNonQuery()
        End If
        Try
            RefreshAction()
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub
End Class