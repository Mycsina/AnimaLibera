Public Class Bullet
    Public Caller As String
    Private StartingPos As Point
    Private Velocity As Single
    Private VelAngle As Single
    Protected Accel As Single
    Protected AccelAngle As Single
    Public CurrentPos As Point
    Private ReadOnly ElapsedTime As Stopwatch

    Public Sub New(StartingPos As Point, Velocity As Single, VelAngle As Single, Accel As Single, AccelAngle As Single, Optional Caller As String = "")
        Me.StartingPos = StartingPos
        Me.Velocity = Velocity
        Me.VelAngle = VelAngle
        Me.Accel = Accel
        Me.AccelAngle = AccelAngle
        ElapsedTime = Stopwatch.StartNew()
        Me.Caller = Caller
    End Sub

    Public Function Position()
        Dim X_Distance As Integer
        Dim Y_Distance As Integer
        Dim TimeElapsed As Single
        TimeElapsed = ElapsedTime.Elapsed.TotalMilliseconds / 1000
        X_Distance = (Velocity * Math.Cos(VelAngle) * TimeElapsed) + 1 / 2 * Accel * Math.Cos(AccelAngle) * TimeElapsed ^ 2
        Y_Distance = (Velocity * Math.Sin(VelAngle) * TimeElapsed) + 1 / 2 * Accel * Math.Sin(AccelAngle) * TimeElapsed ^ 2
        CurrentPos = New Point(StartingPos.X + X_Distance, StartingPos.Y + Y_Distance)
        Return CurrentPos
    End Function
End Class


Public Class Enemy
    Protected Modifier As Integer
    Protected StartingPos As Point
    Public Health As Single
    Protected ReadOnly Trajectory As List(Of Point)
    Protected VectorList = New List(Of Vector)
    Protected TimeOfTravel As Single
    Protected TimeBeforeEntry As Single
    Private ReadOnly ElapsedTime As Stopwatch
    Public CurrentPos As Point
    Private CooldownTimer As Stopwatch
    Public EnemySize As Size

    Public Sub New(StartingPos As Point, Trajectory As List(Of Point), TimeOfTravel As Single, Optional TimeBeforeEntry As Single = 0, Optional Health As Single = 100, Optional Modifier As Integer = 1)
        Me.Health = Health
        Me.StartingPos = StartingPos
        For i = 0 To Trajectory.Count - 2
            VectorList.Add(New Vector(Trajectory(i), Trajectory(i + 1)))
        Next
        Me.TimeOfTravel = TimeOfTravel
        Me.TimeBeforeEntry = TimeBeforeEntry * 1000
        ElapsedTime = Stopwatch.StartNew()
    End Sub

    Public Function Position()
        Dim TimeInterval As Single
        Dim TimePerVector = TimeOfTravel * 1000 / VectorList.Count()
        Dim DisposableList = New List(Of Point)
        Dim X_Distance As Integer
        Dim Y_Distance As Integer
        Dim LastPos As Point
        TimeInterval = ElapsedTime.Elapsed.TotalMilliseconds
        If TimeBeforeEntry < TimeInterval Then
            TimeInterval -= TimeBeforeEntry
            For i = 0 To VectorList.Count - 1
                If i = 0 Then
                    DisposableList.Add(New Point(StartingPos.X + VectorList(0).Equation.X, StartingPos.Y + VectorList(0).Equation.Y))
                Else
                    DisposableList.Add(New Point(DisposableList.Last.X + VectorList(i).Equation.X, DisposableList.Last.Y + VectorList(i).Equation.Y))
                End If
            Next
            For i = 0 To VectorList.Count - 1
                VectorList(i).Time(TimePerVector, i)
                If i = 0 Then
                    If VectorList(i).EffectiveTime(0) <= TimeInterval AndAlso VectorList(i).EffectiveTime(1) >= TimeInterval Then
                        X_Distance = VectorList(i).Equation.X * TimeInterval / TimePerVector
                        Y_Distance = VectorList(i).Equation.Y * TimeInterval / TimePerVector
                        CurrentPos = New Point(StartingPos.X + X_Distance, StartingPos.Y + Y_Distance)
                        Return CurrentPos
                    End If
                ElseIf VectorList(i).EffectiveTime(0) <= TimeInterval AndAlso VectorList(i).EffectiveTime(1) >= TimeInterval Then
                    Try
                        LastPos = DisposableList((TimeInterval \ TimePerVector) - 1)
                    Catch
                        LastPos = DisposableList(((TimeInterval + 10) \ TimePerVector) - 1)
                    End Try
                    X_Distance = VectorList(i).Equation.X * (TimeInterval - TimePerVector * i) / TimePerVector
                    Y_Distance = VectorList(i).Equation.Y * (TimeInterval - TimePerVector * i) / TimePerVector
                    CurrentPos = New Point(LastPos.X + X_Distance, LastPos.Y + Y_Distance)
                    Return CurrentPos
                End If
            Next
        Else
            Return New Point(1280, 720)
        End If
    End Function

    Public Function Aiming(Target As Point)
        Return New Vector(CurrentPos, Target)
    End Function

    Public Function Shooting(Velocity As Single, Aiming As Vector, Optional Accel As Single = 0, Optional AccelAngle As Single = 0, Optional Caller As String = "")
        Return New Bullet(CurrentPos, Velocity, Aiming.Angle, Accel, AccelAngle, Caller)
    End Function

    Public Function Cooldown(ShootingCD)
        If CooldownTimer Is Nothing Then
            CooldownTimer = Stopwatch.StartNew()
            Return False
        ElseIf CooldownTimer.ElapsedMilliseconds < ShootingCD * 1000 Then
            Return True
        ElseIf CooldownTimer.ElapsedMilliseconds > ShootingCD * 1000 Then
            CooldownTimer.Restart()
            Return False
        End If
    End Function
