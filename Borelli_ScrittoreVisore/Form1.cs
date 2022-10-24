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
            ilVisualizzatore = new visualizzatore();
            loScrittore = new scrittore(ilVisualizzatore);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = comboBox2.DropDownStyle = ComboBoxStyle.DropDownList; //1=tipoScrittura 2=colore

            comboBox1.Items.Add("GRASSETTO");
            comboBox1.Items.Add("CORSIVO");
            comboBox1.Items.Add("SOTTOLINEATO");

            comboBox2.Items.Add("Yellow");
            comboBox2.Items.Add("Black");
            comboBox2.Items.Add("Red");
            comboBox2.Items.Add("Green");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
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
            switchUser = true;
            textBox1.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)//invia
        {

            FontStyle f = richTextBox1.SelectionFont.Style;
            if (ilVisualizzatore.Stile == 0)
                f ^= FontStyle.Bold;
            else if (ilVisualizzatore.Stile == 1)
                f ^= FontStyle.Italic;
            else
                f ^= FontStyle.Underline;

            richTextBox1.SelectionFont=new Font(richTextBox1.SelectionFont,f);

            richTextBox1.Text = $"{loScrittore.Nome.ToUpper()}: {loScrittore.Text}";
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
    }
}
