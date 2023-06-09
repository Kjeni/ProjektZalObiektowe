using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasy
{
    public interface IKsiazka
    {
        string Tytul { get; set; }
        string Autor { get; set; }
        string Rodzaj { get; set; }
        int LiczbaStron { get; set; }
        int Ocena { get; set; }
    }

    public interface IKsiegozbior
    {
        List<IKsiazka> Ksiazki { get; }
        void Dodaj(IKsiazka ksiazka);
        void WyswietlNajlepsze(int odOceny);
    }
}
