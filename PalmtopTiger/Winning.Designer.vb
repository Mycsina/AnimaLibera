<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Winning
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
        Me.MenuPB = New System.Windows.Forms.PictureBox()
        Me.ExitPB = New System.Windows.Forms.PictureBox()
        CType(Me.MenuPB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExitPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuPB
        '
        Me.MenuPB.BackColor = System.Drawing.Color.Transparent
        Me.MenuPB.Location = New System.Drawing.Point(961, 593)
        Me.MenuPB.Name = "MenuPB"
        Me.MenuPB.Size = New System.Drawing.Size(145, 78)
        Me.MenuPB.TabIndex = 0
        Me.MenuPB.TabStop = False
        '
        'ExitPB
        '
        Me.ExitPB.BackColor = System.Drawing.Color.Transparent
        Me.ExitPB.Location = New System.Drawing.Point(1112, 593)
        Me.ExitPB.Name = "ExitPB"
        Me.ExitPB.Size = New System.Drawing.Size(126, 78)
        Me.ExitPB.TabIndex = 1
        Me.ExitPB.TabStop = False
        '
        'Winning
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.PalmtopTiger.My.Resources.Resources.Winner
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1280, 720)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExitPB)
        Me.Controls.Add(Me.MenuPB)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Helvetica", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = Global.PalmtopTiger.My.Resources.Resources.Winner_taiga
        Me.KeyPreview = True
        Me.Name = "Winning"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Palmtop Tiger"
        CType(Me.MenuPB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExitPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuPB As PictureBox
    Friend WithEvents ExitPB As PictureBox
End Class
