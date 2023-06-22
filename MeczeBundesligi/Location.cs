using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeczeBundesligi
{
    internal class Location
    {
        public string Name { get; }

        public Location(string name)
        {
            Name = name;
        }

        public List<BundDataSet> GetMatchesForLocation(List<BundDataSet> matches)
        {
            List<BundDataSet> matchesForLocation = matches
                .Where(m => m.location.Equals(Name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return matchesForLocation;
        }
    }

}

