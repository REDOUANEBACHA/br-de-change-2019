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
    public partial class suprimer_devis : Form
    {
        public suprimer_devis()
        {
            InitializeComponent();
        }
        classe_cnx cnx = new classe_cnx();

        private void button1_Click(object sender, EventArgs e)

        {
            string l = comboBox1.Text;
            SqlCommand cmnds = new SqlCommand("delete devise where nom_devise='" +l+ "' ", cnx.cnx);
            cnx.cnx.Open();
            cmnds.ExecuteNonQuery();
            cnx.cnx.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            this.Hide();
            suprimer_devis sup_de = new suprimer_devis();
            sup_de.Show();
            // pour remplir combobox de devis
            SqlCommand dev = new SqlCommand("select nom_devise from devise ", cnx.cnx);
            cnx.cnx.Open();
            SqlDataReader readdev = dev.ExecuteReader();
            while (readdev.Read())
            {
                comboBox1.Items.Add(readdev[0]);
            }
            cnx.cnx.Close();
        }

        private void suprimer_devis_Load(object sender, EventArgs e)
        {
            // pour remplir combobox de devis
            SqlCommand dev = new SqlCommand("select nom_devise from devise ", cnx.cnx);
            cnx.cnx.Open();
            SqlDataReader readdev = dev.ExecuteReader();
            while (readdev.Read())
            {
                comboBox1.Items.Add(readdev[0]);
            }
            cnx.cnx.Close();
            cnx.cnx.Close();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // pour remplir cours_app
            string l = comboBox1.Text;
            SqlCommand cours_a = new SqlCommand("select * from devise where nom_devise='" + l + "' ", cnx.cnx);
            cnx.cnx.Open();
            SqlDataReader read_c = cours_a.ExecuteReader();
            while (read_c.Read())
            {
                textBox1.Text = read_c.GetValue(2).ToString();
                textBox2.Text = read_c.GetValue(3).ToString();
                textBox3.Text = read_c.GetValue(4).ToString();
                

            }
            cnx.cnx.Close();
        }
    }
}
