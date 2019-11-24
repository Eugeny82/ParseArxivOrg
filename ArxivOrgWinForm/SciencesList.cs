using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArxivOrgWinForm.Settings;
using OpenQA.Selenium;

namespace ArxivOrgWinForm
{
    public class SciencesList
    {
        ChromeDrv chromeDrv;
        ChromeDrv chromeDrv2;
        List<Science> scienses;

        public SciencesList()
        {
            chromeDrv = new ChromeDrv();
            chromeDrv2 = new ChromeDrv();
            CreateSciencesList();

            chromeDrv.ExitDriver();
            chromeDrv2.ExitDriver();
        }

        private void CreateSciencesList()
        {            
            Scien scien2 = new Scien();

            if (scien2.ReadXml())
            {
                scienses = scien2.Fields.Sciences;
            }
            else 
            {
                string archive = "https://arxiv.org/archive/";
                chromeDrv.ChromeGoToURL(archive);
                Dictionary<string, IWebElement> lstElem_a = chromeDrv.GetLstElem_a();

                List<Subject> subjects = new List<Subject>();

                foreach (KeyValuePair<string, IWebElement> el in lstElem_a)
                {
                    Subject subject = new Subject();
                    chromeDrv2.ChromeGoToURL(el.Value.GetAttribute("href"));
                    subject.Category = chromeDrv2.GetCategory(el.Key);
                    subject.Name = el.Value.Text;
                    subjects.Add(subject);
                }

                scienses = new List<Science>();
                ScienceDictionary sc = new ScienceDictionary();

                foreach (Subject subj in subjects)
                {
                    Science science = null;
                    foreach (KeyValuePair<string, string> kv in sc.subjects)
                    {
                        if (subj.Name.Contains(kv.Key))
                        {
                            science = new Science();
                            science.Name = kv.Value;
                            science.subjects.Add(subj);
                        }
                    }
                    scienses.Add(science);
                }

                Scien scien = new Scien();
                scien.Fields.Sciences = scienses;
                scien.WriteXml();
            }
        }

        public List<Science> GetSciencesList()
        {      
            return scienses;
        }
    }
}
