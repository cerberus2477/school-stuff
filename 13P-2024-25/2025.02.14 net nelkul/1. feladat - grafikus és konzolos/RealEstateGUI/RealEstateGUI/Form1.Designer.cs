namespace RealEstateGUI
{
    partial class Form1
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
            this.list_sellers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_sellername = new System.Windows.Forms.Label();
            this.lbl_sellerphone = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_sellerads = new System.Windows.Forms.Label();
            this.btn_loadads = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // list_sellers
            // 
            this.list_sellers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_sellers.FormattingEnabled = true;
            this.list_sellers.Location = new System.Drawing.Point(0, 1);
            this.list_sellers.Name = "list_sellers";
            this.list_sellers.Size = new System.Drawing.Size(194, 446);
            this.list_sellers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Eladó neve:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hirdetések száma:";
            // 
            // lbl_sellername
            // 
            this.lbl_sellername.AutoSize = true;
            this.lbl_sellername.Location = new System.Drawing.Point(329, 18);
            this.lbl_sellername.Name = "lbl_sellername";
            this.lbl_sellername.Size = new System.Drawing.Size(64, 13);
            this.lbl_sellername.TabIndex = 5;
            this.lbl_sellername.Text = "Eladó neve:";
            // 
            // lbl_sellerphone
            // 
            this.lbl_sellerphone.AutoSize = true;
            this.lbl_sellerphone.Location = new System.Drawing.Point(329, 59);
            this.lbl_sellerphone.Name = "lbl_sellerphone";
            this.lbl_sellerphone.Size = new System.Drawing.Size(64, 13);
            this.lbl_sellerphone.TabIndex = 7;
            this.lbl_sellerphone.Text = "Eladó neve:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Eladó telefonszáma:";
            // 
            // lbl_sellerads
            // 
            this.lbl_sellerads.AutoSize = true;
            this.lbl_sellerads.Location = new System.Drawing.Point(329, 124);
            this.lbl_sellerads.Name = "lbl_sellerads";
            this.lbl_sellerads.Size = new System.Drawing.Size(64, 13);
            this.lbl_sellerads.TabIndex = 8;
            this.lbl_sellerads.Text = "Eladó neve:";
            // 
            // btn_loadads
            // 
            this.btn_loadads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_loadads.AutoSize = true;
            this.btn_loadads.Location = new System.Drawing.Point(200, 87);
            this.btn_loadads.Name = "btn_loadads";
            this.btn_loadads.Size = new System.Drawing.Size(595, 23);
            this.btn_loadads.TabIndex = 9;
            this.btn_loadads.Text = "Hirdetések betöltése";
            this.btn_loadads.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_loadads);
            this.Controls.Add(this.lbl_sellerads);
            this.Controls.Add(this.lbl_sellerphone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_sellername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list_sellers);
            this.Name = "frm_ingatlanok";
            this.Text = "Ingatlanok";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox list_sellers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_sellername;
        private System.Windows.Forms.Label lbl_sellerphone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_sellerads;
        private System.Windows.Forms.Button btn_loadads;
    }
}

