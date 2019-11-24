using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ArxivOrgWinForm
{
    public class Log
    {
        public void LogWrite(string str)
        {
            try
            {
                File.AppendAllText("LogParsing.txt", DateTime.Now.ToString() + " => " + str);
            }
            catch{}
        }

    }
}
