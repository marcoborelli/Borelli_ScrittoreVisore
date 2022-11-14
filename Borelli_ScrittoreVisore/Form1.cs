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

        Scrittore loScrittore;
        Visualizzatore ilVisualizzatore;

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

            ilVisualizzatore = new Visualizzatore(richTextBox1);
            loScrittore = new Scrittore(ilVisualizzatore);

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

                loScrittore.setColore(getColor(comboBox2.Text));

                loScrittore.setGrassetto(checkBox1.Checked);
                loScrittore.setCorsivo(checkBox3.Checked);
                loScrittore.setSottolineato(checkBox2.Checked);
            }
            else
                MessageBox.Show("SETTARE PRIMA I VALORI");

        }
        private void button1_Click(object sender, EventArgs e)//invia
        {
            textBox1_TextChanged(sender, e);//nel caso in cui non si metta nulla almeno mi salvo il nick dell'utente
            loScrittore.aggiungiTesto(textBox1.Text);
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
