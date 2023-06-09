using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeczeBundesligi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BundDataSet> list = BundDataSet.GetData(@"FIles\matchesdata.csv");
            BundDataSet.DisplayItem(list, 7);
            BundDataSet.Winning(list, 7);
            Console.ReadKey();
        }
    }
}
