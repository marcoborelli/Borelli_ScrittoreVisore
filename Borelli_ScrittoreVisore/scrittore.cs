using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_ScrittoreVisore
{
    public class scrittore
    {
        private string _nome;
        private string _text;
        private visualizzatore _vis;

        public scrittore (visualizzatore _ilVis)
        {
            this.Vis = _ilVis;
            this.Text = String.Empty;
        }

        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                _nome = value;
            }
        }
        public string[] Stile
        {
            get
            {
                return _vis.Stile;
            }
            set
            {
                    _vis.Stile = value;
            }
        }
        public visualizzatore Vis
        {
            get
            {
                return _vis;
            }
            set
            {
                _vis = value;
            }
        }
        public string Colore
        {
            get
            {
                return _vis.Colore;
            }
            set
            {
                _vis.Colore = value;
            }
        }
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }
    }
}
