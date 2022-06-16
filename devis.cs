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
    public partial class devis : Form
    {
        public devis()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ajouter_devis aj = new ajouter_devis();
            aj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            suprimer_devis sp_de = new suprimer_devis();
            sp_de.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            modifier_devis md = new modifier_devis();
            md.Show();
        }
    }
}
