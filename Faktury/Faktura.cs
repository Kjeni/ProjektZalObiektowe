using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktury
{
    public class Faktura : IFaktura
    {
        public string Numer { get; set; }
        public string NipKlienta { get; set; }
        public DateTime DataSprzedazy { get; set; }

        public decimal Netto => nettoZPozycji();

        public decimal Vat => vatZPozycji();

        public decimal Brutto => bruttoZPozycji();

        private List<IPozycjaFaktury> _pozycje;
        public List<IPozycjaFaktury> Pozycje
        {
            get
            {
                if (_pozycje == null )
                    _pozycje = new List<IPozycjaFaktury>();
                return _pozycje;
            }
        }

        private decimal nettoZPozycji()
        {
            decimal netto = 0;
            if (Pozycje != null)
            {
                foreach (IPozycjaFaktury p in Pozycje)
                {
                    netto = netto + p.Netto;
                }
            }
            return netto;
        }
        private decimal vatZPozycji()
        {
            decimal vat = 0;
            if (Pozycje != null)
            {
                foreach (IPozycjaFaktury p in Pozycje)
                {
                    vat = vat + p.Vat;
                }
            }
            return vat;
        }
        private decimal bruttoZPozycji()
        {
            decimal brutto = 0;
            if (Pozycje != null)
            {
                foreach (IPozycjaFaktury p in Pozycje)
                {
                    brutto = brutto + p.Brutto;
                }
            }
            return brutto;
        }

        public void DodajPozycje(IPozycjaFaktury pozycjaFaktury)
        {
            Pozycje.Add(pozycjaFaktury);
        }

        public void WyswietlKwoty()
        {
            Console.WriteLine($"Netto: {Netto}, Vat: {Vat}, Brutto: {Brutto}");
        }

        public decimal BruttoPierwszejPozycji()
        {
            decimal brutto = 0;
            foreach(IPozycjaFaktury pf in Pozycje)
            {
                brutto = pf.Brutto;
                break;
            }
            return brutto;
        }
    }
}
