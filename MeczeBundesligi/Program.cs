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
            Console.WriteLine("_____________Indeks_____________");
            List<BundDataSet> list = BundDataSet.GetData(@"FIles\matchesdata.csv");
            BundDataSet.DisplayItem(list, 7);
            BundDataSet.Winning(list, 7);
            //Team winner counter from date to date
            string drużyna = "Borussia Dortmund";
            Console.WriteLine("______Zwycięstwa " + drużyna + "______");
            int wins = Counting.CountTeamWins(list,drużyna, new DateTime(2007, 12, 1), new DateTime(2022, 12 ,31));
            Console.WriteLine("Liczba zwycięstw w podanym okresie: " + wins);
            //Mecze od daty do daty
            DateTime datapoczatkowa = new DateTime(2007, 12, 1);
            DateTime datakoncowa = new DateTime(2007, 12, 10);
            Console.WriteLine("___Lista meczy od: "+ datapoczatkowa+ "do: "+ datakoncowa+"___");
            Mecze.Matches(list, datapoczatkowa, datakoncowa);



            Console.ReadKey();
            //komentarztestowy
        }
    }
}
