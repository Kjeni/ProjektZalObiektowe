using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Obliczenia ob = new Obliczenia();
            ob.A = 1;
            ob.B = 2;
            Console.WriteLine(ob.WynikDodawania);
            Console.WriteLine(ob.Odejmij());
            Console.WriteLine(ob.Pomnoz());
            Console.WriteLine(ob.Podziel());
            Console.WriteLine($"Ostatnia operacja: {ob.RodzajOperacjiTekstowo}");

            Obliczenia ob2 = new Obliczenia();

            ob2.A = 100;
            ob2.B = 200;
            ob2.Odejmij();

            Obliczenia ob3 = new Obliczenia(1000, 1000000);
            ob3.Podziel();

            Console.WriteLine("********** Historia *********");
            foreach (Obliczenia h in Obliczenia.Historia)
            {
                Console.WriteLine($"A = {h.A}; B = {h.B}; Operacja = {h.RodzajOperacjiTekstowo}");
            }

            ObslugaPracownikow();


            Console.ReadKey();
        }

        static void ObslugaPracownikow()
        {
            Console.WriteLine("********* Obsługa pracowników *********");

            IPracownik pracownik = new Pracownik();
            pracownik.Imie = "Jan";
            pracownik.Nazwisko = "Kowalski";
            pracownik.Pesel = "80090109876";
            pracownik.Zarobki = 10000;

            IPracownik pracownik2 = new Pracownik()
            {
                Imie = "Anna",
                Nazwisko = "Nowak",
                Pesel = "91010198765",
                Zarobki = 15000
            };

            pracownik2.DodajPodwladnego(pracownik);
            pracownik.ZwiekszZarobki(1000);
            pracownik2.WyswietlZarobki();
            pracownik2.WyswietlListePodwladnych();
        }
    }
}
