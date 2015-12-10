using System;
using System.Xml.Serialization;

[XmlRoot("PRACTICE")]
public class T3Practice
{
    [XmlElement("STARTTIME")]
    public DateTime starttime { get; set; }

    [XmlElement("ENDTIME")]
    public DateTime endtime { get; set; }

    [XmlElement("TRAVEL")]
    public int travel { get; set; }
}