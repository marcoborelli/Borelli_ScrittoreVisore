using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace Borelli_ScrittoreVisore
{
    public class Visualizzatore
    {
        private Color _colore;
        private bool _grassetto, _corsivo, _sottolineato;

        private RichTextBox _rich = new RichTextBox();

        public Visualizzatore(RichTextBox rich)
        {
            this.Rich = rich;
        }
        public void visualizza(string nome, string testo)
        {
            Font fontt = _rich.SelectionFont;
            if (fontt != null)
            {
                FontStyle f = FontStyle.Regular; //lo inizializzo così poi cambio alla peggio

                if (this.Grassetto)
                    f ^= FontStyle.Bold;
                if (this.Corsivo)
                    f ^= FontStyle.Italic;
                if (this.Sottolineato)
                    f ^= FontStyle.Underline;

                

                _rich.SelectionFont = new Font(fontt, f);
            }
            _rich.SelectionColor = this.Colore;

            _rich.AppendText($"{nome}: {testo}\n");
        }

        public RichTextBox Rich
        {
            get
            {
                return _rich;
            }
            set
            {
                if (value != null)
                    _rich = value;
                else
                    throw new Exception("Inserire valori validi");
            }
        }
        public bool Grassetto
        {
            get
            {
                return _grassetto;
            }
            set
            {
                _grassetto = value;
            }
        }

        public bool Corsivo
        {
            get
            {
                return _corsivo;
            }
            set
            {
                _corsivo = value;
            }
        }

        public bool Sottolineato
        {
            get
            {
                return _sottolineato;
            }
            set
            {
                _sottolineato = value;
            }
        }

        public Color Colore
        {
            get
            {
                return _colore;
            }
            set
            {
                _colore = value;
            }
        }

    }
}
