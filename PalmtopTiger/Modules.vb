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

    Public Function Level1(Modifier)
        Dim Enemies As List(Of Enemy)
        Enemies = New List(Of Enemy) From {
            {New Parrot(New Point(50, 298), New List(Of Point) From {
            {New Point(113, 298)},
            {New Point(176, 250)},
            {New Point(239, 203)},
            {New Point(302, 108)},
            {New Point(365, 60)}},
            5, 5, Modifier)},
            {New Parrot(New Point(910, 298), New List(Of Point) From {
            {New Point(869, 298)},
            {New Point(806, 250)},
            {New Point(743, 203)},
            {New Point(680, 108)},
            {New Point(617, 60)}},
            5, 5, Modifier)},
            {New Turtle(New Point(178, 108), New List(Of Point) From {
            {New Point(178, 108)},
            {New Point(178, 108)}},
            10, 10, Modifier)},
            {New Turtle(New Point(302, 155), New List(Of Point) From {
            {New Point(302, 155)},
            {New Point(302, 155)}},
            10, 10, Modifier)},
            {New Turtle(New Point(680, 108), New List(Of Point) From {
            {New Point(680, 108)},
            {New Point(680, 108)}},
            10, 10, Modifier)},
            {New Turtle(New Point(806, 155), New List(Of Point) From {
            {New Point(806, 155)},
            {New Point(806, 155)}},
            10, 10, Modifier)},
            {New Polvinho(New Point(113, 108), New List(Of Point) From {
            {New Point(113, 108)},
            {New Point(113, 108)}},
            10, 15, Modifier)},
            {New Polvinho(New Point(869, 108), New List(Of Point) From {
            {New Point(113, 582)},
            {New Point(113, 582)}},
            10, 15, Modifier)},
            {New Polvinho(New Point(113, 155), New List(Of Point) From {
            {New Point(113, 155)},
            {New Point(113, 155)}},
            10, 30, Modifier)},
            {New Polvinho(New Point(113, 345), New List(Of Point) From {
            {New Point(113, 345)},
            {New Point(113, 345)}},
            10, 35, Modifier)},
            {New Polvinho(New Point(113, 535), New List(Of Point) From {
            {New Point(113, 535)},
            {New Point(113, 535)}},
            10, 30, Modifier)},
            {New Polvinho(New Point(869, 155), New List(Of Point) From {
            {New Point(869, 155)},
            {New Point(869, 155)}},
            10, 30, Modifier)},
            {New Polvinho(New Point(869, 345), New List(Of Point) From {
            {New Point(869, 345)},
            {New Point(869, 345)}},
            10, 35, Modifier)},
            {New Dragoon(New Point(365, 108), New List(Of Point) From {
            {New Point(365, 155)},
            {New Point(365, 203)},
            {New Point(302, 250)},
            {New Point(365, 298)},
            {New Point(428, 250)},
            {New Point(365, 203)},
            {New Point(365, 60)}},
            15, 45, Modifier)},
            {New Dragoon(New Point(491, 108), New List(Of Point) From {
            {New Point(491, 155)},
            {New Point(491, 203)},
            {New Point(554, 250)},
            {New Point(491, 298)},
            {New Point(428, 250)},
            {New Point(491, 203)},
            {New Point(491, 60)}},
            15, 45, Modifier)},
            {New Tiger(New Point(491, 155), New List(Of Point) From {
            {New Point(806, 155)},
            {New Point(806, 535)},
            {New Point(176, 155)},
            {New Point(680, 298)},
            {New Point(365, 155)},
            {New Point(617, 155)},
            {New Point(302, 298)},
            {New Point(491, 250)}},
            100, 60, Modifier)}}
        Return Enemies
    End Function

    Public Function Level2(Modifier)
        Dim Enemies As List(Of Enemy)
        Enemies = New List(Of Enemy) From {
            {New Parrot(New Point(113, 108), New List(Of Point) From {
            {New Point(176, 155)},
            {New Point(239, 108)},
            {New Point(302, 155)},
            {New Point(365, 108)},
            {New Point(428, 155)}},
            14, 5, Modifier)},
            {New Parrot(New Point(428, 155), New List(Of Point) From {
            {New Point(365, 108)},
            {New Point(302, 155)},
            {New Point(239, 108)},
            {New Point(176, 155)},
            {New Point(113, 108)}},
            11, 7, Modifier)},
            {New Parrot(New Point(869, 108), New List(Of Point) From {
            {New Point(806, 155)},
            {New Point(743, 108)},
            {New Point(680, 155)},
            {New Point(617, 108)},
            {New Point(554, 155)}},
            14, 5, Modifier)},
            {New Parrot(New Point(554, 155), New List(Of Point) From {
            {New Point(617, 108)},
            {New Point(680, 155)},
            {New Point(743, 108)},
            {New Point(806, 155)},
            {New Point(869, 108)}},
            11, 7, Modifier)},
            {New Parrot(New Point(302, 250), New List(Of Point) From {
            {New Point(302, 250)},
            {New Point(302, 250)}},
            10, 50, Modifier)},
            {New Parrot(New Point(680, 250), New List(Of Point) From {
            {New Point(680, 250)},
            {New Point(680, 250)}},
            10, 50, Modifier)},
            {New Polvinho(New Point(113, 155), New List(Of Point) From {
            {New Point(113, 155)},
            {New Point(113, 155)}},
            15, 45, Modifier)},
            {New Polvinho(New Point(869, 155), New List(Of Point) From {
            {New Point(869, 155)},
            {New Point(869, 155)}},
            15, 45, Modifier)},
            {New Turtle(New Point(176, 205), New List(Of Point) From {
            {New Point(239, 205)},
            {New Point(113, 205)}},
            18, 20, Modifier)},
            {New Turtle(New Point(302, 205), New List(Of Point) From {
            {New Point(365, 205)},
            {New Point(239, 205)}},
            18, 20, Modifier)},
            {New Turtle(New Point(428, 205), New List(Of Point) From {
            {New Point(491, 205)},
            {New Point(365, 205)}},
            18, 20, Modifier)},
            {New Turtle(New Point(554, 205), New List(Of Point) From {
            {New Point(617, 205)},
            {New Point(491, 205)}},
            18, 20, Modifier)},
            {New Turtle(New Point(680, 205), New List(Of Point) From {
            {New Point(745, 205)},
            {New Point(617, 205)}},
            18, 20, Modifier)},
            {New Dragoon(New Point(113, 488), New List(Of Point) From {
            {New Point(176, 535)},
            {New Point(235, 488)},
            {New Point(302, 393)},
            {New Point(365, 250)},
            {New Point(428, 60)}},
            10, 30, Modifier)},
            {New Dragoon(New Point(869, 488), New List(Of Point) From {
            {New Point(806, 535)},
            {New Point(743, 488)},
            {New Point(680, 393)},
            {New Point(617, 250)},
            {New Point(554, 60)}},
            10, 30, Modifier)},
            {New Dragoon(New Point(113, 488), New List(Of Point) From {
            {New Point(176, 535)},
            {New Point(235, 488)},
            {New Point(302, 393)},
            {New Point(365, 250)},
            {New Point(428, 0)}},
            10, 40, Modifier)},
            {New Dragoon(New Point(869, 488), New List(Of Point) From {
            {New Point(806, 535)},
            {New Point(743, 488)},
            {New Point(680, 393)},
            {New Point(617, 250)},
            {New Point(554, 0)}},
            10, 40, Modifier)},
            {New Tiger(New Point(491, 108), New List(Of Point) From {
            {New Point(113, 203)},
            {New Point(806, 108)},
            {New Point(365, 298)},
            {New Point(680, 298)},
            {New Point(491, 155)}},
            1000, 60, Modifier)}}
        Return Enemies
    End Function
    Public Function LevelR(Modifier)
        Dim ChaoticPoint1 = New Point(CInt(Math.Floor(750 * Rnd())) + 120, CInt(Math.Floor(250 * Rnd())) + 108)
        Dim ChaoticPoint2 = New Point(CInt(Math.Floor(750 * Rnd())) + 120, CInt(Math.Floor(250 * Rnd())) + 108)
        Dim ChaoticPoint3 = New Point(CInt(Math.Floor(750 * Rnd())) + 120, CInt(Math.Floor(250 * Rnd())) + 108)
        Dim ChaoticPoint4 = New Point(CInt(Math.Floor(750 * Rnd())) + 120, CInt(Math.Floor(250 * Rnd())) + 108)
        Dim ChaoticPointOList = New List(Of Point) From {{ChaoticPoint1}, {ChaoticPoint2}, {ChaoticPoint3}, {ChaoticPoint4}}
        Dim ChaoticTime = CInt(Math.Floor(20 * Rnd())) + 5
        Randomize()
        Select Case CInt(Math.Floor(5 * Rnd())) + 1
            Case 1
                Return New Parrot(ChaoticPointOList(0), ChaoticPointOList, ChaoticTime, 0, Modifier)
            Case 2
                Return New Turtle(ChaoticPointOList(0), ChaoticPointOList, ChaoticTime, 0, Modifier)
            Case 3
                Return New Polvinho(ChaoticPointOList(0), ChaoticPointOList, ChaoticTime, 0, Modifier)
            Case 4
                Return New Dragoon(ChaoticPointOList(0), ChaoticPointOList, ChaoticTime, 0, Modifier)
            Case 5
                Return New Tiger(ChaoticPointOList(0), ChaoticPointOList, ChaoticTime, 0, Modifier)
        End Select
    End Function
End Module