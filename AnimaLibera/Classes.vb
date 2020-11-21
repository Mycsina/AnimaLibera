Public Class Bullet
    Public StartingPos As Point
    Private Damage As Single
    Private Velocity As Single
    Private VelAngle As Double
    Protected Accel As Single
    Protected AccelAngle As Double
    Private ReadOnly ElapsedTime As Stopwatch
    Private X_Distance
    Private Y_Distance
    Private TimeElapsed As ULong
    Public CurrentPos
    Public Sub New(ByVal StartingPos As Point, ByVal Damage As Single, ByVal Velocity As Single, ByVal Vel_Angle As Double, ByVal Accel As Single, ByVal Accel_Angle As Double)
        Me.StartingPos = StartingPos
        Me.Damage = Damage
        Me.Velocity = Velocity
        VelAngle = Vel_Angle
        Me.Accel = Accel
        AccelAngle = Accel_Angle
        ElapsedTime = Stopwatch.StartNew()
    End Sub
    Public Function Position()
        TimeElapsed = ElapsedTime.ElapsedMilliseconds()
        X_Distance = (Velocity * Math.Sin(VelAngle) * TimeElapsed) + 1 / 2 * Accel * Math.Sin(AccelAngle) * TimeElapsed ^ 2
        Y_Distance = (Velocity * Math.Cos(VelAngle) * TimeElapsed) + 1 / 2 * Accel * Math.Cos(AccelAngle) * TimeElapsed ^ 2
        CurrentPos = New Point(StartingPos.X + X_Distance, StartingPos.Y + Y_Distance)
        Return CurrentPos
    End Function
End Class
Public Class Enemy
    Private StartingPos As Point
    Protected Health As Single
    Private ReadOnly Trajectory As List(Of Point)
    Protected VectorList = New List(Of Vector)
    Protected TimeOfTravel As Single
    Protected TimeBeforeEntry As Single
    Protected Bullet As Bullet
    Protected ShootingCD As Single
    Private ReadOnly ElapsedTime As Stopwatch
    Protected CurrentPos As Point
    Private TimeInterval As ULong
    Private X_Distance
    Private Y_Distance
    Public Sub New(ByVal StartingPos As Point, ByVal Health As Single, ByVal Trajectory As List(Of Point), ByVal TimeOfTravel As Single, ByVal TimeBeforeEntry As Single, ByVal Bullet As Bullet, ByVal ShootingCD As Single)
        Me.Health = Health
        Me.StartingPos = StartingPos
        For i = 0 To Trajectory.Count - 2
            VectorList.Add(New Vector(Trajectory(i), Trajectory(i + 1)))
        Next
        Me.TimeOfTravel = TimeOfTravel
        Me.TimeBeforeEntry = TimeBeforeEntry
        Me.Bullet = Bullet
        Me.ShootingCD = ShootingCD
        ElapsedTime = Stopwatch.StartNew()
    End Sub
    Public Function Position()
        TimeInterval = ElapsedTime.ElapsedMilliseconds()
        Dim TimePerVector = TimeOfTravel * 1000 / VectorList.Count()
        If TimeBeforeEntry < TimeInterval Then
            For i = 0 To VectorList.Count - 1
                VectorList(i).Time(TimePerVector, i)
            Next
            For Each Vector In VectorList
                If Vector.EffectiveTime(0) < TimeInterval And Vector.EffectiveTime(1) > TimeInterval Then
                    Debug.WriteLine(Vector.VectorToVel(TimeInterval))
                    Debug.WriteLine(Math.Sin(Vector.Angle))
                    X_Distance = (Vector.VectorToVel(TimeInterval) * Math.Sin(Vector.Angle) * TimeInterval)
                    Y_Distance = (Vector.VectorToVel(TimeInterval) * Math.Cos(Vector.Angle) * TimeInterval)
                    CurrentPos = New Point(StartingPos.X + X_Distance, StartingPos.Y + Y_Distance)
                    Return CurrentPos
                ElseIf Vector.EffectiveTime(1) < TimeInterval Then
                    Return True
                End If
            Next
        Else
            Return Nothing
        End If
    End Function
End Class
Public Class Vector
    Public Equation As Point
    Public EffectiveTime As ArrayList
    Public Angle As Single
    Public Sub New(ByVal Point1 As Point, ByVal Point2 As Point)
        Equation = New Point(Point2.X - Point1.X, Point2.Y - Point1.Y)
        Angle = Math.Atan(Equation.Y / Equation.X)
    End Sub
    Public Function VectorToVel(ByVal TimeElapsed)
        Return (Math.Sqrt(Equation.X ^ 2 + Equation.Y ^ 2)) / TimeElapsed
    End Function
    Public Sub Time(ByVal TimePerVector As Single, ByVal VectorNumber As UInteger)
        EffectiveTime = New ArrayList From {
            {TimePerVector * VectorNumber},
            {TimePerVector * (VectorNumber + 1)}
        }
    End Sub
End Class
