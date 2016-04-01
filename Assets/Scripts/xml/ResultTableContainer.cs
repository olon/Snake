using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

[XmlRoot("ResultTableCollection")]
public class ResultTableContainer{

    [XmlArray("ResultTableContainer")]
    [XmlArrayItem("ResultTable")]
    public List<ResultTable> ResultTableList = new List<ResultTable>();

    private int changeCounter = 0;

    public int GetChangeCounter
    {
        get{ return changeCounter; }
        set{ changeCounter = value; }      
    }

    public void SaveParamsInResultTable(string userName, int scores)
    {
        var serializer = new XmlSerializer(typeof(ResultTableContainer));

        if(File.Exists("ResultTable.xml"))
            ResultTableList = LoadParamsInResultTable().ResultTableList;
        
        var ResultTable = new ResultTable();

        ResultTable.userName = userName;
        ResultTable.scores = scores;

        ResultTableList.Add(ResultTable);

        using (var stream = new FileStream("ResultTable.xml", FileMode.Create))
        {
            serializer.Serialize(stream, this);
            changeCounter++;
        }
    }

    public ResultTableContainer LoadParamsInResultTable()
    {
        var serializer = new XmlSerializer(typeof(ResultTableContainer));
        using (var stream = new FileStream("ResultTable.xml", FileMode.Open))
        {
            return serializer.Deserialize(stream) as ResultTableContainer;
        }
    }

}
