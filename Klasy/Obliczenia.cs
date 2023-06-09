using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasy
{
    public enum RodzajeOperacji { Dodawanie, Odejmowanie, Mnozenie, Dzielenie}
    public class Obliczenia
    {
        public Obliczenia()
        {

        }
        public Obliczenia(float a, float b)
        {
            _a = a;
            _b = b;
        }

        static private List<Obliczenia> _historia;
        static public List<Obliczenia> Historia
        {
            get
            {
                if (_historia == null)
                    _historia = new List<Obliczenia>();
                return _historia;
            }
        }

        private void dodajElementHistorii()
        {
            Obliczenia h = new Obliczenia();
            h._a = A;
            h._b = B;
            h.RodzajOperacji = RodzajOperacji;
            Historia.Add(h);
        }

        public RodzajeOperacji RodzajOperacji { get; private set; }
        public string RodzajOperacjiTekstowo
        {
            get
            {
                switch (RodzajOperacji)
                {
                    case RodzajeOperacji.Dodawanie:
                        return "Dodawanie";
                    case RodzajeOperacji.Mnozenie:
                        return "Mnożenie";
                    case RodzajeOperacji.Odejmowanie:
                        return "Odejmowanie";
                    default://case: RodzajeOperacji.Dzielenie:
                        return "Dzielenie";
                }
            }
        }
        private float _a;
        public float A
        {
            get {
                //Console.WriteLine($"Pobrano {_a}");
                return _a; 
            }
            set { 
                _a = value;
                //Console.WriteLine($"Podstawiono {_a}");
                Dodaj();
            }
        }
        private float _b;
        public float B
        {
            get { return _b; }  
            set 
            { 
                _b = value;
                Dodaj();
            }
        }
        private float _wynikDodawania;
        public float WynikDodawania
        {
            get { return _wynikDodawania; }
        }
        public float Dodaj()
        {
            RodzajOperacji = RodzajeOperacji.Dodawanie;
            _wynikDodawania = A + B;
            dodajElementHistorii();
            return _wynikDodawania;
        }

        public float Odejmij()
        {
            RodzajOperacji = RodzajeOperacji.Odejmowanie;
            dodajElementHistorii();
            return A - B;
        }

        public float Pomnoz()
        {
            RodzajOperacji = RodzajeOperacji.Mnozenie;
            dodajElementHistorii();
            return A * B;
        }

        public float? Podziel()
        {
            RodzajOperacji = RodzajeOperacji.Dzielenie;
            dodajElementHistorii();
            return B == 0 ? null : (float?) A / B;
        }
    }
}
