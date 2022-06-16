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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
          

            
        }

     


        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("remplire votre email et votre  code ");

            }
            else
            {

                classe_cnx cnx = new classe_cnx();
                SqlDataAdapter KK = new SqlDataAdapter("select *  from dbo.directeur where nom_utilisateur='"+textBox1.Text+"' and mot_de_passe='"+textBox2.Text+"'", cnx.cnx);
                DataTable tb = new DataTable();
                cnx.cnx.Open();
                KK.Fill(tb);
                if (tb.Rows.Count == 1)
                {

                    SqlCommand cmnd1 = new SqlCommand("select *  from dbo.directeur where nom_utilisateur='" + textBox1.Text + "' and mot_de_passe='" + textBox2.Text + "'", cnx.cnx);
                    SqlDataReader read = cmnd1.ExecuteReader();

                    while (read.Read())
                    {


                        string nom_ut = read.GetValue(2).ToString();
                        string pre_u = read.GetValue(3).ToString();
                        int id_em = read.GetInt32(0);
                        directeur pageofficer = new directeur(nom_ut,pre_u,id_em);
                        this.Hide();
                        pageofficer.Show();

                    }



                    
                }
                cnx.cnx.Close();
                //____________________________________________


                SqlDataAdapter KKo = new SqlDataAdapter("select *  from dbo.employé where nom_utilisateur='" + textBox1.Text + "' and mot_de_passe='" + textBox2.Text + "'", cnx.cnx);
                cnx.cnx.Open();
                DataTable tbo = new DataTable();
                KKo.Fill(tbo);
                if (tbo.Rows.Count == 1)
                {
                    SqlCommand cmnd1 = new SqlCommand("select *  from dbo.employé where nom_utilisateur='" + textBox1.Text + "' and mot_de_passe='" + textBox2.Text + "'", cnx.cnx);
                   
                    SqlDataReader read = cmnd1.ExecuteReader();
                   
                    
                    

                    //int id_em;
                    while (read.Read())
                    {


                         string nom_ut = read.GetValue(2).ToString();
                         string pre_u = read.GetValue(3).ToString();
                         int id_em = read.GetInt32(0);
                         emploiyer pageofficer = new emploiyer(nom_ut,pre_u,id_em);
                         this.Hide();
                         pageofficer.Show();

                    }
                  


                    
                   
                    cnx.cnx.Close();
                }
             
               



            }
        }
    }
}
