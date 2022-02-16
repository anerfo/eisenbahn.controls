namespace Webcams
{
    partial class WebcamController
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddWebcamButton = new System.Windows.Forms.Button();
            this.RemoveWebcamButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PropertiesGroup = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.PropertiesGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddWebcamButton
            // 
            this.AddWebcamButton.Location = new System.Drawing.Point(6, 19);
            this.AddWebcamButton.Name = "AddWebcamButton";
            this.AddWebcamButton.Size = new System.Drawing.Size(120, 23);
            this.AddWebcamButton.TabIndex = 0;
            this.AddWebcamButton.Text = "Add";
            this.AddWebcamButton.UseVisualStyleBackColor = true;
            this.AddWebcamButton.Click += new System.EventHandler(this.AddWebcam_Click);
            // 
            // RemoveWebcamButton
            // 
            this.RemoveWebcamButton.Location = new System.Drawing.Point(6, 149);
            this.RemoveWebcamButton.Name = "RemoveWebcamButton";
            this.RemoveWebcamButton.Size = new System.Drawing.Size(120, 23);
            this.RemoveWebcamButton.TabIndex = 1;
            this.RemoveWebcamButton.Text = "Remove";
            this.RemoveWebcamButton.UseVisualStyleBackColor = true;
            this.RemoveWebcamButton.Click += new System.EventHandler(this.RemoveWebcam_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 48);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(47, 48);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 95);
            this.listBox2.TabIndex = 3;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.AddWebcamButton);
            this.groupBox1.Controls.Add(this.RemoveWebcamButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 179);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Webcams";
            // 
            // PropertiesGroup
            // 
            this.PropertiesGroup.Controls.Add(this.label2);
            this.PropertiesGroup.Controls.Add(this.label1);
            this.PropertiesGroup.Controls.Add(this.textBox1);
            this.PropertiesGroup.Controls.Add(this.listBox2);
            this.PropertiesGroup.Enabled = false;
            this.PropertiesGroup.Location = new System.Drawing.Point(141, 3);
            this.PropertiesGroup.Name = "PropertiesGroup";
            this.PropertiesGroup.Size = new System.Drawing.Size(175, 179);
            this.PropertiesGroup.TabIndex = 5;
            this.PropertiesGroup.TabStop = false;
            this.PropertiesGroup.Text = "Eigenschaften";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(47, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quelle";
            // 
            // WebcamController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.PropertiesGroup);
            this.Controls.Add(this.groupBox1);
            this.Name = "WebcamController";
            this.Size = new System.Drawing.Size(324, 189);
            this.groupBox1.ResumeLayout(false);
            this.PropertiesGroup.ResumeLayout(false);
            this.PropertiesGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddWebcamButton;
        private System.Windows.Forms.Button RemoveWebcamButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox PropertiesGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
