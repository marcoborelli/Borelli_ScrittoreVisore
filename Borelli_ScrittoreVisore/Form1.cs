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
        bool switchUser = false;
        string vecchiDati = "";
        int cont = 0;

        scrittore loScrittore;
        visualizzatore ilVisualizzatore;
        public Form1()
        {
            InitializeComponent();
            richTextBox1.ReadOnly = true;
            ilVisualizzatore = new visualizzatore();
            loScrittore = new scrittore(ilVisualizzatore);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList; //1=tipoScrittura 2=colore

            comboBox2.Items.Add("ROSSO SCURO");
            comboBox2.Items.Add("ROSSO");
            comboBox2.Items.Add("GIALLO POLENTA");
            comboBox2.Items.Add("GIALLO");
            comboBox2.Items.Add("VERDE CHIARO");
            comboBox2.Items.Add("VERDE");
            comboBox2.Items.Add("AZZURRO");
            comboBox2.Items.Add("BLU");
            comboBox2.Items.Add("BLU SCURO");
            comboBox2.Items.Add("VIOLA");
            comboBox2.Items.Add("NERO");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && comboBox2.Text != ""&& (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked))
            {

                FontStyle font = getFont(ilVisualizzatore.Stile);
                richTextBox1.ForeColor = getColor(ilVisualizzatore.Colore);

                richTextBox1.Font = new Font("Consolas", 12, font);

                if (switchUser && cont != 1)//questa variabile è true solo quando modifico il nome utente quindi significa che devo andare a capo perchè ha iniziato un nuovo utente
                    vecchiDati = $"{richTextBox1.Text}\n";

                loScrittore.Nome = textBox2.Text;

                if (checkBox1.Checked)
                    loScrittore.Stile = checkBox1.Text;
                else if (checkBox2.Checked)
                    loScrittore.Stile = checkBox2.Text;
                else if (checkBox3.Checked)
                    loScrittore.Stile = checkBox3.Text;

                loScrittore.Colore = comboBox2.Text;

                if (loScrittore.Text.Length < textBox1.Text.Length) //vuol dire che ho aggiunto testo
                    loScrittore.Text += textBox1.Text.Substring(loScrittore.Text.Length, (textBox1.Text.Length - loScrittore.Text.Length));
                else if (loScrittore.Text.Length > textBox1.Text.Length)//vuol dire che ho cancellato testo
                    loScrittore.Text = $"{loScrittore.Text.Substring(0, textBox1.Text.Length)}";

                richTextBox1.Text = vecchiDati + $"{loScrittore.Nome.ToUpper()}: {loScrittore.Text}";

                switchUser = false;

            }
            else
                MessageBox.Show("SETTARE PRIMA I VALORI");
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //textBox1.Text = "";
            if (!switchUser)//perchè senò la prima volta che inserisco username va a capo
                cont++;

            switchUser = true;

        }

        public static FontStyle getFont(string stile)
        {
            if (stile == "GRASSETTO")
                return FontStyle.Bold;
            else if (stile == "CORSIVO")
                return FontStyle.Italic;
            else
                return FontStyle.Underline;
        }
        public Color getColor(string color)
        {
            if (color == "ROSSO SCURO")
                return Color.DarkRed;
            else if (color == "ROSSO")
                return Color.Red;
            else if (color == "GIALLO POLENTA")
                return Color.LightGoldenrodYellow;
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
                return Color.Purple;
            else
                return Color.Black;
        }
    }
}
