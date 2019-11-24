using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArxivOrgWinForm
{
    public static class DateList
    {
        public static List<int> GetYears()
        {
            return new List<int>()
            {
                2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019
            };
        }

        public static List<int> GetMonths()
        {
            return new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
            };
        }
    }
}
