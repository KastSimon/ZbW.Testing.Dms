using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services.Interface
{
    public interface IMetaDataControl
    {
      


        bool Save(MetadataItem obj, string targetPath, string currentGuid,
            IDataBaseHandler dataBaseHandler);


        MetadataItem Load(string fileName, IDataBaseHandler dataBaseHandler);

    } 
    
}
