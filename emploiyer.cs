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
    public partial class emploiyer : Form
    {
        public emploiyer(string a , string b , int c)
        {
           InitializeComponent ();
           label1.Text = a;
           label2.Text = b;
           label3.Text = c.ToString();
           
        
        }
        classe_cnx cnx = new classe_cnx();
        private void button3_Click(object sender, EventArgs e)
        {

            vent vnt = new vent(int.Parse(label3.Text));
            vnt.Show();
        }

        private void emploiyer_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            achat ach = new achat(int.Parse(label3.Text));
            ach.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
