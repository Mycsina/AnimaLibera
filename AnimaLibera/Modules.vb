Module Modules
    Public Sub SaveResourceObject(Resource As String, Filename As String, Path As String)
        If IO.File.Exists(Path & Filename) Then
        Else
            If IO.Directory.Exists(Path) Then
                IO.File.WriteAllBytes(Path & Filename, My.Resources.ResourceManager.GetObject(Resource))
            Else
                IO.Directory.CreateDirectory(Path)
                IO.File.WriteAllBytes(Path & Filename, My.Resources.ResourceManager.GetObject(Resource))
            End If
        End If
    End Sub
    Public Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (lpstrCommand As String, Optional lpstrReturnString As String = "0", Optional uReturnLength As Integer = 0, Optional hwndCallback As Integer = 0) As Integer
    Public Function HighPerfImage(original As Image)
        Dim bitmap As Bitmap
        bitmap = New Bitmap(original.Width, original.Height, Imaging.PixelFormat.Format32bppPArgb)
        bitmap.SetResolution(original.HorizontalResolution, original.VerticalResolution)
        Using g As Graphics = Graphics.FromImage(bitmap)
            g.DrawImage(original, New Rectangle(New Point(0, 0), bitmap.Size), New Rectangle(New Point(0, 0), bitmap.Size), GraphicsUnit.Pixel)
        End Using
        Return bitmap
    End Function
    Public Function ChangeOpacity(Image As Image, OpacityValue As Single) As Bitmap
        Dim bmp As New Bitmap(Image.Width, Image.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim colormatrix As New Imaging.ColorMatrix With {
            .Matrix33 = OpacityValue
        }
        Dim imgAttribute As New Imaging.ImageAttributes
        imgAttribute.SetColorMatrix(colormatrix, Imaging.ColorMatrixFlag.[Default], Imaging.ColorAdjustType.Bitmap)
        g.DrawImage(Image, New Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, imgAttribute)
        g.Dispose()
        Return bmp
    End Function
    Public Function Level1()
        Dim Enemies As List(Of Enemy)
        Enemies = New List(Of Enemy) From {
            {New Parrot(New Point(50, 298), New List(Of Point) From {
            {New Point(113, 298)},
            {New Point(176, 250)},
            {New Point(239, 203)},
            {New Point(302, 108)},
            {New Point(365, 60)}},
            5, 5)},
            {New Parrot(New Point(910, 298), New List(Of Point) From {
            {New Point(869, 298)},
            {New Point(806, 250)},
            {New Point(743, 203)},
            {New Point(680, 108)},
            {New Point(617, 60)}},
            5, 5)},
            {New Turtle(New Point(178, 108), New List(Of Point) From {
            {New Point(178, 108)},
            {New Point(178, 108)}},
            10, 10)},
            {New Turtle(New Point(302, 155), New List(Of Point) From {
            {New Point(302, 155)},
            {New Point(302, 155)}},
            10, 10)},
            {New Turtle(New Point(428, 108), New List(Of Point) From {
            {New Point(428, 108)},
            {New Point(428, 108)}},
            10, 10)},
            {New Turtle(New Point(554, 155), New List(Of Point) From {
            {New Point(554, 155)},
            {New Point(554, 155)}},
            10, 10)},
            {New Turtle(New Point(680, 108), New List(Of Point) From {
            {New Point(680, 108)},
            {New Point(680, 108)}},
            10, 10)},
            {New Turtle(New Point(806, 155), New List(Of Point) From {
            {New Point(806, 155)},
            {New Point(806, 155)}},
            10, 10)},
            {New Polvinho(New Point(113, 108), New List(Of Point) From {
            {New Point(113, 108)},
            {New Point(113, 108)}},
            10, 15)}}
        Return Enemies
    End Function
End Module
