using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("USER")]
public class T3User
{
    [XmlElement("USERNAME")]
    public string username { get; set; }

    [XmlElement("HASH")]
    public string hash { get; set; }

    [XmlElement("PRACTICE")]
    public List<T3Practice> practices { get; set; }
}