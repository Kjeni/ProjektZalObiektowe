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
            Console.WriteLine("*************Indeks*************");
            List<BundDataSet> list = BundDataSet.GetData(@"FIles\matchesdata.csv");
            BundDataSet.DisplayItem(list, 7);
            BundDataSet.Winning(list, 7);
            Console.WriteLine("****************************************************");
            Console.WriteLine();


            //Team winner counter from date to date
            string drużyna = "Borussia Dortmund";
            Console.WriteLine("*************Zwycięstwa " + drużyna + "*************");
            DateTime datapoczatkowawin = new DateTime(2007, 12, 1);
            string dateStart = datapoczatkowawin.ToString("dd-MM-yyyy");

            DateTime datakoncowawin = new DateTime(2022, 12, 31);
            string dateEnd = datakoncowawin.ToString("dd-MM-yyyy");

            int wins = Counting.CountTeamWins(list, drużyna, datapoczatkowawin, datakoncowawin);
            Console.WriteLine("Liczba zwycięstw od: " + dateStart + " do: " + dateEnd + ": " + wins);
            Console.WriteLine("****************************************************");
            Console.WriteLine();


            //Mecze od daty do daty
            DateTime datapoczatkowa = new DateTime(2007, 12, 1);
            string dateStart2 = datapoczatkowa.ToString("dd-MM-yyyy");

            DateTime datakoncowa = new DateTime(2007, 12, 10);
            string dateEnd2 = datakoncowa.ToString("dd-MM-yyyy");

            Console.WriteLine("*************Lista meczy od: " + dateStart2 + " do: " + dateEnd2 + "*************");
            Console.WriteLine("Naciśnij klawisz Enter, aby zapisać do pliku. Naciśnij Escape, aby zakończyć.");
            Console.WriteLine();
            Mecze.Matches(list, datapoczatkowa, datakoncowa);


            //Zapis do pliku txt
            BundDataSet.SaveToFile("Bundesliga.txt", list);


            //Zapis do pliku CSV
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
                Console.WriteLine("****************************************************");
                Console.ReadKey();
            }
        }
    }
}



