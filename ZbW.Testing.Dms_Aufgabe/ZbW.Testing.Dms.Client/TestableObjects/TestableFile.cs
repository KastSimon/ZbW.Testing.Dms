using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.TestableObjects
{
    class TestableFile
    {
        public virtual void Copy(string sourceFileName, string destFileName)
        {
            File.Copy(sourceFileName, destFileName);
            
        }

        public virtual bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}
