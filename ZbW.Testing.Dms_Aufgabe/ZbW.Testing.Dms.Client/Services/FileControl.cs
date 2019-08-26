using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.TestableObjects;

namespace ZbW.Testing.Dms.Client.Services
{
    class FileControl
    {
        private object repositoryDir;
        private XmlControl xmlControl = new XmlControl();
        private const string BACKSLASH = "\\";
        private const string FILENAMECONTENT = "_Content.Pdf";
        private const string FILENAMEMETADATA = "_Metadata.xml";
        private string currentGuid;
        private TestableGUID guid;
        private TestableDirectory dir;
        private TestableFile file;

        public FileControl(TestableDirectory dir, TestableGUID guid, TestableFile file)
        {
            AppSettingsReader appSettingsReader = new AppSettingsReader();
            repositoryDir = appSettingsReader.GetValue("RepositoryDir", typeof(string));
            this.guid = guid;
            this.dir = dir;
            this.file = file;
        }



        public bool Save(MetadataItem obj,string sourcePath)
        {
            currentGuid = Convert.ToString(guid.NewGuid());
            var targetPath = creatFileFolder(obj);
            if (CreatMetaDataXml(obj, targetPath) && CreateContentFile(sourcePath,targetPath))
                return true;
            else
                return false;
        }

        private bool CreatMetaDataXml(MetadataItem obj, string targetPath)
        {
            if (obj.ValideMetadata(new TestableMessageBox()))
            {
                try
                {
                    
                    xmlControl.SaveData(obj, targetPath + BACKSLASH + GetFileNameMetadata(currentGuid));
                    return true;
                }
                catch (Exception ex)
                {
                    var testableMessageBox = new TestableMessageBox();
                    testableMessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool CreateContentFile(string sourcePath, string targetPath)
        {
            var sourceFileName = sourcePath;
            var targetFileName = targetPath + BACKSLASH + GetFileNameContent(currentGuid);
            file.Copy(sourcePath, targetFileName);

            if (file.Exists(targetFileName))
                return true;
            else
                return false;
        }

        private string GetFileNameContent(string currentGuid)
        {
            return guid.NewGuid()+ FILENAMECONTENT;
        }

        private string GetFileNameMetadata(string currentGuid)
        {
            return guid.NewGuid() + FILENAMEMETADATA;
        }

        private string creatFileFolder(MetadataItem obj)
        {
  
            if (obj.ValutaDatum != null)
            {
                var valutaYear = obj.ValutaDatum.Value.Year;
                var targetPath = repositoryDir + BACKSLASH + Convert.ToString(valutaYear);

                if (dir.Exists(targetPath))
                    return targetPath;
                else
                {
                    dir.CreateDirectory(targetPath);
                    return targetPath;
                }
            }
            else
            {
                return repositoryDir + BACKSLASH;
            }

        }


    }
}