End Class


Public Class Vector
    Public Equation As Point
    Public Absolute As Single
    Public EffectiveTime As ArrayList
    Public Angle As Single

    Public Sub New(Point1 As Point, Point2 As Point)
        Equation = New Point(Point2.X - Point1.X, Point2.Y - Point1.Y)
        Absolute = Math.Sqrt(Equation.X ^ 2 + Equation.Y ^ 2)
        If Point2.Y < Point1.Y Then
            Angle = -Math.Acos(Equation.X / Absolute)
        Else
            Angle = Math.Acos(Equation.X / Absolute)
        End If
    End Sub

    Public Sub Time(TimePerVector As Single, VectorNumber As UInteger)
        EffectiveTime = New ArrayList From {
            {TimePerVector * VectorNumber},
            {TimePerVector * (VectorNumber + 1)}
        }
    End Sub
End Class


Public Class Parrot
    Inherits Enemy
    Protected Accel
    Protected AccelAngle
    Public ShootingCD
    Public Velocity
    Public Sub New(StartingPos As Point, Trajectory As List(Of Point), TimeOfTravel As Single, TimeBeforeEntry As Single, Optional Modifier As Single = 1)
        MyBase.New(StartingPos, Trajectory, TimeOfTravel, TimeBeforeEntry)
        Health = 30 * Modifier
        ShootingCD = 0.5 / Modifier
        Velocity = 100 * Modifier
        EnemySize = New Size(20, 20)
    End Sub
    Public Overloads Function Shooting(Aiming As Vector)
        Return New Bullet(CurrentPos, Velocity, Aiming.Angle, Accel, AccelAngle, Caller:=TypeName(Me))
    End Function
