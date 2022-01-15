<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteuerpultFunktionen
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
        Me.Loknummer = New System.Windows.Forms.MaskedTextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.F3 = New System.Windows.Forms.PictureBox
        Me.F2 = New System.Windows.Forms.PictureBox
        Me.F1 = New System.Windows.Forms.PictureBox
        Me.Hauptfunktion = New System.Windows.Forms.PictureBox
        Me.F4 = New System.Windows.Forms.PictureBox
        Me.FunktionenBeenden = New System.Windows.Forms.Label
        CType(Me.F3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Hauptfunktion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Loknummer
        '
        Me.Loknummer.Location = New System.Drawing.Point(78, 3)
        Me.Loknummer.Mask = "00"
        Me.Loknummer.Name = "Loknummer"
        Me.Loknummer.Size = New System.Drawing.Size(33, 20)
        Me.Loknummer.TabIndex = 0
        Me.Loknummer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(0, 66)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(192, 140)
        Me.Panel1.TabIndex = 6
        '
        'F3
        '
        Me.F3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F3.Location = New System.Drawing.Point(125, 30)
        Me.F3.Name = "F3"
        Me.F3.Size = New System.Drawing.Size(30, 30)
        Me.F3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.F3.TabIndex = 4
        Me.F3.TabStop = False
        Me.F3.Tag = "3"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Location = New System.Drawing.Point(89, 30)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(30, 30)
        Me.F2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.F2.TabIndex = 3
        Me.F2.TabStop = False
        Me.F2.Tag = "2"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Location = New System.Drawing.Point(53, 30)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(30, 30)
        Me.F1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.F1.TabIndex = 2
        Me.F1.TabStop = False
        Me.F1.Tag = "1"
        '
        'Hauptfunktion
        '
        Me.Hauptfunktion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Hauptfunktion.Location = New System.Drawing.Point(3, 30)
        Me.Hauptfunktion.Name = "Hauptfunktion"
        Me.Hauptfunktion.Size = New System.Drawing.Size(30, 30)
        Me.Hauptfunktion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Hauptfunktion.TabIndex = 1
        Me.Hauptfunktion.TabStop = False
        Me.Hauptfunktion.Tag = "0"
        '
        'F4
        '
        Me.F4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F4.Location = New System.Drawing.Point(161, 30)
        Me.F4.Name = "F4"
        Me.F4.Size = New System.Drawing.Size(30, 30)
        Me.F4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.F4.TabIndex = 5
        Me.F4.TabStop = False
        Me.F4.Tag = "4"
        '
        'FunktionenBeenden
        '
        Me.FunktionenBeenden.AutoSize = True
        Me.FunktionenBeenden.BackColor = System.Drawing.Color.WhiteSmoke
        Me.FunktionenBeenden.Location = New System.Drawing.Point(179, 0)
        Me.FunktionenBeenden.Name = "FunktionenBeenden"
        Me.FunktionenBeenden.Size = New System.Drawing.Size(12, 13)
        Me.FunktionenBeenden.TabIndex = 7
        Me.FunktionenBeenden.Text = "x"
        Me.FunktionenBeenden.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SteuerpultFunktionen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.FunktionenBeenden)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.F4)
        Me.Controls.Add(Me.F3)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Hauptfunktion)
        Me.Controls.Add(Me.Loknummer)
        Me.Name = "SteuerpultFunktionen"
        Me.Size = New System.Drawing.Size(192, 206)
        CType(Me.F3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Hauptfunktion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Loknummer As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Hauptfunktion As System.Windows.Forms.PictureBox
    Friend WithEvents F1 As System.Windows.Forms.PictureBox
    Friend WithEvents F2 As System.Windows.Forms.PictureBox
    Friend WithEvents F3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents F4 As System.Windows.Forms.PictureBox
    Friend WithEvents FunktionenBeenden As System.Windows.Forms.Label

End Class
