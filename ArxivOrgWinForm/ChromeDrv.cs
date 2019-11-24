using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ArxivOrgWinForm
{
    public class ChromeDrv
    {
        int _processId = -1;
        public IWebDriver WebDriver { get; set; }

        public ChromeDrv()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-extensions");
            options.AddArgument("test-type");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("no-sandbox");
            options.AddArgument("--headless");
            
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory);

            service.SuppressInitialDiagnosticInformation = true;
            service.HideCommandPromptWindow = true;

            WebDriver = new ChromeDriver(service, options);
            _processId = service.ProcessId;
        }

        public IWebDriver GetWebDriver()
        {
            return WebDriver;
        }

        public void ChromeGoToURL(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        internal bool IsPageNotFound()
        {
            try
            {              
                if (WebDriver.FindElements(By.CssSelector("#content > h1")).Count != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        internal List<string> GetArticleInfo()
        {
            List<string> lstArticleInfo = new List<string>();

            string category = WebDriver.FindElement(By.CssSelector("span.primary-subject")).Text;
            lstArticleInfo.Add(category);

            string title = WebDriver.FindElement(By.CssSelector("#abs > h1")).Text;
            lstArticleInfo.Add(title);

            string autors = "";
            var lstElem = WebDriver.FindElements(By.CssSelector(".authors > a"));
            foreach (IWebElement elem in lstElem)
                autors += elem.Text + ", ";
            lstArticleInfo.Add(autors);

            string quotation = WebDriver.FindElement(By.CssSelector("#abs > blockquote")).Text;
            lstArticleInfo.Add(quotation);
               
            string date = WebDriver.FindElement(By.CssSelector(".submission-history")).Text;
            lstArticleInfo.Add(date);

            string document_Source = WebDriver.FindElement(By.CssSelector("div.full-text > ul > li > a")).GetAttribute("href") + ".pdf";
            lstArticleInfo.Add(document_Source);

            return lstArticleInfo;
        }

        internal List<string> GetListLinkSubjects()
        {
            var elem_li = WebDriver.FindElement(By.CssSelector("#content > ul")).FindElements(By.CssSelector("li > a"));
            List<string> lstElem_Subj = new List<string>();
            foreach (IWebElement el in elem_li)
            {
                lstElem_Subj.Add(el.GetAttribute("href"));
            }
            return lstElem_Subj;
        }

        internal Dictionary<int, string> GetListLinkYears()
        {
            Dictionary<int, string> lstElemYear_a = new Dictionary<int, string>();
            var elem_li = WebDriver.FindElements(By.CssSelector("#content > ul > li"));
            var elemYear_a = elem_li[3].FindElement(By.CssSelector("a")).GetAttribute("href");
            ChromeGoToURL(elemYear_a);
         
            var elem_p = WebDriver.FindElements(By.CssSelector("#content > p"));
            var elemYears_a = elem_p[2].FindElements(By.CssSelector("a"));
            foreach (IWebElement el in elemYears_a)
            {
                lstElemYear_a.Add(Convert.ToInt32(el.Text), el.GetAttribute("href"));
            }
            return lstElemYear_a;
        }

        internal Dictionary<string, string> GetListLinkMonths()
        {
            Dictionary<string, string> lstElemMonth_a = new Dictionary<string, string>();
            var elem_li = WebDriver.FindElements(By.CssSelector("#content > ul > li"));
            foreach (IWebElement li in elem_li)
            {
                var elemMonth_a = li.FindElement(By.CssSelector("a"));
                lstElemMonth_a.Add(elemMonth_a.Text, elemMonth_a.GetAttribute("href"));
            }

            return lstElemMonth_a;
        }

        internal List<string> GetListLinkArticles()
        {
            List<string> lstA = new List<string>();
            if (IsPageFound())
            {
                string str_span = WebDriver.FindElement(By.CssSelector("#dlpage > small")).Text;
                var elem_small = WebDriver.FindElements(By.CssSelector("#dlpage > small"));
                var elemLst_a = elem_small[1].FindElements(By.CssSelector("a"));
                if (elemLst_a.Count > 1)
                {
                    string a = elemLst_a[2].GetAttribute("href");
                    ChromeGoToURL(a);
                }

                var elem_span = WebDriver.FindElements(By.CssSelector("#dlpage > dl > dt > span"));


                foreach (IWebElement span in elem_span)
                {
                    lstA.Add(span.FindElement(By.CssSelector("a")).GetAttribute("href"));
                }
            }
            return lstA;
        }

        internal bool IsPageFound()
        {
            try
            {
                string str_span = WebDriver.FindElement(By.CssSelector("#dlpage > small")).Text;
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal Dictionary<string, IWebElement> GetLstElem_a()
        {
            var list_l = WebDriver.FindElement(By.CssSelector("#content > ul")).FindElements(By.CssSelector("li"));

            Dictionary<string, IWebElement> dictElem = new Dictionary<string, IWebElement>();
            foreach (IWebElement l in list_l)
            {
                IWebElement a = l.FindElement(By.CssSelector("a"));
                dictElem.Add(l.Text, a);
            }

            return dictElem;
        }

        internal List<string> GetCategory(string text)
        {
            Subject subject = new Subject();

            var list_ul = WebDriver.FindElements(By.CssSelector("#content > ul"));

            if (list_ul.Count > 1)
            {
                var list_category = list_ul[1].FindElements(By.CssSelector("li > b"));

                foreach (IWebElement cat in list_category)
                    subject.Category.Add(cat.Text);
            }
            else
            {
                subject.Category.Add(text);
            }

            return subject.Category;
        }

        public void ExitDriver()
        {
            if (WebDriver != null)
            {
                WebDriver.Quit();
            }

            WebDriver = null;

            try
            {
                Process.GetProcessById(_processId).Kill();
            }
            catch { }
        }

    }
}
