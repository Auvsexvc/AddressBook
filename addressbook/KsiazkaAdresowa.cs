using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook
{
    class KsiazkaAdresowa
    {
        public List<Kontakt> Kontakty { get; set; } = new List<Kontakt>();

        public void DodajKontakt(Kontakt kontakt)
        {
            Kontakty.Add(kontakt);
        }

        private void WyswietlSzczegolyKontaktu(Kontakt kontakt)
        {
            Console.WriteLine($"Kontakt: {kontakt.Nazwa}, {kontakt.Numer}");
        }

        private void WyswietlSczegolyKontaktow(List<Kontakt> kontakty)
        {
            foreach (var kontakt in kontakty)
            {
                WyswietlSzczegolyKontaktu(kontakt);
            }
        }

        public bool WyswietlKontakt(string numer)
        {
            var kontakt = Kontakty.FirstOrDefault(k => k.Numer == numer);

            if(kontakt == null)
            {
                Console.WriteLine("Kontakt nie znaleziony");
                return false;
            }
            else
            {
                WyswietlSzczegolyKontaktu(kontakt);
                return true;
            }
        }

        public void UsunKontakt(string numer)
        {
            var kontakt = Kontakty.FirstOrDefault(k => k.Numer == numer);
            Kontakty.Remove(kontakt);
        }

        public void WyswietlWszystkieKontakty()
        {
            WyswietlSczegolyKontaktow(Kontakty);
        }

        public void WyswietlPasujaceKontaktu( string szukanaFraza)
        {
            var pasujaceKontakty = Kontakty.Where(c => c.Nazwa.Contains(szukanaFraza)).ToList();
            WyswietlSczegolyKontaktow(pasujaceKontakty);
        }
    }
}
