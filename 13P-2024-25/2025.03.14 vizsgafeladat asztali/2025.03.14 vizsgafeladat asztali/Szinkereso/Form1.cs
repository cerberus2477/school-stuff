using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szinkereso
{
    public partial class frmSzinkereso : Form
    {
        public frmSzinkereso()
        {
            InitializeComponent();
        }

        private void btnKilep_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        static int max1 = 12, max2 = 4;
        Color[] szin = { Color.Yellow, Color.Red, Color.Blue, Color.Green, Color.Purple, Color.Orange };
        Random vél = new Random();
        Button[,] gombok1 = new Button[max2, max1];
        Button[] gombok2 = new Button[max2];
        Button[] gombok3 = new Button[max1];
        Label[,] cimkék = new Label[max1, 2];

        private Timer timer1;
        private DateTime jatekKezdet;
        private TimeSpan jatekIdo;

        //etsztadatok, ezt persze dinamikusan kéne kiszedni a programból
        private int maxJatekId = 1000;
        private int lepes = 6690;


        private void szkatt(object sender, EventArgs e)
        {
            if ((sender as Button).BackColor == szin[0]) (sender as Button).BackColor = szin[1];
            else if ((sender as Button).BackColor == szin[1]) (sender as Button).BackColor = szin[2];
            else if ((sender as Button).BackColor == szin[2]) (sender as Button).BackColor = szin[3];
            else if ((sender as Button).BackColor == szin[3]) (sender as Button).BackColor = szin[4];
            else if ((sender as Button).BackColor == szin[4]) (sender as Button).BackColor = szin[5];
            else (sender as Button).BackColor = szin[0];
        }

        private int helyén(int sor)
        {
            int db = 0;
            for (int i = 0; i < max2; i++)
            {
                if (gombok2[i].BackColor == Color.Beige) ;
                else if (gombok2[i].BackColor == gombok1[i, sor].BackColor) db++;
            }
            return db;
        }

        private int szinjó(int sor)
        {
            int db = 0;
            bool van;
            List<int> vanmár = new List<int>();
            for (int i = 0; i < max2; i++)
            {
                van = false;
                int oszlop = 0;
                while (!van && oszlop < max2)
                {
                    if (gombok2[oszlop].BackColor == Color.Beige) ;
                    else if (gombok2[oszlop].BackColor == gombok1[i, sor].BackColor && vanmár.IndexOf(oszlop) == -1)
                    {
                        vanmár.Add(oszlop);
                        van = true;
                        db++;
                    }
                    oszlop++;
                }
            }
            return db;
        }

        private void ellen(object sender, EventArgs e)
        {
            int sor = Convert.ToInt16((sender as Button).Name);
            int helyénvan = helyén(sor);
            int szin = szinjó(sor);
            cimkék[sor, 0].Text = Convert.ToString(helyénvan);
            cimkék[sor,1].Text= Convert.ToString(szin-helyénvan);
            for (int i = 0; i < max2; i++)
            {
                gombok1[i, sor].Enabled = false;
            }
            gombok3[sor].Enabled = false;
            if(helyénvan==max2)
            {
                //this.btnRejt_Click(sender, e);
                panel1.Visible = true;
                MessageBox.Show("Sikerült kirakni!", "Nyert!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                timer1.Stop();
                jatekIdo = DateTime.Now - jatekKezdet;

                eredmenyMentes();

                this.btnUj_Click(sender, e);
            }
        }

        private void btnUj_Click(object sender, EventArgs e)
        {
            //TODO: ide kell a név bekérése (vagy lehetősége)
            //a felhasználó bele tudjon írni a tb_id és tb_nev dobozokba
            //amíg nincs mindkettőben szöveg, ne tudja elkezdeni

            if (tb_id.Text == "" || tb_nev.Text == "")
            {
                MessageBox.Show("Add meg a játékos ID-t és nevet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            jatekKezdet = DateTime.Now;
            timer1.Start();

            for (int i = 0; i < max2; i++)
            {
                gombok2[i].BackColor = Color.Beige;
                for (int j = 0; j < max1; j++)
                {
                    gombok1[i, j].BackColor = Color.Beige;
                    gombok1[i, j].Enabled = true;
                    gombok3[j].Enabled = true;
                }
            }
            for (int i = 0; i < max1; i++)
            {
                cimkék[i, 0].Text = "";
                cimkék[i, 1].Text = "";
            }
            panel1.Visible = true;
            btnRejt.Text = "Rejt";
        }

        private void btnRejt_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
            if (btnRejt.Text == "&Rejt") btnRejt.Text = "&Mutat";
            else btnRejt.Text = "&Rejt";
        }

        private void btnKever_Click(object sender, EventArgs e)
        {
            btnUj_Click(sender, e);
            for (int i = 0; i < max2; i++)
            {
                gombok2[i].BackColor = szin[vél.Next(0, 6)];
            }
            btnRejt.Text = "&Mutat";
            panel1.Visible = false;
        }


        

        public void eredmenyMentes()
        {
            StreamWriter sw = new StreamWriter("eredmenyek.csv", true);
            //d.a játék_id-t a program a fájlban található legnagyobb sorszámot követő számban határozza meg,


            // Új jatek_id +1-el
            int ujJatekId = maxJatekId + 1;


            sw.WriteLine($"{tb_id.Text};{tb_nev.Text};{ujJatekId};{lepes};{jatekIdo.ToString(@"hh\:mm\:ss")}");
  


            sw.Close();
        }

        private void btn_jatekosCsere_Click(object sender, EventArgs e)
        {
            tb_id.Enabled = true;
            tb_nev.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - jatekKezdet;
            lbl_ido.Text = elapsed.ToString();
        }




        private void frmSzinkereso_Load(object sender, EventArgs e)
        {

            timer1 = new Timer();
            timer1.Interval = 1000; 
            timer1.Tick += timer1_Tick;


            int sorszám = max1;
            for (int i = 0; i < max2; i++)
            {
                for (int j = 0; j < max1; j++)
                {
                    sorszám++;
                    gombok1[i, j] = new Button();
                    gombok1[i, j].Name = sorszám.ToString();
                    gombok1[i, j].Size = new System.Drawing.Size(this.panel2.ClientSize.Width / max2, this.panel2.ClientSize.Height / max1);
                    gombok1[i, j].Location = new System.Drawing.Point(i * gombok1[i, j].Width, j * gombok1[i, j].Height);
                    gombok1[i, j].BackColor = Color.Beige;
                    gombok1[i, j].Visible = true;
                    this.panel2.Controls.Add(gombok1[i, j]);
                    this.gombok1[i, j].Click += new System.EventHandler(this.szkatt);
                }
            }
            for (int i = 0; i < max2; i++)
            {
                gombok2[i] = new Button();
                gombok2[i].Name = sorszám.ToString();
                gombok2[i].Size = new System.Drawing.Size(this.panel1.ClientSize.Width / max2, this.panel1.ClientSize.Height );
                gombok2[i].Location = new System.Drawing.Point(i * gombok2[i].Width, 0);
                gombok2[i].BackColor = Color.Beige;
                gombok2[i].Visible = true;
                this.panel1.Controls.Add(gombok2[i]);
                this.gombok2[i].Click += new System.EventHandler(this.szkatt);
            }
            for (int i = 0; i < max1; i++)
            {
                gombok3[i] = new Button();
                gombok3[i].Name = i.ToString();
                gombok3[i].Size = new System.Drawing.Size(this.panel3.ClientSize.Width, this.panel3.ClientSize.Height / max1);
                gombok3[i].Location = new System.Drawing.Point(0, i * gombok3[i].Height);
                gombok3[i].BackColor = Color.Beige;
                gombok3[i].Text = "OK";
                gombok3[i].Visible = true;
                this.panel3.Controls.Add(gombok3[i]);
                this.gombok3[i].Click += new System.EventHandler(this.ellen);
            }
            for (int i = 0; i < max1; i++)
            {
                cimkék[i, 0] = new Label();
                cimkék[i, 1] = new Label();
                cimkék[i, 0].Location = new System.Drawing.Point(20, i * gombok3[i].Height + 3);
                cimkék[i, 1].Location = new System.Drawing.Point(20, i * gombok3[i].Height + 23);
                cimkék[i, 0].Text = "";
                cimkék[i, 1].Text = "";
                cimkék[i, 0].ForeColor = Color.Red;
                cimkék[i, 1].ForeColor = Color.Blue;
                cimkék[i, 0].Font = new Font(cimkék[i, 0].Font.Name, 15, FontStyle.Bold);
                cimkék[i, 1].Font = new Font(cimkék[i, 1].Font.Name, 15, FontStyle.Bold);
                this.panel4.Controls.Add(cimkék[i, 0]);
                this.panel4.Controls.Add(cimkék[i, 1]);
            }
            this.panel1.BackColor = Color.Transparent;
            this.panel2.BackColor = Color.Transparent;
            this.panel3.BackColor = Color.Transparent;
            this.panel4.BackColor = Color.Transparent;
        }
    }
}
