using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
            int wins = Counting.CountTeamWins(list, drużyna, datapoczatkowawin, datakoncowawin);
            Console.WriteLine("Liczba zwycięstw od: " + datakoncowawin + " do: " + datakoncowawin + ": " + wins);
            //Mecze od daty do daty
            DateTime datapoczatkowa = new DateTime(2007, 12, 1);
            DateTime datakoncowa = new DateTime(2007, 12, 10);
            Console.WriteLine("___Lista meczy od: " + datapoczatkowa + "do: " + datakoncowa + "___");
            Mecze.Matches(list, datapoczatkowa, datakoncowa);
            //Zapis do pliku



            Console.WriteLine("Naciśnij klawisz Enter, aby zapisać do pliku. Naciśnij Escape, aby zakończyć.");

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    string csvFilePath = @"FIles\zapismatches.csv";
                    using (var writer = new StreamWriter(csvFilePath))
                    {
                        writer.WriteLine("team1,team2,draw,team1_win,team2_win,Date,goal1,goal2"); // Nagłówki kolumn

                        foreach (var match in Mecze.Matches(list, datapoczatkowa, datakoncowa))
                        {
                            string csvLine = $"{match.team1},{match.team2},{match.draw},{match.team1_win},{match.team2_win},{match.Date},{match.goal1},{match.goal2}";
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



