using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_ScrittoreVisore
{
    public class visualizzatore
    {
        private string _stile;//0= grassetto 1= corsivo 2=sottolineato
        private string _colore;

        public string Stile
        {
            get
            {
                return _stile;
            }
            set
            {
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
