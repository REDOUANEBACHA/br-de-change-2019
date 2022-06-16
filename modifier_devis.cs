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
    public partial class modifier_devis : Form
    {
        public modifier_devis()
        {
            InitializeComponent();
        }
        classe_cnx cnx = new classe_cnx();
     
    
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string l = comboBox1.Text;
                SqlCommand cmnds = new SqlCommand("update  devise set prix_devise_dh="+textBox1.Text+", prix_devise_en_achat_dh= "+textBox2.Text+",prix_devise_en_vente_dh= "+textBox3.Text+" where nom_devise='"+l+"'", cnx.cnx);
                cnx.cnx.Open();
                cmnds.ExecuteNonQuery();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch (Exception h)
            {
                MessageBox.Show("e" + h.Message);
            }
            finally
            {
                cnx.cnx.Close();
            }
   
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

        private void modifier_devis_Load(object sender, EventArgs e)
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
        }

        }
    }

