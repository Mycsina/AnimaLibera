Public Class Options
    Protected Overloads Overrides Sub OnPaint(e As PaintEventArgs)
        Dim ScoreboardFont As Font = New Font("Bauhaus 93", 30, FontStyle.Regular, GraphicsUnit.Pixel)
        e.Graphics.DrawString(My.Settings.MusicVol, ScoreboardFont, Brushes.HotPink, 875, 360)
        e.Graphics.DrawString(Decimal.Round(My.Settings.DifficultyMultiplier, decimals:=2), ScoreboardFont, Brushes.HotPink, 875, 245)
    End Sub

    Private Sub MusicUp_Click(sender As Object, e As EventArgs) Handles MusicUp.Click
        My.Settings.MusicVol += 10
        mciSendString("setaudio Theme volume to " & My.Settings.MusicVol)
        Invalidate(New Rectangle(875, 360, 100, 100))
    End Sub

    Private Sub MusicDown_Click(sender As Object, e As EventArgs) Handles MusicDown.Click
        If My.Settings.MusicVol > 0 Then
            My.Settings.MusicVol -= 10
            mciSendString("setaudio Theme volume to " & My.Settings.MusicVol)
            Invalidate(New Rectangle(875, 360, 100, 100))
        End If
    End Sub

    Private Sub SoundFXUp_Click(sender As Object, e As EventArgs) Handles SoundFXUp.Click
        My.Settings.SoundFXVol += 10
        mciSendString("setaudio Attack volume to " & My.Settings.SoundFXVol)
        MainMenu.ClickSound()
    End Sub

    Private Sub SoundFXDown_Click(sender As Object, e As EventArgs) Handles SoundFXDown.Click
        If My.Settings.SoundFXVol > 0 Then
            My.Settings.SoundFXVol -= 10
            mciSendString("setaudio Attack volume to " & My.Settings.SoundFXVol)
            MainMenu.ClickSound()
        End If
    End Sub

    Private Sub Back_Click(sender As Object, e As EventArgs) Handles BackPB.Click
        MainMenu.ClickSound()
        Close()
        MainMenu.Show()
    End Sub

    Private Sub MusicUp_DoubleClick(sender As Object, e As EventArgs) Handles MusicUp.DoubleClick
        My.Settings.MusicVol += 40
        mciSendString("setaudio Theme volume to " & My.Settings.MusicVol)
        Invalidate(New Rectangle(875, 360, 100, 100))
    End Sub

    Private Sub MusicDown_DoubleClick(sender As Object, e As EventArgs) Handles MusicDown.DoubleClick
        If My.Settings.MusicVol >= 40 Then
            My.Settings.MusicVol -= 40
            mciSendString("setaudio Theme volume to " & My.Settings.MusicVol)
            Invalidate(New Rectangle(875, 360, 100, 100))
        End If
    End Sub

    Private Sub SoundFXUp_DoubleClick(sender As Object, e As EventArgs) Handles SoundFXUp.DoubleClick
        My.Settings.SoundFXVol += 40
        mciSendString("setaudio Attack volume to " & My.Settings.SoundFXVol)
        MainMenu.ClickSound()
    End Sub

    Private Sub SoundFXDown_DoubleClick(sender As Object, e As EventArgs) Handles SoundFXDown.DoubleClick
        If My.Settings.MusicVol >= 50 Then
            My.Settings.SoundFXVol -= 40
            mciSendString("setaudio Attack volume to " & My.Settings.SoundFXVol)
            MainMenu.ClickSound()
        End If
    End Sub

    Private Sub Options_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            MainMenu.ClickSound()
            Close()
            MainMenu.Show()
        End If
    End Sub

    Private Sub DifficultyDown_Click(sender As Object, e As EventArgs) Handles DifficultyDown.Click
        If My.Settings.DifficultyMultiplier > 0 Then
            My.Settings.DifficultyMultiplier -= 0.05
            MainMenu.ClickSound()
            Invalidate(New Rectangle(875, 245, 100, 100))
        End If
    End Sub

    Private Sub DifficultyUp_Click(sender As Object, e As EventArgs) Handles DifficultyUp.Click
        My.Settings.DifficultyMultiplier += 0.05
        MainMenu.ClickSound()
        Invalidate(New Rectangle(875, 245, 100, 100))
    End Sub

    Private Sub DifficultyUp_DoubleClick(sender As Object, e As EventArgs) Handles DifficultyUp.DoubleClick
        My.Settings.DifficultyMultiplier += 0.2
        MainMenu.ClickSound()
        Invalidate(New Rectangle(875, 245, 100, 100))
    End Sub

    Private Sub DifficultyDown_DoubleClick(sender As Object, e As EventArgs) Handles DifficultyDown.DoubleClick
        If My.Settings.DifficultyMultiplier > 0.2 Then
            My.Settings.DifficultyMultiplier -= 0.2
            MainMenu.ClickSound()
            Invalidate(New Rectangle(875, 245, 100, 100))
        End If
    End Sub
End Class