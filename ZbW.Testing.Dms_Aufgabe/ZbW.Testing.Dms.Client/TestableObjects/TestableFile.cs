using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.TestableObjects
{
    public class TestableFile
    {
        public virtual void Copy(string sourceFileName, string destFileName)
        {
            File.Copy(sourceFileName, destFileName);
            
        }

        public virtual bool Exists(string path)
        {
            return File.Exists(path);
        }

        public virtual void Open(string path)
        {
            Process.Start(path);
        }

        public virtual void Delete(string path)
        {
            File.Delete(path);
        }
    }
}
