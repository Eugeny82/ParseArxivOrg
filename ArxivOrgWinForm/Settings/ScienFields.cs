using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArxivOrgWinForm.Settings
{
    public class ScienFields
    {
        public string XMLFileName = Environment.CurrentDirectory + "\\settingsSubj.xml";

        public List<Science> Sciences;

        public ScienFields()
        {
            Sciences = new List<Science>();
        }
    }
}
