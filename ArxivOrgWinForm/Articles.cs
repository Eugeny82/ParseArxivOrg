using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using ArxivOrgWinForm.DAL;
using ArxivOrgWinForm.DBModel;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using ArxivOrgWinForm.Settings;

namespace ArxivOrgWinForm
{
    public class Articles
    {
        public IWebDriver _driver;
        public ChromeDrv _browser;
        string _pathFirst = "https://arxiv.org/abs/"; 
        string _pathPDF = @"";
        int _yearStart, _yearStop; 
        int _monthStart, _monthStop; 
        int _indexStart; 
        bool _flagPDF; 
        bool _flagArticles; 
        List<int> lstSettings;
        bool _cancel = false;      

        public Articles(int yearStart, int yearStop, int monthStart, int monthStop, int index, string pathPDF, bool flagPDF, bool flagArticles)
        {
            _yearStart = yearStart;
            _yearStop = yearStop;
            _monthStart = monthStart;
            _monthStop = monthStop;
            _indexStart = index;
            _pathPDF = pathPDF;
            _flagPDF = flagPDF;
            _flagArticles = flagArticles;
        }

        public void Cancel()
        {
            _cancel = true;
        }

        public void GetSubjects(object context)
        {
            SynchronizationContext contextSync = (SynchronizationContext)context;

            ArticleModel article = new ArticleModel();
            DataAccess dal = new DataAccess();            

            int year = 0;
            int month = 0;
            int index = 0;

            string y = "";
            string m = "";

            try
            {
                _browser = new ChromeDrv();
                _driver = _browser.GetWebDriver();
            }
            catch (Exception e)
            {
                contextSync.Send(OnGetArticles_Exception, e.Message);
                _browser.ExitDriver();
                return;
            }

            Scien scien2 = new Scien();
            List<Science> scienses2 = new List<Science>();
            if (scien2.ReadXml())
            {
                scienses2 = scien2.Fields.Sciences;
            }
            
            for (year = _yearStart; year <= _yearStop; year++)
            {               
                for (month = _monthStart; month <= _monthStop; month++)
                {
                    for (index = _indexStart; ; index++)
                    {
                        try
                        {
                            article.Article_Source = string.Format("{0}{1:d2}{2:d2}.{3:d5}",
                                                                    _pathFirst, int.Parse(year.ToString().Substring(2, 2)), month, index);

                            contextSync.Send(OnGetSource, article.Article_Source);

                            _driver.Navigate().GoToUrl(article.Article_Source);

                            if (PageNotFound())
                            {
                                contextSync.Send(OnGetSource_Exception, "Page not found : " + article.Article_Source);
                                _indexStart = 1;
                                break;
                            }

                            article.Id = 0;

                            article.Category = _driver.FindElement(By.CssSelector("span.primary-subject")).Text;
                            bool flagReturn = false;

                            foreach (Science sc in scienses2)
                            {
                                foreach (Subject sb in sc.subjects)
                                {
                                    foreach (string cat in sb.Category)
                                    {
                                        Regex regexCat = new Regex(@"\S+\.\S+");
                                        Match matchCat = regexCat.Match(cat);

                                        if (matchCat.Value != "")
                                        {
                                            if (article.Category.Contains(matchCat.Value))
                                            {
                                                string catStr = cat.Substring(matchCat.Length + 2, cat.Length - matchCat.Length - 2);
                                                article.Category = catStr;
                                                article.Subject = sb.Name;
                                                article.Science = sc.Name;
                                                flagReturn = true;
                                            }
                                        }
                                        if (flagReturn) break;
                                    }
                                    if (flagReturn) break;
                                }
                                if (flagReturn) break;
                            }

                            article.Title = _driver.FindElement(By.CssSelector("#abs > h1")).Text;
                            var lstElem = _driver.FindElements(By.CssSelector(".authors > a"));
                            article.Autors = "";
                            foreach (IWebElement elem in lstElem)
                                article.Autors += elem.Text + ", ";

                            string strDate = _driver.FindElement(By.CssSelector(".submission-history")).Text;
                            Regex regex = new Regex(@"\d{1,2}\s\D{3}\s\d{4}\s\d{2}\W\d{2}\W\d{2}");
                            Match match = regex.Match(strDate);
                            article.Publication_Date = DateTime.Parse(match.Value);
                            article.Quotation = _driver.FindElement(By.CssSelector("#abs > blockquote")).Text;
                            article.Document_Source = _driver.FindElement(By.CssSelector("div.full-text > ul > li > a")).GetAttribute("href") + ".pdf";
                            regex = new Regex(@"(pdf)\/\d{4}");
                            match = regex.Match(article.Document_Source);

                            if (match.Value != "")
                            {
                                y = match.Value.Substring(4, 2);
                                m = match.Value.Substring(6, 2);
                                DirectoryInfo dir = new DirectoryInfo(_pathPDF + @"\" + y + @"\" + m);
                                if (!dir.Exists && _pathPDF != string.Empty)
                                    dir.Create();

                                Regex regexFile = new Regex(@"\d{4}\W\d{4,5}\W(pdf)");
                                Match matchFile = regexFile.Match(article.Document_Source);
                                string document_Local = _pathPDF + @"\" + y + @"\" + m + @"\" + matchFile.Value;
                                article.Document_Local = @"\" + y + @"\" + m + @"\" + matchFile.Value;

                                if (_flagPDF)
                                {
                                    try
                                    {
                                        using (var client = new WebClient())
                                        {
                                            client.Headers.Add("User-Agent: Other");
                                            client.DownloadFile(article.Document_Source, document_Local);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        contextSync.Send(OnGetSource_Exception, e.Message);
                                        index = --index;
                                        if (_cancel) break;
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                article.Document_Local = "";
                                article.Document_Source = "";
                            }

                            article.Recording_Date = DateTime.Now;
                        }
                        catch (Exception e)
                        {
                            contextSync.Send(OnGetSource_Exception, e.Message);
                            Thread.Sleep(10000);
                            index = --index;
                            if (_cancel) break;
                            continue;
                        }

                        if (_flagArticles) 
                        {
                            try
                            {
                                dal.WriteDBSQL(article);
                            }
                            catch (Exception e)
                            {
                                contextSync.Send(OnGetArticles_Exception, e.Message);
                                _cancel = true;
                                index = --index;
                                break;
                            }
                        } 
                        if (_cancel) break;
                    }
                    if (_cancel) break;
                    if (month == 12) _monthStart = 1;                    
                }
                if (_cancel) break;
            }

            _yearStart = year;
            _monthStart = month;
            _indexStart = ++index;

            lstSettings = new List<int>();
            lstSettings.Add(_yearStart);
            lstSettings.Add(_monthStart);
            lstSettings.Add(_indexStart);

            contextSync.Send(OnGetSettings, lstSettings);
            contextSync.Send(OnGetArticles_Cancel, true);
        }        

        private bool PageNotFound()
        {
            try
            {               
                if (_driver.FindElements(By.CssSelector("#content > h1")).Count != 0)
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

        public void OnGetArticles_Exception(object ex)
        {
            if (GetArticlesException != null)
                GetArticlesException((string)ex);
        }
        
        private void OnGetSource_Exception(object source)
        {
            if (GetSource_Exception != null)
                GetSource_Exception((string)source);
        }
        
        private void OnGetSource(object sourceInfo)
        {
            if (GetSource != null)
                GetSource((string)sourceInfo);
        }

        private void OnGetSettings(object lst)
        {
            if (GetSettings != null)
                GetSettings((List<int>)lst);
        }
        
        private void OnGetArticles_Cancel(object cancel)
        {
            if (GetArticles_Cancel != null)
                GetArticles_Cancel((bool)cancel);
        }
        

        public event Action<string> GetArticlesException;
        public event Action<List<int>> GetSettings;
        public event Action<string> GetSource;
        public event Action<string> GetSource_Exception;
        public event Action<bool> GetArticles_Cancel;        
    }
}
