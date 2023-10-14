using System;
using System.Linq;
using System.Xml;
using System.IO;
using System.Xml.Schema;
using System.Xml.Linq;

string currDir = Directory.GetCurrentDirectory();
string xsdFilePath = "" + currDir + "\\lifiBeispiel.xsd";
string xmlFilePath = "" + currDir + "\\lifiBeispiel.xml";

XmlSchemaSet schema = new XmlSchemaSet();
schema.Add(null, xsdFilePath);

XmlReader rd = XmlReader.Create(xmlFilePath);
XDocument doc = XDocument.Load(rd);
doc.Validate(schema, (o, e) =>
{
    Console.WriteLine("{0}", e.Message);
});