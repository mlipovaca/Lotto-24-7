using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto_7_35
{
    public partial class Pocetna : Form
    {
        public Pocetna()
        {
            InitializeComponent();

            //Linija ispod naslova
            lineLbl.BorderStyle = BorderStyle.Fixed3D;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lotoForm lotoForma = new lotoForm();
            this.Hide();
            lotoForma.ShowDialog();
            this.Close();
        }
    }
}
