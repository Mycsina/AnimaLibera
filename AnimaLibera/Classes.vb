Public Class Bullet
    Public StartingPos As Point
    Protected Color As Color
    Protected Damage As Single
    Protected Velocity As Single
    Protected VelAngle As Double
    Protected Accel As Single
    Protected AccelAngle As Double
    Protected ElapsedTime As Stopwatch
    Protected TimeElapsed As Double
    Public Sub New(ByVal StartingPos As Point, ByVal Damage As Single, ByVal Velocity As Single, ByVal Vel_Angle As Double, ByVal Accel As Single, ByVal Accel_Angle As Single)
        Me.StartingPos = StartingPos
        Me.Damage = Damage
        Me.Velocity = Velocity
        VelAngle = Vel_Angle
        Me.Accel = Accel
        AccelAngle = Accel_Angle
        ElapsedTime = Stopwatch.StartNew()
    End Sub
    Public Function Position()
        Dim TimeElapsed = ElapsedTime.ElapsedMilliseconds()
        Dim V_Distance = (Velocity * Math.Cos(VelAngle) * TimeElapsed) + 1 / 2 * Accel * Math.Cos(AccelAngle) * TimeElapsed ^ 2
        Dim X_Distance = (Velocity * Math.Sin(VelAngle) * TimeElapsed) + 1 / 2 * Accel * Math.Sin(AccelAngle) * TimeElapsed ^ 2
        Return New Point(StartingPos.X + X_Distance, StartingPos.Y + V_Distance)
    End Function
End Class
