using System;
using System.Linq;
using System.Xml;
using System.IO;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Text;

var fileName = "lifiBeispiel.xsd";
if (File.Exists(fileName))
{
    File.Delete(fileName);
}
string fileContent = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<xs:schema attributeFormDefault=\"unqualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">\r\n  <xs:element name=\"verkehrInformation\">\r\n    <xs:complexType>\r\n      <xs:sequence>\r\n        <xs:element name=\"strasse\">\r\n          <xs:complexType>\r\n            <xs:sequence>\r\n              <xs:element name=\"name\" type=\"xs:string\" />\r\n              <xs:element name=\"verkehrStatus\" type=\"xs:string\" />\r\n              <xs:element name=\"geschwindigkeitsbegrenzung\" type=\"xs:unsignedByte\" />\r\n              <xs:element name=\"strasseZustand\" type=\"xs:string\" />\r\n            </xs:sequence>\r\n            <xs:attribute name=\"id\" type=\"xs:unsignedShort\" use=\"required\" />\r\n          </xs:complexType>\r\n        </xs:element>\r\n      </xs:sequence>\r\n    </xs:complexType>\r\n  </xs:element>\r\n</xs:schema>";
File.WriteAllText(fileName, fileContent);

fileName = "lifiBeispiel.xml";
if (File.Exists(fileName))
{
    File.Delete(fileName);
}
fileContent = "<verkehrInformation>\r\n  <strasse id=\"7123\">\r\n    <name>Hauptstrasse</name>\r\n    <verkehrStatus>moderat</verkehrStatus>\r\n    <geschwindigkeitsbegrenzung>50</geschwindigkeitsbegrenzung>\r\n    <strasseZustand>einwandfrei</strasseZustand>\r\n  </strasse>\r\n</verkehrInformation>\r\n";
File.WriteAllText(fileName, fileContent);

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