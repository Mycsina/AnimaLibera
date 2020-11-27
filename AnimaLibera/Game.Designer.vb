<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Game
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.RunningTime = New System.Windows.Forms.Timer(Me.components)
        Me.ShootingCD = New System.Windows.Forms.Timer(Me.components)
        Me.GraphicsAC = New System.Windows.Forms.Timer(Me.components)
        Me.BombLingerTime = New System.Windows.Forms.Timer(Me.components)
        Me.LevelSelection = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'RunningTime
        '
        Me.RunningTime.Enabled = True
        Me.RunningTime.Interval = 10
        '
        'ShootingCD
        '
        Me.ShootingCD.Enabled = True
        '
        'GraphicsAC
        '
        Me.GraphicsAC.Enabled = True
        '
        'BombLingerTime
        '
        Me.BombLingerTime.Interval = 3000
        '
        'LevelSelection
        '
        Me.LevelSelection.Enabled = True
        '
        'Game
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1280, 720)
        Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Game"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Game"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RunningTime As Timer
    Friend WithEvents ShootingCD As Timer
    Friend WithEvents GraphicsAC As Timer
    Friend WithEvents BombLingerTime As Timer
    Friend WithEvents LevelSelection As Timer
End Class
