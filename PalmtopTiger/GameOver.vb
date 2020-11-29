Public Class GameOver
    Private Sub ExitPB_Click(sender As Object, e As EventArgs) Handles ExitPB.Click
        MainMenu.ExitPB_Click(sender, e)
    End Sub

    Private Sub MenuPB_Click(sender As Object, e As EventArgs) Handles MenuPB.Click
        MainMenu.ClickSound()
        MainMenu.Show()
        Close()
    End Sub

    Private Sub GameOver_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            MainMenu.ExitPB_Click(sender, e)
        End If
    End Sub

    Private Sub GameOver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mciSendString("close Level1")
        mciSendString("close Level2")
        mciSendString("close LevelR")
        mciSendString("play Theme repeat")
    End Sub
End Class