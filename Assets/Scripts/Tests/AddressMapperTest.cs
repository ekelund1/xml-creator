using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SofthouseXML;
using System;

public class AddressMapperTest
{

    [Test]
    public void ThrowOnInvalidInput()
    {
        string input = "P|a";

        Assert.Throws<Exception>(() => AddressMapper.SerializeAddress(input));
    }


    [Test]
    public void OnlyAddress()
    {
        string input = "A|adress|";

        var endastAdress = AddressMapper.SerializeAddress(input);

        Assert.AreEqual("adress", endastAdress.Street);
        Assert.IsNull(endastAdress.City);
        Assert.IsNull(endastAdress.PostalCode);
    }  

    [Test]
    public void MappAdress()
    {
        string input = "A|adress|stad|postkod";

        var endastAdress = AddressMapper.SerializeAddress(input);

        Assert.AreEqual("adress", endastAdress.Street);
        Assert.AreEqual("stad", endastAdress.City);
        Assert.AreEqual("postkod", endastAdress.PostalCode);
    }  
}
