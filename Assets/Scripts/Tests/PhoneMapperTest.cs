using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SofthouseXML;
using System;

public class PhoneMapperTest
{

    [Test]
    public void ThrowOnInvalidInput()
    {
        string input = "H|a";

        Assert.Throws<Exception>(() => PhoneMapper.SerializePhone(input));
    }


    [Test]
    public void OnlyMobile()
    {
        string input = "T|123|";

        var endastMobil = PhoneMapper.SerializePhone(input);

        Assert.AreEqual("123", endastMobil.Mobile);
        Assert.IsNull(endastMobil.Landline);
    }  

    [Test]
    public void MapAll()
    {
        string input = "T|123|456";

        var phone = PhoneMapper.SerializePhone(input);

        Assert.AreEqual("123", phone.Mobile);
        Assert.AreEqual("456", phone.Landline);
    }  
}
