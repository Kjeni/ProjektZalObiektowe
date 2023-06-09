using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasy
{
    public class Pracownik : IPracownik
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public decimal Zarobki { get; set; }
        private List<IPracownik> _ListaPodwladnych;
        public List<IPracownik> ListaPodwladnych
        {
            get
            {
                if (_ListaPodwladnych == null)
                    _ListaPodwladnych = new List<IPracownik>();
                return _ListaPodwladnych;
            }
        }

        public void DodajPodwladnego(IPracownik pracownik)
        {
            ListaPodwladnych.Add(pracownik);
        }

        public void WyswietlListePodwladnych()
        {
            Console.WriteLine("******** Lista podwładnych ********");
            foreach(IPracownik pracownik in _ListaPodwladnych)
            {
                Console.WriteLine($"{pracownik.Imie} {pracownik.Nazwisko}, Pesel: {pracownik.Pesel}, Zarobki: {pracownik.Zarobki}");
            }
        }

        public void WyswietlZarobki()
        {
            Console.WriteLine($"Zarobki dla {Imie} {Nazwisko} to: {Zarobki}");
        }

        public void ZwiekszZarobki(decimal zmiana)
        {
            Zarobki = Zarobki + zmiana;
        }
    }
}
