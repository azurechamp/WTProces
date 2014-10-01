using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IccWorld2015
{
    public class Fixture
    {
        public string Match_no { get; set; }
        public string Match_t1 { get; set; }
        public string Match_t2 { get; set; }
        public string Match_venue { get; set; }
        public string Match_date { get; set; }
        public string Match_type { get; set; }
    }

    public class RootFixtures
    {
        public List<Fixture> Fixtures { get; set; }
    }
}
