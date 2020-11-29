Public Class CharacterPicker
    Public GameObject
    Private Sub ExitPB_Click(sender As Object, e As EventArgs) Handles ExitPB.Click
        MainMenu.ClickSound()
        MainMenu.Show()
        Close()
    End Sub
    Public Sub ElfTaigaPB_Click(sender As Object, e As EventArgs) Handles ElfTaigaPB.Click
        MainMenu.ClickSound()
        GameObject = New Game(HighPerfImage(My.Resources.Green_taiga))
        GameObject.Show()
        Close()
    End Sub
    Public Sub RegularTaigaPB_Click(sender As Object, e As EventArgs) Handles RegularTaigaPB.Click
        MainMenu.ClickSound()
        GameObject = New Game(HighPerfImage(My.Resources.Normal_taiga))
        GameObject.Show()
        Close()
    End Sub
    Public Sub WaterTaigaPB_Click(sender As Object, e As EventArgs) Handles WaterTaigaPB.Click
        MainMenu.ClickSound()
        GameObject = New Game(HighPerfImage(My.Resources.Blue_taiga))
        GameObject.Show()
        Close()
    End Sub
    Public Sub GothTaigaPB_Click(sender As Object, e As EventArgs) Handles GothTaigaPB.Click
        MainMenu.ClickSound()
        GameObject = New Game(HighPerfImage(My.Resources.Goth_taiga))
        GameObject.Show()
        Close()
    End Sub
    Private Sub CharacterPicker_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            MainMenu.Show()
            Close()
        End If
    End Sub
End Class