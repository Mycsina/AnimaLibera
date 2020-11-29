Public Class MainMenu
    Public AppPath As String = Application.StartupPath
    Protected HelpToggle As Boolean = False
    Protected Overloads Overrides Sub OnPaint(e As PaintEventArgs)
        If HelpToggle Then
            e.Graphics.DrawImage(My.Resources.Help, New Rectangle(New Point(300, 0), New Size(500, 500)))
        End If
    End Sub
    Private Sub Start_Click(sender As Object, e As EventArgs) Handles Start.Click
        ClickSound()
        CharacterPicker.Show()
        Hide()
    End Sub
    Private Sub Options_Click(sender As Object, e As EventArgs) Handles OptionsPB.Click
        ClickSound()
        Options.Show()
        Hide()
    End Sub
    Public Sub ExitPB_Click(sender As Object, e As EventArgs) Handles ExitPB.Click
        IO.Directory.Delete(AppPath & "/temp/", True)
        Application.Exit()
    End Sub
    Public Sub Menu_Load(sender As Object, e As EventArgs) Handles Me.Load
        SaveResourceObject("Theme", "theme.mp3", AppPath & "/temp/")
        SaveResourceObject("attack", "attack.mp3", AppPath & "/temp/")
        SaveResourceObject("Level1", "level1.mp3", AppPath & "/temp/")
        SaveResourceObject("Level2", "level2.mp3", AppPath & "/temp/")
        SaveResourceObject("RandomLevel", "randomlevel.mp3", AppPath & "/temp/")
        Dim attack = AppPath & "/temp/attack.mp3"
        mciSendString("Open " & attack & " alias Attack")
        Dim theme = AppPath & "/temp/theme.mp3"
        mciSendString("Open " & theme & " alias Theme")
        mciSendString("setaudio Theme volume to " & My.Settings.MusicVol)
        mciSendString("setaudio Attack volume to " & My.Settings.SoundFXVol)
        If My.Settings.Music Then
            mciSendString("play Theme repeat")
        End If
    End Sub
    Private Sub Music_Click(sender As Object, e As EventArgs) Handles Music.Click
        My.Settings.Music = Not My.Settings.Music
        If My.Settings.Music Then
            mciSendString("play Theme repeat")
        Else
            mciSendString("stop Theme")
        End If
    End Sub
    Public Sub SoundEffects_Click(sender As Object, e As EventArgs) Handles SoundEffects.Click
        My.Settings.SoundEffects = Not My.Settings.SoundEffects
        ClickSound()
    End Sub
    Public Sub ClickSound()
        If My.Settings.SoundEffects Then
            mciSendString("seek Attack to start")
            mciSendString("play Attack")
        End If
    End Sub
    Private Sub MainMenu_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If HelpToggle Then
                HelpToggle = False
                Invalidate()
            Else
                Close()
            End If
        End If
        If e.KeyValue = 219 Then
            HelpToggle = True
            Invalidate()
        End If
    End Sub
End Class
