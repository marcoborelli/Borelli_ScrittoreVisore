using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borelli_ScrittoreVisore
{
    public partial class Form1 : Form
    {
        /*bool switchUser = false;
        string vecchiDati = "";
        int cont = 0;*/
        CheckBox[] arrayCarino;

        scrittore loScrittore;
        visualizzatore ilVisualizzatore;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
                button1.PerformClick();
            else if (keyData == (Keys.Control | Keys.NumPad1) || (keyData == (Keys.Control | Keys.D1)))//aumenta volume
                textBox2.Focus();
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public Form1()
        {
            InitializeComponent();

            richTextBox1.ReadOnly = true;//così non posso scriverci ed è di sola lettura

            ilVisualizzatore = new visualizzatore();
            loScrittore = new scrittore(ilVisualizzatore);

            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList; 

            comboBox2.Items.Add("ROSSO SCURO"); //tutto l'elenco della combo-box
            comboBox2.Items.Add("ROSSO");
            comboBox2.Items.Add("GIALLOGNOLO");
            comboBox2.Items.Add("GIALLO");
            comboBox2.Items.Add("VERDE CHIARO");
            comboBox2.Items.Add("VERDE");
            comboBox2.Items.Add("AZZURRO");
            comboBox2.Items.Add("BLU");
            comboBox2.Items.Add("BLU SCURO");
            comboBox2.Items.Add("VIOLA");
            comboBox2.Items.Add("NERO");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.Text = "NERO";
            textBox1.Text = "";//è quella in cui scrivo il testo
            checkBox1.Checked = checkBox2.Checked = checkBox3.Checked = false;
            //textBox2.Text = "Marco";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && comboBox2.Text != "" /*&& (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked)*/)
            {

                loScrittore.Nome = textBox2.Text;
                loScrittore.Colore = comboBox2.Text;

                arrayCarino = new CheckBox[] { checkBox1, checkBox2, checkBox3 };

                int count = getNumeroCaselleSelez(arrayCarino);
                loScrittore.Stile = new string[count];
                int k = 0;
                for (int i = 0; i < arrayCarino.Length; i++)
                {
                    if (arrayCarino[i].Checked)
                    {
                        loScrittore.Stile[k] = arrayCarino[i].Text;
                        k++;
                    }
                }

                if (loScrittore.Text.Length < textBox1.Text.Length) //vuol dire che ho aggiunto testo
                    loScrittore.Text += textBox1.Text.Substring(loScrittore.Text.Length, (textBox1.Text.Length - loScrittore.Text.Length));
                else if (loScrittore.Text.Length > textBox1.Text.Length)//vuol dire che ho cancellato testo
                    loScrittore.Text = $"{loScrittore.Text.Substring(0, textBox1.Text.Length)}";

                //richTextBox1.Text = vecchiDati + $"{loScrittore.Nome.ToUpper()}: {loScrittore.Text}";

            }
            else
                MessageBox.Show("SETTARE PRIMA I VALORI");

        }
        private void button1_Click(object sender, EventArgs e)//invia
        {
            //if (!switchUser)
            //{

            textBox1_TextChanged(sender, e);//nel caso in cui non si metta nulla almeno mi salvo il nick dell'utente

            /*string uwu = "";
            for (int i = 0; i < ilVisualizzatore.Stile.Length; i++)
                uwu += $"{ilVisualizzatore.Stile[i]}\n";

            MessageBox.Show($"{uwu}");*/


            Font fontt = richTextBox1.SelectionFont;
            if (fontt != null)
            {
                FontStyle f=FontStyle.Regular; //lo inizializzo così poi cambio alla peggio

                for (int i = 0; i < getNumeroCaselleSelez(arrayCarino)/*-1*/;i++)
                    f ^= (getFont(ilVisualizzatore.Stile[i]));

                //f = (getFont(ilVisualizzatore.Stile[i]) | getFont(ilVisualizzatore.Stile[i+1]));

                richTextBox1.SelectionFont = new Font(fontt, f);
            }
            richTextBox1.SelectionColor = getColor(ilVisualizzatore.Colore);

            richTextBox1.AppendText($"{loScrittore.Nome}: {textBox1.Text}\n");
            //}
        }

        public static int getNumeroCaselleSelez(CheckBox[] check)
        {
            int count = 0;
            for (int i = 0; i < check.Length; i++)
            {
                if (check[i].Checked)
                    count++;
            }

            return count;
        }
        public static FontStyle getFont(string stile)
        {
            if (stile == "GRASSETTO")
                return FontStyle.Bold;
            else if (stile == "CORSIVO")
                return FontStyle.Italic;
            else if (stile == "SOTTOLINEATO")
                return FontStyle.Underline;
            else
                return FontStyle.Regular;
        }
        public Color getColor(string color)
        {
            if (color == "ROSSO SCURO")
                return Color.DarkRed;
            else if (color == "ROSSO")
                return Color.Red;
            else if (color == "GIALLOGNOLO")
                return Color.YellowGreen;
            else if (color == "GIALLO")
                return Color.Yellow;
            else if (color == "VERDE CHIARO")
                return Color.LightGreen;
            else if (color == "VERDE")
                return Color.Green;
            else if (color == "AZZURRO")
                return Color.LightBlue;
            else if (color == "BLU")
                return Color.Blue;
            else if (color == "BLU SCURO")
                return Color.DarkBlue;
            else if (color == "VIOLA")
                return Color.DarkViolet;
            else
                return Color.Black;
        }
    }
}
