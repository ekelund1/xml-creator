using System;
using System.Collections.Generic;
using System.Linq;

namespace SofthouseXML
{
    public class AddressMapper
    {
        public static Address SerializeAddress(string input)
        {
            if (!input.StartsWith("A"))
            {
                throw new Exception("SerializeAddress input börjar inte på A");
            }

            //Använder lista och ElementAtOrDefault för att den är length access safe
            List<string> split = input.Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();

            var output = new Address();

            if (split.ElementAtOrDefault(1) != null)
            {
                output.Street = split.ElementAtOrDefault(1);
            }

            if (split.ElementAtOrDefault(2) != null)
            {
                output.City = split.ElementAtOrDefault(2);
            }

            if (split.ElementAtOrDefault(3) != null)
            {
                output.PostalCode = split.ElementAtOrDefault(3);
            }

            return output;
        }
    }
}