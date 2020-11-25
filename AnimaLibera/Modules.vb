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
        bitmap = New Bitmap(original.Width, original.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb)
        bitmap.SetResolution(original.HorizontalResolution, original.VerticalResolution)
        Using g As Graphics = Graphics.FromImage(bitmap)
            g.DrawImage(original, New Rectangle(New Point(0, 0), bitmap.Size), New Rectangle(New Point(0, 0), bitmap.Size), GraphicsUnit.Pixel)
        End Using
        Return bitmap
    End Function
End Module
