using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeczeBundesligi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BundDataSet> list = BundDataSet.GetData(@"FIles\matchesdata.csv");
            BundDataSet.DisplayItem(list, 7);
            BundDataSet.Winning(list, 7);

            //Team winner counter from date to date
            int wins = Counting.CountTeamWins(list,"Borussia Dortmund", new DateTime(2007, 12, 1), new DateTime(2022, 12 ,31));
            Console.WriteLine("Liczba zwycięstw w podanym okresie: " + wins);



            Console.ReadKey();
            //komentarztestowy
        }
    }
}
