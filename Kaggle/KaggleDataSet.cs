using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaggle
{
    public class KaggleDataSet
    {
        public string name1 { get; set; }
        public string name2 { get; set; }
        public bool player_1_win { get; set; }
        public DateTime Date { get; set; }

        public static List<KaggleDataSet> GetData(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<KaggleDataMap>();
                        List<KaggleDataSet> list = csv.GetRecords<KaggleDataSet>().ToList();
                        return list;

                    }
                }
            }
            return null;
        }
        public static void DisplayItem(List<KaggleDataSet> list, int index)
        {
            if (index >= 0 && index < list.Count)
            {
                KaggleDataSet person = list[index];

                Console.WriteLine("Gra w dniu " + person.Date + "między:");
                Console.WriteLine("Gracz 1: " + person.name1);
                Console.WriteLine("Gracz 2: " + person.name2);

            }
            else
            {
                Console.WriteLine("Niepoprawny indeks");
            }
        }

        public static void Winning(List<KaggleDataSet> list, int index)
        {
            KaggleDataSet person = list[index];
            bool winner = person.player_1_win;
            if (winner == true)
            {
                Console.WriteLine(person.name1 + " wygrał/a!");
            }
            else
            {
                Console.WriteLine(person.name2 + " wygrał/a!");
            }

        }
        public static int CountWins(List<KaggleDataSet> list, string playerName)
        {
            Console.WriteLine(playerName);
            return list.Count(p => (p.name1 == playerName && p.player_1_win) || (p.name2 == playerName && !p.player_1_win));
        }


        public static int Count(List<KaggleDataSet> list, DateTime dateFrom, DateTime dateTo)
        {
            return list.Count(p => p.Date >= dateFrom && p.Date <= dateTo);
        }

        public static void Winning(List<KaggleDataSet> list, string Name, DateTime Date)
        {

            KaggleDataSet person = list.Where(p => p.name1 == Name && p.Date == Date).FirstOrDefault();
            if (person == null)
                Console.WriteLine("Nie znaleziono zawodnika.");
            else
                if (person.player_1_win)
                {
                    Console.WriteLine(Name + " wygrał/a!");
                }
                else
                {
                    Console.WriteLine(Name + " przegrał/a!");
                };

        }
        public static void SaveToFile(string fileName, List<KaggleDataSet> list)
        {
            string textToSave = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(fileName, textToSave);
        }

        public static List<KaggleDataSet> LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                string textLoad = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<List<KaggleDataSet>>(textLoad);

            }
            else
            {
                return null;
            }

        }






        public class KaggleDataMap : ClassMap<KaggleDataSet>
        {
            public KaggleDataMap()
            {
                Map(m => m.name1).Name("name_1");
                Map(m => m.name2).Name("name_2");
                Map(m => m.player_1_win).Name("player1_is_win?");
                Map(m => m.Date).Name("date").TypeConverterOption.Format("dd.MM.yyyy");

            }






        }

    }
}
