using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeczeBundesligi
{
    public class BundDataSet: IDataSet
    {
        public string team1 { get; set; }
        public string team2 { get; set; }
        public double draw { get; set; }
        public double team1_win { get; set; }
        public double team2_win { get; set; }
        public DateTime Date { get; set; }
        public int goal1 { get; set; }
        public int goal2 { get; set; }
        public static List<BundDataSet> GetData(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<BundDataMap>();
                        List<BundDataSet> list = csv.GetRecords<BundDataSet>().ToList();
                        return list;

                    }
                }
            }
            return null;
        }
        public static void DisplayItem(List<BundDataSet> list, int index)
        {
            if (index >= 0 && index < list.Count)
            {
                BundDataSet match = list[index];

                Console.WriteLine("Mecz w dniu " + match.Date + " między: ");
                Console.WriteLine("Drużyna gospodarzy: " + match.team1 + "  Gole: " + match.goal1);
                Console.WriteLine("Drużyna gości: " + match.team2 + "  Gole: " + match.goal2);
            }
            else
            {
                Console.WriteLine("Niepoprawny indeks");
            }
        }
        public static void Winning(List<BundDataSet> list, int index)
        {
            BundDataSet match = list[index];
            double draw = match.draw;
            double team1_win = match.team1_win;
            double team2_win = match.team2_win;   
            if (match.draw == 1)
            {
                Console.WriteLine("Mecz zakończył się remisem");
            }
            else if (match.team1_win == 1)
            {
                Console.WriteLine("Zwyciężyła drużyna gospodarzy: " + match.team1);
            }
            else
            {
                Console.WriteLine("Zwyciężyła drużyna gości: " + match.team2);
            }
        }

        public static void SaveToFile(string fileName, List<BundDataSet> list)
        {
            string textToSave = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(fileName, textToSave);
        }


        public class BundDataMap : ClassMap<BundDataSet>
        {
            public BundDataMap()
            {
                //MATCH_DATE,LEAGUE_NAME,SEASON,LEAGUE,FINISHED,LOCATION,VIEWER,MATCHDAY,MATCHDAY_NR,HOME_TEAM_ID,HOME_TEAM_NAME,HOME_TEAM,HOME_ICON,AWAY_TEAM_ID,AWAY_TEAM_NAME,AWAY_TEAM,AWAY_ICON,GOALS_HOME,GOALS_AWAY,DRAW,WIN_HOME,WIN_AWAY
                Map(m => m.team1).Name("HOME_TEAM_NAME");
                Map(m => m.team2).Name("AWAY_TEAM_NAME");
                Map(m => m.draw).Name("DRAW");
                Map(m => m.team1_win).Name("WIN_HOME");
                Map(m => m.team2_win).Name("WIN_AWAY");
                Map(m => m.Date).Name("MATCH_DATE").TypeConverterOption.Format("yyyy-MM-dd HH:mm:ss");
                Map(m => m.goal1).Name("GOALS_HOME");
                Map(m => m.goal2).Name("GOALS_AWAY");

            }
        }
    }
}
