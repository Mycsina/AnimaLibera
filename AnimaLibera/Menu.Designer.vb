<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu))
        Me.Start = New System.Windows.Forms.PictureBox()
        Me.Options = New System.Windows.Forms.PictureBox()
        CType(Me.Start, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Options, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Start
        '
        Me.Start.BackColor = System.Drawing.Color.Transparent
        Me.Start.Image = CType(resources.GetObject("Start.Image"), System.Drawing.Image)
        Me.Start.Location = New System.Drawing.Point(114, 503)
        Me.Start.Name = "Start"
        Me.Start.Size = New System.Drawing.Size(100, 50)
        Me.Start.TabIndex = 1
        Me.Start.TabStop = False
        '
        'Options
        '
        Me.Options.BackColor = System.Drawing.Color.Transparent
        Me.Options.Image = Global.AnimaLibera.My.Resources.Resources.HighResBackground
        Me.Options.Location = New System.Drawing.Point(936, 503)
        Me.Options.Name = "Options"
        Me.Options.Size = New System.Drawing.Size(100, 50)
        Me.Options.TabIndex = 2
        Me.Options.TabStop = False
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1280, 720)
        Me.ControlBox = False
        Me.Controls.Add(Me.Options)
        Me.Controls.Add(Me.Start)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Helvetica", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu"
        CType(Me.Start, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Options, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Start As PictureBox
    Friend WithEvents Options As PictureBox
End Class
