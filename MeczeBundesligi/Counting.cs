using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using static MeczeBundesligi.BundDataSet;

namespace MeczeBundesligi
{
    public class Counting : IMatch

    {
        public string team1 { get; set; }
        public string team2 { get; set; }
        public double draw { get; set; }
        public double team1_win { get; set; }
        public double team2_win { get; set; }
        public DateTime Date { get; set; }
        public int goal1 { get; set; }
        public int goal2 { get; set; }

        public static List<Counting> GetData(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<CountingMap>();
                        List<Counting> mecze = csv.GetRecords<Counting>().ToList();
                        return mecze;

                    }
                }
            }
            return null;
        }

        public static int CountTeamWins(List<Counting> mecze, string teamName /*,DateTime startDate, DateTime endDate*/)
        {
            int count = 0;

            foreach (Counting m in mecze)
            {
                if /*(*/(m.team1 == teamName || m.team2 == teamName) /*&& match.Date.Date >= startDate.Date && match.Date.Date <= endDate.Date)*/
                {
                    if (m.team1 == teamName && m.team1_win == 1.0)
                    {
                        count++;
                    }
                    else if (m.team2 == teamName && m.team2_win == 1.0)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine("Nazwa drużyny: " + teamName);
            return count;
        }

    public class CountingMap : ClassMap<Counting>
        {
            public CountingMap()
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
