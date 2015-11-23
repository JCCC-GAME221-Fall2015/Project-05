namespace P04_Map_Maker {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.countBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.activationBox = new System.Windows.Forms.NumericUpDown();
            this.radioButtonSwitch4 = new RadioButtonSwitch();
            this.radioButtonSwitch1 = new RadioButtonSwitch();
            this.radioButtonSwitch19 = new RadioButtonSwitch();
            this.radioButtonSwitch2 = new RadioButtonSwitch();
            this.radioButtonSwitch18 = new RadioButtonSwitch();
            this.radioButtonSwitch3 = new RadioButtonSwitch();
            this.radioButtonSwitch17 = new RadioButtonSwitch();
            this.radioButtonSwitch6 = new RadioButtonSwitch();
            this.radioButtonSwitch16 = new RadioButtonSwitch();
            this.radioButtonSwitch5 = new RadioButtonSwitch();
            this.radioButtonSwitch13 = new RadioButtonSwitch();
            this.radioButtonSwitch9 = new RadioButtonSwitch();
            this.radioButtonSwitch14 = new RadioButtonSwitch();
            this.radioButtonSwitch8 = new RadioButtonSwitch();
            this.radioButtonSwitch15 = new RadioButtonSwitch();
            this.radioButtonSwitch7 = new RadioButtonSwitch();
            this.radioButtonSwitch10 = new RadioButtonSwitch();
            this.radioButtonSwitch12 = new RadioButtonSwitch();
            this.radioButtonSwitch11 = new RadioButtonSwitch();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activationBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(522, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 38);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
            this.loadToolStripMenuItem.Text = "Open";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(77, 38);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 38);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Activation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Count";
            // 
            // typeBox
            // 
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Items.AddRange(new object[] {
            "Grain",
            "Brick",
            "Wood",
            "Wool"});
            this.typeBox.Location = new System.Drawing.Point(339, 81);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(121, 33);
            this.typeBox.TabIndex = 24;
            this.typeBox.SelectedIndexChanged += new System.EventHandler(this.typeBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 25);
            this.label3.TabIndex = 25;
            this.label3.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 25);
            this.label4.TabIndex = 27;
            this.label4.Text = "Map Name";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(32, 83);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(258, 31);
            this.nameBox.TabIndex = 28;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // countBox
            // 
            this.countBox.Location = new System.Drawing.Point(339, 266);
            this.countBox.Name = "countBox";
            this.countBox.Size = new System.Drawing.Size(121, 31);
            this.countBox.TabIndex = 51;
            this.countBox.ValueChanged += new System.EventHandler(this.countBox_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonSwitch4);
            this.groupBox1.Controls.Add(this.radioButtonSwitch1);
            this.groupBox1.Controls.Add(this.radioButtonSwitch19);
            this.groupBox1.Controls.Add(this.radioButtonSwitch2);
            this.groupBox1.Controls.Add(this.radioButtonSwitch18);
            this.groupBox1.Controls.Add(this.radioButtonSwitch3);
            this.groupBox1.Controls.Add(this.radioButtonSwitch17);
            this.groupBox1.Controls.Add(this.radioButtonSwitch6);
            this.groupBox1.Controls.Add(this.radioButtonSwitch16);
            this.groupBox1.Controls.Add(this.radioButtonSwitch5);
            this.groupBox1.Controls.Add(this.radioButtonSwitch13);
            this.groupBox1.Controls.Add(this.radioButtonSwitch9);
            this.groupBox1.Controls.Add(this.radioButtonSwitch14);
            this.groupBox1.Controls.Add(this.radioButtonSwitch8);
            this.groupBox1.Controls.Add(this.radioButtonSwitch15);
            this.groupBox1.Controls.Add(this.radioButtonSwitch7);
            this.groupBox1.Controls.Add(this.radioButtonSwitch10);
            this.groupBox1.Controls.Add(this.radioButtonSwitch12);
            this.groupBox1.Controls.Add(this.radioButtonSwitch11);
            this.groupBox1.Location = new System.Drawing.Point(32, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 197);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tiles";
            // 
            // activationBox
            // 
            this.activationBox.Location = new System.Drawing.Point(339, 173);
            this.activationBox.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.activationBox.Name = "activationBox";
            this.activationBox.Size = new System.Drawing.Size(121, 31);
            this.activationBox.TabIndex = 53;
            this.activationBox.ValueChanged += new System.EventHandler(this.activationBox_ValueChanged);
            // 
            // radioButtonSwitch4
            // 
            this.radioButtonSwitch4.AutoSize = true;
            this.radioButtonSwitch4.ID = 5;
            this.radioButtonSwitch4.Location = new System.Drawing.Point(103, 68);
            this.radioButtonSwitch4.Name = "radioButtonSwitch4";
            this.radioButtonSwitch4.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch4.TabIndex = 37;
            this.radioButtonSwitch4.TabStop = true;
            this.radioButtonSwitch4.UseVisualStyleBackColor = true;
            this.radioButtonSwitch4.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch1
            // 
            this.radioButtonSwitch1.AutoSize = true;
            this.radioButtonSwitch1.ID = 0;
            this.radioButtonSwitch1.Location = new System.Drawing.Point(49, 38);
            this.radioButtonSwitch1.Name = "radioButtonSwitch1";
            this.radioButtonSwitch1.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch1.TabIndex = 30;
            this.radioButtonSwitch1.TabStop = true;
            this.radioButtonSwitch1.UseVisualStyleBackColor = true;
            // 
            // radioButtonSwitch19
            // 
            this.radioButtonSwitch19.AutoSize = true;
            this.radioButtonSwitch19.ID = 15;
            this.radioButtonSwitch19.Location = new System.Drawing.Point(136, 126);
            this.radioButtonSwitch19.Name = "radioButtonSwitch19";
            this.radioButtonSwitch19.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch19.TabIndex = 50;
            this.radioButtonSwitch19.TabStop = true;
            this.radioButtonSwitch19.UseVisualStyleBackColor = true;
            this.radioButtonSwitch19.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch2
            // 
            this.radioButtonSwitch2.AutoSize = true;
            this.radioButtonSwitch2.ID = 1;
            this.radioButtonSwitch2.Location = new System.Drawing.Point(82, 38);
            this.radioButtonSwitch2.Name = "radioButtonSwitch2";
            this.radioButtonSwitch2.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch2.TabIndex = 31;
            this.radioButtonSwitch2.TabStop = true;
            this.radioButtonSwitch2.UseVisualStyleBackColor = true;
            this.radioButtonSwitch2.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch18
            // 
            this.radioButtonSwitch18.AutoSize = true;
            this.radioButtonSwitch18.ID = 11;
            this.radioButtonSwitch18.Location = new System.Drawing.Point(152, 97);
            this.radioButtonSwitch18.Name = "radioButtonSwitch18";
            this.radioButtonSwitch18.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch18.TabIndex = 49;
            this.radioButtonSwitch18.TabStop = true;
            this.radioButtonSwitch18.UseVisualStyleBackColor = true;
            this.radioButtonSwitch18.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch3
            // 
            this.radioButtonSwitch3.AutoSize = true;
            this.radioButtonSwitch3.ID = 2;
            this.radioButtonSwitch3.Location = new System.Drawing.Point(115, 38);
            this.radioButtonSwitch3.Name = "radioButtonSwitch3";
            this.radioButtonSwitch3.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch3.TabIndex = 32;
            this.radioButtonSwitch3.TabStop = true;
            this.radioButtonSwitch3.UseVisualStyleBackColor = true;
            this.radioButtonSwitch3.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch17
            // 
            this.radioButtonSwitch17.AutoSize = true;
            this.radioButtonSwitch17.ID = 6;
            this.radioButtonSwitch17.Location = new System.Drawing.Point(136, 68);
            this.radioButtonSwitch17.Name = "radioButtonSwitch17";
            this.radioButtonSwitch17.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch17.TabIndex = 48;
            this.radioButtonSwitch17.TabStop = true;
            this.radioButtonSwitch17.UseVisualStyleBackColor = true;
            this.radioButtonSwitch17.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch6
            // 
            this.radioButtonSwitch6.AutoSize = true;
            this.radioButtonSwitch6.ID = 3;
            this.radioButtonSwitch6.Location = new System.Drawing.Point(37, 68);
            this.radioButtonSwitch6.Name = "radioButtonSwitch6";
            this.radioButtonSwitch6.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch6.TabIndex = 35;
            this.radioButtonSwitch6.TabStop = true;
            this.radioButtonSwitch6.UseVisualStyleBackColor = true;
            this.radioButtonSwitch6.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch16
            // 
            this.radioButtonSwitch16.AutoSize = true;
            this.radioButtonSwitch16.ID = 10;
            this.radioButtonSwitch16.Location = new System.Drawing.Point(119, 97);
            this.radioButtonSwitch16.Name = "radioButtonSwitch16";
            this.radioButtonSwitch16.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch16.TabIndex = 47;
            this.radioButtonSwitch16.TabStop = true;
            this.radioButtonSwitch16.UseVisualStyleBackColor = true;
            this.radioButtonSwitch16.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch5
            // 
            this.radioButtonSwitch5.AutoSize = true;
            this.radioButtonSwitch5.ID = 4;
            this.radioButtonSwitch5.Location = new System.Drawing.Point(70, 68);
            this.radioButtonSwitch5.Name = "radioButtonSwitch5";
            this.radioButtonSwitch5.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch5.TabIndex = 36;
            this.radioButtonSwitch5.TabStop = true;
            this.radioButtonSwitch5.UseVisualStyleBackColor = true;
            this.radioButtonSwitch5.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch13
            // 
            this.radioButtonSwitch13.AutoSize = true;
            this.radioButtonSwitch13.ID = 18;
            this.radioButtonSwitch13.Location = new System.Drawing.Point(119, 156);
            this.radioButtonSwitch13.Name = "radioButtonSwitch13";
            this.radioButtonSwitch13.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch13.TabIndex = 46;
            this.radioButtonSwitch13.TabStop = true;
            this.radioButtonSwitch13.UseVisualStyleBackColor = true;
            this.radioButtonSwitch13.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch9
            // 
            this.radioButtonSwitch9.AutoSize = true;
            this.radioButtonSwitch9.ID = 7;
            this.radioButtonSwitch9.Location = new System.Drawing.Point(16, 97);
            this.radioButtonSwitch9.Name = "radioButtonSwitch9";
            this.radioButtonSwitch9.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch9.TabIndex = 38;
            this.radioButtonSwitch9.TabStop = true;
            this.radioButtonSwitch9.UseVisualStyleBackColor = true;
            this.radioButtonSwitch9.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch14
            // 
            this.radioButtonSwitch14.AutoSize = true;
            this.radioButtonSwitch14.ID = 17;
            this.radioButtonSwitch14.Location = new System.Drawing.Point(86, 156);
            this.radioButtonSwitch14.Name = "radioButtonSwitch14";
            this.radioButtonSwitch14.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch14.TabIndex = 45;
            this.radioButtonSwitch14.TabStop = true;
            this.radioButtonSwitch14.UseVisualStyleBackColor = true;
            this.radioButtonSwitch14.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch8
            // 
            this.radioButtonSwitch8.AutoSize = true;
            this.radioButtonSwitch8.ID = 8;
            this.radioButtonSwitch8.Location = new System.Drawing.Point(49, 97);
            this.radioButtonSwitch8.Name = "radioButtonSwitch8";
            this.radioButtonSwitch8.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch8.TabIndex = 39;
            this.radioButtonSwitch8.TabStop = true;
            this.radioButtonSwitch8.UseVisualStyleBackColor = true;
            this.radioButtonSwitch8.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch15
            // 
            this.radioButtonSwitch15.AutoSize = true;
            this.radioButtonSwitch15.ID = 16;
            this.radioButtonSwitch15.Location = new System.Drawing.Point(53, 156);
            this.radioButtonSwitch15.Name = "radioButtonSwitch15";
            this.radioButtonSwitch15.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch15.TabIndex = 44;
            this.radioButtonSwitch15.TabStop = true;
            this.radioButtonSwitch15.UseVisualStyleBackColor = true;
            this.radioButtonSwitch15.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch7
            // 
            this.radioButtonSwitch7.AutoSize = true;
            this.radioButtonSwitch7.ID = 9;
            this.radioButtonSwitch7.Location = new System.Drawing.Point(82, 97);
            this.radioButtonSwitch7.Name = "radioButtonSwitch7";
            this.radioButtonSwitch7.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch7.TabIndex = 40;
            this.radioButtonSwitch7.TabStop = true;
            this.radioButtonSwitch7.UseVisualStyleBackColor = true;
            this.radioButtonSwitch7.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch10
            // 
            this.radioButtonSwitch10.AutoSize = true;
            this.radioButtonSwitch10.ID = 14;
            this.radioButtonSwitch10.Location = new System.Drawing.Point(103, 126);
            this.radioButtonSwitch10.Name = "radioButtonSwitch10";
            this.radioButtonSwitch10.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch10.TabIndex = 43;
            this.radioButtonSwitch10.TabStop = true;
            this.radioButtonSwitch10.UseVisualStyleBackColor = true;
            this.radioButtonSwitch10.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch12
            // 
            this.radioButtonSwitch12.AutoSize = true;
            this.radioButtonSwitch12.ID = 12;
            this.radioButtonSwitch12.Location = new System.Drawing.Point(37, 126);
            this.radioButtonSwitch12.Name = "radioButtonSwitch12";
            this.radioButtonSwitch12.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch12.TabIndex = 41;
            this.radioButtonSwitch12.TabStop = true;
            this.radioButtonSwitch12.UseVisualStyleBackColor = true;
            this.radioButtonSwitch12.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // radioButtonSwitch11
            // 
            this.radioButtonSwitch11.AutoSize = true;
            this.radioButtonSwitch11.ID = 13;
            this.radioButtonSwitch11.Location = new System.Drawing.Point(70, 126);
            this.radioButtonSwitch11.Name = "radioButtonSwitch11";
            this.radioButtonSwitch11.Size = new System.Drawing.Size(27, 26);
            this.radioButtonSwitch11.TabIndex = 42;
            this.radioButtonSwitch11.TabStop = true;
            this.radioButtonSwitch11.UseVisualStyleBackColor = true;
            this.radioButtonSwitch11.CheckedChanged += new System.EventHandler(this.radioButtonSwitch_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 339);
            this.Controls.Add(this.activationBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.countBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Title Of Catan - Map Maker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activationBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

}

