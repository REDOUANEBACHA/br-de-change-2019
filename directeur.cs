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
    public partial class directeur : Form
    {
        public directeur(string a , string b , int c )
        {
            InitializeComponent();
            label1.Text = a;
            label2.Text = b;
            label3.Text = c.ToString(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gestion_emlpyer gem = new gestion_emlpyer();
            gem.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            vent v = new vent(int.Parse(label3.Text));
            v.Show();
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            achat ach = new achat(int.Parse(label3.Text));
            ach.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            devis dvs = new devis();
            dvs.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            table_de_bord tb_br = new table_de_bord();
            tb_br.Show();






        }

        private void directeur_Load(object sender, EventArgs e)
        {

        }
    }
}
