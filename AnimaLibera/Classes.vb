Public Class Bullet
    Private StartingPos As Point
    Private Damage As Single
    Private Velocity As Single
    Private VelAngle As Single
    Protected Accel As Single
    Protected AccelAngle As Single
    Public CurrentPos As Point
    Private ReadOnly ElapsedTime As Stopwatch
    Public Sub New(StartingPos As Point, Damage As Single, Velocity As Single, Vel_Angle As Single, Accel As Single, Accel_Angle As Single)
        Me.StartingPos = StartingPos
        Me.Damage = Damage
        Me.Velocity = Velocity
        VelAngle = Vel_Angle
        Me.Accel = Accel
        AccelAngle = Accel_Angle
        ElapsedTime = Stopwatch.StartNew()
    End Sub
    Public Function Position()
        Dim X_Distance As Integer
        Dim Y_Distance As Integer
        Dim TimeElapsed As Single
        TimeElapsed = ElapsedTime.Elapsed.TotalMilliseconds / 1000
        X_Distance = (Velocity * Math.Sin(VelAngle) * TimeElapsed) + 1 / 2 * Accel * Math.Sin(AccelAngle) * TimeElapsed ^ 2
        Y_Distance = (Velocity * Math.Cos(VelAngle) * TimeElapsed) + 1 / 2 * Accel * Math.Cos(AccelAngle) * TimeElapsed ^ 2
        CurrentPos = New Point(StartingPos.X + X_Distance, StartingPos.Y + Y_Distance)
        Return CurrentPos
    End Function
End Class
Public Class Enemy
    Protected StartingPos As Point
    Protected Health As Single
    Protected ReadOnly Trajectory As List(Of Point)
    Protected VectorList = New List(Of Vector)
    Protected TimeOfTravel As Single
    Protected TimeBeforeEntry As Single
    Private ReadOnly ElapsedTime As Stopwatch
    Public CurrentPos As Point
    Private CooldownTimer As Stopwatch
    Public Sub New(StartingPos As Point, Trajectory As List(Of Point), TimeOfTravel As Single, Optional TimeBeforeEntry As Single = 0, Optional Health As Single = 100)
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
            Return Nothing
        End If
    End Function
    Public Function Aiming(Target As Point)
        Return New Vector(CurrentPos, Target)
    End Function
    Public Function Shooting(Damage As Integer, Aiming As Vector, Optional Velocity As Single = 0, Optional Accel As Single = 0, Optional AccelAngle As Single = 0)
        Return New Bullet(CurrentPos, Damage, Velocity, Aiming.Angle, Accel, AccelAngle)
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
    Public EffectiveTime As ArrayList
    Public Angle As Single
    Public Sub New(Point1 As Point, Point2 As Point)
        Equation = New Point(Point2.X - Point1.X, Point2.Y - Point1.Y)
        Angle = Math.Atan(Equation.Y / Equation.X)
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
    Public Damage
    Protected Accel
    Protected AccelAngle
    Public ShootingCD
    Public Velocity
    Public Sub New(StartingPos As Point, Trajectory As List(Of Point), TimeOfTravel As Single, TimeBeforeEntry As Single)
        MyBase.New(StartingPos, Trajectory, TimeOfTravel, TimeBeforeEntry)
        Health = 10
        Damage = 10
        ShootingCD = 0.1
        Velocity = 100
    End Sub
    Public Overloads Function Shooting(Aiming As Vector)
        Return New Bullet(CurrentPos, Damage, Velocity, Aiming.Angle, Accel, AccelAngle)
    End Function
End Class