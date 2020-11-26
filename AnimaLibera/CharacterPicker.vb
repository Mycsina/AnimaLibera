Public Class CharacterPicker
    Public GameObject
    Private Sub ExitPB_Click(sender As Object, e As EventArgs) Handles ExitPB.Click
        Close()
        MainMenu.Show()
    End Sub
    Public Sub ElfTaigaPB_Click(sender As Object, e As EventArgs) Handles ElfTaigaPB.Click
        GameObject = New Game(HighPerfImage(My.Resources.Green_taiga))
        Close()
        GameObject.Show()
    End Sub
    Public Sub RegularTaigaPB_Click(sender As Object, e As EventArgs) Handles RegularTaigaPB.Click
        GameObject = New Game(HighPerfImage(My.Resources.Normal_taiga))
        Close()
        GameObject.Show()
    End Sub
    Public Sub WaterTaigaPB_Click(sender As Object, e As EventArgs) Handles WaterTaigaPB.Click
        GameObject = New Game(HighPerfImage(My.Resources.Blue_taiga))
        Close()
        GameObject.Show()
    End Sub
    Public Sub GothTaigaPB_Click(sender As Object, e As EventArgs) Handles GothTaigaPB.Click
        GameObject = New Game(HighPerfImage(My.Resources.Goth_taiga))
        Close()
        GameObject.Show()
    End Sub
End Class