using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktury
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Faktura f = new Faktura()
            {
                DataSprzedazy = new DateTime(2023, 4, 14),
                NipKlienta = "8889992211",
                Numer = "10/2023"
            };
            IPozycjaFaktury pf1 = new PozycjaFaktury()
            {
                Lp = 1,
                NazwaProduktu = "Telewizor",
                CenaJednostkowa = 5000,
                Liczba = 1,
                JednostkaMiary = "Szt.",
                StawkaVat = 0.23m
            };
            IPozycjaFaktury pf2 = new PozycjaFaktury()
            {
                Lp = 2,
                NazwaProduktu = "Kolumny głośnikowe",
                CenaJednostkowa = 4000,
                Liczba = 1,
                JednostkaMiary = "Para",
                StawkaVat = 0.23m
            };
            f.DodajPozycje(pf1);
            f.DodajPozycje(pf2);

            Console.WriteLine($"Brutto pierwszej pozycji {f.BruttoPierwszejPozycji()}");

            f.WyswietlKwoty();

            pf1.Liczba = 2;
            f.WyswietlKwoty();

            Console.ReadKey();
        }
    }
}
