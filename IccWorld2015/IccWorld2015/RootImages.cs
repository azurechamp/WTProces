using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IccWorld2015
{
    public class Photo
    {
        public string Image_url { get; set; }
        public string Image_disc { get; set; }
    }

    public class RootImages
    {
        public List<Photo> Photos { get; set; }
    }
}
