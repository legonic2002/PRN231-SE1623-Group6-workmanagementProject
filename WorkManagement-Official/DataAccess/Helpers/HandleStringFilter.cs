using AutoMapper.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helpers
{
    public static class HandleStringFilter
    {
        public static int[] HandleString(string stringFilter)
        {
            if(stringFilter == null || stringFilter.Trim().Equals(""))
            {
                return new int[0];
            }
            StringBuilder number = new StringBuilder();
            if (stringFilter.Contains("-"))
            {
                int[] result = new int[2];
                string[] s = stringFilter.Split('-');
                foreach (string s1 in s)
                {
                    foreach (var item in s1.Trim().Where(item => char.IsDigit(item)))
                    {
                        number.Append(item);
                    }
                    number.Append('.');
                }
                result[0] = int.Parse(number.ToString().Split(".")[0]);
                result[1] = int.Parse(number.ToString().Split(".")[1]);
                return result;
            }
            else
            {
                int[] result = new int[1];
                foreach (var item in stringFilter.Trim().Where(item => char.IsDigit(item)))
                {
                    number.Append(item);
                }

                result[0] = int.Parse(number.ToString());
                return result;
            }
        }
    }
}
