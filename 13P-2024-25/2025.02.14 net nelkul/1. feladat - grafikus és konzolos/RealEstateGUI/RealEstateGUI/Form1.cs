using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace RealEstateGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            FillListView();
        }

        private void FillListView()
        {
            MySqlConnection conn = new MySqlConnection("Server = localhost; Database = ingatlan; Uid = root; Pwd =; ");
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT name FROM sellers;");
                MySqlDataReader reader = cmd.ExecuteReader();
                list_sellers.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["name"].ToString());
                    list_sellers.Items.Add(item);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
            finally 
            {
                conn.Close();
            }
        }

    }
}
