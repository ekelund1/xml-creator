using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace SofthouseXML
{
    public class ToXml
    {
        public string Transform(People input)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(input.GetType());

            using(StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, input);
                return textWriter.ToString();
            }
        }
    }
}