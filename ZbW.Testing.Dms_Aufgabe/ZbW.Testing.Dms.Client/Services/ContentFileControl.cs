using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.TestableObjects;

namespace ZbW.Testing.Dms.Client.Services
{
   public class ContentFileControl
    {
        private const string BACKSLASH = "\\";
        private const string FILEENDING = "_Content.Pdf";

        public string GetFileEnding
        { 
            get { return FILEENDING; }
        }

        public virtual void Create(string sourcePath, string targetPath, string currentGuid, TestableFile file)
        {
            var sourceFileName = sourcePath;
            var targetFileName = targetPath + BACKSLASH + GetFileNameContent(currentGuid);


            file.Copy(sourcePath, targetFileName);

        }
        
        private string GetFileNameContent(string currentGuid)
        {
            return currentGuid + FILEENDING;
        }
    }
}
