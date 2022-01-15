<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Steuerpulte
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
        Me.components = New System.ComponentModel.Container()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LoksAuswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SteuerpultToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HinzuToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntfernenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FunktionenDefinierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoksAuswählenToolStripMenuItem, Me.SteuerpultToolStripMenuItem, Me.FunktionenDefinierenToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(191, 70)
        '
        'LoksAuswählenToolStripMenuItem
        '
        Me.LoksAuswählenToolStripMenuItem.Name = "LoksAuswählenToolStripMenuItem"
        Me.LoksAuswählenToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.LoksAuswählenToolStripMenuItem.Text = "Loks Auswählen"
        '
        'SteuerpultToolStripMenuItem
        '
        Me.SteuerpultToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HinzuToolStripMenuItem1, Me.EntfernenToolStripMenuItem1})
        Me.SteuerpultToolStripMenuItem.Name = "SteuerpultToolStripMenuItem"
        Me.SteuerpultToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.SteuerpultToolStripMenuItem.Text = "Steuerpult"
        '
        'HinzuToolStripMenuItem1
        '
        Me.HinzuToolStripMenuItem1.Name = "HinzuToolStripMenuItem1"
        Me.HinzuToolStripMenuItem1.Size = New System.Drawing.Size(125, 22)
        Me.HinzuToolStripMenuItem1.Text = "Hinzu"
        '
        'EntfernenToolStripMenuItem1
        '
        Me.EntfernenToolStripMenuItem1.Name = "EntfernenToolStripMenuItem1"
        Me.EntfernenToolStripMenuItem1.Size = New System.Drawing.Size(125, 22)
        Me.EntfernenToolStripMenuItem1.Text = "Entfernen"
        '
        'FunktionenDefinierenToolStripMenuItem
        '
        Me.FunktionenDefinierenToolStripMenuItem.Name = "FunktionenDefinierenToolStripMenuItem"
        Me.FunktionenDefinierenToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.FunktionenDefinierenToolStripMenuItem.Text = "Funktionen definieren"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.AutoScrollMinSize = New System.Drawing.Size(0, 15)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(341, 190)
        Me.Panel1.TabIndex = 1
        '
        'Steuerpulte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Steuerpulte"
        Me.Size = New System.Drawing.Size(341, 190)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LoksAuswählenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SteuerpultToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HinzuToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EntfernenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FunktionenDefinierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.FlowLayoutPanel

End Class
