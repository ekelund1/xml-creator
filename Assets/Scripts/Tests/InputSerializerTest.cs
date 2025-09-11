using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SofthouseXML;
using System.Linq;
using System;

public class Serializer
{
    InputSerializer serializer = new InputSerializer();

    [Test]
    public void ReturnCorrectAmountOfPeople()
    {
        string input = "P|a\n" +
            "P|b";

        var result = serializer.ParseInput(input);

        Assert.AreEqual(2, result.Person.Count);
    }

    [Test]
    public void KastaOmTelefonInteKanKnytas()
    {
        string input = "" +
        "T|123|456\n" +
        "P|förnamn|efternamn\n" +
        "A|gata|stad|postnummer";

        var exception = Assert.Throws<Exception>(() => serializer.ParseInput(input));
        Assert.AreEqual("Attempted to attach Phone without any parent.", exception.Message);
    }

    [Test]
    public void KastaOmAdressInteKanKnytas()
    {
        string input = "" +
        "A|gata|stad|postnummer\n" +
        "T|123|456\n" +
        "P|förnamn|efternamn";

        var exception = Assert.Throws<Exception>(() => serializer.ParseInput(input));
        Assert.AreEqual("Attempted to attach Address without any parent.", exception.Message);
    }

    [Test]
    public void KastaOmFamiljInteKanKnytas()
    {
        string input = "" +
        "F|namn|ålder\n" +
        "A|gata|stad|postnummer\n" +
        "T|123|456\n" +
        "P|förnamn|efternamn";

        var exception = Assert.Throws<Exception>(() => serializer.ParseInput(input));
        Assert.AreEqual("Attempted to attach Family without any Person.", exception.Message);
    }

    [Test]
    public void EnPErson_TvaFamilj()
    {
        string input = "" +
        "P|förnamn|efternamn\n" +
        "T|123|456\n" +
        "A|gata|stad|postnummer\n" +

        "F|familj1|1\n" +
        "T|1|11\n" +
        "A|1|11|111\n" +

        "F|familj2|2\n" +
        "T|2|22\n" +
        "A|2|22|222";

        var peopleResult = serializer.ParseInput(input);

        Assert.AreEqual(1, peopleResult.Person.Count);

        Person person = peopleResult.Person[0];
        Assert.AreEqual("förnamn", person.FirstName);
        Assert.AreEqual("efternamn", person.LastName);

        Assert.AreEqual("123", person.Phone.Mobile);
        Assert.AreEqual("456", person.Phone.Landline);

        Assert.AreEqual("gata", person.Address.Street);
        Assert.AreEqual("stad", person.Address.City);
        Assert.AreEqual("postnummer", person.Address.PostalCode);

        Assert.AreEqual(2, person.Family.Count);

        var family1 = person.Family.ElementAt(0);
        Assert.AreEqual("familj1", family1.Name);
        Assert.AreEqual("1", family1.Born);

        Assert.AreEqual("1", family1.Phone.Mobile);
        Assert.AreEqual("11", family1.Phone.Landline);

        Assert.AreEqual("1", family1.Address.Street);
        Assert.AreEqual("11", family1.Address.City);
        Assert.AreEqual("111", family1.Address.PostalCode);

        var family2 = person.Family.ElementAt(1);
        Assert.AreEqual("familj2", family2.Name);
        Assert.AreEqual("2", family2.Born);

        Assert.AreEqual("2", family2.Phone.Mobile);
        Assert.AreEqual("22", family2.Phone.Landline);

        Assert.AreEqual("2", family2.Address.Street);
        Assert.AreEqual("22", family2.Address.City);
        Assert.AreEqual("222", family2.Address.PostalCode);
    }  
}
