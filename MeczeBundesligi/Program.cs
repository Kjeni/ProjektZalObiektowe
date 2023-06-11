using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            int wins = Counting.CountTeamWins(list, drużyna, datapoczatkowawin, datakoncowawin);
            Console.WriteLine("Liczba zwycięstw od: " + datakoncowawin + " do: " + datakoncowawin + ": " + wins);
            //Mecze od daty do daty
            DateTime datapoczatkowa = new DateTime(2007, 12, 1);
            DateTime datakoncowa = new DateTime(2007, 12, 10);
            Console.WriteLine("___Lista meczy od: " + datapoczatkowa + "do: " + datakoncowa + "___");
            Mecze.Matches(list, datapoczatkowa, datakoncowa);
            //Zapis do pliku



            Console.WriteLine("Naciśnij klawisz Enter, aby zapisać do pliku. Naciśnij Escape, aby zakończyć.");
            List<BundDataSet> matchingMatches = Mecze.Matches(list, datapoczatkowa, datakoncowa);
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    string csvFilePath = @"Files\zapis.csv";
                    using (var writer = new StreamWriter(csvFilePath))
                    {
                        writer.WriteLine("team1,team2,draw,team1_win,team2_win,Date,goal1,goal2"); // Nagłówki kolumn

                        foreach (BundDataSet m in matchingMatches)
                        {
                            string csvLine = $"{m.team1},{m.team2},{m.draw},{m.team1_win},{m.team2_win},{m.Date},{m.goal1},{m.goal2}";
                            writer.WriteLine(csvLine);
                        }
                    }

                    Console.WriteLine("Dane zapisane do pliku CSV.");

                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.ReadKey();
            }
        }
    }
}