End Class
Public Class Dragoon
    Inherits Enemy
    Protected Accel
    Protected AccelAngle
    Public ShootingCD
    Public Velocity

    Public Sub New(StartingPos As Point, Trajectory As List(Of Point), TimeOfTravel As Single, TimeBeforeEntry As Single, Optional Modifier As Single = 1)
        MyBase.New(StartingPos, Trajectory, TimeOfTravel, TimeBeforeEntry)
        Health = 200 * Modifier
        ShootingCD = 0.55 / Modifier
        Velocity = 700 * Modifier
        EnemySize = New Size(100, 100)
    End Sub

    Public Overloads Function Shooting(Aiming As Vector)
        Return New Bullet(CurrentPos, Velocity, Aiming.Angle, Accel, AccelAngle, Caller:=TypeName(Me))
    End Function
End Class


Public Class Polvinho
    Inherits Enemy
    Protected Accel
    Protected AccelAngle
    Public ShootingCD
    Public Velocity

    Public Sub New(StartingPos As Point, Trajectory As List(Of Point), TimeOfTravel As Single, TimeBeforeEntry As Single, Optional Modifier As Single = 1)
        MyBase.New(StartingPos, Trajectory, TimeOfTravel, TimeBeforeEntry)
        Health = 40 * Modifier
        ShootingCD = 0.65 / Modifier
        Velocity = 600 * Modifier
        EnemySize = New Size(50, 50)
    End Sub

    Public Overloads Function Shooting(Aiming As Vector)
        Return New Bullet(CurrentPos, Velocity, Aiming.Angle, Accel, AccelAngle, Caller:=TypeName(Me))
    End Function
End Class


Public Class Turtle
    Inherits Enemy
    Protected Accel
    Protected AccelAngle
    Public ShootingCD
    Public Velocity

    Public Sub New(StartingPos As Point, Trajectory As List(Of Point), TimeOfTravel As Single, TimeBeforeEntry As Single, Optional Modifier As Single = 1)
        MyBase.New(StartingPos, Trajectory, TimeOfTravel, TimeBeforeEntry)
        Health = 100 * Modifier
        ShootingCD = 1 / Modifier
        Velocity = 100 * Modifier
        EnemySize = New Size(40, 40)
    End Sub

    Public Overloads Function Shooting(Aiming As Vector)
        Return New Bullet(CurrentPos, Velocity, Aiming.Angle, Accel, AccelAngle, Caller:=TypeName(Me))
    End Function
End Class


Public Class Tiger
    Inherits Enemy
    Protected Accel
    Protected AccelAngle
    Public ShootingCD
    Public Velocity

    Public Sub New(StartingPos As Point, Trajectory As List(Of Point), TimeOfTravel As Single, TimeBeforeEntry As Single, Optional Modifier As Single = 1)
        MyBase.New(StartingPos, Trajectory, TimeOfTravel, TimeBeforeEntry)
        Health = 5000 * Modifier
        ShootingCD = 0.1 / Modifier
        Velocity = 300 * Modifier
        EnemySize = New Size(200, 186)
    End Sub

    Public Overloads Function Shooting(Aiming As Vector)
        Dim ChaoticInt
        Randomize(Health)
        ChaoticInt = 1.5 * Rnd() + 1
        Return New Bullet(CurrentPos + New Point(30, 30), Velocity, Aiming.Angle, ChaoticInt * 10, ChaoticInt, Caller:=TypeName(Me))
    End Function
End Class


Public Class Bomb
    Public StartingPos As Point
    Public Radius As Single
    Public Distance As Single

    Public Sub New(StartingPos As Point, Radius As Single)
        Me.StartingPos = StartingPos
        Me.Radius = Radius
    End Sub

    Public Function IsInRange(Bullet)
        Distance = Math.Sqrt(Math.Abs(Bullet.CurrentPos.X - StartingPos.X) ^ 2 + Math.Abs(Bullet.CurrentPos.Y - StartingPos.Y) ^ 2)
        If Distance <= Radius Then
            Return True
        Else
            Return False
        End If
    End Function
End Class