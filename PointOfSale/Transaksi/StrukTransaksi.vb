Imports MySql.Data.MySqlClient

Public Class StrukTransaksi
    Public PageWidth As Long = 185
    'Field Size in Percent
    Public itemSize As Integer = 50
    Public qtySize As Integer = 20
    Public priceSize As Integer = 30

    Private Const StoreName As String = "Toko Nugie"
    Private Const StoreAddress As String = "Jl. Jambi suak-kandis KM.32 Desa Teluk Raya Rt.07"
    Private Const Telpon As String = "+62853-6924-7358"
    Private Const SMS As String = Telpon

    'for item sales | untuk item penjualan
    Dim arrWidth() As Integer
    Dim arrFormat() As StringFormat

    'declaring printing format class
    Dim c As New PrintingFormat

    Dim ds As New DataSet

    Public Sub New(ByVal kode As String)
        adapter = New MySqlDataAdapter("SELECT * FROM struk_view WHERE kode_transaksi='" & kode & "'", connection)
        adapter.Fill(ds, "struk_view")
    End Sub

    Public Function TestPrint() As Boolean
        Dim res As Boolean = True
        Try
            Printer.NewPrint()
            Printer.SetFont("Courier New", 11, FontStyle.Bold)
            Printer.Print(StoreName, {PageWidth}, {c.MidCenter}) 'Store Name | Nama Toko
            Printer.SetFont("Courier New", 7, FontStyle.Regular)
            Printer.Print(StoreAddress, {PageWidth}, {c.MidCenter}) 'Store Address | Alamat Toko

            Printer.Print(" ") 'spacing
            Printer.SetFont("Courier New", 8, FontStyle.Bold) 'Setting Font
            Printer.Print("PRINTER TEST", {PageWidth}, {c.MidCenter})
        Catch ex As Exception

        End Try
        Return res
    End Function

    Public Sub PrintAsync()
        Printer.NewPrint()

        Printer.SetFont("Courier New", 11, FontStyle.Bold)
        Printer.Print(StoreName, {PageWidth}, {c.MidCenter}) 'Store Name | Nama Toko

        Printer.SetFont("Courier New", 6, FontStyle.Regular)
        Printer.Print(StoreAddress, {PageWidth}, {c.MidCenter}) 'Store Address | Alamat Toko

        'spacing
        Printer.Print(" ")
        With ds.Tables("struk_view")
            Dim d As Date = StringToTime(.Rows(0).Item("timestamps").ToString())
            Printer.Print(d.DayOfWeek.ToString(), {PageWidth}, {c.TopRight}) ' Day Of Week
            Printer.Print(d.ToLongDateString, {PageWidth}, {c.TopRight}) ' Date
            Printer.Print(d.ToLongTimeString, {PageWidth}, {c.TopRight}) ' Date

            Printer.Print("Receipt Number : " & .Rows(0).Item("kode_transaksi").ToString()) ' Transaction No | Nomor transaksi
            Printer.Print(" ") 'spacing


            Printer.Print(" ") 'spacing
            Printer.SetFont("Courier New", 7, FontStyle.Bold) 'Setting Font
            Dim d1, d2, d3 As Integer
            d1 = PageWidth * (itemSize / 100)
            d2 = PageWidth * (qtySize / 100)
            d3 = PageWidth * (priceSize / 100)
            arrWidth = {d1, d2, d3} 'array for column width | array untuk lebar kolom
            arrFormat = {c.MidLeft, c.MidCenter, c.MidRight} 'array alignment
            'column header split by ; | nama kolom dipisah dengan ;
            Printer.Print("Item;Qty;Price", arrWidth, arrFormat)

            Printer.SetFont("Courier New", 6, FontStyle.Regular) 'Setting Font
            Printer.Print("------------------------------------") 'line
            'looping item sales | loop item penjualan
            For Each ro As DataRow In .Rows
                Printer.Print(ro.Item("nama_barang").ToString() & ";" &
                              ro.Item("qty").ToString() & ";" &
                              "Rp" & FormatNumber(ro.Item("harga").ToString(), 0),
                              arrWidth, arrFormat)
            Next

            Printer.Print("------------------------------------")
            arrWidth = {Math.Round(PageWidth.ToString() / 2), Math.Round(PageWidth.ToString() / 2)} 'array for column width | array untuk lebar kolom
            arrFormat = {c.MidRight, c.MidRight} 'array alignment 

            Printer.Print("SUBTOTAL;" & "Rp." & FormatNumber(.Rows(0).Item("total").ToString() - .Rows(0).Item("discount").ToString(), 0), arrWidth, arrFormat)
            Printer.Print("POTONGAN;" & "Rp." & FormatNumber(.Rows(0).Item("discount").ToString(), 0), arrWidth, arrFormat)
            Printer.Print("TUNAI;" & "Rp." & FormatNumber(.Rows(0).Item("bayar").ToString(), 0), arrWidth, arrFormat)
            Printer.Print("------------------------------------")
            Printer.Print("KEMBALI;" & "Rp." & FormatNumber(.Rows(0).Item("kembali").ToString(), 0), arrWidth, arrFormat)

            Printer.Print(" ") 'spacing
            Printer.SetFont("Courier New", 8, FontStyle.Bold) 'Setting Font
            Printer.Print("TERIMAKASIH", {PageWidth}, {c.MidCenter})
            Printer.Print("SELAMAT BELANJA KEMBALI", {PageWidth}, {c.MidCenter})

            Printer.Print(" ") 'spacing
            Printer.SetFont("Courier New", 8, FontStyle.Regular) 'Setting Font
            Printer.Print("=== LAYANAN KONSUMEN ===", {PageWidth}, {c.MidCenter})
            Printer.Print(Telpon, {PageWidth}, {c.MidCenter})
            Printer.Print("VIA SMS : " & SMS, {PageWidth}, {c.MidCenter})
        End With
        'Release the job for actual printing
        Printer.DoPrint()
    End Sub

End Class
