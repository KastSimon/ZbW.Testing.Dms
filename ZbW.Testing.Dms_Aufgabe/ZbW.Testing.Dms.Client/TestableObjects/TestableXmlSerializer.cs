using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.TestableObjects
{
  public   class TestableXmlSerializer :XmlSerializer
    {
        public virtual void Serialize(TextWriter writer, object obj)
        {
           
        }

        public virtual object Deserialize(FileStream reader)
        {
            return null;
        }
    }
}
