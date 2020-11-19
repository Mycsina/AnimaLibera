Public Class Game
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            Return cp
        End Get
    End Property
    Protected BoolUp As Boolean = False
    Protected BoolDown As Boolean = False
    Protected BoolLeft As Boolean = False
    Protected BoolRight As Boolean = False
    Protected BoolShift As Boolean = False
    Protected BoolZ As Boolean = False
    Protected Position = New Point(560, 420)
    Protected Bullets = New List(Of Bullet)
    Protected BulletsDummy = New List(Of Bullet)
    Protected Character = New Rectangle(560, 420, 60, 90)
    Protected Overloads Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim Backbuffer = New Rectangle(0, 0, Width, Height)
        Dim BulletSize As Size = New Size(20, 20)
        Dim g As Graphics = e.Graphics
        Dim Background As Image = My.Resources.ResourceManager.GetObject("LowResBackground")
        Dim CharImage As Image = My.Resources.ResourceManager.GetObject("RegularTaiga")
        Dim BulletImage As Image = My.Resources.ResourceManager.GetObject("Flower")
        g.DrawImage(Background, Backbuffer)
        g.DrawImage(CharImage, Character)
        If Bullets IsNot Nothing Then
            For Each bullet In Bullets
                g.DrawImage(BulletImage, New Rectangle(bullet.Position(), BulletSize))
            Next
        End If
    End Sub
    Sub Form2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.W Then
            BoolUp = True
        End If
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.S Then
            BoolDown = True
        End If
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.A Then
            BoolLeft = True
        End If
        If e.KeyCode = Keys.Right Or e.KeyCode = Keys.D Then
            BoolRight = True
        End If
        If e.KeyCode = Keys.ShiftKey Then
            BoolShift = True
        End If
        If e.KeyCode = Keys.Z Then
            BoolZ = True
        End If
    End Sub
    Sub Form2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.W Then
            BoolUp = False
        End If
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.S Then
            BoolDown = False
        End If
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.A Then
            BoolLeft = False
        End If
        If e.KeyCode = Keys.Right Or e.KeyCode = Keys.D Then
            BoolRight = False
        End If
        If e.KeyCode = Keys.ShiftKey Then
            BoolShift = False
        End If
        If e.KeyCode = Keys.Z Then
            BoolZ = False
        End If
    End Sub
    Protected Sub RunningTime_Tick(sender As Object, e As EventArgs) Handles RunningTime.Tick
        If Not Character.IntersectsWith(New Rectangle(0, 0, Width, 0)) Then
            If BoolUp Then
                If BoolShift Then
                    Position = New Point(Character.Location.X, Character.Location.Y - 5)
                    Character.Y -= 5
                    Invalidate()
                Else
                    Position = New Point(Character.Location.X, Character.Location.Y - 8)
                    Character.Y -= 8
                    Invalidate()
                End If
            End If
        End If
        If Not Character.IntersectsWith(New Rectangle(0, Height, Width, 0)) Then
            If BoolDown Then
                If BoolShift Then
                    Position = New Point(Position.X, Position.Y + 5)
                    Character.Y += 5
                    Invalidate()
                Else
                    Position = New Point(Position.X, Position.Y + 8)
                    Character.Y += 8
                    Invalidate()
                End If
            End If
        End If
        If Not Character.IntersectsWith(New Rectangle(0, 0, 0, Height)) Then
            If BoolLeft Then
                If BoolShift Then
                    Position = New Point(Position.X - 5, Position.Y)
                    Character.X -= 5
                    Invalidate()
                Else
                    Position = New Point(Position.X - 8, Position.Y)
                    Character.X -= 8
                    Invalidate()
                End If
            End If
        End If
        If Not Character.IntersectsWith(New Rectangle(Width, 0, 0, Height)) Then
            If BoolRight Then
                If BoolShift Then
                    Position = New Point(Position.X + 5, Position.Y)
                    Character.X += 5
                    Invalidate()
                Else
                    Position = New Point(Position.X + 8, Position.Y)
                    Character.X += 8
                    Invalidate()
                End If
            End If
        End If
        If Bullets IsNot Nothing Then
            For Each bullet In Bullets
                If bullet.StartingPos.Y < -5 Or bullet.StartingPos.Y > Size.Height Or bullet.StartingPos.X > Size.Width Or bullet.StartingPos.X < -5 Then
                    BulletsDummy.Add(bullet)
                Else
                    Invalidate()
                End If
            Next
            If BulletsDummy IsNot Nothing Then
                For Each bullet In BulletsDummy
                    Bullets.Remove(bullet)
                Next
                BulletsDummy = New List(Of Bullet)
            End If
        End If
    End Sub
    Protected Sub Shooting(sender As Object, e As EventArgs) Handles ShootingCD.Tick
        If BoolZ Then
            Bullets.Add(New Bullet(New Point(Character.Location.X + 45, Character.Location.Y + 35), 10, 0.1, -Math.PI, 0.001, -3))
        End If
    End Sub
End Class