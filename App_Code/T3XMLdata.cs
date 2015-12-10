using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot("XMLDATA")]
public class T3XMLdata
{
    [XmlElement("USER")]
    public List<T3User> users { get; set; }
}