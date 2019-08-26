using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.TestableObjects
{
    class TestableDirectory
    {
        public virtual bool Exists(string path)
        {
            return Directory.Exists(path);
        }

        public virtual DirectoryInfo CreateDirectory(string path)
        {
            return Directory.CreateDirectory(path);
        }
    }
}
