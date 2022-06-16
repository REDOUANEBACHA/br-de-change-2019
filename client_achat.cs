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
    public partial class client_achat : Form
    {
        public client_achat()
        {
            InitializeComponent();
        }
        classe_cnx cnx = new classe_cnx();
        private void client_achat_Load(object sender, EventArgs e)
        {

            label4.Visible = false;
            button1.Visible = false;
            textBox2.Visible = false;
          
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            label4.Visible = false;
            button1.Visible = false;
            textBox2.Visible = false;
            SqlCommand cmnd = new SqlCommand("select *  from client join achat on client.id_client=achat.id_client", cnx.cnx);
            cnx.cnx.Open();
            SqlDataReader read = cmnd.ExecuteReader();

            while (read.Read())
            {
                dataGridView1.Rows.Add(read[0], read[1], read[2], read[3], read[4], read[5], read[6], read[7], read[8], read[9]);
            }
            cnx.cnx.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            label4.Visible = true;
            button1.Visible = true;
            textBox2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                SqlCommand cmnd = new SqlCommand("select *  from client join achat on client.id_client=achat.id_client where client.id_client=" + int.Parse(textBox2.Text) + " ", cnx.cnx);
                cnx.cnx.Open();
                SqlDataReader read = cmnd.ExecuteReader();


                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[0], read[1], read[2], read[3], read[4], read[5], read[6], read[7], read[8], read[9]);
                }
                cnx.cnx.Close();
            }
            catch (Exception l)
            {
                MessageBox.Show("errur " + l.Message);
            }
            finally
            {
                cnx.cnx.Close();
            }
        }
    }
}
