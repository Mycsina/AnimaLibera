Public Class Bullet
    Inherits PictureBox
    Public StartingPos As Point
    Protected Color As Color
    Protected Damage As Single
    Protected Velocity As Single
    Protected VelocityX As Single
    Protected VelocityY As Single
    Protected Vel_Angle As Double
    Protected Accel As Single
    Protected Accel_Angle As Double
    Protected Elapsed_Time As Stopwatch
    Protected TimeElapsed As Double
    Public Sub New(ByVal StartingPos As Point, ByVal Color As Color, ByVal Damage As Single, ByVal Velocity As Single, ByVal Vel_Angle As Double, ByVal Accel As Single, ByVal Accel_Angle As Single)
        Location = New Point(StartingPos.X, StartingPos.Y)
        Me.StartingPos = StartingPos
        Width = 10
        Height = 10
        BackColor = Color
        Me.Damage = Damage
        Me.Velocity = Velocity
        Me.Vel_Angle = Vel_Angle
        Me.Accel = Accel
        Me.Accel_Angle = Accel_Angle
        Elapsed_Time = Stopwatch.StartNew()
    End Sub
    Public Function Position()
        Dim TimeElapsed = Elapsed_Time.ElapsedMilliseconds()
        Dim V_Distance = (Velocity * Math.Cos(Vel_Angle) * TimeElapsed) + 1 / 2 * Accel * Math.Cos(Accel_Angle) * TimeElapsed ^ 2
        Dim X_Distance = (Velocity * Math.Sin(Vel_Angle) * TimeElapsed) + 1 / 2 * Accel * Math.Sin(Accel_Angle) * TimeElapsed ^ 2
        Return New Point(StartingPos.X + X_Distance, StartingPos.Y + V_Distance)
    End Function
End Class
