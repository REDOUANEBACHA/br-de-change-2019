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
    public partial class table_de_bord : Form
    {
        public table_de_bord()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            les_profit_et_les_operation prft = new les_profit_et_les_operation();
            prft.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            table_les_emploiye tb_em = new table_les_emploiye();
            this.Hide();
            tb_em.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            client_vent cl_v = new client_vent();
            this.Hide();
            cl_v.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            client_achat cl_ach = new client_achat();
            cl_ach.Show();
        }
       
   
    }
}
