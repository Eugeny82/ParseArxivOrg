using System.Xml.Serialization;
using System.IO;

namespace ArxivOrgWinForm.Settings
{
    public class Scien
    {
        public ScienFields Fields;

        public Scien()
        {
            Fields = new ScienFields();
        }
        public void WriteXml()
        {
            XmlSerializer ser = new XmlSerializer(typeof(ScienFields));

            TextWriter writer = new StreamWriter(Fields.XMLFileName);
            ser.Serialize(writer, Fields);
            writer.Close();
        }
        public bool ReadXml()
        {
            if (File.Exists(Fields.XMLFileName))
            {
                string path = Fields.XMLFileName;
                XmlSerializer ser = new XmlSerializer(typeof(ScienFields));
                TextReader reader = new StreamReader(Fields.XMLFileName);
                Fields = ser.Deserialize(reader) as ScienFields;
                Fields.XMLFileName = path;
                reader.Close();

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
