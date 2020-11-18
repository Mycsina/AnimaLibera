Public Class Game
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            Return cp
        End Get
    End Property
    Protected bool_up As Boolean = False
    Protected bool_down As Boolean = False
    Protected bool_left As Boolean = False
    Protected bool_right As Boolean = False
    Protected bool_shift As Boolean = False
    Protected bool_z As Boolean = False
    Protected Position = New Point(560, 420)
    Protected Bullets = New List(Of Bullet)
    Protected Bullets_Dummy = New List(Of Bullet)
    Protected Character = New Rectangle(560, 420, 50, 50)
    Protected Overloads Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        Dim curImage As Image = Image.FromFile("C:\Users\andré\Downloads\AnimaLibera\AnimaLibera\Resources\Th06ReimuBackSprite.png")
        g.DrawImage(curImage, Character)
    End Sub
    Sub Form2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.W Then
            bool_up = True
        End If
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.S Then
            bool_down = True
        End If
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.A Then
            bool_left = True
        End If
        If e.KeyCode = Keys.Right Or e.KeyCode = Keys.D Then
            bool_right = True
        End If
        If e.KeyCode = Keys.ShiftKey Then
            bool_shift = True
        End If
        If e.KeyCode = Keys.Z Then
            bool_z = True
        End If
    End Sub
    Sub Form2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.W Then
            bool_up = False
        End If
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.S Then
            bool_down = False
        End If
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.A Then
            bool_left = False
        End If
        If e.KeyCode = Keys.Right Or e.KeyCode = Keys.D Then
            bool_right = False
        End If
        If e.KeyCode = Keys.ShiftKey Then
            bool_shift = False
        End If
        If e.KeyCode = Keys.Z Then
            bool_z = False
        End If
    End Sub
    Protected Sub RunningTime_Tick(sender As Object, e As EventArgs) Handles RunningTime.Tick
        If bool_up Then
            If bool_shift Then
                Position = New Point(invis.Location.X, invis.Location.Y - 3)
                Character.Y -= 3
                Invalidate()
            Else
                Position = New Point(invis.Location.X, invis.Location.Y - 5)
                Character.Y -= 5
                Invalidate()
            End If
        End If
        If bool_down Then
            If bool_shift Then
                Position = New Point(Position.X, Position.Y + 3)
                Character.Y += 3
                Invalidate()
            Else
                Position = New Point(Position.X, Position.Y + 5)
                Character.Y += 5
                Invalidate()
            End If
        End If
        If bool_left Then
            If bool_shift Then
                Position = New Point(Position.X - 3, Position.Y)
                Character.X -= 3
                Invalidate()
            Else
                Position = New Point(Position.X - 5, Position.Y)
                Character.X -= 5
                Invalidate()
            End If
        End If
        If bool_right Then
            If bool_shift Then
                Position = New Point(Position.X + 3, Position.Y)
                Character.X += 3
                Invalidate()
            Else
                Position = New Point(Position.X + 5, Position.Y)
                Character.X += 5
                Invalidate()
            End If
        End If
        invis.Location = Position
        If Bullets IsNot Nothing Then
            For Each bullet In Bullets
                If bullet.Location.Y < -5 Or bullet.Location.Y > Size.Height Or bullet.Location.X > Size.Width Or bullet.Location.X < -5 Then
                    Bullets_Dummy.Add(bullet)
                Else
                    bullet.Location = bullet.Position()
                End If
            Next
            If Bullets_Dummy IsNot Nothing Then
                For Each bullet In Bullets_Dummy
                    Bullets.Remove(bullet)
                    Controls.Remove(bullet)
                Next
                Bullets_Dummy = New List(Of Bullet)
            End If
        End If
    End Sub

    Protected Sub Shooting(sender As Object, e As EventArgs) Handles ShootingCD.Tick
        If bool_z Then
            Bullets.Add(New Bullet(Character.Location, Color.Black, 10, 0.1, -Math.PI, 0.0000000001, -3))
            Controls.Add(Bullets(Bullets.count - 1))
        End If
    End Sub
End Class