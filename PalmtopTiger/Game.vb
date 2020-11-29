Public Class Game
    Private BoolUp = False
    Private BoolDown = False
    Private BoolLeft = False
    Private BoolRight = False
    Private BoolShift = False
    Private BoolZ = False
    Protected Bullets = New List(Of Bullet)
    Protected BulletsDummy = New List(Of Bullet)
    Protected Enemies
    Protected EnemiesDummy = New List(Of Enemy)
    Protected UsedBomb As Bomb
    Protected Character As Rectangle = New Rectangle(560, 420, 40, 70)
    Protected Hitbox = New Rectangle(560 + 10, 420 + 40, 7, 7)
    Protected Lives = 4
    Protected Bombs = 3
    Protected Score = 0
    Private CharacterCooldown As Stopwatch = Stopwatch.StartNew()
    Protected GrazeCount = 0
    Protected KillCount = 0
    Protected BulletSize = New Size(20, 20)
    Protected Background As Image = HighPerfImage(My.Resources.GameBackground)
    Protected BulletImage As Image = HighPerfImage(My.Resources.Flower)
    Protected CharImage As Image
    Protected ParrotImage As Image = HighPerfImage(My.Resources.Parrot)
    Protected EggImage As Image = HighPerfImage(My.Resources.Egg)
    Protected DragoonImage As Image = HighPerfImage(My.Resources.Dragoon)
    Protected FireImage As Image = HighPerfImage(My.Resources.Fire)
    Protected TurtleImage As Image = HighPerfImage(My.Resources.Turtle)
    Protected BubbleImage As Image = HighPerfImage(My.Resources.Bubble)
    Protected PolvinhoImage As Image = HighPerfImage(My.Resources.Polvinho)
    Protected InkImage As Image = HighPerfImage(My.Resources.Droplet)
    Protected TigerImage As Image = HighPerfImage(My.Resources.Tiger)
    Protected WavesImage As Image = HighPerfImage(My.Resources.Waves)
    Protected ToriiGate As Image = HighPerfImage(My.Resources.torii)
    Protected BurntGate As Image = HighPerfImage(My.Resources.boo_boo_torii)
    Protected LifeImage As Image = HighPerfImage(My.Resources.White_star)
    Protected BombImage As Image = HighPerfImage(My.Resources.Pink_star)
    Protected ToriiSize = New Size(125, 100)
    Protected ToriiGate1 As Rectangle = New Rectangle(100, 250, ToriiSize.Width, ToriiSize.Height)
    Protected ToriiGate2 As Rectangle = New Rectangle(770, 250, ToriiSize.Width, ToriiSize.Height)
    Protected ToriiGate3 As Rectangle = New Rectangle(435, 100, ToriiSize.Width, ToriiSize.Height)
    Protected OpacityTickCount As Integer = 0
    Protected ChoosingCount As Integer = 0
    Private CurrentFrameRate As Integer
    Protected CurrentTime As Stopwatch = Stopwatch.StartNew()
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
    Protected Overloads Overrides Sub OnPaint(e As PaintEventArgs)
        Dim Backbuffer = New Rectangle(0, 0, Width, Height)
        Dim FramerateFont As Font = New Font("Helvetica", 12, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim ScoreboardFont As Font = New Font("Bauhaus 93", 30, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim myPen As New Pen(Color.White, 3)
        Dim g As Graphics = e.Graphics
        Score = CInt((GrazeCount \ 8) * ((Lives + Bombs) / 2) + KillCount * 100)
        g.CompositingMode = Drawing2D.CompositingMode.SourceOver
        g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        g.CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
        g.SmoothingMode = Drawing2D.SmoothingMode.None
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
        g.DrawImageUnscaled(Background, Backbuffer)
        If OpacityTickCount > 3000 AndAlso Not -1 Then
            g.DrawImage(ToriiGate, ToriiGate1)
            g.DrawImage(ToriiGate, ToriiGate2)
            g.DrawImage(BurntGate, ToriiGate3)
        ElseIf OpacityTickCount = -1 Then
        Else
            g.DrawImage(ChangeOpacity(ToriiGate, OpacityTickCount / 3000), ToriiGate1)
            g.DrawImage(ChangeOpacity(ToriiGate, OpacityTickCount / 3000), ToriiGate2)
            g.DrawImage(ChangeOpacity(BurntGate, OpacityTickCount / 3000), ToriiGate3)
        End If
        g.DrawImage(CharImage, Character)
        g.DrawImage(BulletImage, Hitbox)
        AdvanceFrameRate()
        g.DrawString(CurrentFrameRate & " FPS", FramerateFont, Brushes.Black, 0, 0)
        g.DrawString(Score, ScoreboardFont, Brushes.HotPink, 975, 125)
        g.DrawString(GrazeCount \ 4, ScoreboardFont, Brushes.HotPink, 1085, 393)
        g.DrawString(My.Settings.Highscore, ScoreboardFont, Brushes.HotPink, 960, 225)
        Select Case Lives
            Case 2
                g.DrawImage(LifeImage, 1115, 267)
            Case 3
                g.DrawImage(LifeImage, 1115, 267)
                g.DrawImage(LifeImage, 1150, 267)
            Case 4
                g.DrawImage(LifeImage, 1115, 267)
                g.DrawImage(LifeImage, 1150, 267)
                g.DrawImage(LifeImage, 1185, 267)
        End Select
        Select Case Bombs
            Case 1
                g.DrawImage(BombImage, 1115, 330)
            Case 2
                g.DrawImage(BombImage, 1115, 330)
                g.DrawImage(BombImage, 1150, 330)
            Case 3
                g.DrawImage(BombImage, 1115, 330)
                g.DrawImage(BombImage, 1150, 330)
                g.DrawImage(BombImage, 1185, 330)
        End Select
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
                        Case "Tiger"
                            g.DrawImage(TigerImage, New Rectangle(Enemy.Position(), Enemy.EnemySize))
                    End Select
                End If
            Next
        End If
        For Each Bullet In Bullets
            Select Case Bullet.Caller
                Case "Parrot"
                    g.DrawImage(EggImage, New Rectangle(Bullet.CurrentPos.X, Bullet.CurrentPos.Y, EggImage.Width, EggImage.Height))
                Case "Dragoon"
                    g.DrawImage(FireImage, New Rectangle(Bullet.CurrentPos.X, Bullet.CurrentPos.Y, FireImage.Width, FireImage.Height))
                Case "Polvinho"
                    g.DrawImage(InkImage, New Rectangle(Bullet.CurrentPos.X, Bullet.CurrentPos.Y, InkImage.Width, InkImage.Height))
                Case "Turtle"
                    g.DrawImage(BubbleImage, New Rectangle(Bullet.CurrentPos.X, Bullet.CurrentPos.Y, BubbleImage.Width, BubbleImage.Height))
                Case "Tiger"
                    g.DrawImage(WavesImage, New Rectangle(Bullet.CurrentPos.X, Bullet.CurrentPos.Y, WavesImage.Width, WavesImage.Height))
                Case ""
                    g.DrawImage(BulletImage, New Rectangle(Bullet.CurrentPos, BulletSize))
            End Select
        Next
        If UsedBomb IsNot Nothing Then
            g.DrawEllipse(myPen, UsedBomb.StartingPos.X - UsedBomb.Radius, UsedBomb.StartingPos.Y - UsedBomb.Radius, UsedBomb.Radius * 2, UsedBomb.Radius * 2)
        End If
    End Sub

    Private Sub AdvanceFrameRate()
        Static ptlu As Double
        Static callCount As Integer
        callCount += 1
        If (Environment.TickCount - ptlu) >= 1000 Then
            CurrentFrameRate = callCount
            callCount = 0
            ptlu = Environment.TickCount
        End If
    End Sub

    Sub Game_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Lives = -1
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
            If Bombs > 0 Then
                UsedBomb = New Bomb(New Point(Hitbox.X, Hitbox.Y), 200)
                BombLingerTime.Enabled = True
                Bombs -= 1
            End If
        End If
    End Sub

    Sub Game_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
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
        Dim BulletHitbox As Rectangle
        If Not Character.IntersectsWith(New Rectangle(50, 60, 1280, 0)) Then
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
        If Not Character.IntersectsWith(New Rectangle(50, 663, 1280, 0)) Then
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
        If Not Character.IntersectsWith(New Rectangle(50, 0, 0, 720)) Then
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
        If Not Character.IntersectsWith(New Rectangle(930, 60, 0, 720)) Then
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
        For Each Bullet In Bullets
            BulletResult = Bullet.Position()
            If UsedBomb IsNot Nothing Then
                If UsedBomb.IsInRange(Bullet) And Not Bullet.Caller = "" Then
                    BulletsDummy.Add(Bullet)
                End If
            End If
            BulletHitbox = New Rectangle(BulletResult, BulletSize)
            If Bullet.CurrentPos.Y < 60 OrElse Bullet.CurrentPos.Y > 630 OrElse Bullet.CurrentPos.X > 930 OrElse Bullet.CurrentPos.X < 50 Then
                BulletsDummy.Add(Bullet)
            Else Invalidate(New Rectangle(New Point(BulletResult.X - 10, BulletResult.Y - 10), New Size(BulletSize.Width * 2, BulletSize.Height * 2.5)))
            End If
            If Bullet.Caller <> "" AndAlso BulletHitbox.IntersectsWith(Hitbox) AndAlso CharacterCooldown.ElapsedMilliseconds > 3000 Then
                CharacterCooldown = Stopwatch.StartNew()
                Lives -= 1
            ElseIf BulletHitbox.IntersectsWith(Character) And Bullet.Caller <> "" Then
                GrazeCount += 1
            End If
        Next
        For Each Bullet In BulletsDummy
            Bullets.Remove(Bullet)
        Next
        BulletsDummy = New List(Of Bullet)
        If Enemies IsNot Nothing Then
            If Enemies.Count = 0 AndAlso ChoosingCount <> 666 Then
                Close()
                Winning.Show()
            End If
            For Each Enemy In Enemies
                EnemyResult = Enemy.Position()
                If Enemy.Health <= 0 Then
                    KillCount += 1
                    EnemiesDummy.Add(Enemy)
                Else
                    If TypeName(EnemyResult) = "Point" And EnemyResult <> New Point(1280, 720) Then
                        Invalidate(New Rectangle(Enemy.CurrentPos - New Point(10, 10), New Size(Enemy.EnemySize.Width * 2.3, Enemy.EnemySize.Height * 2)))
                        If Enemy.Cooldown(Enemy.ShootingCD) = False Then
                            Bullets.Add(Enemy.Shooting(Enemy.Aiming(New Point(Hitbox.X, Hitbox.Y))))
                        End If
                        For Each Bullet In Bullets
                            If Bullet.Caller = "" Then
                                If New Rectangle(EnemyResult, Enemy.EnemySize).Contains(Bullet.CurrentPos) Then
                                    Enemy.Health -= 10
                                    BulletsDummy.Add(Bullet)
                                End If
                            End If
                        Next
                    ElseIf EnemyResult = New Point(1280, 720) Then
                    Else
                        EnemiesDummy.Add(Enemy)
                    End If
                End If
            Next
            For Each Enemy In EnemiesDummy
                Enemies.Remove(Enemy)
                Invalidate(New Rectangle(Enemy.CurrentPos - New Point(10, 10), New Size(Enemy.EnemySize.Width * 2.3, Enemy.EnemySize.Height * 2)))
            Next
            EnemiesDummy = New List(Of Enemy)
        End If
    End Sub

    Protected Sub Shooting(sender As Object, e As EventArgs) Handles ShootingCD.Tick
        If BoolZ Then
            Bullets.Add(New Bullet(New Point(Character.Location.X + 30, Character.Location.Y + 35), 500, -Math.PI / 2, 0, 0))
        End If
    End Sub

    Private Sub GraphicsAC_Tick(sender As Object, e As EventArgs) Handles GraphicsAC.Tick
        Invalidate()
        If Lives <= 0 Then
            If My.Settings.Highscore < Score Then
                My.Settings.Highscore = Score
            End If
            Close()
            GameOver.Show()
            mciSendString("stop Level1")
            mciSendString("stop Level2")
            If My.Settings.Music Then
                mciSendString("play Theme repeat")
            End If
        End If
    End Sub

    Private Sub BombLingerTime_Tick(sender As Object, e As EventArgs) Handles BombLingerTime.Tick
        UsedBomb = Nothing
        BombLingerTime.Enabled = False
    End Sub

    Private Sub LevelSelection_Tick(sender As Object, e As EventArgs) Handles LevelSelection.Tick
        Dim Theme1 = MainMenu.AppPath & "/temp/level1.mp3"
        Dim Theme2 = MainMenu.AppPath & "/temp/level2.mp3"
        Dim ThemeR = MainMenu.AppPath & "/temp/randomlevel.mp3"
        OpacityTickCount += 30
        If Character.IntersectsWith(ToriiGate1) Then
            ChoosingCount = 1
        ElseIf Character.IntersectsWith(ToriiGate2) Then
            ChoosingCount = -1
        ElseIf Character.IntersectsWith(ToriiGate3) Then
            ChoosingCount = 666
        End If
        If ChoosingCount = 1 Then
            OpacityTickCount = -1
            CurrentTime.Stop()
            LevelSelection.Dispose()
            Enemies = Level1(My.Settings.DifficultyMultiplier)
            If My.Settings.Music Then
                mciSendString("Open " & Theme1 & " alias Level1")
                mciSendString("setaudio Level1 volume to " & My.Settings.MusicVol)
                mciSendString("stop Theme")
                mciSendString("play Level1 repeat")
            End If
        ElseIf ChoosingCount = -1 Then
            OpacityTickCount = -1
            CurrentTime.Stop()
            LevelSelection.Dispose()
            Enemies = Level2(My.Settings.DifficultyMultiplier)
            If My.Settings.Music Then
                mciSendString("Open " & Theme2 & " alias Level2")
                mciSendString("setaudio Level2 volume to " & My.Settings.MusicVol)
                mciSendString("stop Theme")
                mciSendString("play Level2 repeat")
            End If
        ElseIf ChoosingCount = 666 Then
            OpacityTickCount = -1
            LevelSelection.Dispose()
            LevelRTimer.Enabled = True
            Enemies = New List(Of Enemy)
            If My.Settings.Music Then
                mciSendString("Open " & ThemeR & " alias LevelR")
                mciSendString("setaudio LevelR volume to " & My.Settings.MusicVol)
                mciSendString("stop Theme")
                mciSendString("play LevelR repeat")
            End If
        End If
    End Sub

    Private Sub LevelRTimer_Tick(sender As Object, e As EventArgs) Handles LevelRTimer.Tick
        Enemies.Add(LevelR((CurrentTime.ElapsedMilliseconds / (3 * 60 * 1000)) * My.Settings.DifficultyMultiplier))
    End Sub
End Class