using System;
using System.Collections.Generic;
using System.Linq;
using SofthouseXML;

public class FamilyMapper
{
    public static Family SerializeFamily(string input)
    {
        if (!input.StartsWith("F"))
        {
            throw new Exception("FamilyMapper input börjar inte på F");
        }

        List<string> split = input.Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();

        var family = new Family();
        
        if (split.ElementAtOrDefault(1) != null)
        {
            family.Name = split.ElementAtOrDefault(1);
        }
        if (split.ElementAtOrDefault(2) != null)
        {
            family.Born = split.ElementAtOrDefault(2);
        }
        return family;
    }
}