#endregion

private System.Windows.Forms.MenuStrip menuStrip1;
private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
private System.Windows.Forms.Label label1;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.ComboBox typeBox;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.Label label4;
private System.Windows.Forms.TextBox nameBox;
private RadioButtonSwitch radioButtonSwitch1;
private RadioButtonSwitch radioButtonSwitch2;
private RadioButtonSwitch radioButtonSwitch3;
private RadioButtonSwitch radioButtonSwitch4;
private RadioButtonSwitch radioButtonSwitch5;
private RadioButtonSwitch radioButtonSwitch6;
private RadioButtonSwitch radioButtonSwitch7;
private RadioButtonSwitch radioButtonSwitch8;
private RadioButtonSwitch radioButtonSwitch9;
private RadioButtonSwitch radioButtonSwitch10;
private RadioButtonSwitch radioButtonSwitch11;
private RadioButtonSwitch radioButtonSwitch12;
private RadioButtonSwitch radioButtonSwitch13;
private RadioButtonSwitch radioButtonSwitch14;
private RadioButtonSwitch radioButtonSwitch15;
private RadioButtonSwitch radioButtonSwitch16;
private RadioButtonSwitch radioButtonSwitch17;
private RadioButtonSwitch radioButtonSwitch18;
private RadioButtonSwitch radioButtonSwitch19;
private System.Windows.Forms.NumericUpDown countBox;
private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown activationBox;
    }
}

