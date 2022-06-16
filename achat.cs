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
    public partial class achat : Form
    {
        public achat(int b)
        {
            InitializeComponent();
            label25.Text = b.ToString();
        }
        classe_cnx cnx = new classe_cnx();

        private void achat_Load(object sender, EventArgs e)
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = comboBox1.Text;
            string p = comboBox2.Text;
            textBox2.Text = " vent  " + m + " " + p;
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // pour remplir cours_app
            string l = comboBox3.Text;
            SqlCommand cours_a = new SqlCommand("select * from devise where nom_devise='" + l + "' ", cnx.cnx);
            cnx.cnx.Open();
            SqlDataReader read_c = cours_a.ExecuteReader();
            while (read_c.Read())
            {
                textBox11.Text = read_c.GetValue(3).ToString();
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
                textBox15.Text = read.GetValue(3).ToString();

            }

            cnx.cnx.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {

                int a = int.Parse(textBox12.Text);
                float b = float.Parse(textBox15.Text);
                textBox13.Text = " = " + (a * b);
                dataGridView1.Rows.Add(textBox6.Text + "_" + textBox7.Text, comboBox3.Text, textBox12.Text, textBox13.Text, label13.Text);
            }
            catch
            {
                MessageBox.Show("remplire le Montant et le devis ", "attention", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
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


            //______________________ ACHAT
            int i;
            i = int.Parse(textBox3.Text);

            string l;
            l = comboBox3.Text;

            int mont;
            mont = int.Parse(textBox12.Text);
            int P = int.Parse(label25.Text);
            try
            {


                SqlCommand cmnd_aj_vent = new SqlCommand("insert into achat (id_employé,id_client,nom_devise,prix_devise_dh,prix_devise_en_achat_dh,montant_achat) values (" + P + "," + i + ",'" + l + "',@a,@b," + mont + ")", cnx.cnx);
                cmnd_aj_vent.Parameters.Add("@a", SqlDbType.Float);
                cmnd_aj_vent.Parameters.Add("@b", SqlDbType.Float);

                cmnd_aj_vent.Parameters[0].Value = textBox14.Text;
                cmnd_aj_vent.Parameters[1].Value = textBox15.Text;

                cnx.cnx.Open();
                cmnd_aj_vent.ExecuteNonQuery();
                cnx.cnx.Close();


            }
            catch (Exception p)
            {
                MessageBox.Show("  problem b " + p.Message);
                cnx.cnx.Close();
            }
            DialogResult mp = MessageBox.Show(" votre operation était  valider ", " message de validation : ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (mp == DialogResult.OK)
            {
                achat vn = new achat(int.Parse(label25.Text));
                this.Hide();
                vn.Show();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            achat vnt = new achat(int.Parse(label25.Text));
            this.Hide();
            vnt.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        }
    }

