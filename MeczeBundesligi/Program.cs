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
            DateTime datapoczatkowawin = new DateTime(2007, 12, 1);
            DateTime datakoncowawin = new DateTime(2022, 12, 31);
            int wins = Counting.CountTeamWins(list,drużyna, datapoczatkowawin, datakoncowawin);
            Console.WriteLine("Liczba zwycięstw od: "+ datakoncowawin +" do: "+ datakoncowawin+": " + wins);
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
