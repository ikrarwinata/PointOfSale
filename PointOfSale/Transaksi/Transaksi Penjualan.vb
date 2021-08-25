Imports MySql.Data.MySqlClient

Public Class Transaksi_Penjualan
    Private refNumber As Long = 1
    Private hargaSatuan, subtotalbarang, subtotalsemua, total, kembali As Long

    Private Property Subtotal
        Get
            Return subtotalsemua
        End Get
        Set(ByVal value)
            subtotalsemua = value
            Try
                Label40.Text = "Rp." & FormatNumber(subtotalsemua, 0)
            Catch ex As Exception
                Label40.Text = "Rp.0"
            End Try
            Try
                kembali = (txbbayar.Text - (subtotalsemua - txbdiscount.Text))
                total = subtotalsemua - txbdiscount.Text
                If kembali >= 0 Then
                    Label24.Text = "Rp." & FormatNumber(kembali, 0)
                Else
                    Label24.Text = "Rp.0"
                End If
                Label30.Text = "Rp." & FormatNumber(total, 0)
            Catch ex As Exception
                Label30.Text = "Rp.0"
            End Try
        End Set
    End Property

    Private Function BuatKodeTransaksi() As String
        Dim s As String = "TR-" & Date.Now.Year & "-"
        Try
            command = New MySqlCommand("SELECT kode FROM transaksi ORDER BY kode DESC LIMIT 1 OFFSET 0", connection)
            reader = command.ExecuteReader()
            reader.Read()
            Dim i As Integer = 1
            reader.Read()
            If reader.HasRows Then
                If Not String.IsNullOrEmpty(reader.Item("kode").ToString()) Then
                    i = reader.Item("kode").ToString().Split("-").Last()
                    i += 1
                End If
            End If
            s &= New String("0", 9 - i.ToString().Length) & i.ToString()
            refNumber = i
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        reader.Close()
        Return s
    End Function

    Private Sub BersihkanDetailBarang(ByVal reset As Boolean)
        hargaSatuan = 0
        subtotalbarang = 0
        Label25.Text = ""
        Label20.Text = ""
        Label15.Text = 0
        Label22.Text = ""
        Label17.Text = "Rp.0"
        NumericUpDown1.Maximum = 100000
        NumericUpDown1.Value = 1
        Label7.Text = ""
        Label8.Text = ""
        Label13.Text = ""
        Label4.Text = "Rp.0"
        If reset Then
            dgv1.Rows.Clear()
            barcodeField.Text = ""
            txbbayar.Text = "0"
            txbdiscount.Text = "0"
            total = 0
            kembali = 0
            Subtotal = 0
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        Try
            subtotalbarang = hargaSatuan * NumericUpDown1.Value
            Label4.Text = "Rp." & FormatNumber(subtotalbarang, 0)
        Catch ex As Exception
            subtotalbarang = 0
            Label4.Text = "Rp.0"
        End Try
    End Sub

    Private Sub NumericUpDown1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NumericUpDown1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            If NumericUpDown1.Value > Label15.Text Then
                MessageBox.Show("Stok tidak mencukupi !")
                NumericUpDown1.Focus()
                Exit Sub
            End If
            dgv1.Rows.Add(barcodeField.Text, Label25.Text, Label20.Text, hargaSatuan, NumericUpDown1.Value, subtotalbarang)

            Subtotal += subtotalbarang
            BersihkanDetailBarang(False)
            barcodeField.Text = ""
            barcodeField.Focus()
        End If
    End Sub

    Private Sub Transaksi_Penjualan_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, txbdiscount.KeyUp, txbbayar.KeyUp, barcodeField.KeyUp, NumericUpDown1.KeyUp, dgv1.KeyUp
        Select Case e.KeyCode
            Case Keys.F1
                barcodeField.Focus()
            Case Keys.F2
                dgv1.Focus()
            Case Keys.F3
                txbbayar.Focus()
                txbbayar.SelectAll()
            Case Keys.F4
                txbdiscount.Focus()
                txbdiscount.SelectAll()
            Case Keys.F11
                Button2.PerformClick()
            Case Keys.F12
                Button3.PerformClick()
            Case Else

        End Select

        Try
            If TypeOf (sender) Is DataGridView Then
                If e.KeyCode = Keys.Delete Then
                    For Each row As DataGridViewRow In dgv1.SelectedRows
                        dgv1.Rows.Remove(row)
                    Next
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Transaksi_Penjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        field1.Text = DateTime.Now.DayOfWeek.ToString() & ", " & Date.Now.ToLongDateString
        field2.Text = id
        field3.Text = BuatKodeTransaksi()
        field4.Text = nama
        field5.Text = refNumber
        field8.Text = Date.Now.ToLongTimeString
        Select Case leveluser
            Case Level.kasir
                field6.Text = "Kasir"
            Case Level.admin
                field6.Text = "Administrator"
            Case Else
                field6.Text = "Owner"
        End Select
        Timer1.Start()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim brg As transaksiCariBarang = New transaksiCariBarang
        brg.MdiParent = Me.MdiParent
        brg.Pencarian(AddressOf OnPencarian)
    End Sub

    Public Sub OnPencarian(ByVal kode As String)
        Dim s As String = "SELECT a.kode, d.barcode, a.nama, b.kategori, c.satuan, a.harga, a.kadaluarsa, a.stok FROM barang a LEFT OUTER JOIN kategori_barang b ON a.kategori=b.id LEFT OUTER JOIN satuanbarang c ON a.satuan=c.id LEFT OUTER JOIN barcodebarang d ON a.kode=d.kode_barang WHERE a.kode = '" & kode & "'  LIMIT 1 OFFSET 0"
        command = New MySqlCommand(s, connection)
        reader = command.ExecuteReader()
        reader.Read()

        If reader.HasRows Then
            Try
                With reader
                    barcodeField.Text = .Item("barcode")
                    Label25.Text = .Item("kode")
                    Label20.Text = .Item("nama")
                    Label15.Text = .Item("stok")
                    If .Item("stok") >= 1 Then NumericUpDown1.Maximum = .Item("stok")
                    Label22.Text = SentenceCase(.Item("kategori"))
                    Try
                        hargaSatuan = .Item("harga")
                        Label17.Text = "Rp." & FormatNumber(hargaSatuan, 0)
                    Catch ex As Exception
                        hargaSatuan = 0
                        Label17.Text = "Rp.0"
                    End Try
                    Label7.Text = SentenceCase(.Item("satuan"))
                    Label8.Text = StringToTime(.Item("kadaluarsa")).DayOfWeek.ToString() & ", " & StringToTime(.Item("kadaluarsa")).ToLongDateString()
                    Dim date1 As Date = Date.Now
                    Dim date2 As Date = StringToTime(.Item("kadaluarsa"))
                    Dim day As Long = DateDiff(DateInterval.Day, date1, date2)
                    If day <= 0 Then
                        Label13.Text = "Kadaluarsa telah lewat " & day & " hari"
                        Label13.ForeColor = Color.Firebrick
                    Else
                        If day <= 28 Then
                            Label13.Text = "(" & day & " hari yang akan datang)"
                        Else
                            day = DateDiff(DateInterval.Month, date1, date2)
                            Label13.Text = "(" & day & " bulan yang akan datang)"
                        End If
                        Label13.ForeColor = Color.SeaGreen
                    End If
                    Try
                        subtotalbarang = hargaSatuan * NumericUpDown1.Value
                        Label4.Text = "Rp." & FormatNumber(subtotalbarang, 0)
                    Catch ex As Exception
                        subtotalbarang = 0
                        Label4.Text = "Rp.0"
                    End Try
                End With
                NumericUpDown1.Focus()
                NumericUpDown1.Select(0, 1)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            BersihkanDetailBarang(False)
        End If
        reader.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        field8.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles barcodeField.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Dim s As String = "SELECT a.kode, d.barcode, a.nama, b.kategori, c.satuan, a.harga, a.kadaluarsa, a.stok FROM barang a LEFT OUTER JOIN kategori_barang b ON a.kategori=b.id LEFT OUTER JOIN satuanbarang c ON a.satuan=c.id LEFT OUTER JOIN barcodebarang d ON a.kode=d.kode_barang WHERE d.barcode = '" & barcodeField.Text & "'  LIMIT 1 OFFSET 0"
            command = New MySqlCommand(s, connection)
            reader = command.ExecuteReader()
            reader.Read()

            If reader.HasRows Then
                Try
                    With reader
                        Label25.Text = .Item("kode")
                        Label20.Text = .Item("nama")
                        Label15.Text = .Item("stok")
                        If .Item("stok") >= 1 Then NumericUpDown1.Maximum = .Item("stok")
                        Label22.Text = SentenceCase(.Item("kategori"))
                        Try
                            hargaSatuan = .Item("harga")
                            Label17.Text = "Rp." & FormatNumber(hargaSatuan, 0)
                        Catch ex As Exception
                            hargaSatuan = 0
                            Label17.Text = "Rp.0"
                        End Try
                        Label7.Text = SentenceCase(.Item("satuan"))
                        Label8.Text = StringToTime(.Item("kadaluarsa")).DayOfWeek.ToString() & ", " & StringToTime(.Item("kadaluarsa")).ToLongDateString()
                        Dim date1 As Date = Date.Now
                        Dim date2 As Date = StringToTime(.Item("kadaluarsa"))
                        Dim day As Long = DateDiff(DateInterval.Day, date1, date2)
                        If day <= 0 Then
                            Label13.Text = "Kadaluarsa telah lewat " & day & " hari"
                            Label13.ForeColor = Color.Firebrick
                        Else
                            If day <= 28 Then
                                Label13.Text = "(" & day & " hari yang akan datang)"
                            Else
                                day = DateDiff(DateInterval.Month, date1, date2)
                                Label13.Text = "(" & day & " bulan yang akan datang)"
                            End If
                            Label13.ForeColor = Color.SeaGreen
                        End If
                        Try
                            subtotalbarang = hargaSatuan * NumericUpDown1.Value
                            Label4.Text = "Rp." & FormatNumber(subtotalbarang, 0)
                        Catch ex As Exception
                            subtotalbarang = 0
                            Label4.Text = "Rp.0"
                        End Try
                    End With
                    NumericUpDown1.Focus()
                    NumericUpDown1.Select(0, 1)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Else
                BersihkanDetailBarang(False)
            End If
            reader.Close()
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txbdiscount.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txbbayar.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Function Valid()
        If dgv1.Rows.Count <= 0 Then
            MessageBox.Show("Barang masih kosong")
            barcodeField.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(txbbayar.Text) Then
            MessageBox.Show("Masukan nominal pembayaran")
            Return False
        Else
            If Integer.Parse(txbbayar.Text) = 0 Then
                MessageBox.Show("Masukan nominal pembayaran")
                txbbayar.Focus()
                Return False
            ElseIf (Integer.Parse(txbbayar.Text) - Subtotal) < 0 Then
                MessageBox.Show("Uang pembayaran kurang")
                txbbayar.Focus()
                Return False
            End If
        End If

        If String.IsNullOrEmpty(txbdiscount.Text) Then
            txbdiscount.Text = 0
        End If

        Return True
    End Function

    Private Sub SimpanTransaksi()
        Dim kodetransaksi As String = field3.Text

        command = New MySqlCommand("INSERT INTO transaksi (kode, timestamps, total, bayar, discount, kembali, kasir) VALUES ('" & kodetransaksi & "', " & TimeToString(Now) & ", " & total & ", " & txbbayar.Text & ", " & txbdiscount.Text & ", " & kembali & ", '" & username & "')", connection)
        command.ExecuteNonQuery()

        For Each ro As DataGridViewRow In dgv1.Rows
            command = New MySqlCommand("INSERT INTO detail_transaksi (kode_transaksi, qty, kode_barang) VALUES ('" & kodetransaksi & "', " & ro.Cells("dgvcqty").Value & ", '" & ro.Cells("dgvckode").Value & "')", connection)
            command.ExecuteNonQuery()
            command = New MySqlCommand("UPDATE barang SET stok=stok-" & ro.Cells("dgvcqty").Value & " WHERE kode = '" & ro.Cells("dgvckode").Value & "'", connection)
            command.ExecuteNonQuery()
        Next
    End Sub

    Private Sub CetakTransaksi()
        Dim strf As StrukTransaksi = New StrukTransaksi(field3.Text)
        strf.PrintAsync()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Not Valid() Then Exit Sub
        SimpanTransaksi()
        CetakTransaksi()
        BersihkanDetailBarang(True)
        field3.Text = BuatKodeTransaksi()
        field5.Text = refNumber
        barcodeField.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MessageBox.Show("Balatkan transaksi saat ini ?" & vbNewLine & "Aksi ini akan menghapus barang dan tidak dapat diulang", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            BersihkanDetailBarang(True)
            dgv1.Rows.Clear()
            barcodeField.Text = ""
            barcodeField.Focus()
        End If
    End Sub

    Private Sub Hitung()
        Try
            kembali = (txbbayar.Text - (subtotalsemua - txbdiscount.Text))
            total = subtotalsemua - txbdiscount.Text
            If kembali >= 0 Then
                Label24.Text = "Rp." & FormatNumber(kembali, 0)
            Else
                Label24.Text = "Rp.0"
            End If
            Label30.Text = "Rp." & FormatNumber(total, 0)
        Catch ex As Exception
            Label30.Text = "Rp.0"
        End Try
    End Sub

    Private Sub txbbayar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbbayar.TextChanged, txbdiscount.TextChanged
        Hitung()
    End Sub
End Class