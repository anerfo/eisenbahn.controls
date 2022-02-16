<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DasKalteHerz
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DasKalteHerz))
        Me.StoryPictureBox = New System.Windows.Forms.PictureBox()
        Me.StoryLabel = New System.Windows.Forms.Label()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.KapitelLabel = New System.Windows.Forms.Label()
        CType(Me.StoryPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StoryPictureBox
        '
        Me.StoryPictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StoryPictureBox.BackColor = System.Drawing.Color.Black
        Me.StoryPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StoryPictureBox.Location = New System.Drawing.Point(6, 3)
        Me.StoryPictureBox.Name = "StoryPictureBox"
        Me.StoryPictureBox.Size = New System.Drawing.Size(670, 409)
        Me.StoryPictureBox.TabIndex = 0
        Me.StoryPictureBox.TabStop = False
        '
        'StoryLabel
        '
        Me.StoryLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StoryLabel.BackColor = System.Drawing.Color.LightGray
        Me.StoryLabel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.StoryLabel.Location = New System.Drawing.Point(43, 415)
        Me.StoryLabel.Name = "StoryLabel"
        Me.StoryLabel.Size = New System.Drawing.Size(587, 106)
        Me.StoryLabel.TabIndex = 1
        Me.StoryLabel.Text = "StoryLabel"
        Me.StoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(0, 0)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(676, 412)
        Me.AxWindowsMediaPlayer1.TabIndex = 2
        Me.AxWindowsMediaPlayer1.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(636, 485)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 29)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = ">"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(0, 450)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(37, 29)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "<<"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button4.Location = New System.Drawing.Point(0, 415)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(37, 29)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "|<"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(636, 450)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(37, 29)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = ">>"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.Location = New System.Drawing.Point(636, 415)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(37, 29)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "A"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button6.Location = New System.Drawing.Point(0, 485)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 29)
        Me.Button6.TabIndex = 9
        Me.Button6.Text = "<"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'KapitelLabel
        '
        Me.KapitelLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.KapitelLabel.AutoSize = True
        Me.KapitelLabel.BackColor = System.Drawing.Color.LightGray
        Me.KapitelLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KapitelLabel.Location = New System.Drawing.Point(44, 415)
        Me.KapitelLabel.Name = "KapitelLabel"
        Me.KapitelLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.KapitelLabel.Size = New System.Drawing.Size(57, 20)
        Me.KapitelLabel.TabIndex = 10
        Me.KapitelLabel.Text = "Kapitel"
        '
        'DasKalteHerz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.KapitelLabel)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.Controls.Add(Me.StoryPictureBox)
        Me.Controls.Add(Me.StoryLabel)
        Me.Name = "DasKalteHerz"
        Me.Size = New System.Drawing.Size(676, 521)
        CType(Me.StoryPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StoryPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents StoryLabel As System.Windows.Forms.Label
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents KapitelLabel As System.Windows.Forms.Label

End Class
