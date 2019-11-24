using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArxivOrgWinForm
{
    public class Subject
    {
        public string Name { get; set; }

        public List<string> Category { get; set; }

        public Subject()
        {
            Category = new List<string>();
        }
    }
}
