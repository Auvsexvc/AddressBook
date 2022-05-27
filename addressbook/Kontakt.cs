using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook
{
    class Kontakt
    {
        public Kontakt(string nazwa, string numer)
        {
            Nazwa = nazwa;
            Numer = numer;
        }
        public string Nazwa { get; set; }
        public string Numer { get; set; }
    }
}
