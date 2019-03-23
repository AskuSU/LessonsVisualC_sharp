using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    class HMS
    {
        public HMS(DateTime dateTime)
        {
            if (dateTime.Hour < 10)
            {
                H = $"0{dateTime.Hour}";
            }
            else
            {
                H = dateTime.Hour.ToString();
            }

            if (dateTime.Minute < 10)
            {
                M = $"0{dateTime.Minute}";
            }
            else
            {
                M = dateTime.Minute.ToString();
            }

            if (dateTime.Second < 10)
            {
                S = $"0{dateTime.Second}";
            }
            else
            {
                S = dateTime.Second.ToString();
            }
        }

        public string H { get; }

        public string M { get; }

        public string S { get; }

    }
}
