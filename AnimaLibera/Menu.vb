Public Class Menu
    Private Sub Start_Click(sender As Object, e As EventArgs) Handles Start.Click
        Hide()
        Game.Show()
    End Sub

    Private Sub Options_Click(sender As Object, e As EventArgs) Handles Options.Click
        Hide()
        Options.Show()
    End Sub
End Class
