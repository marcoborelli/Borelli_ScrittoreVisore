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
        scrittore scritt;
        visualizzatore visi;
        public Form1()
        {
            InitializeComponent();
            visi = new visualizzatore();
            scritt = new scrittore(visi);
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
                scritt.Nome = textBox2.Text;
                scritt.Stile = ConvertiStileInInt(comboBox1.Text);
                scritt.Colore = comboBox2.Text;

                if (scritt.Text.Length < textBox1.Text.Length)
                    scritt.Text += textBox1.Text.Substring(scritt.Text.Length, (textBox1.Text.Length - scritt.Text.Length));
                else if (scritt.Text.Length > textBox1.Text.Length)
                    scritt.Text = $"{scritt.Text.Substring(0, textBox1.Text.Length)}";

            }
            else
                MessageBox.Show("SETTARE PRIMA I VALORI");
        }
        private void button1_Click(object sender, EventArgs e)//invia
        {

            FontStyle f = richTextBox1.SelectionFont.Style;
            if (visi.Stile == 0)
                f ^= FontStyle.Bold;
            else if (visi.Stile == 1)
                f ^= FontStyle.Italic;
            else
                f ^= FontStyle.Underline;

            richTextBox1.SelectionFont=new Font(richTextBox1.SelectionFont,f);

            richTextBox1.Text = $"{scritt.Nome.ToUpper()}: {visi.Text}";
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
