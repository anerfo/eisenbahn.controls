<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteuerpultControl
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Geschwindigkeit = New System.Windows.Forms.TrackBar()
        Me.Funktion0 = New System.Windows.Forms.CheckBox()
        Me.Funktion1 = New System.Windows.Forms.CheckBox()
        Me.Funktion4 = New System.Windows.Forms.CheckBox()
        Me.Funktion3 = New System.Windows.Forms.CheckBox()
        Me.Funktion2 = New System.Windows.Forms.CheckBox()
        Me.Loknummerbox = New System.Windows.Forms.MaskedTextBox()
        Me.Umkehren1 = New System.Windows.Forms.Button()
        Me.Bild = New System.Windows.Forms.PictureBox()
        CType(Me.Geschwindigkeit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bild, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Geschwindigkeit
        '
        Me.Geschwindigkeit.AutoSize = False
        Me.Geschwindigkeit.Dock = System.Windows.Forms.DockStyle.Right
        Me.Geschwindigkeit.Location = New System.Drawing.Point(157, 0)
        Me.Geschwindigkeit.Maximum = 14
        Me.Geschwindigkeit.Name = "Geschwindigkeit"
        Me.Geschwindigkeit.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.Geschwindigkeit.Size = New System.Drawing.Size(37, 149)
        Me.Geschwindigkeit.TabIndex = 0
        '
        'Funktion0
        '
        Me.Funktion0.Appearance = System.Windows.Forms.Appearance.Button
        Me.Funktion0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Funktion0.Location = New System.Drawing.Point(70, 31)
        Me.Funktion0.Name = "Funktion0"
        Me.Funktion0.Size = New System.Drawing.Size(64, 23)
        Me.Funktion0.TabIndex = 1
        Me.Funktion0.Tag = "0"
        Me.Funktion0.Text = "Funktion"
        Me.Funktion0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Funktion0.UseVisualStyleBackColor = True
        '
        'Funktion1
        '
        Me.Funktion1.Appearance = System.Windows.Forms.Appearance.Button
        Me.Funktion1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Funktion1.Location = New System.Drawing.Point(3, 60)
        Me.Funktion1.Name = "Funktion1"
        Me.Funktion1.Size = New System.Drawing.Size(29, 23)
        Me.Funktion1.TabIndex = 5
        Me.Funktion1.Tag = "1"
        Me.Funktion1.Text = "F1"
        Me.Funktion1.UseVisualStyleBackColor = True
        '
        'Funktion4
        '
        Me.Funktion4.Appearance = System.Windows.Forms.Appearance.Button
        Me.Funktion4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Funktion4.Location = New System.Drawing.Point(105, 60)
        Me.Funktion4.Name = "Funktion4"
        Me.Funktion4.Size = New System.Drawing.Size(29, 23)
        Me.Funktion4.TabIndex = 10
        Me.Funktion4.Tag = "4"
        Me.Funktion4.Text = "F4"
        Me.Funktion4.UseVisualStyleBackColor = True
        '
        'Funktion3
        '
        Me.Funktion3.Appearance = System.Windows.Forms.Appearance.Button
        Me.Funktion3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Funktion3.Location = New System.Drawing.Point(70, 60)
        Me.Funktion3.Name = "Funktion3"
        Me.Funktion3.Size = New System.Drawing.Size(29, 23)
        Me.Funktion3.TabIndex = 9
        Me.Funktion3.Tag = "3"
        Me.Funktion3.Text = "F3"
        Me.Funktion3.UseVisualStyleBackColor = True
        '
        'Funktion2
        '
        Me.Funktion2.Appearance = System.Windows.Forms.Appearance.Button
        Me.Funktion2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Funktion2.Location = New System.Drawing.Point(35, 60)
        Me.Funktion2.Name = "Funktion2"
        Me.Funktion2.Size = New System.Drawing.Size(29, 23)
        Me.Funktion2.TabIndex = 8
        Me.Funktion2.Tag = "2"
        Me.Funktion2.Text = "F2"
        Me.Funktion2.UseVisualStyleBackColor = True
        '
        'Loknummerbox
        '
        Me.Loknummerbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.Loknummerbox.Location = New System.Drawing.Point(43, 5)
        Me.Loknummerbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Loknummerbox.Mask = "00"
        Me.Loknummerbox.Name = "Loknummerbox"
        Me.Loknummerbox.Size = New System.Drawing.Size(56, 20)
        Me.Loknummerbox.TabIndex = 11
        Me.Loknummerbox.Text = "00"
        Me.Loknummerbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Umkehren1
        '
        Me.Umkehren1.Location = New System.Drawing.Point(3, 31)
        Me.Umkehren1.Name = "Umkehren1"
        Me.Umkehren1.Size = New System.Drawing.Size(64, 23)
        Me.Umkehren1.TabIndex = 12
        Me.Umkehren1.Text = "Umkehren"
        Me.Umkehren1.UseVisualStyleBackColor = True
        '
        'Bild
        '
        Me.Bild.Location = New System.Drawing.Point(8, 89)
        Me.Bild.Name = "Bild"
        Me.Bild.Size = New System.Drawing.Size(126, 55)
        Me.Bild.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Bild.TabIndex = 13
        Me.Bild.TabStop = False
        '
        'SteuerpultControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.Bild)
        Me.Controls.Add(Me.Umkehren1)
        Me.Controls.Add(Me.Loknummerbox)
        Me.Controls.Add(Me.Funktion4)
        Me.Controls.Add(Me.Funktion3)
        Me.Controls.Add(Me.Funktion2)
        Me.Controls.Add(Me.Funktion1)
        Me.Controls.Add(Me.Funktion0)
        Me.Controls.Add(Me.Geschwindigkeit)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.MinimumSize = New System.Drawing.Size(179, 86)
        Me.Name = "SteuerpultControl"
        Me.Size = New System.Drawing.Size(194, 149)
        CType(Me.Geschwindigkeit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bild, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Geschwindigkeit As System.Windows.Forms.TrackBar
    Friend WithEvents Funktion0 As System.Windows.Forms.CheckBox
    Friend WithEvents Funktion1 As System.Windows.Forms.CheckBox
    Friend WithEvents Funktion4 As System.Windows.Forms.CheckBox
    Friend WithEvents Funktion3 As System.Windows.Forms.CheckBox
    Friend WithEvents Funktion2 As System.Windows.Forms.CheckBox
    Friend WithEvents Loknummerbox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Umkehren1 As System.Windows.Forms.Button
    Friend WithEvents Bild As System.Windows.Forms.PictureBox

End Class
