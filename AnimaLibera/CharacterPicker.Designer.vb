<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CharacterPicker
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ExitPB = New System.Windows.Forms.PictureBox()
        Me.ElfTaigaPB = New System.Windows.Forms.PictureBox()
        Me.RegularTaigaPB = New System.Windows.Forms.PictureBox()
        Me.WaterTaigaPB = New System.Windows.Forms.PictureBox()
        Me.GothTaigaPB = New System.Windows.Forms.PictureBox()
        CType(Me.ExitPB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElfTaigaPB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RegularTaigaPB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WaterTaigaPB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GothTaigaPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExitPB
        '
        Me.ExitPB.BackColor = System.Drawing.Color.Transparent
        Me.ExitPB.Location = New System.Drawing.Point(1111, 548)
        Me.ExitPB.Name = "ExitPB"
        Me.ExitPB.Size = New System.Drawing.Size(145, 122)
        Me.ExitPB.TabIndex = 0
        Me.ExitPB.TabStop = False
        '
        'ElfTaigaPB
        '
        Me.ElfTaigaPB.BackColor = System.Drawing.Color.Transparent
        Me.ElfTaigaPB.Location = New System.Drawing.Point(178, 282)
        Me.ElfTaigaPB.Name = "ElfTaigaPB"
        Me.ElfTaigaPB.Size = New System.Drawing.Size(180, 226)
        Me.ElfTaigaPB.TabIndex = 1
        Me.ElfTaigaPB.TabStop = False
        '
        'RegularTaigaPB
        '
        Me.RegularTaigaPB.BackColor = System.Drawing.Color.Transparent
        Me.RegularTaigaPB.Location = New System.Drawing.Point(444, 282)
        Me.RegularTaigaPB.Name = "RegularTaigaPB"
        Me.RegularTaigaPB.Size = New System.Drawing.Size(180, 226)
        Me.RegularTaigaPB.TabIndex = 2
        Me.RegularTaigaPB.TabStop = False
        '
        'WaterTaigaPB
        '
        Me.WaterTaigaPB.BackColor = System.Drawing.Color.Transparent
        Me.WaterTaigaPB.Location = New System.Drawing.Point(707, 282)
        Me.WaterTaigaPB.Name = "WaterTaigaPB"
        Me.WaterTaigaPB.Size = New System.Drawing.Size(180, 226)
        Me.WaterTaigaPB.TabIndex = 3
        Me.WaterTaigaPB.TabStop = False
        '
        'GothTaigaPB
        '
        Me.GothTaigaPB.BackColor = System.Drawing.Color.Transparent
        Me.GothTaigaPB.Location = New System.Drawing.Point(948, 282)
        Me.GothTaigaPB.Name = "GothTaigaPB"
        Me.GothTaigaPB.Size = New System.Drawing.Size(180, 226)
        Me.GothTaigaPB.TabIndex = 4
        Me.GothTaigaPB.TabStop = False
        '
        'CharacterPicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.PalmtopTiger.My.Resources.Resources.CharacterPicker
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1280, 720)
        Me.ControlBox = False
        Me.Controls.Add(Me.GothTaigaPB)
        Me.Controls.Add(Me.WaterTaigaPB)
        Me.Controls.Add(Me.RegularTaigaPB)
        Me.Controls.Add(Me.ElfTaigaPB)
        Me.Controls.Add(Me.ExitPB)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Helvetica", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(My.Resources.Winner_taiga, System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "CharacterPicker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Palmtop Tiger"
        CType(Me.ExitPB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElfTaigaPB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RegularTaigaPB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WaterTaigaPB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GothTaigaPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ExitPB As PictureBox
    Friend WithEvents ElfTaigaPB As PictureBox
    Friend WithEvents RegularTaigaPB As PictureBox
    Friend WithEvents WaterTaigaPB As PictureBox
    Friend WithEvents GothTaigaPB As PictureBox
End Class
