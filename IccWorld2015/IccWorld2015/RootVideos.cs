using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IccWorld2015
{
    public class Movie
    {
        public string Video_img { get; set; }
        public string Video_text { get; set; }
        public string Video_url { get; set; }
    }

    public class RootVideos
    {
        public List<Movie> Movie { get; set; }
    }
}
