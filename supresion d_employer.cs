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
    public partial class supresion_d_employer : Form
    {
        public supresion_d_employer()
        {
            InitializeComponent();
        }
        classe_cnx cl_cnx = new classe_cnx();
        private void supresion_d_employer_Load(object sender, EventArgs e)
        {
             SqlCommand cmnd = new SqlCommand("select CIN_employé FROM employé ", cl_cnx.cnx);
            cl_cnx.cnx.Open();
            SqlDataReader read = cmnd.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read[0]);
            }
            cl_cnx.cnx.Close();
            textBox2.Enabled=false;
            textBox3.Enabled=false;
            textBox4.Enabled=false;
            textBox5.Enabled=false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
              string l =  comboBox1.Text ; 
            try
            {
                cl_cnx.cnx.Open();
                SqlCommand cmnd = new SqlCommand("select * from employé where CIN_employé='"+l+"'", cl_cnx.cnx);

                SqlDataReader read = cmnd.ExecuteReader();
                 while (read.Read())
                 {
                   textBox2.Text=read.GetValue(2).ToString();
                   textBox3.Text = read.GetValue(3).ToString();
                   textBox4.Text = read.GetValue(4).ToString();
                   textBox5.Text = read.GetValue(5).ToString();
                  
                 }
                 cl_cnx.cnx.Close();
            }
          
            catch (Exception r)
            {
                MessageBox.Show("interdit  ! "+r.Message);
            }
                   
            }

        private void button1_Click(object sender, EventArgs e)
        {
             try
            {


                DialogResult mess = MessageBox.Show("La confirmation ", "supresion de employer ! ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (mess == DialogResult.Yes)
                    {
                     string l = comboBox1.Text;
                    string req = "update employé set mot_de_passe=''  where CIN_employé='"+l+"'";
                    cl_cnx.cnx.Open();
                    SqlCommand comand = new SqlCommand(req, cl_cnx.cnx);
                    comand.ExecuteNonQuery();
                    MessageBox.Show(" le stagiaire était suprimer  ");
                    this.Hide();
                    cl_cnx.cnx.Close();
                    }
                    if (mess == DialogResult.Cancel)
                    {
                        gestion_emlpyer g =  new gestion_emlpyer();
                        g.Show();
                        this.Hide();
                    }
                }
          
            catch (Exception l)
            {
                MessageBox.Show("il as un problem", l.Message);
                cl_cnx.cnx.Close();
            }
        }
        }
    }

