using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasy
{
    public interface IPracownik
    {
        string Imie { get; set; }
        string Nazwisko { get; set; }
        string Pesel { get; set; }
        decimal Zarobki { get; set; }
        List<IPracownik> ListaPodwladnych { get; }
        void ZwiekszZarobki(decimal zmiana);
        void DodajPodwladnego(IPracownik pracownik);
        void WyswietlListePodwladnych();
        void WyswietlZarobki();
    }
}
