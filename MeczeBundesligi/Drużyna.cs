using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MeczeBundesligi
{
    internal class Drużyna: IMatch
    {
        public string team1 { get; set; }
        public string team2 { get; set; }
        public double draw { get; set; }
        public double team1_win { get; set; }
        public double team2_win { get; set; }
        public DateTime Date { get; set; }
        public int goal1 { get; set; }
        public int goal2 { get; set; }

        public static void Winning(List<BundDataSet> list, string Name, DateTime Date)
        {

            BundDataSet team = list.Where(t => t.team1 == Name && t.Date == Date).FirstOrDefault();
            if (team == null)
                Console.WriteLine("Nie znaleziono drużyny.");
            else if(team.draw == 1)
            {
                Console.WriteLine("Mecz zakończył się remisem");
            }
            else if (team.team1_win == 1)
            {
                Console.WriteLine("Zwyciężyli " + team.team1);
            }
            else
            {
                Console.WriteLine("Przegrali" + team.team2);
            }
        }
    }
}
