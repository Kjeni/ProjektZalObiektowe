﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeczeBundesligi
{
    public class Counting
    {
        public static int CountTeamWins(List<BundDataSet> list, string teamName ,DateTime startDate, DateTime endDate)
        {
            int count = 0;

            foreach (BundDataSet m in list)
            {
                if ((m.team1 == teamName || m.team2 == teamName) && m.Date.Date >= startDate.Date && m.Date.Date <= endDate.Date)
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
            return count;
        }
    }
}

