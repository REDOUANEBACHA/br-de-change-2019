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
    public partial class ajouter_employer : Form
    {
        public ajouter_employer()
        {
            InitializeComponent();
        }
        classe_cnx cl_cnx = new classe_cnx();
        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("remplire  tous  les champs ! ");
                }
                else
                {
                    string req = "insert into employé(CIN_employé,nom_employé,prénom_employé,adresse_employé,mot_de_passe,nom_utilisateur) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','"+textBox2.Text+"'+'_'+'"+textBox3.Text+"')";
                cl_cnx.cnx.Open();
                SqlCommand comand = new SqlCommand(req,cl_cnx.cnx);
                comand.ExecuteNonQuery();
                MessageBox.Show("votre validation etait reussie ");
                this.Hide();
                cl_cnx.cnx.Close();
                gestion_emlpyer gs_a = new gestion_emlpyer();
                gs_a.Show();


                }
            }
            catch (Exception l)
            {
                MessageBox.Show("il as un problem", l.Message);
                cl_cnx.cnx.Close();
            }
        }

        private void ajouter_employer_Load(object sender, EventArgs e)
        {

        }
    }
}
