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

namespace fuggohid
{
    public partial class frm_fuggohidak : Form
    {
        static Fuggohid[] hidak;
        public frm_fuggohidak()
        {
            InitializeComponent();
        }

        private void frm_fuggohidak_Load(object sender, EventArgs e)
        {

        }


        private Fuggohid[] HidakCSVbol(string fajlnev)
        {
            StreamReader sr = new StreamReader(fajlnev);
            sr.ReadLine();
            return sr.ReadToEnd().Split('\n').Select(s => new Fuggohid(s)).ToArray();
        }


        private void megnyitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Válassza ki a fájlt!";
            openFileDialog.Filter = "CSV files|*.csv";
            openFileDialog.FileName = "fuggohidak.csv";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                hidak = HidakCSVbol(openFileDialog.FileName);
                listBox.Items.AddRange(hidak);
                MessageBox.Show("Az adatok betöltése megtörtént.", "Sikeres művelet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kilepes();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Kilepes();
        }

        private void Kilepes()
        {
            Application.Exit();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( listBox.SelectedItem is Fuggohid hid)
            {
                tb_ev.Text = $"{hid.ev}";
                tb_hely.Text = hid.hely;
                tb_orszag.Text = hid.orszag;
                tb_hossz.Text = $"{hid.hossz}";
            }

        }

        //előtt
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tb_hidakSzama.Text = hidak.Where(h => h.ev < 2000).Count().ToString();
        }

        //után
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tb_hidakSzama.Text = hidak.Where(h => h.ev >= 2000).Count().ToString();
        }


    }
}
