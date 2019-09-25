using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services.Interface
{
    public interface IDataBaseHandler
    {
         void SaveData(object obj, string fileName);

         MetadataItem LoadData(string fileName);
    }
}
