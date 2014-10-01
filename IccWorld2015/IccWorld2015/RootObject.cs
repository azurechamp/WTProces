using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IccWorld2015
{
    public class LatestNew
    {
        public string News_thumb { get; set; }
        public string News_title { get; set; }
        public string News_link { get; set; }
    }

    public class RootObject
    {
        public List<LatestNew> LatestNews { get; set; }
    }
}
