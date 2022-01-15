<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WeichenparameterDarstellung
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Weiche n"
        '
        'CheckBox1
        '
        Me.CheckBox1.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox1.Location = New System.Drawing.Point(3, 14)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(64, 24)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.Text = "umdrehen"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(3, 39)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "links"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(67, 39)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "rechts"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"nicht schalten", "links", "rechts"})
        Me.ComboBox1.Location = New System.Drawing.Point(68, 15)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(64, 21)
        Me.ComboBox1.TabIndex = 4
        '
        'WeichenparameterDarstellung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "WeichenparameterDarstellung"
        Me.Size = New System.Drawing.Size(134, 66)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox

End Class
