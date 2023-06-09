using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Kaggle
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<KaggleDataSet> list = KaggleDataSet.GetData(@"FIles\tenis.csv");
            KaggleDataSet.DisplayItem(list, 7);
            KaggleDataSet.Winning(list, 7);
            Console.WriteLine($"Liczba meczów w danym przedziale dat:" + KaggleDataSet.Count(list, new DateTime(2016, 1, 1), new DateTime(2017, 12, 31)));
            Console.WriteLine( " Wygrał/a : " + KaggleDataSet.CountWins(list, "Jana Fett") + " razy.");
            KaggleDataSet.Winning(list, "Josephine Kuhlman", new DateTime(2017, 1, 18));
            ///KaggleDataSet.SaveToFile("Tenis.txt", list);
           //List<KaggleDataSet> fromFile = KaggleDataSet.LoadFromFile("Tenisss.txt");
            //Console.WriteLine(fromFile.FirstOrDefault().name1);
            try
            {
                List<KaggleDataSet> fromFile = KaggleDataSet.LoadFromFile("Tenisss.txt");
                if (fromFile != null)
                    Console.WriteLine(fromFile.FirstOrDefault().name1);
                else
                {
                    Console.WriteLine("Brak plik!");
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }




            Console.ReadKey();
        }
    }
}   
