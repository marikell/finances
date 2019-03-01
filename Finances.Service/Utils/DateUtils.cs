using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Finances.Service.Utils
{
    public static class DateUtils
    {
        private static Dictionary<int, string> _months;
        private static Dictionary<int, string> _formattedMonths;


        public static Dictionary<int, string> Months
        {
            get
            {
                if(_months == null)
                {
                    _months = new Dictionary<int, string>();

                    string[] names = DateTimeFormatInfo.CurrentInfo.MonthNames;


                    for (int i = 0; i < 12; i++)
                    {
                        _months.Add(i + 1, names[i]);
                    }



                }

                return _months;
            }
        }

        public static Dictionary<int, string> FormattedMonths
        {
            get
            {
               if(_formattedMonths == null)
                {
                    _formattedMonths = new Dictionary<int, string>();

                    foreach (var m in Months)
                    {
                        _formattedMonths.Add(m.Key, string.Format("{0}/{1}", m.Value, DateTime.Now.Year));
                    }
                }

                return _formattedMonths;
            }
        }
    }
}
