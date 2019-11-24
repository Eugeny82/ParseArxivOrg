using System.Xml.Serialization;
using System.IO;

namespace ArxivOrgWinForm.Settings
{
    class Prop
    {
        public PropFields Fields;

        public Prop()
        {
            Fields = new PropFields();
        }
        public void WriteXml()
        {
            XmlSerializer ser = new XmlSerializer(typeof(PropFields));

            TextWriter writer = new StreamWriter(Fields.XMLFileName);
            ser.Serialize(writer, Fields);
            writer.Close();
        }
        public bool ReadXml()
        {
            if (File.Exists(Fields.XMLFileName))
            {
                string path = Fields.XMLFileName;
                XmlSerializer ser = new XmlSerializer(typeof(PropFields));
                TextReader reader = new StreamReader(Fields.XMLFileName);
                Fields = ser.Deserialize(reader) as PropFields;
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
