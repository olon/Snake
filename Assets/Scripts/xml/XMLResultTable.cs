using System.Collections;
using System.Xml.Serialization;
using System.IO;

[System.Serializable]
public class XMLResultTable {

     public int length;
     public string userName;
     public int scores;

    //public XMLResultTable()
    //{

    //}

    //public XMLResultTable(string userName, int length, int scores)
    //{
    //    this.userName = userName;
    //    this.length = length;
    //    this.scores = scores;
    //}

    public static void SaveParamsInResultTable(string userName, int length, int scores)
    {
        var xml = new XmlSerializer(typeof(XMLResultTable));

        var XMLResultTable = new XMLResultTable();

        XMLResultTable.userName = userName;
        XMLResultTable.length = length;
        XMLResultTable.scores = scores;

        using (var stream = new FileStream("ResultTable.xml", FileMode.OpenOrCreate, FileAccess.Write))
        {
            xml.Serialize(stream, XMLResultTable);
        }
    }

    //public void LoadParamsInResultTable()
    //{

    //    var xml = new XmlSerializer(typeof(XMLResultTable));

    //    var test = new Test();//создаем экземпляр класса Test

    //    using (var stream = new FileStream("Test.xml", FileMode.Open, FileAccess.Read))
    //    {
    //        // Восстанавливаем объект из XML-файла.
    //        test = xml.Deserialize(stream) as Test;
    //    }

    //    //присваиваем переменным значения
    //    Health = test.Health;
    //    Name = test.Name;
    //    Speed = test.Speed;
    //    transform.position = new Vector3(test.x, test.y, test.z);

    //    print("параметры загружены");
    //}

}
