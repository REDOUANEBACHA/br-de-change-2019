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
    public partial class les_profit_et_les_operation : Form
    {
        public les_profit_et_les_operation()
        {
            InitializeComponent();
        }
        classe_cnx cnx = new classe_cnx();
        private void les_profit_et_les_operation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            string a = dateTimePicker1.Value.ToString("yyyy/MM/dd");

            string b = dateTimePicker2.Value.ToString("yyyy/MM/dd");
            try
            {
                string l = comboBox1.Text;
                if (l == "achat")
                {

                    SqlCommand cmnd = new SqlCommand(" select *  from  achat where date_achat  between '" + a + "'  and  '" + b + "'  ", cnx.cnx);
                    cnx.cnx.Open();
                    SqlDataReader read = cmnd.ExecuteReader();
                    while (read.Read())
                    {

                        dataGridView1.Rows.Add(read[0], read[1], read[2], read[3], read[4], read[5], read[6], read[7], read[8]);

                    }

                    cnx.cnx.Close();

                    SqlCommand cmndo = new SqlCommand(" select SUM(profit_vente)  from  achat where date_achat  between '" + a + "'  and  '" + b + "'  ", cnx.cnx);
                    cnx.cnx.Open();
                    SqlDataReader reado = cmndo.ExecuteReader();
                    while (reado.Read())
                    {

                        label8.Text = reado.GetValue(0).ToString();

                    }


                    cnx.cnx.Close();
                    int k = dataGridView1.Rows.Count - 1;
                    label1.Text = k.ToString();
                    label7.Text = "";
                }

                if (l == "vent")
                {
                    try
                    {
                        SqlCommand cmnd = new SqlCommand(" select *  from  vente where date_vente  between '" + a + "'  and  '" + b + "'  ", cnx.cnx);
                        cnx.cnx.Open();
                        SqlDataReader read = cmnd.ExecuteReader();
                        while (read.Read())
                        {
                            dataGridView1.Rows.Add(read[0], read[1], read[2], read[3], read[4], read[5], read[6], read[8], read[7]);


                        }
                        cnx.cnx.Close();
                    }
                    catch (Exception m) { MessageBox.Show("problem "+m.Message);}

                    SqlCommand cmndr = new SqlCommand(" select SUM(profit_vente)  from  vente where date_vente  between '" + a + "'  and  '" + b + "'  ", cnx.cnx);
                    cnx.cnx.Open();
                    SqlDataReader readr = cmndr.ExecuteReader();
                    while (readr.Read())
                    {

                        label8.Text = readr.GetValue(0).ToString();

                    }


                    cnx.cnx.Close();

                    int kl = dataGridView1.Rows.Count - 1;
                    label7.Text = kl.ToString();
                    label1.Text = "";
                }
            }
            catch (Exception t)
            {
                MessageBox.Show("remplire tous les champs " + t.Message);
            }
            finally
            {
                cnx.cnx.Close();
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
