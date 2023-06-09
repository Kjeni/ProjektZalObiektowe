using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktury
{
    public class PozycjaFaktury : IPozycjaFaktury
    {
        public int Lp { get; set; }
        public string NazwaProduktu { get; set; }
        private decimal _cenaJednostkowa;
        public decimal CenaJednostkowa 
        {
            get 
            { 
                return _cenaJednostkowa;
            }
            set 
            {
                _cenaJednostkowa = value;
                ObliczNetto();
            } 
        }
        public string JednostkaMiary { get; set; }
        private decimal _liczba;
        public decimal Liczba 
        { 
            get
            {
                return _liczba;
            }
            set 
            {
                _liczba = value;
                ObliczNetto();
            } 
        }
        private decimal _netto;
        public decimal Netto 
        {
            get
            {
                return _netto;
            }
            set
            {
                _netto = value;
                ObliczVat();
            }
        }
        private decimal _stawkaVat;
        public decimal StawkaVat 
        {
            get 
            {
                return _stawkaVat;
            }
            set
            {
                _stawkaVat = value;
                ObliczVat();
            }
        }
        private decimal _vat;
        public decimal Vat 
        {
            get 
            {
                return _vat;
            } 
            set
            {
                _vat = value;
                ObliczBrutto();
            }
        }
        public decimal Brutto { get; set; }

        public void ObliczBrutto()
        {
            Brutto = Netto + Vat;
        }

        public void ObliczNetto()
        {
            Netto = CenaJednostkowa * Liczba;
        }

        public void ObliczVat()
        {
            Vat = Netto * StawkaVat;
        }
    }
}
