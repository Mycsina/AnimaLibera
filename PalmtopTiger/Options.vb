Public Class Options
    Protected Overloads Overrides Sub OnPaint(e As PaintEventArgs)
        Dim ScoreboardFont As Font = New Font("Bauhaus 93", 30, FontStyle.Regular, GraphicsUnit.Pixel)
        e.Graphics.DrawString(My.Settings.MusicVol, ScoreboardFont, Brushes.HotPink, 805, 275)
    End Sub
    Private Sub MusicUp_Click(sender As Object, e As EventArgs) Handles MusicUp.Click
        My.Settings.MusicVol += 10
        mciSendString("setaudio Theme volume to " & My.Settings.MusicVol)
        Invalidate(New Rectangle(805, 275, 100, 100))
    End Sub
    Private Sub MusicDown_Click(sender As Object, e As EventArgs) Handles MusicDown.Click
        My.Settings.MusicVol -= 10
        mciSendString("setaudio Theme volume to " & My.Settings.MusicVol)
        Invalidate(New Rectangle(805, 275, 100, 100))
    End Sub
    Private Sub SoundFXUp_Click(sender As Object, e As EventArgs) Handles SoundFXUp.Click
        My.Settings.SoundFXVol += 10
        MainMenu.ClickSound()
        mciSendString("setaudio Attack volume to " & My.Settings.SoundFXVol)
    End Sub
    Private Sub SoundFXDown_Click(sender As Object, e As EventArgs) Handles SoundFXDown.Click
        My.Settings.SoundFXVol -= 10
        MainMenu.ClickSound()
        mciSendString("setaudio Attack volume to " & My.Settings.SoundFXVol)
    End Sub
    Private Sub Back_Click(sender As Object, e As EventArgs) Handles BackPB.Click
        MainMenu.ClickSound()
        Close()
        MainMenu.Show()
    End Sub
    Private Sub MusicUp_DoubleClick(sender As Object, e As EventArgs) Handles MusicUp.DoubleClick
        My.Settings.MusicVol += 50
        mciSendString("setaudio Theme volume to " & My.Settings.MusicVol)
        Invalidate(New Rectangle(805, 275, 100, 100))
    End Sub
    Private Sub MusicDown_DoubleClick(sender As Object, e As EventArgs) Handles MusicDown.DoubleClick
        My.Settings.MusicVol -= 50
        mciSendString("setaudio Theme volume to " & My.Settings.MusicVol)
        Invalidate(New Rectangle(805, 275, 100, 100))
    End Sub
    Private Sub SoundFXUp_DoubleClick(sender As Object, e As EventArgs) Handles SoundFXUp.DoubleClick
        My.Settings.SoundFXVol += 50
        MainMenu.ClickSound()
        mciSendString("setaudio Attack volume to " & My.Settings.SoundFXVol)
    End Sub
    Private Sub SoundFXDown_DoubleClick(sender As Object, e As EventArgs) Handles SoundFXDown.DoubleClick
        My.Settings.SoundFXVol -= 50
        MainMenu.ClickSound()
        mciSendString("setaudio Attack volume to " & My.Settings.SoundFXVol)
    End Sub
    Private Sub Options_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            MainMenu.ClickSound()
            Close()
            MainMenu.Show()
        End If
    End Sub
End Class