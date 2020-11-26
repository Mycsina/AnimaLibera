Public Class GameOver
    Private Sub ExitPB_Click(sender As Object, e As EventArgs) Handles ExitPB.Click
        MainMenu.ExitPB_Click(sender, e)
    End Sub
    Private Sub MenuPB_Click(sender As Object, e As EventArgs) Handles MenuPB.Click
        Close()
        MainMenu.Show()
    End Sub
End Class