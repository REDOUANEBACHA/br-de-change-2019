using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bureau_de_change
{
    public partial class gestion_emlpyer : Form
    {
        public gestion_emlpyer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ajouter_employer a = new ajouter_employer();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            modification_demployer md = new modification_demployer();
            md.Show();
            this.Hide();
        }

      

        private void button3_Click_1(object sender, EventArgs e)
        {
            supresion_d_employer s = new supresion_d_employer();
            s.Show();
            this.Hide();
        }
    }
}
