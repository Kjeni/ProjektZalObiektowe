﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MeczeBundesligi
{
    public class Mecze
    {

        public  List<BundDataSet> matchingMatches { get; set; }
        public static List<BundDataSet> Matches(List<BundDataSet> list, DateTime startDate, DateTime endDate)
        {
            List<BundDataSet> matchingMatches = new List<BundDataSet>();
            foreach (BundDataSet m in list)
        {
            if(m.Date >= startDate && m.Date <= endDate)
            {
                Console.WriteLine("Mecz w dniu " + m.Date + " między:");
                Console.WriteLine("Drużyna gospodarzy: " + m.team1 + "  Gole: " + m.goal1);
                Console.WriteLine("Drużyna gości: " + m.team2 + "  Gole: " + m.goal2);
                    Console.WriteLine();

                matchingMatches.Add(m);
                }
        }
        return matchingMatches;
        }
        }

    }
