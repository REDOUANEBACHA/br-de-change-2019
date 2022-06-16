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
    public partial class vent : Form



    {
        public vent(int a)
        {
            InitializeComponent();
            label25.Text = a.ToString();
        }
          classe_cnx cnx = new classe_cnx();
        private void vent_Load(object sender, EventArgs e)
        {
            
            SqlCommand cn = new SqlCommand("select Max(id_client) from client", cnx.cnx);
            cnx.cnx.Open();
            SqlDataReader read = cn.ExecuteReader();
            
            //int countDis = Convert.ToInt32(cn.ExecuteScalar());
 
            while (read.Read())
            {

                textBox3.Text = (read.GetInt32(0) + 1).ToString();
            }
            //textBox3.Text = countDis.ToString();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox11.Enabled = false;
            textBox13.Enabled = false;
            textBox14.Enabled = false;
            textBox15.Enabled = false;

           
            label13.Text = DateTime.Now.ToString();
            cnx.cnx.Close();
            // pour remplir combobox de devis
            SqlCommand dev = new SqlCommand("select nom_devise from devise ", cnx.cnx);
            cnx.cnx.Open();
            SqlDataReader readdev = dev.ExecuteReader();
            while (readdev.Read())
            {
                comboBox3.Items.Add(readdev[0]);
            }
            cnx.cnx.Close();
         

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = comboBox1.Text;
            string p = comboBox2.Text;
            textBox2.Text = " vent aux  " + m + " " + p;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = comboBox1.Text;
            string p = comboBox2.Text;
            textBox2.Text = " vent  " + m + " " + p;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // pour remplir cours_app
            string l = comboBox3.Text;
            SqlCommand cours_a = new SqlCommand("select * from devise where nom_devise='" + l + "' ", cnx.cnx);
            cnx.cnx.Open();
            SqlDataReader read_c = cours_a.ExecuteReader();
            while (read_c.Read())
            {
                textBox11.Text = read_c.GetValue(4).ToString();
                label23.Text = read_c.GetValue(1).ToString();

            }
            cnx.cnx.Close();
            //____________________


            string p = comboBox3.Text;
            //float r = float.Parse(textBox11.Text);
            SqlCommand cours_l = new SqlCommand("select *from devise where nom_devise ='" + p + "' ", cnx.cnx);
            cnx.cnx.Open();
            SqlDataReader read = cours_l.ExecuteReader();
            while (read.Read())
            {
                textBox14.Text = read.GetValue(2).ToString();
                textBox15.Text = read.GetValue(4).ToString();

            }

            cnx.cnx.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                
                int a = int.Parse(textBox12.Text);
                float b = float.Parse( textBox15.Text );
                float somme = a / b;
                

                textBox13.Text = somme.ToString();
                dataGridView1.Rows.Add(textBox6.Text+"_"+textBox7.Text, comboBox3.Text,textBox12.Text, textBox13.Text, label13.Text);
            }
            catch
            {
                MessageBox.Show("remplire le Montant et le devis ", "attention", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {








            if (label19.Text == "")
            {
                //string a = DateTime.Now.ToString();
                //label13.Text = a;

                string nom_dev = comboBox3.Text;


                //________________ CLIENT 
                string pay = comboBox2.Text;
                string qualite = comboBox1.Text;
                try
                {

                    SqlCommand cmnd = new SqlCommand("insert into client (CNI_client,num_paspor,nom_client,prénom_client,adresse_client,date_naissance_client,tel_client,pays,qualite)VALUES ('" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + pay + "','" + qualite + "')", cnx.cnx);
                    cnx.cnx.Open();
                    cmnd.ExecuteNonQuery();
                    cnx.cnx.Close();
                }
                catch (Exception p)
                {
                    MessageBox.Show("problem a " + p.Message);
                    cnx.cnx.Close();
                }


                //______________________ VENT 
                int i;
                i = int.Parse(textBox3.Text);

                string l;
                l = comboBox3.Text;
                int mont;
                mont = int.Parse(textBox12.Text); 
                


                int P = int.Parse(label25.Text);
                try
                {

                    SqlCommand cmnd_aj_vent = new SqlCommand("insert into vente (id_employé,id_client,nom_devise,prix_devise_dh,prix_devise_en_vente_dh,montant_vente) values (" + P + "," + i + ",'" + l + "',@a,@b," + mont+ ")", cnx.cnx);
                    cmnd_aj_vent.Parameters.Add("@a", SqlDbType.Float);
                    cmnd_aj_vent.Parameters.Add("@b", SqlDbType.Float);

                    cmnd_aj_vent.Parameters[0].Value = textBox14.Text;
                    cmnd_aj_vent.Parameters[1].Value = textBox15.Text;

                    cnx.cnx.Open();
                    cmnd_aj_vent.ExecuteNonQuery();
                    cnx.cnx.Close();


                    //_________ remplir le rest 

                    string x = comboBox1.Text;
                    float a;
                    float XB = float.Parse(textBox12.Text);
                    if (x == "Marocain Résident")
                    {
                        a = 45000;
                    }
                    else
                    {
                        a = 16000;
                    }
                    float sooma1 = a - XB;
                    if (sooma1 > 0)
                    {
                        SqlCommand cmnd_rem = new SqlCommand("insert into dbo.le_reste(cni_client,le_rest) VALUES ('" + textBox4.Text + "',@res)", cnx.cnx);
                        cmnd_rem.Parameters.Add("@res", SqlDbType.Float);
                        cmnd_rem.Parameters[0].Value = sooma1;
                        cnx.cnx.Open();
                        cmnd_rem.ExecuteNonQuery();
                        cnx.cnx.Close();

                        textBox1.Text = "";
                        textBox2.Text = "";

                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
                        textBox11.Text = "";
                        textBox12.Text = "";
                        textBox13.Text = "";
                        textBox14.Text = "";
                        textBox15.Text = "";
                        DialogResult mp = MessageBox.Show(" votre operation était  valider ", " message de validation : ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (mp == DialogResult.OK)
                        {
                            vent vn = new vent(int.Parse(label25.Text));
                            this.Hide();
                            vn.Show();
                        }

                    }
                    else
                    {
                        MessageBox.Show("le mantant interdit de change ! ");
                    }


                }
                catch (Exception p)
                {
                    MessageBox.Show("  problem b " + p.Message);
                    cnx.cnx.Close();
                }
              


            }
            else
            {
                string a = DateTime.Now.ToString();
                //label13.Text = a;

                string nom_dev = comboBox3.Text;


                //________________ CLIENT 
                string pay = comboBox2.Text;
                string qualite = comboBox1.Text;
                try
                {

                    SqlCommand cmnd = new SqlCommand("insert into client (CNI_client,num_paspor,nom_client,prénom_client,adresse_client,date_naissance_client,tel_client,pays,qualite)VALUES ('" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + pay + "','" + qualite + "')", cnx.cnx);
                    cnx.cnx.Open();
                    cmnd.ExecuteNonQuery();
                    cnx.cnx.Close();
                }
                catch (Exception p)
                {
                    MessageBox.Show("problem C " + p.Message);
                    cnx.cnx.Close();
                }


                //______________________ VENT 
                int i;
                i = int.Parse(textBox3.Text);

                string l;
                l = comboBox3.Text;

                int mont;
                mont = int.Parse(textBox12.Text);

                int P = int.Parse(label25.Text);

                try
                {

                    SqlCommand cmnd_aj_vent = new SqlCommand("insert into vente (id_employé,id_client,nom_devise,prix_devise_dh,prix_devise_en_vente_dh,montant_vente) values (" + P + "," + i + ",'" + l + "',@a,@b," + mont + ")", cnx.cnx);
                    cmnd_aj_vent.Parameters.Add("@a", SqlDbType.Float);
                    cmnd_aj_vent.Parameters.Add("@b", SqlDbType.Float);

                    cmnd_aj_vent.Parameters[0].Value = textBox14.Text;
                    cmnd_aj_vent.Parameters[1].Value = textBox15.Text;

                    cnx.cnx.Open();
                    cmnd_aj_vent.ExecuteNonQuery();
                    cnx.cnx.Close();


                    //_________ remplir le rest 
                    try
                    {
                       string x = comboBox1.Text;

                       float XB = float.Parse(textBox12.Text);

                       float cr = float.Parse(label19.Text);

                       float soome = cr - XB;
                       if (soome > 0)
                       {
                           SqlCommand cmnd_rem = new SqlCommand("insert into dbo.le_reste(cni_client,le_rest) VALUES ('" + textBox4.Text + "',@res)", cnx.cnx);
                           cmnd_rem.Parameters.Add("@res", SqlDbType.Float);
                           cmnd_rem.Parameters[0].Value = soome;
                           cnx.cnx.Open();
                           cmnd_rem.ExecuteNonQuery();
                           cnx.cnx.Close();


                           textBox1.Text = "";
                           textBox2.Text = "";

                           textBox4.Text = "";
                           textBox5.Text = "";
                           textBox6.Text = "";
                           textBox7.Text = "";
                           textBox8.Text = "";
                           textBox9.Text = "";
                           textBox10.Text = "";
                           textBox11.Text = "";
                           textBox12.Text = "";
                           textBox13.Text = "";
                           textBox14.Text = "";
                           textBox15.Text = "";
                           DialogResult mp = MessageBox.Show(" votre operation était  valider ", " message de validation : ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           if (mp == DialogResult.OK)
                           {
                               vent vn = new vent(int.Parse(label25.Text));
                               this.Hide();
                               vn.Show();
                           }
 
                       }
                       else
                       {
                           MessageBox.Show(" le montant saisie et plus grande de la montant de reste ");
                       }
                    }
                    catch ( Exception p )
                    {
                        MessageBox.Show(" errur   "+p.Message);
                    }


                }
                catch (Exception p)
                {
                    MessageBox.Show("  problem D " + p.Message);
                    cnx.cnx.Close();
                }
            
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("remplir CNI ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else{
                try
                {
                    //pour savoir juste le montantant reste 

                    cnx.cnx.Open();
                    SqlCommand cmnd_ref = new SqlCommand("select * from dbo.le_reste where cni_client = '" + textBox4.Text + "'", cnx.cnx);
                    SqlDataReader read = cmnd_ref.ExecuteReader();
                    while (read.Read())
                    {
                        label19.Text = read.GetValue(1).ToString();
                    }

                    cnx.cnx.Close();
                    // pour remplire  les text 
                    cnx.cnx.Open();
                    SqlCommand cmnd_rem = new SqlCommand("select * from client where CNI_client ='" + textBox4.Text + "'", cnx.cnx);
                    SqlDataReader readd = cmnd_rem.ExecuteReader();
                    while (readd.Read())
                    {
                        comboBox1.Enabled = false;
                        comboBox2.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox5.Enabled = false;
                        textBox6.Enabled = false;
                        textBox8.Enabled = false;
                        textBox9.Enabled = false;
                        textBox7.Enabled = false;
                        textBox4.Enabled = false;
                        textBox1.Enabled = false;
                        comboBox1.Text = readd.GetValue(9).ToString();
                        comboBox2.Text = readd.GetValue(8).ToString();
                        textBox10.Text = readd.GetValue(7).ToString();
                        textBox5.Text = readd.GetValue(2).ToString();
                        textBox6.Text = readd.GetValue(3).ToString();
                        textBox7.Text = readd.GetValue(4).ToString();
                        textBox8.Text = readd.GetValue(5).ToString();
                        textBox9.Text = readd.GetValue(6).ToString();
                        textBox2.Text = " vent au " + readd.GetValue(9).ToString() + "  " + readd.GetValue(8).ToString();

                    }

                    cnx.cnx.Close();
                }

                catch (Exception l)
                {
                    MessageBox.Show(" c " + l.Message);
                }
                finally
                {
                    cnx.cnx.Close();
                }
            }
            
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            vent vnt = new vent(int.Parse(label25.Text));
            this.Hide();
            vnt.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
