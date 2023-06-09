using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasy
{
    public interface IFaktura
    {
        string Numer { get; set; }        string NipKlienta { get; set; }
        DateTime DataSprzedazy { get; set; }        
        decimal Netto { get; }
        decimal Vat { get; }        
        decimal Brutto { get; }
        List<IPozycjaFaktury> Pozycje {get;}
        void DodajPozycje(IPozycjaFaktury pozycjaFaktury);
        void WyswietlKwoty();
    }
    public interface IPozycjaFaktury
    {
        int Lp { get; set; }        string NazwaProduktu { get; set; }
        decimal CenaJednostkowa { get; set; }        string JednostkaMiary { get; set; }
        decimal Liczba { get; set; }        decimal Netto { get; set; }
        decimal StawkaVat { get; set; }        decimal Vat { get; set; }
        decimal Brutto { get; set; }
        void ObliczNetto(); //CenaJednostkowa * Liczba
        void ObliczVat(); //Netto * StawkaVat
        void ObliczBrutto(); //Netto + Vat
    }
}
