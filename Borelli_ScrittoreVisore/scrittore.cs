using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_ScrittoreVisore
{
    public class scrittore
    {
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
                return _vis.Nome;
            }
            set
            {
                _vis.Nome = value;
            }
        }
        public int Stile
        {
            get
            {
                return _vis.Stile;
            }
            set
            {
                if (value >= 0 && value < 4)//controllo che vada bene
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
                return _vis.Text;
            }
            set
            {
                _vis.Text = value;
            }
        }
    }
}
