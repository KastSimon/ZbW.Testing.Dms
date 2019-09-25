using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services.Interface;
using ZbW.Testing.Dms.Client.TestableObjects;

namespace ZbW.Testing.Dms.Client.Services
{
    public class MetaDataControl: IMetaDataControl
    {
        private const string BACKSLASH = "\\";
        private const string FILEENDING = "_Metadata.xml";

        public string GetFileEnding
        {
            get { return FILEENDING; }
            private set { }
        }

        public virtual bool Save(MetadataItem obj, string targetPath, string currentGuid, IDataBaseHandler dataBaseHandler)
        {
            string fileName = targetPath + BACKSLASH + GetFileNameMetadata(currentGuid);

            if (obj.ValideMetadata(new TestableMessageBox()))
            {
                dataBaseHandler.SaveData(obj, fileName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual MetadataItem Load(string fileName, IDataBaseHandler dataBaseHandler)
        {
            return dataBaseHandler.LoadData(fileName);
        }

        private string GetFileNameMetadata(string currentGuid)
        {
            return currentGuid + FILEENDING;
        }
    }
}
