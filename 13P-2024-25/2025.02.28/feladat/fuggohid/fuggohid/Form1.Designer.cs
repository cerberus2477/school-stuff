namespace fuggohid
{
    partial class frm_fuggohidak
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.megnyitasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keresesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kilépésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_hidakSzama = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_hely = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_orszag = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_hossz = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_ev = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.megnyitasToolStripMenuItem,
            this.keresesToolStripMenuItem,
            this.kilépésToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(620, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // megnyitasToolStripMenuItem
            // 
            this.megnyitasToolStripMenuItem.Name = "megnyitasToolStripMenuItem";
            this.megnyitasToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.megnyitasToolStripMenuItem.Text = "Fájl/Megnyitás";
            this.megnyitasToolStripMenuItem.Click += new System.EventHandler(this.megnyitasToolStripMenuItem_Click);
            // 
            // keresesToolStripMenuItem
            // 
            this.keresesToolStripMenuItem.Name = "keresesToolStripMenuItem";
            this.keresesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.keresesToolStripMenuItem.Text = "Keresés";
            // 
            // kilépésToolStripMenuItem
            // 
            this.kilépésToolStripMenuItem.Name = "kilépésToolStripMenuItem";
            this.kilépésToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.kilépésToolStripMenuItem.Text = "Kilépés";
            this.kilépésToolStripMenuItem.Click += new System.EventHandler(this.kilépésToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(21, 37);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(297, 277);
            this.listBox.TabIndex = 1;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tb_hidakSzama);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Location = new System.Drawing.Point(21, 338);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 140);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "dabab";
            // 
            // tb_hidakSzama
            // 
            this.tb_hidakSzama.Location = new System.Drawing.Point(36, 95);
            this.tb_hidakSzama.Name = "tb_hidakSzama";
            this.tb_hidakSzama.Size = new System.Drawing.Size(100, 20);
            this.tb_hidakSzama.TabIndex = 5;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(36, 63);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(126, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "2000-ben vagy utána";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(36, 28);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(98, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "2000 előtt épült";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hidak száma";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hely";
            // 
            // tb_hely
            // 
            this.tb_hely.Location = new System.Drawing.Point(420, 50);
            this.tb_hely.Name = "tb_hely";
            this.tb_hely.Size = new System.Drawing.Size(145, 20);
            this.tb_hely.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ország";
            // 
            // tb_orszag
            // 
            this.tb_orszag.Location = new System.Drawing.Point(420, 110);
            this.tb_orszag.Name = "tb_orszag";
            this.tb_orszag.Size = new System.Drawing.Size(145, 20);
            this.tb_orszag.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Hossz";
            // 
            // tb_hossz
            // 
            this.tb_hossz.Location = new System.Drawing.Point(420, 170);
            this.tb_hossz.Name = "tb_hossz";
            this.tb_hossz.Size = new System.Drawing.Size(145, 20);
            this.tb_hossz.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(371, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Év";
            // 
            // tb_ev
            // 
            this.tb_ev.Location = new System.Drawing.Point(420, 228);
            this.tb_ev.Name = "tb_ev";
            this.tb_ev.Size = new System.Drawing.Size(145, 20);
            this.tb_ev.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(445, 396);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Kilépés";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frm_fuggohidak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 507);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_ev);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_hossz);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_orszag);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_hely);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "frm_fuggohidak";
            this.Text = "Függőhidak";
            this.Load += new System.EventHandler(this.frm_fuggohidak_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem megnyitasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keresesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kilépésToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_hidakSzama;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_hely;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_orszag;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_hossz;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_ev;
        private System.Windows.Forms.Button button2;
    }
}

