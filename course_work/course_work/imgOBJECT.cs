using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_work
{
    public class imgOBJECT
    {
        public string name { get; set; }
        public string path { get; set; }
        public string url { get; set; }
        public string category { get; set; }

        public List<string> tags { get; set; }

        public imgOBJECT(string name, string path, string url, string category, List<string> tags)
        {
            this.name = name;
            this.path = path;
            this.category = category;
            this.url = url;
            this.tags = tags;
        }

        
    }
}
