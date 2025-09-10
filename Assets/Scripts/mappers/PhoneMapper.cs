using System;
using System.Collections.Generic;
using System.Linq;

namespace SofthouseXML
{
    public class PhoneMapper
    {
        public static Phone SerializePhone(string input)
        {
            if (!input.StartsWith("T"))
            {
                throw new Exception("SerializePhone input börjar inte på T");
            }

            //Använder lista och ElementAtOrDefault för att den är length access safe
            List<string> split = input.Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();

            var output = new Phone();

            if (split.ElementAtOrDefault(1) != null)
            {
                output.Mobile = split.ElementAtOrDefault(1);
            }

            if (split.ElementAtOrDefault(2) != null)
            {
                output.Landline = split.ElementAtOrDefault(2);
            }

            return output;
        }
    }
}