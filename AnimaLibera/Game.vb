Public Class Game
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            Return cp
        End Get
    End Property
    Protected BoolUp = False
    Protected BoolDown = False
    Protected BoolLeft = False
    Protected BoolRight = False
    Protected BoolShift = False
    Protected BoolZ = False
    Protected Bullets = New List(Of Bullet)
    Protected BulletsDummy = New List(Of Bullet)
    Protected Enemies = New List(Of Enemy)
    Protected EnemiesDummy = New List(Of Enemy)
    Protected Character = New Rectangle(560, 420, 60, 90)
    Protected Overloads Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim Backbuffer = New Rectangle(0, 0, Width, Height)
        Dim BulletSize = New Size(20, 20)
        Dim EnemySize = New Size(20, 20)
        Dim g As Graphics = e.Graphics
        Dim Background As Image = My.Resources.LowResBackground
        Dim CharImage As Image = My.Resources.RegularTaiga
        Dim BulletImage As Image = My.Resources.Flower
        Dim EnemyImage As Image = My.Resources.Reimu
        g.DrawImage(Background, Backbuffer)
        g.DrawImage(CharImage, Character)
        If Enemies IsNot Nothing Then
            For Each Enemy In Enemies
                If TypeName(Enemy.Position()) = "Point" Then
                    g.DrawImage(EnemyImage, New Rectangle(Enemy.Position(), EnemySize))
                End If
            Next
        End If
        If Bullets IsNot Nothing Then
            For Each Bullet In Bullets
                g.DrawImage(BulletImage, New Rectangle(Bullet.Position(), BulletSize))
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
                    Character.Y -= 5
                    Invalidate()
                Else
                    Character.Y -= 8
                    Invalidate()
                End If
            End If
        End If
        If Not Character.IntersectsWith(New Rectangle(0, Height, Width, 0)) Then
            If BoolDown Then
                If BoolShift Then
                    Character.Y += 5
                    Invalidate()
                Else
                    Character.Y += 8
                    Invalidate()
                End If
            End If
        End If
        If Not Character.IntersectsWith(New Rectangle(0, 0, 0, Height)) Then
            If BoolLeft Then
                If BoolShift Then
                    Character.X -= 5
                    Invalidate()
                Else
                    Character.X -= 8
                    Invalidate()
                End If
            End If
        End If
        If Not Character.IntersectsWith(New Rectangle(Width, 0, 0, Height)) Then
            If BoolRight Then
                If BoolShift Then
                    Character.X += 5
                    Invalidate()
                Else
                    Character.X += 8
                    Invalidate()
                End If
            End If
        End If
        If Enemies IsNot Nothing Then
            For Each Enemy In Enemies
                Enemy.Position()
                If TypeName(Enemy.Position()) = "Point" Then
                    Invalidate()
                Else
                    EnemiesDummy.Add(Enemy)
                End If
            Next
            If EnemiesDummy IsNot Nothing Then
                For Each Enemy In EnemiesDummy
                    Enemies.Remove(Enemy)
                Next
                EnemiesDummy = New List(Of Enemy)
            End If
        End If
        If Bullets IsNot Nothing Then
            For Each Bullet In Bullets
                Bullet.Position()
                If Bullet.CurrentPos.Y < -5 OrElse Bullet.CurrentPos.Y > Size.Height OrElse Bullet.CurrentPos.X > Size.Width OrElse Bullet.CurrentPos.X < -5 Then
                    BulletsDummy.Add(Bullet)
                Else
                    Invalidate()
                End If
            Next
            If BulletsDummy IsNot Nothing Then
                For Each Bullet In BulletsDummy
                    Bullets.Remove(Bullet)
                Next
                BulletsDummy = New List(Of Bullet)
            End If
        End If
    End Sub
    Protected Sub Shooting(sender As Object, e As EventArgs) Handles ShootingCD.Tick
        Dim inputs = {New Point(50, 50), New Point(450, 450)}
        Dim traj = New List(Of Point)(inputs)
        If BoolZ Then
            Bullets.Add(New Bullet(New Point(Character.Location.X + 45, Character.Location.Y + 35), 10, 1, Math.PI, 0, -3))
        End If
        If BoolShift And BoolZ Then
            Enemies.Add(New Enemy(New Point(50, 50), 50, traj, 30, 0, New Bullet(New Point(Character.Location.X + 45, Character.Location.Y + 35), 10, 0.1, -Math.PI, 0.001, -3), 0))
        End If
    End Sub
End Class