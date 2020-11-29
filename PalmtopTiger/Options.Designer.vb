<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Options
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
        Me.MusicDown = New System.Windows.Forms.PictureBox()
        Me.MusicUp = New System.Windows.Forms.PictureBox()
        Me.SoundFXUp = New System.Windows.Forms.PictureBox()
        Me.SoundFXDown = New System.Windows.Forms.PictureBox()
        Me.BackPB = New System.Windows.Forms.PictureBox()
        CType(Me.MusicDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MusicUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoundFXUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoundFXDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BackPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MusicDown
        '
        Me.MusicDown.BackColor = System.Drawing.Color.Transparent
        Me.MusicDown.Location = New System.Drawing.Point(679, 260)
        Me.MusicDown.Name = "MusicDown"
        Me.MusicDown.Size = New System.Drawing.Size(53, 88)
        Me.MusicDown.TabIndex = 0
        Me.MusicDown.TabStop = False
        '
        'MusicUp
        '
        Me.MusicUp.BackColor = System.Drawing.Color.Transparent
        Me.MusicUp.Location = New System.Drawing.Point(942, 260)
        Me.MusicUp.Name = "MusicUp"
        Me.MusicUp.Size = New System.Drawing.Size(54, 88)
        Me.MusicUp.TabIndex = 1
        Me.MusicUp.TabStop = False
        '
        'SoundFXUp
        '
        Me.SoundFXUp.BackColor = System.Drawing.Color.Transparent
        Me.SoundFXUp.Location = New System.Drawing.Point(942, 387)
        Me.SoundFXUp.Name = "SoundFXUp"
        Me.SoundFXUp.Size = New System.Drawing.Size(54, 92)
        Me.SoundFXUp.TabIndex = 2
        Me.SoundFXUp.TabStop = False
        '
        'SoundFXDown
        '
        Me.SoundFXDown.BackColor = System.Drawing.Color.Transparent
        Me.SoundFXDown.Location = New System.Drawing.Point(679, 387)
        Me.SoundFXDown.Name = "SoundFXDown"
        Me.SoundFXDown.Size = New System.Drawing.Size(53, 92)
        Me.SoundFXDown.TabIndex = 3
        Me.SoundFXDown.TabStop = False
        '
        'BackPB
        '
        Me.BackPB.BackColor = System.Drawing.Color.Transparent
        Me.BackPB.Image = Global.PalmtopTiger.My.Resources.Resources.Back_button
        Me.BackPB.Location = New System.Drawing.Point(1168, 12)
        Me.BackPB.Name = "BackPB"
        Me.BackPB.Size = New System.Drawing.Size(100, 53)
        Me.BackPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BackPB.TabIndex = 5
        Me.BackPB.TabStop = False
        '
        'Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.PalmtopTiger.My.Resources.Resources.Jpg_options_menu_
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1280, 720)
        Me.ControlBox = False
        Me.Controls.Add(Me.BackPB)
        Me.Controls.Add(Me.SoundFXDown)
        Me.Controls.Add(Me.SoundFXUp)
        Me.Controls.Add(Me.MusicUp)
        Me.Controls.Add(Me.MusicDown)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Helvetica", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = Global.PalmtopTiger.My.Resources.Resources.Winner_taiga
        Me.Name = "Options"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Palmtop Tiger"
        CType(Me.MusicDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MusicUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoundFXUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoundFXDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BackPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MusicDown As PictureBox
    Friend WithEvents MusicUp As PictureBox
    Friend WithEvents SoundFXUp As PictureBox
    Friend WithEvents SoundFXDown As PictureBox
    Friend WithEvents BackPB As PictureBox
End Class
