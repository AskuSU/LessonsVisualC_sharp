using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    class YMD
    {
        public YMD(DateTime dateTime) 
        {
            
            Y = dateTime.Year.ToString();

            if (dateTime.Month< 10)
            {
                M = $"0{dateTime.Month}";
            }
            else
            {
                M = dateTime.Month.ToString();
            }

            if (dateTime.Day< 10)
            {
                D = $"0{dateTime.Day}";
            }
            else
            {
                D = dateTime.Day.ToString();
            }
        }

        public string Y { get; }

        public string M { get; }

        public string D { get; }
    }
}
