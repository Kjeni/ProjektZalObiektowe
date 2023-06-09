using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    internal class Company : ICompany
    {
        public string Ticker { get; set; }
        public string Name { get; set; }
        //public decimal Suma => GetAverageCloseForDates();

        private List<IQuotation> _quotations;
        public List<IQuotation> Quotations
        {
            get
            {
                if (_quotations == null)
                    _quotations = new List<IQuotation>();
                return _quotations;
            }
        }

        public void AddQuotation(IQuotation quotation)
        {
            Quotations.Add(quotation);
        }

        public decimal GetAverageCloseForDates(DateTime dateFrom, DateTime dateTo)
        {
            decimal Suma = 0;
            int i = 0;
            foreach (IQuotation quotation in Quotations)
            {
                if (quotation.Date >= dateFrom && quotation.Date <= dateTo)
                                                                             
                {
                    Suma += quotation.Close;
                    i++;

                }
                            
                                 
            }
            return Suma/i;
        }

        public decimal GetAverageOpenForDates(DateTime dateFrom, DateTime dateTo)
        {
            decimal Suma = 0;
            int i = 0;
            foreach (IQuotation quotation in Quotations)
            {
                if (quotation.Date >= dateFrom && quotation.Date <= dateTo)

                {
                    Suma += quotation.Open;
                    i++;

                }


            }
            return Suma / i;
        }

        public decimal GetHighForDates(DateTime dateFrom, DateTime dateTo)
        {
            decimal Max = 0;
            
            foreach (IQuotation quotation in Quotations)
            {
                if (quotation.Date >= dateFrom && quotation.Date <= dateTo)

                {
                    if (quotation.High > Max)
                    {
                        Max = quotation.High;
                    }
                    

                }


            }
            return Max;
        }

        public decimal GetLowForDates(DateTime dateFrom, DateTime dateTo)
        {
            decimal Min = 0;
           
            foreach (IQuotation quotation in Quotations)
            {
                if (quotation.Date >= dateFrom && quotation.Date <= dateTo)

                {
                    if (quotation.Low > Min)
                    {
                        Min = quotation.Low;
                    }

                }


            }
            return Min;
        }

        public decimal GetSumVolumeForDates(DateTime dateFrom, DateTime dateTo)
        {
            decimal Suma = 0;          
            foreach (IQuotation quotation in Quotations)
            {
                if (quotation.Date >= dateFrom && quotation.Date <= dateTo)

                {
                    Suma += quotation.Vol;                   
                }
            }
            return Suma;
        }
    }
    
}
