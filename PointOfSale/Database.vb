Imports MySql.Data.MySqlClient

Module Database
    Public connection As New MySqlConnection
    Public reader As MySqlDataReader
    Public adapter As MySqlDataAdapter
    Public command As New MySqlCommand

    Public username, password, nama, id As String
    Public leveluser As Level

    Public Enum Level As Integer
        kasir = 0
        admin = 1
        owner = 2
    End Enum

    Public Sub Koneksi()
        If connection.State = ConnectionState.Open Then Exit Sub
        Try
            connection.ConnectionString = "server=127.0.0.1;" _
                           & "user id=root;" _
                           & "password=;" _
                           & "Database=pointofsale"
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function StringToTime(ByVal timestamps As String) As Date
        Dim dt As DateTime = New DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)
        dt = dt.AddMilliseconds(timestamps).ToLocalTime()
        Return dt
    End Function

    Public Function TimeToString(ByVal d As Date) As String
        Return CLng(d.Subtract(New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds)
    End Function

    Public Function DataSudahAda(ByVal namatabel As String, ByVal namafield As String, ByVal value As String)
        command = New MySqlCommand("SELECT " & namafield & " FROM " & namatabel & " WHERE " & namafield & " = '" & value & "' LIMIT 1 OFFSET 0", connection)
        reader = command.ExecuteReader()
        reader.Read()
        Dim res As Boolean = reader.HasRows
        reader.Close()
        Return res
    End Function

    Public Function DataSudahAda(ByVal namatabel As String, ByVal kondisi As String)
        command = New MySqlCommand("SELECT * FROM " & namatabel & " WHERE " & kondisi & " LIMIT 1 OFFSET 0", connection)
        reader = command.ExecuteReader()
        reader.Read()
        Dim res As Boolean = reader.HasRows
        reader.Close()
        Return res
    End Function

    Public Function AmbilData(ByVal namatabel As String, ByVal namafield As String, ByVal fieldkunci As String, ByVal kondisifield As String)
        command = New MySqlCommand("SELECT " & namafield & " FROM " & namatabel & " WHERE " & fieldkunci & " = '" & kondisifield & "' LIMIT 1 OFFSET 0", connection)
        reader = command.ExecuteReader()
        reader.Read()

        Dim res As Object = Nothing
        If reader.HasRows Then
            res = reader.Item(namafield)
        End If
        reader.Close()
        Return res
    End Function

    Public Function UCFirst(ByVal st As String) As String
        If String.IsNullOrEmpty(st) Then Return ""
        Return (st.Substring(0, 1).ToUpper() & st.Substring(1))
    End Function

    Public Function SentenceCase(ByVal st As String) As String
        If String.IsNullOrEmpty(st) Then Return ""
        Dim res As String
        If st.Contains(" ") Then
            Dim s As String() = st.Split(" ")
            For Each item As String In s
                item = UCFirst(item)
            Next
            res = String.Join(" ", s)
        Else
            res = UCFirst(st)
        End If

        Return res
    End Function

End Module
