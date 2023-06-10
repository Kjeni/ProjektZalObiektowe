using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeczeBundesligi
{
    internal interface IMatch
    {
        string team1 { get; set; }
        string team2 { get; set; }
        double draw { get; set; }
        double team1_win { get; set; }
        double team2_win { get; set; }
        DateTime Date { get; set; }
        int goal1 { get; set; }
        int goal2 { get; set; }
    }
}
