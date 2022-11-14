using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Borelli_ScrittoreVisore
{
    public class Scrittore
    {
        private string _nome;
        private Visualizzatore _vis;

        public Scrittore(Visualizzatore _ilVis)
        {
            this.Vis = _ilVis;
        }

        public void setGrassetto(bool g)
        {
            _vis.Grassetto = g;
        }
        public void setSottolineato(bool s)
        {
            _vis.Sottolineato = s;
        }
        public void setCorsivo(bool c)
        {
            _vis.Corsivo = c;
        }
        public void setColore(Color col)
        {
            _vis.Colore = col;
        }

        public void aggiungiTesto(string testo)
        {
            _vis.visualizza(this.Nome, testo);
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

        public Visualizzatore Vis
        {
            get
            {
                return _vis;
            }
            set
            {
                if (value != null)
                    _vis = value;
                else
                    throw new Exception("Inserire un visualizzatore valido");
            }
        }
    }
}
