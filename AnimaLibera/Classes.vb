Public Class Bullet
    Public StartingPos As Point
    Private Damage As Single
    Private Velocity As Single
    Private VelAngle As Double
    Protected Accel As Single
    Protected AccelAngle As Double
    Public CurrentPos As Point
    Private ReadOnly ElapsedTime As Stopwatch
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
        Dim X_Distance As Integer
        Dim Y_Distance As Integer
        Dim TimeElapsed As Single
        TimeElapsed = ElapsedTime.Elapsed.TotalMilliseconds
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
        Dim TimeInterval As Single
        Dim TimePerVector = TimeOfTravel * 1000 / VectorList.Count()
        Dim DisposableList = New List(Of Point)
        Dim X_Distance As Integer
        Dim Y_Distance As Integer
        Dim CurrentPos As Point
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
End Class
Public Class Vector
    Public Equation As Point
    Public EffectiveTime As ArrayList
    Public Angle As Single
    Public Sub New(ByVal Point1 As Point, ByVal Point2 As Point)
        Equation = New Point(Point2.X - Point1.X, Point2.Y - Point1.Y)
        Angle = Math.Atan(Equation.Y / Equation.X)
    End Sub
    Public Sub Time(ByVal TimePerVector As Single, ByVal VectorNumber As UInteger)
        EffectiveTime = New ArrayList From {
            {TimePerVector * VectorNumber},
            {TimePerVector * (VectorNumber + 1)}
        }
    End Sub
End Class
