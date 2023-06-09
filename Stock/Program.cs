using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company c = new Company()
            {
                Ticker = "CDR",
                Name = "CD-Project",
                
            };
            Quotation.LoadQuotations(@"Pliki\cdr.txt", c.Quotations);
            /*
            IQuotation q = new Quotation()
            {
                Ticker = "CDR",
                Date = new DateTime(2023, 4, 14),
                Open = 7,
                Close = 8,
                High = 8,
                Low = 7,
                Vol = 12454,
            };
            IQuotation q1 = new Quotation()
            {
                Ticker = "CDR",
                Date = new DateTime(2023, 4, 15),
                Open = 8,
                Close = 10,
                High = 10,
                Low = 6,
                Vol = 143454,
            };
            IQuotation q2 = new Quotation()
            {
                Ticker = "CDR",
                Date = new DateTime(2023, 4, 16),
                Open = 9,
                Close = 6,
                High = 8,
                Low = 7,
                Vol = 1254354,
            };
            IQuotation q3 = new Quotation()
            {
                Ticker = "CDR",
                Date = new DateTime(2023, 4, 17),
                Open = 11,
                Close = 11,
                High = 11,
                Low = 9,
                Vol = 144454,
            };
            c.AddQuotation(q);
            c.AddQuotation(q1);
            c.AddQuotation(q2); 
            c.AddQuotation(q3);
            */

            Console.WriteLine("Średnia wartości zamknięcia wynosi: ");
            Console.WriteLine(c.GetAverageCloseForDates(new DateTime(2020, 1, 1), new DateTime(2020, 12, 31)));
            Console.WriteLine("Średnia wartości otwarcia wynosi: ");
            Console.WriteLine(c.GetAverageOpenForDates(new DateTime(2020, 1, 1), new DateTime(2020, 12, 31)));
            Console.WriteLine("Największa wartości wynosi: ");
            Console.WriteLine(c.GetHighForDates(new DateTime(2020, 1, 1), new DateTime(2020, 12, 31)));
            Console.WriteLine("Najmniejsza wartości wynosi: ");
            Console.WriteLine(c.GetLowForDates(new DateTime(2020, 1, 1), new DateTime(2020, 12, 31)));
            Console.WriteLine("Suma volume wynosi: ");
            Console.WriteLine(c.GetSumVolumeForDates(new DateTime(2020, 1, 1), new DateTime(2020, 12, 31)));

            Console.ReadKey();
        }
    }
}
