using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieObiektowe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Witaj świecie!");
            int wiek = 26;
            string imie = "Jan";
            string odstep = " ";
            Console.WriteLine(imie + odstep + "ma" + odstep + wiek + odstep + "lat");

            Ints();
            Floats();
            Bools();
            Chars();
            Strings();
            Ifs();
            Switches();*/

            /*Petle();
            decimal wynik = WynikDodawania(b:2, a:3);
            Console.WriteLine(wynik);

            decimal[] liczby = { 1, 2, 3, 4, 0 };
            decimal? max = Max(liczby);
            if (max == null)
                Console.WriteLine("Tablica nie ma wprowadzonych wartości!");
            else
                Console.WriteLine(max);
            Console.WriteLine("*************** Silnia ***************");

            Console.WriteLine("Wpisz liczbę i naciśnij ENTER");
            string s = Console.ReadLine();

            short liczbaZTekstu;
            if (short.TryParse(s, out liczbaZTekstu))
                Console.WriteLine(Silnia(liczbaZTekstu));

            WprowadzanieLiczb();*/

            PowielTekst();


            Console.ReadKey();
        }

        static void Ints()
        {
            Console.WriteLine("*************** TYP int ***************");
            int intMin = int.MinValue;
            int intMax = int.MaxValue;
            Console.WriteLine(intMin);
            Console.WriteLine(intMax);

            Console.WriteLine("*************** TYP uint ***************");
            uint uintMin = uint.MinValue;
            uint uintMax = uint.MaxValue;
            Console.WriteLine(uintMin);
            Console.WriteLine(uintMax);

            Console.WriteLine("*************** TYP long ***************");
            long lintMin = long.MinValue;
            long lintMax = long.MaxValue;
            Console.WriteLine(lintMin);
            Console.WriteLine(lintMax);

            long bardzo_duza_liczba = 0;
        }

        static void Floats()
        {
            Console.WriteLine("*************** TYP float ***************");
            float fMin = float.MinValue;
            float fMax = float.MaxValue;
            Console.WriteLine(fMin);
            Console.WriteLine(fMax);

            float pi = 3.14f;
            float promien = 5f;
            float poleKola = pi * promien * promien;
            Console.WriteLine($"Pole koła o promieniu {promien} wynosi: {poleKola}");

            Console.WriteLine("*************** TYP double ***************");
            double dMin = double.MinValue;
            double dMax = double.MaxValue;
            Console.WriteLine(dMin);
            Console.WriteLine(dMax);

            Console.WriteLine("*************** TYP decimal ***************");
            decimal decMin = decimal.MinValue;
            decimal decMax = decimal.MaxValue;
            Console.WriteLine(decMin);
            Console.WriteLine(decMax);

        }

        static void Bools()
        {
            Console.WriteLine("*************** TYP bool ***************");
            bool wartoscLogiczna = false;
            int l1 = 1;
            int l2 = 2;
            bool coJestWieksze = l1 > l2;
            Console.WriteLine(coJestWieksze);

        }

        static void Chars()
        {
            Console.WriteLine("*************** TYP char ***************");
            char znak = 'ą';
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(znak);

            char znakPlus ='\u002B';
            Console.WriteLine(znakPlus);

        }

        static void Strings()
        {
            Console.WriteLine("*************** TYP string ***************");
            string nazwaUzytkownika = "Administrator";
            Console.WriteLine(nazwaUzytkownika);
            Console.WriteLine(nazwaUzytkownika[10]);

            string separator = new string('*', 30);
            Console.WriteLine(separator);

            string owoce = "Jabłka, GruSZki";
            Console.WriteLine(owoce.ToLower().Contains("gruszki"));

            int liczba = 424544578;
            Console.WriteLine(liczba.ToString().Contains("3"));
            Console.WriteLine("*************** TYP string Format ***************");
            string zlaczenie = string.Format("To jest tekst {0} {1}", "AAA", "BBB");
            Console.WriteLine(zlaczenie);

            string tekst = "12 23";
            float liczba1;
            if (float.TryParse(tekst, out liczba1))
            {
                Console.WriteLine($"Znaleziono : {liczba1}");
            }
            else
            {
                Console.WriteLine($"Tekst {tekst} nie jest liczbą");
            }
        }

        static void Ifs()
        {
            Console.WriteLine("*************** Instrukcja if ***************");
            int a = 10;
            int b = 9;
            if (a > b)
                Console.WriteLine("a jest większe od b");
            else
                Console.WriteLine("a nie jest większe od b");
            int c = 11;
            int d = 19;
            if (a < b || c < d)
                Console.WriteLine("a jest mniejsze od b LUB c mniejsze od d");
            if (a < b && c < d)
                Console.WriteLine("a jest mniejsze od b I c mniejsze od d");
            if (a != c)
                Console.WriteLine("a nie jest równe c");
        }

        static void Switches()
        {
            Console.WriteLine("*************** Instrukcja switch ***************");
            uint i = 21;
            switch(i)
            {
                case 0:
                    Console.WriteLine("i równe 0");
                    break;
                case 1:
                    Console.WriteLine("i równe 1");
                    break;
                case 2:
                    Console.WriteLine("i równe 2");
                    break;
                default:
                    Console.WriteLine("i większe niż 2");
                    break;
            }
        }

        static void PierwiastkiRownaniaKwadratowego()
        {
            double a = -1;
            double b = -2;
            double c = 2;
        }

        static void Petle()
        {
            Console.WriteLine("*************** Pętle - foreach ***************");
            string[] nazwyMiast = { "Warszawa", "Szczecin", "Kraków", "Poznań", "Wrocław" };
            foreach (string miasto in nazwyMiast)
            {
                Console.WriteLine(miasto);
            }

            Console.WriteLine("*************** Miasta na 'w' ***************");
            string szukaj = "w";
            foreach (string miasto in nazwyMiast)
            {
                if (miasto.ToLower().StartsWith(szukaj.ToLower()))
                    Console.WriteLine(miasto);
            }

            Console.WriteLine("*************** Pętle - while ***************");
            int i = 0;
            while (i < nazwyMiast.Length)
            {
                Console.WriteLine(nazwyMiast[i]);
                i++;
            }
            i = 0;
            Console.WriteLine("*************** Pętle - do while ***************");
            do
            {
                Console.WriteLine(nazwyMiast[i]);
                i++;
            } while (i < 5);
            Console.WriteLine("*************** Pętle - for ***************");
            for (int i1 = 0; i1 < nazwyMiast.Length; i1++)
            {
                Console.WriteLine(nazwyMiast[i1]);
            }
        }

        static decimal WynikDodawania(decimal a=1000, decimal b=100)
        {
            Console.WriteLine("*************** Funkcje z parametrami ***************");
            return a + b;
        }

        /// <summary>
        /// Funkcja zwracająca maksymalną wartość z podanej tablicy liczb
        /// </summary>
        /// <param name="liczby">Tablica liczb</param>
        /// <returns>Maksymalna wartość spośród licz znajdujących się w tablicy</returns>
        static decimal? Max(decimal[] liczby)
        {
            decimal? max = null;
            if (liczby != null && liczby.Length > 0)
            {
                max = liczby[0];
                foreach (decimal d in liczby)
                    if (max < d)
                        max = d;
            }
            return max;
        }

        /// <summary>
        /// Obliczanie silni
        /// </summary>
        /// <param name="liczba">liczba naturalna, dla której ma być policzona silnia</param>
        /// <returns>Silnia z danej liczby</returns>
        static long Silnia(short liczba)
        {
            long silnia = 1;
            for (short i = 2; i <= liczba; i++)
                silnia = silnia * i;
            return silnia;
        }

        static void WprowadzanieLiczb()
        {
            Console.WriteLine("Wprowadź liczbę:");
            string s; int liczba; bool liczbaOK;
            do
            {
                s = Console.ReadLine();
                liczbaOK = int.TryParse(s, out liczba);
                if (!liczbaOK)
                    Console.WriteLine("Wprowadź prawidłową liczbę:");
            }
            while (!liczbaOK);
        }

        static void PowielTekst()
        {
            Console.WriteLine("Wprowadź liczbę powieleń:");
            int l;
            string lp = Console.ReadLine();
            if (int.TryParse(lp, out l) && l > 0)
            {
                Console.WriteLine("Wprowadź tekst do powielenia:");
                string tekstDoPowielenia = Console.ReadLine();
                StringBuilder sb = new StringBuilder();
                string powielony = string.Empty;
                DateTime start = DateTime.Now;
                for(int i = 1; i <= l; i++)
                {
                    powielony = powielony + tekstDoPowielenia;
                    //sb.Append(tekstDoPowielenia);
                }
                //File.WriteAllText("plik.txt", sb.ToString());
                File.WriteAllText("plik.txt", powielony);
                DateTime koniec = DateTime.Now;
                Console.WriteLine($"Zapisane w czasie {koniec - start}");

            }
        }
    }
}
