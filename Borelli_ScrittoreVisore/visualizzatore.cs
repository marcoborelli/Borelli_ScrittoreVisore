using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_ScrittoreVisore
{
    public class visualizzatore
    {
        private int _stile;//0= grassetto 1= corsivo 2=sottolineato
        private string _colore;

        public int Stile
        {
            get
            {
                return _stile;
            }
            set
            {
                if (value >= 0 && value < 4)//controllo che vada bene
                    _stile = value;
            }
        }
        public string Colore
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
