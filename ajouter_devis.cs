using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bureau_de_change
{
    public partial class ajouter_devis : Form
    {
        public ajouter_devis()
        {
            InitializeComponent();
        }
        classe_cnx cnx = new classe_cnx();
        private void ajouter_devis_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("remplir tous les champs ");
            }
            else
            {
                SqlCommand cmnd = new SqlCommand("insert into devise values ('" + textBox1.Text + "'," + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text + ")", cnx.cnx);
                cnx.cnx.Open();
                cmnd.ExecuteNonQuery();
                cnx.cnx.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }
    }
}
