﻿using System;
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
        private MetadataItem metadataItem;
        private XmlSerializer sr;

        public XmlControl(XmlSerializer mock)
        {
            sr = mock;
        }

        public XmlControl() 
        {
             sr = new XmlSerializer(typeof(MetadataItem));
        }

        public virtual void SaveData(object obj, string fileName)
        {
          
            TextWriter writer = new StreamWriter(fileName);
            sr.Serialize(writer,obj);
            writer.Close();
        }


        public virtual MetadataItem LoadData(string fileName)
        {
            FileStream read = new FileStream(fileName,FileMode.Open,FileAccess.Read);
            metadataItem = (MetadataItem)sr.Deserialize(read);
            read.Close();
            return metadataItem;
        }
    }
}
