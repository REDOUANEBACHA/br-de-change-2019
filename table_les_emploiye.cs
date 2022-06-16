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
    public partial class table_les_emploiye : Form
    {
        public table_les_emploiye()
        {
            InitializeComponent();
        }
        classe_cnx cnx = new classe_cnx();

        private void table_les_emploiye_Load(object sender, EventArgs e)
        {
           
            SqlCommand cmnd = new SqlCommand("SELECT * FROM employé", cnx.cnx);
            cnx.cnx.Open();
            SqlDataReader read  =  cmnd.ExecuteReader();
            while (read.Read())
            {
                dataGridView1.Rows.Add(read[0], read[1], read[2], read[3], read[4], read[5], read[7]);
            }

            cnx.cnx.Close();
        }
    }
}
