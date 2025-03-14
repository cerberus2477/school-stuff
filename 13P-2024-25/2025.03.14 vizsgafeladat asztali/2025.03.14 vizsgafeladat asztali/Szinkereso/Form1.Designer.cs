namespace Szinkereso
{
    partial class frmSzinkereso
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnKever = new System.Windows.Forms.Button();
            this.btnRejt = new System.Windows.Forms.Button();
            this.btnUj = new System.Windows.Forms.Button();
            this.btnKilep = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_nev = new System.Windows.Forms.TextBox();
            this.btn_jatekosCsere = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lbl_ido = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(26, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 50);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(26, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 600);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(232, 68);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(50, 600);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(288, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(50, 600);
            this.panel4.TabIndex = 3;
            // 
            // btnKever
            // 
            this.btnKever.Location = new System.Drawing.Point(232, 12);
            this.btnKever.Name = "btnKever";
            this.btnKever.Size = new System.Drawing.Size(50, 23);
            this.btnKever.TabIndex = 4;
            this.btnKever.Text = "Ke&ver";
            this.btnKever.UseVisualStyleBackColor = true;
            this.btnKever.Click += new System.EventHandler(this.btnKever_Click);
            // 
            // btnRejt
            // 
            this.btnRejt.Location = new System.Drawing.Point(232, 39);
            this.btnRejt.Name = "btnRejt";
            this.btnRejt.Size = new System.Drawing.Size(50, 23);
            this.btnRejt.TabIndex = 5;
            this.btnRejt.Text = "&Rejt";
            this.btnRejt.UseVisualStyleBackColor = true;
            this.btnRejt.Click += new System.EventHandler(this.btnRejt_Click);
            // 
            // btnUj
            // 
            this.btnUj.Location = new System.Drawing.Point(288, 12);
            this.btnUj.Name = "btnUj";
            this.btnUj.Size = new System.Drawing.Size(50, 23);
            this.btnUj.TabIndex = 6;
            this.btnUj.Text = "Ú&j";
            this.btnUj.UseVisualStyleBackColor = true;
            this.btnUj.Click += new System.EventHandler(this.btnUj_Click);
            // 
            // btnKilep
            // 
            this.btnKilep.Location = new System.Drawing.Point(288, 39);
            this.btnKilep.Name = "btnKilep";
            this.btnKilep.Size = new System.Drawing.Size(50, 23);
            this.btnKilep.TabIndex = 7;
            this.btnKilep.Text = "&Kilépés";
            this.btnKilep.UseVisualStyleBackColor = true;
            this.btnKilep.Click += new System.EventHandler(this.btnKilep_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Játékos egydi kódja (id):";
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(505, 51);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(100, 20);
            this.tb_id.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Név:";
            // 
            // tb_nev
            // 
            this.tb_nev.Location = new System.Drawing.Point(505, 77);
            this.tb_nev.Name = "tb_nev";
            this.tb_nev.Size = new System.Drawing.Size(100, 20);
            this.tb_nev.TabIndex = 11;
            // 
            // btn_jatekosCsere
            // 
            this.btn_jatekosCsere.Location = new System.Drawing.Point(381, 12);
            this.btn_jatekosCsere.Name = "btn_jatekosCsere";
            this.btn_jatekosCsere.Size = new System.Drawing.Size(224, 23);
            this.btn_jatekosCsere.TabIndex = 12;
            this.btn_jatekosCsere.Text = "Játékos cseréje";
            this.btn_jatekosCsere.UseVisualStyleBackColor = true;
            this.btn_jatekosCsere.Click += new System.EventHandler(this.btn_jatekosCsere_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_ido
            // 
            this.lbl_ido.AutoSize = true;
            this.lbl_ido.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ido.Location = new System.Drawing.Point(426, 318);
            this.lbl_ido.Name = "lbl_ido";
            this.lbl_ido.Size = new System.Drawing.Size(0, 37);
            this.lbl_ido.TabIndex = 13;
            // 
            // frmSzinkereso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 684);
            this.Controls.Add(this.lbl_ido);
            this.Controls.Add(this.btn_jatekosCsere);
            this.Controls.Add(this.tb_nev);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKilep);
            this.Controls.Add(this.btnUj);
            this.Controls.Add(this.btnRejt);
            this.Controls.Add(this.btnKever);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmSzinkereso";
            this.Text = "Színkereső";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.frmSzinkereso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnKever;
        private System.Windows.Forms.Button btnRejt;
        private System.Windows.Forms.Button btnUj;
        private System.Windows.Forms.Button btnKilep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_nev;
        private System.Windows.Forms.Button btn_jatekosCsere;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lbl_ido;
    }
}

