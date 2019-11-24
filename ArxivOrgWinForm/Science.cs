using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArxivOrgWinForm
{
    public class Science
    {
        public string Name { get; set; }

        public List<Subject> subjects { get; set; }

        public Science()
        {
            subjects = new List<Subject>();
        }
    }
}
