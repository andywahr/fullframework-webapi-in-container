using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public static class MappingUtil
    {
        public static void SetValue(LoanObject loanObject, int id, Action<string> setMe, string origValue)
        {
            GetValueFromLoanObject(loanObject, id, setMe);
        }

        public static void SetValue(LoanObject loanObject, int id, Action<int> setMe, int origValue)
        {
            GetValueFromLoanObject(loanObject, id, (val) =>
            {
                int newVal = -1;

                if (int.TryParse(val, out newVal))
                {
                    setMe(newVal);
                }
            });
        }

        public static void SetValue(LoanObject loanObject, int id, Action<double> setMe, double origValue)
        {
            GetValueFromLoanObject(loanObject, id, (val) =>
            {
                double newVal = -1;

                if (double.TryParse(val, out newVal))
                {
                    setMe(newVal);
                }
            });
        }
        public static void SetValue(LoanObject loanObject, int id, Action<DateTime> setMe, DateTime origValue)
        {
            GetValueFromLoanObject(loanObject, id, (val) =>
            {
                DateTime newVal;

                if (DateTime.TryParse(val, out newVal))
                {
                    setMe(newVal);
                }
            });
        }

        private static void GetValueFromLoanObject(LoanObject loanObject, int id, Action<string> processValue)
        {
            {
                LoanProperty loanProperty = null;

                if (loanObject.Properties.TryGetValue(id, out loanProperty) && !string.IsNullOrEmpty(loanProperty.Value))
                {
                    processValue(loanProperty.Value);
                }
            }
        }

    }
}
















