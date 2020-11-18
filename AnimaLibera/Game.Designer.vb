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
        Me.invis = New System.Windows.Forms.PictureBox()
        CType(Me.invis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RunningTime
        '
        Me.RunningTime.Enabled = True
        Me.RunningTime.Interval = 15
        '
        'ShootingCD
        '
        Me.ShootingCD.Enabled = True
        Me.ShootingCD.Interval = 500
        '
        'invis
        '
        Me.invis.BackColor = System.Drawing.Color.Transparent
        Me.invis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.invis.InitialImage = Nothing
        Me.invis.Location = New System.Drawing.Point(633, 520)
        Me.invis.Name = "invis"
        Me.invis.Size = New System.Drawing.Size(10, 10)
        Me.invis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.invis.TabIndex = 0
        Me.invis.TabStop = False
        '
        'Game
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1280, 720)
        Me.ControlBox = False
        Me.Controls.Add(Me.invis)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Game"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Game"
        CType(Me.invis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RunningTime As Timer
    Friend WithEvents ShootingCD As Timer
    Friend WithEvents invis As PictureBox
End Class
