<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMenu))
        Me.Start = New System.Windows.Forms.PictureBox()
        Me.OptionsPB = New System.Windows.Forms.PictureBox()
        Me.Music = New System.Windows.Forms.PictureBox()
        Me.SoundEffects = New System.Windows.Forms.PictureBox()
        Me.ExitPB = New System.Windows.Forms.PictureBox()
        CType(Me.Start, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptionsPB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Music, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoundEffects, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExitPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Start
        '
        Me.Start.BackColor = System.Drawing.Color.Transparent
        Me.Start.Location = New System.Drawing.Point(142, 510)
        Me.Start.Name = "Start"
        Me.Start.Size = New System.Drawing.Size(197, 152)
        Me.Start.TabIndex = 1
        Me.Start.TabStop = False
        '
        'OptionsPB
        '
        Me.OptionsPB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OptionsPB.BackColor = System.Drawing.Color.Transparent
        Me.OptionsPB.Location = New System.Drawing.Point(746, 510)
        Me.OptionsPB.Name = "OptionsPB"
        Me.OptionsPB.Size = New System.Drawing.Size(216, 152)
        Me.OptionsPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.OptionsPB.TabIndex = 2
        Me.OptionsPB.TabStop = False
        '
        'Music
        '
        Me.Music.BackColor = System.Drawing.Color.Transparent
        Me.Music.Location = New System.Drawing.Point(570, 510)
        Me.Music.Name = "Music"
        Me.Music.Size = New System.Drawing.Size(158, 152)
        Me.Music.TabIndex = 3
        Me.Music.TabStop = False
        '
        'SoundEffects
        '
        Me.SoundEffects.BackColor = System.Drawing.Color.Transparent
        Me.SoundEffects.Location = New System.Drawing.Point(361, 510)
        Me.SoundEffects.Name = "SoundEffects"
        Me.SoundEffects.Size = New System.Drawing.Size(175, 152)
        Me.SoundEffects.TabIndex = 4
        Me.SoundEffects.TabStop = False
        '
        'ExitPB
        '
        Me.ExitPB.BackColor = System.Drawing.Color.Transparent
        Me.ExitPB.Location = New System.Drawing.Point(968, 510)
        Me.ExitPB.Name = "ExitPB"
        Me.ExitPB.Size = New System.Drawing.Size(154, 152)
        Me.ExitPB.TabIndex = 5
        Me.ExitPB.TabStop = False
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.PalmtopTiger.My.Resources.Resources.Menu_with_help_
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1280, 720)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExitPB)
        Me.Controls.Add(Me.SoundEffects)
        Me.Controls.Add(Me.Music)
        Me.Controls.Add(Me.OptionsPB)
        Me.Controls.Add(Me.Start)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Helvetica", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(My.Resources.Winner_taiga, System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "MainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Palmtop Tiger"
        CType(Me.Start, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OptionsPB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Music, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoundEffects, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExitPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Start As PictureBox
    Friend WithEvents OptionsPB As PictureBox
    Friend WithEvents Music As PictureBox
    Friend WithEvents SoundEffects As PictureBox
    Friend WithEvents ExitPB As PictureBox
End Class
