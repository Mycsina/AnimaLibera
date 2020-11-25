Public Class Options
    Private Sub MusicUp_Click(sender As Object, e As EventArgs) Handles MusicUp.Click
        My.Settings.MusicVol += 50
        mciSendString("setaudio Theme volume to " & CStr(My.Settings.MusicVol))
    End Sub
    Private Sub MusicDown_Click(sender As Object, e As EventArgs) Handles MusicDown.Click
        My.Settings.MusicVol -= 50
        mciSendString("setaudio Theme volume to " & CStr(My.Settings.MusicVol))
    End Sub
    Private Sub SoundFXUp_Click(sender As Object, e As EventArgs) Handles SoundFXUp.Click
        My.Settings.SoundFXVol += 50
        mciSendString("setaudio Attack volume to " & CStr(My.Settings.SoundFXVol))
    End Sub
    Private Sub SoundFXDown_Click(sender As Object, e As EventArgs) Handles SoundFXDown.Click
        My.Settings.SoundFXVol -= 50
        mciSendString("setaudio Attack volume to " & CStr(My.Settings.SoundFXVol))
    End Sub
    Private Sub Test_Click(sender As Object, e As EventArgs) Handles Test.Click
        mciSendString("seek Attack to start")
        mciSendString("play Attack")
    End Sub
    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Close()
        MainMenu.Show()
    End Sub
End Class