using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services.Interface;

namespace ZbW.Testing.Dms.Client.Services
{
    public class XmlControl: IDataBaseHandler
    {
        
        public virtual void SaveData(object obj, string fileName)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(fileName);
            sr.Serialize(writer,obj);
            writer.Close();
        }

        public virtual MetadataItem LoadData(string fileName)
        {
            XmlSerializer sr = new XmlSerializer(typeof(MetadataItem));
            FileStream read = new FileStream(fileName,FileMode.Open,FileAccess.Read);
            return (MetadataItem) sr.Deserialize(read);
        }
    }
}
