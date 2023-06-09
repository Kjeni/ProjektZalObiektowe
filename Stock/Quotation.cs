using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    public class Quotation : IQuotation
    {
        public string Ticker { get; set; }
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Vol { get; set; }
        public static void LoadQuotations(string fileName, List<IQuotation> quotations)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<QuotationMap>();
                        List<Quotation> list = csv.GetRecords<Quotation>().ToList();
                        if (quotations != null)
                        {
                            quotations.AddRange(list);
                        }
                    }
                }
            }
        }

   
    }
    public class QuotationMap: ClassMap<Quotation>
    {
        public QuotationMap()
        {
            Map(m => m.Ticker).Name("<TICKER>");
            Map(m => m.Date).Name("<DATE>").TypeConverterOption.Format("yyyyMMdd");
            Map(m => m.Open).Name("<OPEN>");
            Map(m => m.Close).Name("<CLOSE>");
            Map(m => m.High).Name("<HIGH>");
            Map(m => m.Low).Name("<LOW>");
            Map(m => m.Vol).Name("<VOL>");
        }
    }
}
