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
    public partial class lotoForm : Form
    {
        //Brojac za Button brojeve
        private int GlobalCounter = 0;
        private List<int> odabraniBrojevi = new List<int>();
        public lotoForm()
        {
            InitializeComponent();

            //Linija ispod naslova
            lineLbl.BorderStyle = BorderStyle.Fixed3D;
        }
        #region buttonOnClick
        private void button1_Click(object sender, EventArgs e)
        {
            Oznaci(button1);
            EnableButton();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Oznaci(button2);
            EnableButton();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Oznaci(button3);
            EnableButton();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Oznaci(button4);
            EnableButton();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Oznaci(button5);
            EnableButton();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Oznaci(button6);
            EnableButton();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Oznaci(button7);
            EnableButton();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Oznaci(button14);
            EnableButton();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Oznaci(button13);
            EnableButton();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Oznaci(button12);
            EnableButton();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Oznaci(button11);
            EnableButton();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Oznaci(button10);
            EnableButton();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Oznaci(button9);
            EnableButton();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Oznaci(button8);
            EnableButton();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Oznaci(button21);
            EnableButton();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Oznaci(button20);
            EnableButton();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Oznaci(button19);
            EnableButton();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Oznaci(button18);
            EnableButton();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Oznaci(button17);
            EnableButton();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Oznaci(button16);
            EnableButton();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Oznaci(button15);
            EnableButton();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Oznaci(button28);
            EnableButton();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Oznaci(button27);
            EnableButton();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Oznaci(button26);
            EnableButton();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Oznaci(button25);
            EnableButton();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Oznaci(button24);
            EnableButton();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Oznaci(button23);
            EnableButton();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Oznaci(button22);
            EnableButton();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Oznaci(button35);
            EnableButton();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Oznaci(button34);
            EnableButton();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Oznaci(button33);
            EnableButton();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Oznaci(button32);
            EnableButton();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Oznaci(button31);
            EnableButton();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Oznaci(button30);
            EnableButton();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Oznaci(button29);
            EnableButton();
        }
        #endregion
        //Metoda za Enable-anje buttona za Odigrat ako su ukljucena 7 brojeva
        private void EnableButton()
        {
            if (GlobalCounter == 7)
            {
                btnOdigraj.Enabled = true;
            }
            else
            {
                btnOdigraj.Enabled = false;
            }
        }

        //Metoda za Oznacavanje brojeva u crveno pod oznacenim i maksimalno oznacivanje 7 brojeva
        private void Oznaci(Button button)
        {
            if ((GlobalCounter <= 6) || (button.BackColor == Color.DarkRed && GlobalCounter == 7))
            {
                if (button.BackColor == Color.White)
                {
                    button.BackColor = Color.DarkRed;
                    button.ForeColor = Color.White;
                    button.FlatAppearance.BorderColor = Color.DarkRed;
                    GlobalCounter++;
                }
                else
                {
                    button.BackColor = Color.White;
                    button.ForeColor = Color.Black;
                    button.FlatAppearance.BorderColor = Color.Red;
                    GlobalCounter--;
                }
            }
            else
            {
                MessageBox.Show("Možete odabrati maksimalno 7 brojeva.", "Pažnja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOdigraj_Click(object sender, EventArgs e)
        {
            foreach (Button buttoni in Controls.OfType<Button>())
            {
                if (buttoni.BackColor == Color.DarkRed && buttoni.Text != "ODIGRAJ")
                {
                    int broj = int.Parse(buttoni.Text.Trim());
                    odabraniBrojevi.Add(broj);
                }
            }

            Rezultat rezForma = new Rezultat(odabraniBrojevi);
            this.Hide();
            rezForma.ShowDialog();
            this.Close();

        }
    }
}
