using System.Xml;
using System.Xml.Serialization;

public class ResultTable {

    [XmlAttribute("userName")]
    public string userName;
    public int scores;

}
