using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    internal interface ICompany
    {
        string Ticker { get; set; }
        string Name { get; set; }
        List<IQuotation> Quotations { get; }
        void AddQuotation(IQuotation quotation);
        decimal GetHighForDates(DateTime dateFrom, DateTime dateTo);
        decimal GetLowForDates(DateTime dateFrom, DateTime dateTo);
        decimal GetAverageCloseForDates(DateTime dateFrom, DateTime dateTo);
        decimal GetAverageOpenForDates(DateTime dateFrom, DateTime dateTo);
        decimal GetSumVolumeForDates(DateTime dateFrom, DateTime dateTo);
    }
    public interface IQuotation
    {
        string Ticker { get; set; }
        DateTime Date { get; set; }
        decimal Open { get; set; }
        decimal Close { get; set; }
        decimal High { get; set; }
        decimal Low { get; set; }
        decimal Vol { get; set; }
    }
}
