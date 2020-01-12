using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SbsSW.SwiPlCs;

namespace Lotto_7_35
{
    public partial class Rezultat : Form
    {
        private List<int> listaOdabranihBrojeva;
        public Rezultat(List<int> ulaznaLista)
        {
            listaOdabranihBrojeva = ulaznaLista.OrderBy(x => x).ToList();
            InitializeComponent();

            //Linija ispod naslova
            lineLbl.BorderStyle = BorderStyle.Fixed3D;
            label5.BorderStyle = BorderStyle.Fixed3D;

            OdabraniBrojevi();
        }                                                                                                    
                                                    
        //Metoda koja je prosljeđena iz Lotto-a, korisnički odabrani brojevi
        private void OdabraniBrojevi()
        {
            foreach (var item in listaOdabranihBrojeva)
            {
                label4.Text += item.ToString() + " ";
            }
        }

        private void Rezultat_Load(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("SWI_HOME_DIR", @"swipl");
            Environment.SetEnvironmentVariable("Path", @"swipl\bin");
            string[] p = { "-q", "-f", @"lotto.pl" };
            PlEngine.Initialize(p);
        }

        private void Rezultat_FormClosing(object sender, FormClosingEventArgs e)
        {
            PlQuery q = new PlQuery("zatvoriDatoteku");
            q.NextSolution();
            PlEngine.PlCleanup();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlQuery lotto = new PlQuery("test()");
            MessageBox.Show(lotto.ToString());
        }
    }
}
