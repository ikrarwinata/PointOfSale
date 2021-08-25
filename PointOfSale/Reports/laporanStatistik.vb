Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Public Class laporanStatistik

    Private ReadOnly Property TipeGrafikTransaksi As SeriesChartType
        Get
            If RadioButton1.Checked Then
                Return SeriesChartType.Spline
            ElseIf RadioButton5.Checked Then
                Return SeriesChartType.SplineArea
            Else
                Return SeriesChartType.Column
            End If
        End Get
    End Property

    Private ReadOnly Property TipeGrafikBarang As SeriesChartType
        Get
            If RadioButton4.Checked Then
                Return SeriesChartType.Line
            ElseIf RadioButton6.Checked Then
                Return SeriesChartType.Area
            Else
                Return SeriesChartType.Column
            End If
        End Get
    End Property

    Public Sub LoadDatabase()
        Try
            Dim d, tOmo As Integer
            Dim query As String = ""
            Dim startYear, endYear, startMonth, endMonth As Integer

            Dim d1, d2, d3 As Long
            d1 = TimeToString(DateTimePicker1.Value)
            d2 = TimeToString(DateTimePicker2.Value)
            d3 = d2

            Chart1.Series("Transaksi").Points.Clear()
            Chart1.Series("Barang").Points.Clear()
            Chart1.Series("Transaksi").ChartType = TipeGrafikTransaksi
            Chart1.Series("Barang").ChartType = TipeGrafikBarang

            If d2 <= d1 Then
                Exit Sub
            Else
                Dim df As Long = DateDiff(DateInterval.Day, DateTimePicker1.Value, DateTimePicker2.Value)
                tOmo = DateDiff(DateInterval.Month, DateTimePicker1.Value, DateTimePicker2.Value)

                Dim tr, br, counter As Integer
                startMonth = DateTimePicker1.Value.Month
                endMonth = startMonth
                startYear = DateTimePicker1.Value.Year
                endYear = startYear
                If tOmo > 0 Then
                    tOmo += 1
                    counter = 0
                    For i As Integer = 1 To tOmo
                        If startMonth > 12 Then
                            startMonth -= 12
                            startYear += 1
                        End If
                        If endMonth > 12 Then
                            endMonth -= 12
                            endYear += 1
                        End If
                        tr = 0
                        br = 0
                        d1 = TimeToString(New DateTime(startYear, startMonth, 1, 0, 0, 0))
                        d = System.DateTime.DaysInMonth(endYear, endMonth)
                        d2 = TimeToString(New DateTime(endYear, endMonth, d, 17, 0, 0))
                        If d2 > d3 Then d2 = d3
                        Dim q1 As String = StringToTime(d1).ToLongDateString & " " & StringToTime(d1).ToLongTimeString
                        Dim t1 As String = StringToTime(1612088618602).ToLongDateString & " " & StringToTime(1612088618602).ToLongTimeString
                        Dim q2 As String = StringToTime(d2).ToLongDateString & " " & StringToTime(d2).ToLongTimeString
                        query = "SELECT COUNT(a.kode) AS total_kode, (SELECT SUM(detail_transaksi.qty) FROM detail_transaksi INNER JOIN transaksi ON detail_transaksi.kode_transaksi = transaksi.kode WHERE transaksi.timestamps BETWEEN " & d1 & " AND " & d2 & ") AS barang FROM transaksi a WHERE a.timestamps BETWEEN " & d1 & " AND " & d2 & " ORDER BY a.kode ASC"
                        command = New MySqlCommand(query, connection)
                        reader = command.ExecuteReader()
                        reader.Read()
                        If reader.HasRows Then
                            If Not String.IsNullOrEmpty(reader.Item("total_kode").ToString()) Then
                                tr = reader.Item("total_kode").ToString()
                            End If
                            If Not String.IsNullOrEmpty(reader.Item("barang").ToString()) Then
                                br = reader.Item("barang").ToString()
                            End If
                        End If
                        Chart1.Series("Transaksi").Points.AddXY(StringMonth(startMonth) & " " & startYear.ToString().Substring(2), tr)
                        If tr > 0 And CheckBox1.Checked Then Chart1.Series("Transaksi").Points(counter).Label = tr & " Transaksi"
                        Chart1.Series("Barang").Points.AddXY(StringMonth(startMonth) & " " & startYear.ToString().Substring(2), br)
                        If tr > 0 And CheckBox1.Checked Then Chart1.Series("Barang").Points(counter).Label = br & " Barang Terjual"
                        reader.Close()

                        startMonth += 1
                        endMonth += 1
                        counter += 1
                    Next
                    Chart1.ChartAreas(0).AxisX.Title = "Tanggal"
                Else
                    Dim startDay, endDay, dsw, dew As Integer
                    d = DateTimePicker1.Value.Day
                    startDay = d
                    endDay = d + 1
                    dsw = 0
                    dew = 0
                    For i As Integer = 0 To df
                        dew = System.DateTime.DaysInMonth(endYear, endMonth)
                        dsw = System.DateTime.DaysInMonth(startYear, startMonth)
                        If endDay > dew Then
                            endDay -= dew
                            endMonth += 1
                        End If
                        If startDay > dsw Then
                            d -= dsw
                            startMonth += 1
                        End If
                        If startMonth > 12 Then
                            startMonth -= 12
                            startYear += 1
                        End If
                        If endMonth > 12 Then
                            endMonth -= 12
                            endYear += 1
                        End If
                        tr = 0
                        br = 0
                        d1 = TimeToString(New DateTime(startYear, startMonth, startDay, 0, 0, 0))
                        d = System.DateTime.DaysInMonth(endYear, endMonth)
                        d2 = TimeToString(New DateTime(endYear, endMonth, endDay, 0, 0, 0))


                        query = "SELECT COUNT(a.kode) AS total_kode, (SELECT SUM(detail_transaksi.qty) FROM detail_transaksi INNER JOIN transaksi ON detail_transaksi.kode_transaksi = transaksi.kode WHERE transaksi.timestamps BETWEEN " & d1 & " AND " & d2 & ") AS barang FROM transaksi a WHERE a.timestamps BETWEEN " & d1 & " AND " & d2 & " ORDER BY a.kode ASC"
                        command = New MySqlCommand(query, connection)
                        reader = command.ExecuteReader()
                        reader.Read()
                        If reader.HasRows Then
                            If Not String.IsNullOrEmpty(reader.Item("total_kode").ToString()) Then
                                tr = reader.Item("total_kode").ToString()
                            End If
                            If Not String.IsNullOrEmpty(reader.Item("barang").ToString()) Then
                                br = reader.Item("barang").ToString()
                            End If
                        End If
                        Chart1.Series("Transaksi").Points.AddXY(startDay & " " & StringMonth(startMonth).Substring(0, 3) & " " & startYear.ToString().Substring(2), tr)
                        If tr > 0 And CheckBox1.Checked Then Chart1.Series("Transaksi").Points(counter).Label = tr & " Transaksi"
                        Chart1.Series("Barang").Points.AddXY(startDay & " " & StringMonth(startMonth).Substring(0, 3) & " " & startYear.ToString().Substring(2), br)
                        If tr > 0 And CheckBox1.Checked Then Chart1.Series("Barang").Points(counter).Label = br & " Barang Terjual"
                        reader.Close()

                        startDay += 1
                        endDay += 1
                        counter += 1
                    Next
                    Chart1.ChartAreas(0).AxisX.Title = "Tanggal"
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub laporanStatistik_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ignoreChange = True
        RadioButton1.Checked = True
        RadioButton4.Checked = True
        ignoreChange = False
        DateTimePicker1.Value = New DateTime(Date.Now.Year - 1, 1, 1).ToLongDateString()
        DateTimePicker2.Value = Now
        AddHandler DateTimePicker1.ValueChanged, AddressOf DateTimePicker_ValueChanged
        AddHandler DateTimePicker2.ValueChanged, AddressOf DateTimePicker_ValueChanged
        Timer1.Stop()
        LoadDatabase()
    End Sub

    Private Function StringMonth(ByVal i As Integer) As String
        Dim bulan As String() = {"", "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember"}
        Return bulan(i)
    End Function

    Private Sub DateTimePicker_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer1.Stop()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        LoadDatabase()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        LoadDatabase()
    End Sub


    Private ignoreChange As Boolean
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        ignoreChange = True
        Select Case True
            Case RadioButton1.Checked
                RadioButton2.Checked = False
            Case RadioButton2.Checked
                RadioButton1.Checked = False
            Case Else

        End Select
        ignoreChange = False
        If Not ignoreChange Then LoadDatabase()
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged, RadioButton3.CheckedChanged
        ignoreChange = True
        Select Case True
            Case RadioButton4.Checked
                RadioButton3.Checked = False
            Case RadioButton3.Checked
                RadioButton4.Checked = False
            Case Else

        End Select
        ignoreChange = False
        If Not ignoreChange Then LoadDatabase()
    End Sub
End Class