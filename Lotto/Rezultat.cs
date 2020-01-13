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
        private List<int> listaGeneriranihBrojeva = new List<int>();
        private int brojacPogodenih;

        public Rezultat(List<int> ulaznaLista)
        {
            listaOdabranihBrojeva = ulaznaLista.OrderBy(x => x).ToList();
            InitializeComponent();

            //Linija ispod naslova
            lineLbl.BorderStyle = BorderStyle.Fixed3D;
            label5.BorderStyle = BorderStyle.Fixed3D;
        }

        private void Rezultat_Load(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("SWI_HOME_DIR", @"prolog");
            Environment.SetEnvironmentVariable("Path", @"prolog");
            Environment.SetEnvironmentVariable("Path", @"prolog\bin");
            string[] p = { "-q", "-f", @"lotto.pl" };

            if (!PlEngine.IsInitialized)
                PlEngine.Initialize(p);

            PlQuery generatorBrojeva = new PlQuery("lotto(7,35,L)");
            foreach (PlQueryVariables randomBrojevi in generatorBrojeva.SolutionVariables)
            {
                int brojacIndexa = 0;
                foreach (var item in listaOdabranihBrojeva)
                {
                    PlQuery lotto = new PlQuery("findnum("+item.ToString()+","+randomBrojevi["L"].ToString()+",Ispis)");
                    foreach (PlQueryVariables provjeraBrojeva in lotto.SolutionVariables)
                    {
                        if (provjeraBrojeva["Ispis"].ToString() == "Pronaden")
                        {
                                if (brojacIndexa == 0)
                                    label7.ForeColor = Color.Green;
                                else if (brojacIndexa == 1)
                                    label9.ForeColor = Color.Green;
                                else if (brojacIndexa == 2)
                                    label11.ForeColor = Color.Green;
                                else if (brojacIndexa == 3)
                                    label10.ForeColor = Color.Green;
                                else if (brojacIndexa == 4)
                                    label14.ForeColor = Color.Green;
                                else if (brojacIndexa == 5)
                                    label13.ForeColor = Color.Green;
                                else if (brojacIndexa == 6)
                                    label12.ForeColor = Color.Green;
                            brojacPogodenih++;
                            break;
                        }
                        else if (provjeraBrojeva["Ispis"].ToString() == "Nije pronaden")
                        {
                            for (int i = 0; i < listaOdabranihBrojeva.Count; i++)
                            {
                                if (brojacIndexa == 0)
                                    label7.ForeColor = Color.Black;
                                else if (brojacIndexa == 1)
                                    label9.ForeColor = Color.Black;
                                else if (brojacIndexa == 2)
                                    label11.ForeColor = Color.Black;
                                else if (brojacIndexa == 3)
                                    label10.ForeColor = Color.Black;
                                else if (brojacIndexa == 4)
                                    label14.ForeColor = Color.Black;
                                else if (brojacIndexa == 5)
                                    label13.ForeColor = Color.Black;
                                else if (brojacIndexa == 6)
                                    label12.ForeColor = Color.Black;
                            }
                            break;
                        }
                    }
                    brojacIndexa++;
                }

                string splitBrojeva = randomBrojevi["L"].ToString();
                splitBrojeva = splitBrojeva.Trim('[');
                splitBrojeva = splitBrojeva.Trim(']');
                string[] splitBrojevaLista = splitBrojeva.Split(',');

                foreach (var broj in splitBrojevaLista)
                {
                    label4.Text += broj + " ";
                }

                label1.Text += brojacPogodenih;

                label7.Text = listaOdabranihBrojeva[0].ToString();
                label9.Text = listaOdabranihBrojeva[1].ToString();
                label11.Text = listaOdabranihBrojeva[2].ToString();
                label10.Text = listaOdabranihBrojeva[3].ToString();
                label14.Text = listaOdabranihBrojeva[4].ToString();
                label13.Text = listaOdabranihBrojeva[5].ToString();
                label12.Text = listaOdabranihBrojeva[6].ToString();

                if (brojacPogodenih == 0)
                {
                    label8.Text += "0 kn";
                }
                else if (brojacPogodenih == 1)
                {
                    label8.Text += "17,84 kn";
                }
                else if (brojacPogodenih == 2)
                {
                    label8.Text += "114,54 kn";
                }
                else if (brojacPogodenih == 3)
                {
                    label8.Text += "217,96 kn";
                }
                else if (brojacPogodenih == 4)
                {
                    label8.Text += "871,84 kn";
                }
                else if (brojacPogodenih == 5)
                {
                    label8.Text += "8.718,40 kn";
                }
                else if (brojacPogodenih == 6)
                {
                    label8.Text += "6.240.000 kn";
                }
                else if (brojacPogodenih == 7)
                {
                    label8.Text += "7.500.000 kn";
                }

            }
        }

        private void btnPonovo_Click(object sender, EventArgs e)
        {
            lotoForm lottoForm = new lotoForm();
            this.Hide();
            lottoForm.ShowDialog();
            this.Close();
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            PlEngine.PlCleanup();
            this.Close();
        }
    }
}
