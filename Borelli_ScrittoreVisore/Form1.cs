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
            comboBox1.DropDownStyle = comboBox2.DropDownStyle = ComboBoxStyle.DropDownList; //1=tipoScrittura 2=colore

            comboBox1.Items.Add("GRASSETTO");
            comboBox1.Items.Add("CORSIVO");
            comboBox1.Items.Add("SOTTOLINEATO");

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
            if (textBox2.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {

                FontStyle font = getFont(ilVisualizzatore.Stile);
                richTextBox1.ForeColor = getColor(ilVisualizzatore.Colore);

                richTextBox1.Font = new Font("Consolas", 12, font);

                if (switchUser)//questa variabile è true solo quando modifico il nome utente quindi significa che devo andare a capo perchè ha iniziato un nuovo utente
                {
                    vecchiDati = $"{richTextBox1.Text}\n";
                    loScrittore.Nome = textBox2.Text;
                }

                loScrittore.Stile = ConvertiStileInInt(comboBox1.Text);
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
            switchUser = true;
        }

        public static int ConvertiStileInInt(string stile)
        {
            if (stile == "GRASSETTO")
                return 0;
            else if (stile == "CORSIVO")
                return 1;
            else
                return 2;
        }
        public static FontStyle getFont(int stile)
        {
            if (stile == 0)
                return FontStyle.Bold;
            else if (stile == 1)
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
