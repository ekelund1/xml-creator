using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SofthouseXML;
using System;

public class FamilyMapperTest
{

    [Test]
    public void ThrowOnInvalidInput()
    {
        string input = "B|a";

        Assert.Throws<Exception>(() => FamilyMapper.SerializeFamily(input));
    }

    [Test]
    public void OnlyName()
    {
        string input = "F|namn";

        var family = FamilyMapper.SerializeFamily(input);

        Assert.AreEqual("namn", family.Name);
        Assert.IsNull(family.Born);
        Assert.IsNull(family.Phone);
        Assert.IsNull(family.Address);
    }  

    [Test]
    public void MapFamily()
    {
        string input = "F|namn|92";

        var family = FamilyMapper.SerializeFamily(input);

        Assert.AreEqual("namn", family.Name);
        Assert.AreEqual("92", family.Born);
        Assert.IsNull(family.Phone);
        Assert.IsNull(family.Address);
    }
}
