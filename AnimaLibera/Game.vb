Public Class Game
    Public Sub New(CharImage)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.CharImage = CharImage
    End Sub
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            Return cp
        End Get
    End Property
    Private BoolUp = False
    Private BoolDown = False
    Private BoolLeft = False
    Private BoolRight = False
    Private BoolShift = False
    Private BoolZ = False
    Protected Bullets = New List(Of Bullet)
    Protected BulletsDummy = New List(Of Bullet)
    Protected Enemies = New List(Of Enemy)
    Protected EnemiesDummy = New List(Of Enemy)
    Protected UsedBomb As Bomb
    Protected Character As Rectangle = New Rectangle(560, 420, 50, 90)
    Protected Hitbox = New Rectangle(560 + 16, 420 + 53, 10, 10)
    Protected Lives = 3
    Private CharacterCooldown As Stopwatch = Stopwatch.StartNew()
    Protected BulletSize = New Size(20, 20)
    Protected EnemySize = New Size(50, 50)
    Protected Background As Image = HighPerfImage(My.Resources.LowResBackground)
    Protected BulletImage As Image = HighPerfImage(My.Resources.Flower)
    Protected CharImage As Image
    Protected ParrotImage As Image = HighPerfImage(My.Resources.Parrot)
    Protected EggImage As Image = HighPerfImage(My.Resources.Egg)
    Protected DragoonImage As Image = HighPerfImage(My.Resources.Dragoon)
    Protected FireImage As Image = HighPerfImage(My.Resources.Fire)
    Protected TurtleImage As Image = HighPerfImage(My.Resources.Turtle)
    Protected BubbleImage As Image = HighPerfImage(My.Resources.Bubble)
    Protected PolvinhoImage As Image = HighPerfImage(My.Resources.Polvinho)
    Protected TigerImage As Image = HighPerfImage(My.Resources.Tiger)
    Protected OpacityTickCount As Integer = 0
    Private currentFrameRate As Integer
    Protected Overloads Overrides Sub OnPaint(e As PaintEventArgs)
        Dim Backbuffer = New Rectangle(0, 0, Width, Height)
        Dim framerateFont As Font = New Font("Helvetica", 12, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim myPen As New Pen(Color.White, 3)
        Dim g As Graphics = e.Graphics
        g.CompositingMode = Drawing2D.CompositingMode.SourceOver
        g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        g.CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
        g.SmoothingMode = Drawing2D.SmoothingMode.None
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
        g.DrawImage(Background, Backbuffer)
        If OpacityTickCount > 3000 AndAlso Not -1 Then
            g.DrawImage(My.Resources.torii, 100, 100)
            g.DrawImage(My.Resources.torii, 700, 100)
        ElseIf OpacityTickCount = -1 Then
        Else
            g.DrawImage(ChangeOpacity(My.Resources.torii, OpacityTickCount / 3000), 100, 100)
            g.DrawImage(ChangeOpacity(My.Resources.torii, OpacityTickCount / 3000), 700, 100)
        End If
        g.DrawImage(CharImage, Character)
        g.DrawImage(BulletImage, Hitbox)
        AdvanceFrameRate()
        g.DrawString(currentFrameRate & " FPS", framerateFont, Brushes.Black, 0, 0)
        If Enemies IsNot Nothing Then
            For Each Enemy In Enemies
                If TypeName(Enemy.Position()) = "Point" Then
                    Select Case TypeName(Enemy)
                        Case "Parrot"
                            g.DrawImage(ParrotImage, New Rectangle(Enemy.Position(), Enemy.EnemySize))
                        Case "Dragoon"
                            g.DrawImage(DragoonImage, New Rectangle(Enemy.Position(), Enemy.EnemySize))
                        Case "Polvinho"
                            g.DrawImage(PolvinhoImage, New Rectangle(Enemy.Position(), Enemy.EnemySize))
                        Case "Turtle"
                            g.DrawImage(TurtleImage, New Rectangle(Enemy.Position(), Enemy.EnemySize))
                    End Select
                End If
            Next
        End If
        If Bullets IsNot Nothing Then
            For Each Bullet In Bullets
                Select Case Bullet.Caller
                    Case "Parrot"
                        g.DrawImage(EggImage, New Rectangle(Bullet.CurrentPos.X, Bullet.CurrentPos.Y, EggImage.Width, EggImage.Height))
                    Case "Dragoon"
                        g.DrawImage(FireImage, New Rectangle(Bullet.CurrentPos.X, Bullet.CurrentPos.Y, FireImage.Width, FireImage.Height))
                    Case "Polvinho"
                        g.DrawImage(FireImage, New Rectangle(Bullet.CurrentPos.X, Bullet.CurrentPos.Y, FireImage.Width, FireImage.Height))
                    Case "Turtle"
                        g.DrawImage(BubbleImage, New Rectangle(Bullet.CurrentPos.X, Bullet.CurrentPos.Y, BubbleImage.Width, BubbleImage.Height))
                    Case ""
                        g.DrawImage(BulletImage, New Rectangle(Bullet.CurrentPos, BulletSize))
                End Select
            Next
        End If
        If UsedBomb IsNot Nothing Then
            g.DrawEllipse(myPen, UsedBomb.StartingPos.X - UsedBomb.Radius, UsedBomb.StartingPos.Y - UsedBomb.Radius, UsedBomb.Radius * 2, UsedBomb.Radius * 2)
        End If
    End Sub
    Private Sub AdvanceFrameRate()
        Static ptlu As Double
        Static callCount As Integer
        callCount += 1
        ' Change 1000 if an alternate time value is desired.
        If (Environment.TickCount - ptlu) >= 1000 Then

            currentFrameRate = callCount
            ' Reset the callCount, AFTER updating the value.
            callCount = 0
            ' Reset the timeUpdated
            ptlu = Environment.TickCount
        Else
        End If
    End Sub
    Sub Game_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
            MainMenu.Show()
        End If
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
        If e.KeyCode = Keys.X Then
            UsedBomb = New Bomb(New Point(Hitbox.X, Hitbox.Y), 200)
            BombLingerTime.Enabled = True
        End If
    End Sub
    Sub Game_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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
        Dim CharacterInvalidate = New Rectangle(Character.X - 5, Character.Y - 8, Character.Size.Width + 10, Character.Size.Height + 16)
        Dim EnemyResult
        Dim BulletResult As Point
        If Not Character.IntersectsWith(New Rectangle(0, 0, Width, 0)) Then
            If BoolUp Then
                If BoolShift Then
                    Character.Y -= 5
                    Hitbox.Y -= 5
                    Invalidate(CharacterInvalidate)
                Else
                    Character.Y -= 8
                    Hitbox.Y -= 8
                    Invalidate(CharacterInvalidate)
                End If
            End If
        End If
        If Not Character.IntersectsWith(New Rectangle(0, Height, Width, 0)) Then
            If BoolDown Then
                If BoolShift Then
                    Character.Y += 5
                    Hitbox.Y += 5
                    Invalidate(CharacterInvalidate)
                Else
                    Character.Y += 8
                    Hitbox.Y += 8
                    Invalidate(CharacterInvalidate)
                End If
            End If
        End If
        If Not Character.IntersectsWith(New Rectangle(0, 0, 0, Height)) Then
            If BoolLeft Then
                If BoolShift Then
                    Character.X -= 5
                    Hitbox.X -= 5
                    Invalidate(CharacterInvalidate)
                Else
                    Character.X -= 8
                    Hitbox.X -= 8
                    Invalidate(CharacterInvalidate)
                End If
            End If
        End If
        If Not Character.IntersectsWith(New Rectangle(Width, 0, 0, Height)) Then
            If BoolRight Then
                If BoolShift Then
                    Character.X += 5
                    Hitbox.X += 5
                    Invalidate(CharacterInvalidate)
                Else
                    Character.X += 8
                    Hitbox.X += 8
                    Invalidate(CharacterInvalidate)
                End If
            End If
        End If
        If Enemies IsNot Nothing Then
            For Each Enemy In Enemies
                EnemyResult = Enemy.Position()
                If TypeName(EnemyResult) = "Point" Then
                    Invalidate(New Rectangle(Enemy.CurrentPos - New Point(10, 10), New Size(EnemySize.Width * 2.3, Size.Height * 2)))
                    If Enemy.Cooldown(Enemy.ShootingCD) = False Then
                        Bullets.Add(Enemy.Shooting(Enemy.Aiming(New Point(Hitbox.X, Hitbox.Y))))
                    End If
                Else
                    EnemiesDummy.Add(Enemy)
                End If
            Next
            If EnemiesDummy IsNot Nothing Then
                For Each Enemy In EnemiesDummy
                    Enemies.Remove(Enemy)
                    Invalidate(New Rectangle(Enemy.CurrentPos - New Point(10, 10), New Size(EnemySize.Width * 2.3, Size.Height * 2)))
                Next
                EnemiesDummy = New List(Of Enemy)
            End If
        End If
        If Bullets IsNot Nothing Then
            For Each Bullet In Bullets
                BulletResult = Bullet.Position()
                If UsedBomb IsNot Nothing Then
                    If UsedBomb.IsInRange(Bullet) Then
                        BulletsDummy.Add(Bullet)
                    End If
                End If
                If Bullet.CurrentPos.Y < -5 OrElse Bullet.CurrentPos.Y > Size.Height OrElse Bullet.CurrentPos.X > Size.Width OrElse Bullet.CurrentPos.X < -5 Then
                    BulletsDummy.Add(Bullet)
                Else Invalidate(New Rectangle(New Point(BulletResult.X - 10, BulletResult.Y - 10), New Size(BulletSize.Width * 2, BulletSize.Height * 2.5)))
                End If
                If New Rectangle(BulletResult, BulletSize).IntersectsWith(Hitbox) AndAlso CharacterCooldown.ElapsedMilliseconds > 3000 Then
                    CharacterCooldown = Stopwatch.StartNew()
                    Lives -= 1
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
        Dim inputs = {New Point(50, 50), New Point(450, 450), New Point(100, 100)}
        Dim traj = New List(Of Point)(inputs)
        If BoolZ And Not BoolShift Then
            Bullets.Add(New Bullet(New Point(Character.Location.X + 45, Character.Location.Y + 35), 500, -Math.PI / 2, 0, -3, 10))
        End If
        If BoolShift And BoolUp Then
            Enemies.Add(New Parrot(New Point(50, 50), traj, 10, 0))
        End If
        If BoolShift And BoolDown Then
            Enemies.Add(New Dragoon(New Point(50, 50), traj, 10, 0))
        End If
        If BoolShift And BoolLeft Then
            Enemies.Add(New Polvinho(New Point(50, 50), traj, 10, 0))
        End If
        If BoolShift And BoolRight Then
            Enemies.Add(New Turtle(New Point(50, 50), traj, 10, 0))
        End If
    End Sub
    Private Sub GraphicsAC_Tick(sender As Object, e As EventArgs) Handles GraphicsAC.Tick
        Invalidate()
    End Sub
    Private Sub BombLingerTime_Tick(sender As Object, e As EventArgs) Handles BombLingerTime.Tick
        UsedBomb = Nothing
        BombLingerTime.Enabled = False
    End Sub
    Private Sub LevelSelection_Tick(sender As Object, e As EventArgs) Handles LevelSelection.Tick
        OpacityTickCount += 30
    End Sub
End Class