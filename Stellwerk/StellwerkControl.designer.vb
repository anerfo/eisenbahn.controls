<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StellwerkControl
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.StellwerkBearbeitenSchließen = New System.Windows.Forms.Label()
        Me.TabControlStellwerk = New System.Windows.Forms.TabControl()
        Me.TabPageWeichen = New System.Windows.Forms.TabPage()
        Me.TabPageKontakte = New System.Windows.Forms.TabPage()
        Me.TabPageStrecken = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StellwerkMenü = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BeschreibungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrößeÄndernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditElement = New System.Windows.Forms.Panel()
        Me.Weicheneinstellungen = New System.Windows.Forms.GroupBox()
        Me.SelectWeiche = New System.Windows.Forms.NumericUpDown()
        Me.ElementBearbeitenText2 = New System.Windows.Forms.Label()
        Me.AddScript = New System.Windows.Forms.GroupBox()
        Me.Einfügen = New System.Windows.Forms.Button()
        Me.Kopieren = New System.Windows.Forms.Button()
        Me.Liste_Skriptbefehle = New System.Windows.Forms.ListBox()
        Me.Skript_hinzu = New System.Windows.Forms.Button()
        Me.S_Richtung = New System.Windows.Forms.ComboBox()
        Me.S_weichenadresse = New System.Windows.Forms.NumericUpDown()
        Me.Skript_entfernen = New System.Windows.Forms.Button()
        Me.KontaktEinstellungen = New System.Windows.Forms.GroupBox()
        Me.SelectAdress = New System.Windows.Forms.NumericUpDown()
        Me.SelectModul = New System.Windows.Forms.NumericUpDown()
        Me.ElementBearbeitenText1 = New System.Windows.Forms.Label()
        Me.EditSchließen = New System.Windows.Forms.Label()
        Me.EditText = New System.Windows.Forms.Label()
        Me.SizeDialog = New System.Windows.Forms.Panel()
        Me.SizeAbbrechen = New System.Windows.Forms.Button()
        Me.SizeY = New System.Windows.Forms.NumericUpDown()
        Me.SizeOK = New System.Windows.Forms.Button()
        Me.SizeWarnung = New System.Windows.Forms.Label()
        Me.SizeLabel1 = New System.Windows.Forms.Label()
        Me.SizeLabel3 = New System.Windows.Forms.Label()
        Me.SizeLabel2 = New System.Windows.Forms.Label()
        Me.SizeOptimum = New System.Windows.Forms.Button()
        Me.SizeX = New System.Windows.Forms.NumericUpDown()
        Me.Panel1.SuspendLayout()
        Me.TabControlStellwerk.SuspendLayout()
        Me.StellwerkMenü.SuspendLayout()
        Me.EditElement.SuspendLayout()
        Me.Weicheneinstellungen.SuspendLayout()
        CType(Me.SelectWeiche, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AddScript.SuspendLayout()
        CType(Me.S_weichenadresse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KontaktEinstellungen.SuspendLayout()
        CType(Me.SelectAdress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectModul, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SizeDialog.SuspendLayout()
        CType(Me.SizeY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SizeX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.StellwerkBearbeitenSchließen)
        Me.Panel1.Controls.Add(Me.TabControlStellwerk)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(15, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(180, 234)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Visible = False
        '
        'StellwerkBearbeitenSchließen
        '
        Me.StellwerkBearbeitenSchließen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StellwerkBearbeitenSchließen.BackColor = System.Drawing.Color.Red
        Me.StellwerkBearbeitenSchließen.Font = New System.Drawing.Font("Arial Black", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StellwerkBearbeitenSchließen.Location = New System.Drawing.Point(163, 0)
        Me.StellwerkBearbeitenSchließen.Name = "StellwerkBearbeitenSchließen"
        Me.StellwerkBearbeitenSchließen.Size = New System.Drawing.Size(15, 16)
        Me.StellwerkBearbeitenSchließen.TabIndex = 3
        Me.StellwerkBearbeitenSchließen.Text = "x"
        Me.StellwerkBearbeitenSchließen.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TabControlStellwerk
        '
        Me.TabControlStellwerk.Controls.Add(Me.TabPageWeichen)
        Me.TabControlStellwerk.Controls.Add(Me.TabPageKontakte)
        Me.TabControlStellwerk.Controls.Add(Me.TabPageStrecken)
        Me.TabControlStellwerk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlStellwerk.Location = New System.Drawing.Point(0, 16)
        Me.TabControlStellwerk.Name = "TabControlStellwerk"
        Me.TabControlStellwerk.SelectedIndex = 0
        Me.TabControlStellwerk.Size = New System.Drawing.Size(178, 216)
        Me.TabControlStellwerk.TabIndex = 1
        '
        'TabPageWeichen
        '
        Me.TabPageWeichen.AutoScroll = True
        Me.TabPageWeichen.Location = New System.Drawing.Point(4, 22)
        Me.TabPageWeichen.Name = "TabPageWeichen"
        Me.TabPageWeichen.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageWeichen.Size = New System.Drawing.Size(170, 190)
        Me.TabPageWeichen.TabIndex = 0
        Me.TabPageWeichen.Text = "Weichen"
        Me.TabPageWeichen.UseVisualStyleBackColor = True
        '
        'TabPageKontakte
        '
        Me.TabPageKontakte.AutoScroll = True
        Me.TabPageKontakte.Location = New System.Drawing.Point(4, 22)
        Me.TabPageKontakte.Name = "TabPageKontakte"
        Me.TabPageKontakte.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageKontakte.Size = New System.Drawing.Size(170, 190)
        Me.TabPageKontakte.TabIndex = 1
        Me.TabPageKontakte.Text = "Kontakte"
        Me.TabPageKontakte.UseVisualStyleBackColor = True
        '
        'TabPageStrecken
        '
        Me.TabPageStrecken.AutoScroll = True
        Me.TabPageStrecken.Location = New System.Drawing.Point(4, 22)
        Me.TabPageStrecken.Name = "TabPageStrecken"
        Me.TabPageStrecken.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageStrecken.Size = New System.Drawing.Size(170, 190)
        Me.TabPageStrecken.TabIndex = 2
        Me.TabPageStrecken.Text = "Strecken"
        Me.TabPageStrecken.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Stellwerk bearbeiten"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StellwerkMenü
        '
        Me.StellwerkMenü.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeschreibungenToolStripMenuItem, Me.BearbeitenToolStripMenuItem, Me.GrößeÄndernToolStripMenuItem})
        Me.StellwerkMenü.Name = "StellwerkMenü"
        Me.StellwerkMenü.Size = New System.Drawing.Size(147, 70)
        '
        'BeschreibungenToolStripMenuItem
        '
        Me.BeschreibungenToolStripMenuItem.Name = "BeschreibungenToolStripMenuItem"
        Me.BeschreibungenToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.BeschreibungenToolStripMenuItem.Text = "Beschriftung"
        '
        'BearbeitenToolStripMenuItem
        '
        Me.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem"
        Me.BearbeitenToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.BearbeitenToolStripMenuItem.Text = "Bearbeiten"
        '
        'GrößeÄndernToolStripMenuItem
        '
        Me.GrößeÄndernToolStripMenuItem.Name = "GrößeÄndernToolStripMenuItem"
        Me.GrößeÄndernToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.GrößeÄndernToolStripMenuItem.Text = "Größe ändern"
        Me.GrößeÄndernToolStripMenuItem.Visible = False
        '
        'EditElement
        '
        Me.EditElement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EditElement.Controls.Add(Me.Weicheneinstellungen)
        Me.EditElement.Controls.Add(Me.AddScript)
        Me.EditElement.Controls.Add(Me.KontaktEinstellungen)
        Me.EditElement.Controls.Add(Me.EditSchließen)
        Me.EditElement.Controls.Add(Me.EditText)
        Me.EditElement.Location = New System.Drawing.Point(210, 5)
        Me.EditElement.Name = "EditElement"
        Me.EditElement.Size = New System.Drawing.Size(161, 233)
        Me.EditElement.TabIndex = 1
        Me.EditElement.Visible = False
        '
        'Weicheneinstellungen
        '
        Me.Weicheneinstellungen.Controls.Add(Me.SelectWeiche)
        Me.Weicheneinstellungen.Controls.Add(Me.ElementBearbeitenText2)
        Me.Weicheneinstellungen.Location = New System.Drawing.Point(2, 176)
        Me.Weicheneinstellungen.Name = "Weicheneinstellungen"
        Me.Weicheneinstellungen.Size = New System.Drawing.Size(154, 47)
        Me.Weicheneinstellungen.TabIndex = 6
        Me.Weicheneinstellungen.TabStop = False
        Me.Weicheneinstellungen.Text = "Weichenadresse zuordnen"
        '
        'SelectWeiche
        '
        Me.SelectWeiche.Location = New System.Drawing.Point(57, 15)
        Me.SelectWeiche.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.SelectWeiche.Name = "SelectWeiche"
        Me.SelectWeiche.Size = New System.Drawing.Size(40, 20)
        Me.SelectWeiche.TabIndex = 4
        Me.SelectWeiche.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ElementBearbeitenText2
        '
        Me.ElementBearbeitenText2.AutoSize = True
        Me.ElementBearbeitenText2.Location = New System.Drawing.Point(6, 18)
        Me.ElementBearbeitenText2.Name = "ElementBearbeitenText2"
        Me.ElementBearbeitenText2.Size = New System.Drawing.Size(45, 13)
        Me.ElementBearbeitenText2.TabIndex = 2
        Me.ElementBearbeitenText2.Text = "Adresse"
        '
        'AddScript
        '
        Me.AddScript.Controls.Add(Me.Einfügen)
        Me.AddScript.Controls.Add(Me.Kopieren)
        Me.AddScript.Controls.Add(Me.Liste_Skriptbefehle)
        Me.AddScript.Controls.Add(Me.Skript_hinzu)
        Me.AddScript.Controls.Add(Me.S_Richtung)
        Me.AddScript.Controls.Add(Me.S_weichenadresse)
        Me.AddScript.Controls.Add(Me.Skript_entfernen)
        Me.AddScript.Location = New System.Drawing.Point(3, 21)
        Me.AddScript.Name = "AddScript"
        Me.AddScript.Size = New System.Drawing.Size(153, 153)
        Me.AddScript.TabIndex = 5
        Me.AddScript.TabStop = False
        Me.AddScript.Text = "Skript hinzufügen"
        '
        'Einfügen
        '
        Me.Einfügen.Enabled = False
        Me.Einfügen.Location = New System.Drawing.Point(80, 124)
        Me.Einfügen.Name = "Einfügen"
        Me.Einfügen.Size = New System.Drawing.Size(67, 23)
        Me.Einfügen.TabIndex = 8
        Me.Einfügen.Text = "Einfügen"
        Me.Einfügen.UseVisualStyleBackColor = True
        '
        'Kopieren
        '
        Me.Kopieren.Location = New System.Drawing.Point(6, 124)
        Me.Kopieren.Name = "Kopieren"
        Me.Kopieren.Size = New System.Drawing.Size(65, 23)
        Me.Kopieren.TabIndex = 7
        Me.Kopieren.Text = "Kopieren"
        Me.Kopieren.UseVisualStyleBackColor = True
        '
        'Liste_Skriptbefehle
        '
        Me.Liste_Skriptbefehle.FormattingEnabled = True
        Me.Liste_Skriptbefehle.Location = New System.Drawing.Point(6, 14)
        Me.Liste_Skriptbefehle.Name = "Liste_Skriptbefehle"
        Me.Liste_Skriptbefehle.Size = New System.Drawing.Size(65, 108)
        Me.Liste_Skriptbefehle.TabIndex = 7
        '
        'Skript_hinzu
        '
        Me.Skript_hinzu.Location = New System.Drawing.Point(80, 72)
        Me.Skript_hinzu.Name = "Skript_hinzu"
        Me.Skript_hinzu.Size = New System.Drawing.Size(67, 24)
        Me.Skript_hinzu.TabIndex = 8
        Me.Skript_hinzu.Text = "hinzu"
        Me.Skript_hinzu.UseVisualStyleBackColor = True
        '
        'S_Richtung
        '
        Me.S_Richtung.FormattingEnabled = True
        Me.S_Richtung.Items.AddRange(New Object() {"rechts", "links", "rot", "grün", "schalten", "Musik"})
        Me.S_Richtung.Location = New System.Drawing.Point(77, 45)
        Me.S_Richtung.Name = "S_Richtung"
        Me.S_Richtung.Size = New System.Drawing.Size(70, 21)
        Me.S_Richtung.TabIndex = 11
        Me.S_Richtung.Text = "schalten"
        '
        'S_weichenadresse
        '
        Me.S_weichenadresse.Location = New System.Drawing.Point(77, 19)
        Me.S_weichenadresse.Name = "S_weichenadresse"
        Me.S_weichenadresse.Size = New System.Drawing.Size(70, 20)
        Me.S_weichenadresse.TabIndex = 9
        Me.S_weichenadresse.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Skript_entfernen
        '
        Me.Skript_entfernen.Location = New System.Drawing.Point(80, 98)
        Me.Skript_entfernen.Name = "Skript_entfernen"
        Me.Skript_entfernen.Size = New System.Drawing.Size(67, 24)
        Me.Skript_entfernen.TabIndex = 10
        Me.Skript_entfernen.Text = "löschen"
        Me.Skript_entfernen.UseVisualStyleBackColor = True
        '
        'KontaktEinstellungen
        '
        Me.KontaktEinstellungen.Controls.Add(Me.SelectAdress)
        Me.KontaktEinstellungen.Controls.Add(Me.SelectModul)
        Me.KontaktEinstellungen.Controls.Add(Me.ElementBearbeitenText1)
        Me.KontaktEinstellungen.Location = New System.Drawing.Point(-1, 180)
        Me.KontaktEinstellungen.Name = "KontaktEinstellungen"
        Me.KontaktEinstellungen.Size = New System.Drawing.Size(157, 43)
        Me.KontaktEinstellungen.TabIndex = 4
        Me.KontaktEinstellungen.TabStop = False
        Me.KontaktEinstellungen.Text = "Kontaktadresse zuordnen"
        '
        'SelectAdress
        '
        Me.SelectAdress.Location = New System.Drawing.Point(120, 15)
        Me.SelectAdress.Maximum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.SelectAdress.Name = "SelectAdress"
        Me.SelectAdress.Size = New System.Drawing.Size(35, 20)
        Me.SelectAdress.TabIndex = 4
        Me.SelectAdress.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'SelectModul
        '
        Me.SelectModul.Location = New System.Drawing.Point(40, 15)
        Me.SelectModul.Name = "SelectModul"
        Me.SelectModul.Size = New System.Drawing.Size(35, 20)
        Me.SelectModul.TabIndex = 3
        Me.SelectModul.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ElementBearbeitenText1
        '
        Me.ElementBearbeitenText1.AutoSize = True
        Me.ElementBearbeitenText1.Location = New System.Drawing.Point(6, 18)
        Me.ElementBearbeitenText1.Name = "ElementBearbeitenText1"
        Me.ElementBearbeitenText1.Size = New System.Drawing.Size(116, 13)
        Me.ElementBearbeitenText1.TabIndex = 2
        Me.ElementBearbeitenText1.Text = "Modul              Adresse"
        '
        'EditSchließen
        '
        Me.EditSchließen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditSchließen.BackColor = System.Drawing.Color.Red
        Me.EditSchließen.Font = New System.Drawing.Font("Arial Black", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditSchließen.Location = New System.Drawing.Point(145, 0)
        Me.EditSchließen.Name = "EditSchließen"
        Me.EditSchließen.Size = New System.Drawing.Size(15, 16)
        Me.EditSchließen.TabIndex = 3
        Me.EditSchließen.Text = "x"
        Me.EditSchließen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EditText
        '
        Me.EditText.BackColor = System.Drawing.Color.Silver
        Me.EditText.Dock = System.Windows.Forms.DockStyle.Top
        Me.EditText.Location = New System.Drawing.Point(0, 0)
        Me.EditText.Name = "EditText"
        Me.EditText.Size = New System.Drawing.Size(159, 16)
        Me.EditText.TabIndex = 0
        Me.EditText.Text = "Element bearbeiten"
        Me.EditText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SizeDialog
        '
        Me.SizeDialog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SizeDialog.Controls.Add(Me.SizeAbbrechen)
        Me.SizeDialog.Controls.Add(Me.SizeY)
        Me.SizeDialog.Controls.Add(Me.SizeOK)
        Me.SizeDialog.Controls.Add(Me.SizeWarnung)
        Me.SizeDialog.Controls.Add(Me.SizeLabel1)
        Me.SizeDialog.Controls.Add(Me.SizeLabel3)
        Me.SizeDialog.Controls.Add(Me.SizeLabel2)
        Me.SizeDialog.Controls.Add(Me.SizeOptimum)
        Me.SizeDialog.Controls.Add(Me.SizeX)
        Me.SizeDialog.Location = New System.Drawing.Point(342, 4)
        Me.SizeDialog.Name = "SizeDialog"
        Me.SizeDialog.Size = New System.Drawing.Size(220, 117)
        Me.SizeDialog.TabIndex = 2
        Me.SizeDialog.Visible = False
        '
        'SizeAbbrechen
        '
        Me.SizeAbbrechen.Location = New System.Drawing.Point(140, 89)
        Me.SizeAbbrechen.Name = "SizeAbbrechen"
        Me.SizeAbbrechen.Size = New System.Drawing.Size(75, 23)
        Me.SizeAbbrechen.TabIndex = 8
        Me.SizeAbbrechen.Text = "Abbrechen"
        Me.SizeAbbrechen.UseVisualStyleBackColor = True
        '
        'SizeY
        '
        Me.SizeY.Location = New System.Drawing.Point(120, 44)
        Me.SizeY.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SizeY.Name = "SizeY"
        Me.SizeY.Size = New System.Drawing.Size(38, 20)
        Me.SizeY.TabIndex = 1
        Me.SizeY.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'SizeOK
        '
        Me.SizeOK.Location = New System.Drawing.Point(6, 89)
        Me.SizeOK.Name = "SizeOK"
        Me.SizeOK.Size = New System.Drawing.Size(75, 23)
        Me.SizeOK.TabIndex = 2
        Me.SizeOK.Text = "OK"
        Me.SizeOK.UseVisualStyleBackColor = True
        '
        'SizeWarnung
        '
        Me.SizeWarnung.Location = New System.Drawing.Point(3, 63)
        Me.SizeWarnung.Name = "SizeWarnung"
        Me.SizeWarnung.Size = New System.Drawing.Size(216, 33)
        Me.SizeWarnung.TabIndex = 7
        '
        'SizeLabel1
        '
        Me.SizeLabel1.AutoSize = True
        Me.SizeLabel1.Location = New System.Drawing.Point(2, 0)
        Me.SizeLabel1.Name = "SizeLabel1"
        Me.SizeLabel1.Size = New System.Drawing.Size(217, 13)
        Me.SizeLabel1.TabIndex = 6
        Me.SizeLabel1.Text = "Verändern der Anzahl der angezeigten Bilder"
        '
        'SizeLabel3
        '
        Me.SizeLabel3.AutoSize = True
        Me.SizeLabel3.Location = New System.Drawing.Point(11, 46)
        Me.SizeLabel3.Name = "SizeLabel3"
        Me.SizeLabel3.Size = New System.Drawing.Size(103, 13)
        Me.SizeLabel3.TabIndex = 5
        Me.SizeLabel3.Text = "Bilder in Y-Richtung:"
        '
        'SizeLabel2
        '
        Me.SizeLabel2.AutoSize = True
        Me.SizeLabel2.Location = New System.Drawing.Point(11, 20)
        Me.SizeLabel2.Name = "SizeLabel2"
        Me.SizeLabel2.Size = New System.Drawing.Size(103, 13)
        Me.SizeLabel2.TabIndex = 4
        Me.SizeLabel2.Text = "Bilder in X-Richtung:"
        '
        'SizeOptimum
        '
        Me.SizeOptimum.Location = New System.Drawing.Point(164, 18)
        Me.SizeOptimum.Name = "SizeOptimum"
        Me.SizeOptimum.Size = New System.Drawing.Size(51, 46)
        Me.SizeOptimum.TabIndex = 3
        Me.SizeOptimum.Text = "Optimal"
        Me.SizeOptimum.UseVisualStyleBackColor = True
        '
        'SizeX
        '
        Me.SizeX.Location = New System.Drawing.Point(120, 18)
        Me.SizeX.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SizeX.Name = "SizeX"
        Me.SizeX.Size = New System.Drawing.Size(38, 20)
        Me.SizeX.TabIndex = 0
        Me.SizeX.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'StellwerkControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContextMenuStrip = Me.StellwerkMenü
        Me.Controls.Add(Me.EditElement)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.SizeDialog)
        Me.DoubleBuffered = True
        Me.Name = "StellwerkControl"
        Me.Size = New System.Drawing.Size(565, 340)
        Me.Panel1.ResumeLayout(False)
        Me.TabControlStellwerk.ResumeLayout(False)
        Me.StellwerkMenü.ResumeLayout(False)
        Me.EditElement.ResumeLayout(False)
        Me.Weicheneinstellungen.ResumeLayout(False)
        Me.Weicheneinstellungen.PerformLayout()
        CType(Me.SelectWeiche, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AddScript.ResumeLayout(False)
        CType(Me.S_weichenadresse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KontaktEinstellungen.ResumeLayout(False)
        Me.KontaktEinstellungen.PerformLayout()
        CType(Me.SelectAdress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectModul, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SizeDialog.ResumeLayout(False)
        Me.SizeDialog.PerformLayout()
        CType(Me.SizeY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SizeX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents TabControlStellwerk As System.Windows.Forms.TabControl
    Private WithEvents TabPageWeichen As System.Windows.Forms.TabPage
    Private WithEvents TabPageKontakte As System.Windows.Forms.TabPage
    Private WithEvents StellwerkMenü As System.Windows.Forms.ContextMenuStrip
    Private WithEvents BearbeitenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents TabPageStrecken As System.Windows.Forms.TabPage
    Private WithEvents EditElement As System.Windows.Forms.Panel
    Private WithEvents EditText As System.Windows.Forms.Label
    Private WithEvents StellwerkBearbeitenSchließen As System.Windows.Forms.Label
    Private WithEvents EditSchließen As System.Windows.Forms.Label
    Private WithEvents KontaktEinstellungen As System.Windows.Forms.GroupBox
    Private WithEvents ElementBearbeitenText1 As System.Windows.Forms.Label
    Private WithEvents SelectAdress As System.Windows.Forms.NumericUpDown
    Private WithEvents SelectModul As System.Windows.Forms.NumericUpDown
    Private WithEvents AddScript As System.Windows.Forms.GroupBox
    Private WithEvents Liste_Skriptbefehle As System.Windows.Forms.ListBox
    Private WithEvents Skript_hinzu As System.Windows.Forms.Button
    Private WithEvents S_Richtung As System.Windows.Forms.ComboBox
    Private WithEvents S_weichenadresse As System.Windows.Forms.NumericUpDown
    Private WithEvents Skript_entfernen As System.Windows.Forms.Button
    Private WithEvents Weicheneinstellungen As System.Windows.Forms.GroupBox
    Private WithEvents SelectWeiche As System.Windows.Forms.NumericUpDown
    Private WithEvents ElementBearbeitenText2 As System.Windows.Forms.Label
    Friend WithEvents Einfügen As System.Windows.Forms.Button
    Friend WithEvents Kopieren As System.Windows.Forms.Button
    Friend WithEvents GrößeÄndernToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SizeDialog As System.Windows.Forms.Panel
    Friend WithEvents SizeLabel3 As System.Windows.Forms.Label
    Friend WithEvents SizeLabel2 As System.Windows.Forms.Label
    Friend WithEvents SizeOptimum As System.Windows.Forms.Button
    Friend WithEvents SizeOK As System.Windows.Forms.Button
    Friend WithEvents SizeY As System.Windows.Forms.NumericUpDown
    Friend WithEvents SizeX As System.Windows.Forms.NumericUpDown
    Friend WithEvents SizeLabel1 As System.Windows.Forms.Label
    Friend WithEvents SizeWarnung As System.Windows.Forms.Label
    Friend WithEvents BeschreibungenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SizeAbbrechen As System.Windows.Forms.Button

End Class
