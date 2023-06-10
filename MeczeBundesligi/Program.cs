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
            //Display item[index]
            BundDataSet.DisplayItem(list, 7);
            //DisplayWinner item,[index]
            BundDataSet.Winning(list, 7);
            //Team winner counter from date to date
            List<Counting> mecze = Counting.GetData(@"FIles\matchesdata.csv");
            int wins = Counting.CountTeamWins(mecze,"Borussia Dortmund"/*, new DateTime(2005, 12, 1,0, 0, 0), new DateTime(2020, 12 ,31, 0,0, 0)*/);
            Console.WriteLine("Liczba zwycięstw w podanym okresie: " + wins);



            Console.ReadKey();
        }
    }
}
