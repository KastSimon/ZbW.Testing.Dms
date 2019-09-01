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
using ZbW.Testing.Dms.Client.Services.Interface;
using ZbW.Testing.Dms.Client.TestableObjects;

namespace ZbW.Testing.Dms.Client.Services
{
    public class FileControl
    {
        private object repositoryDir;
        private XmlControl xmlControl = new XmlControl();
        private const string BACKSLASH = "\\";
        private const string FILENAMECONTENT = "_Content.Pdf";
        private const string FILENAMEMETADATA = "_Metadata.xml";
        private const int MAXNUMBERS_OF_LETTERS_FILENAMEMETADATA = 49;
        private string currentGuid;
        private TestableGUID guid;
        private TestableDirectory dir;
        private TestableFile file;
        private List<MetadataItem> fileList;

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
            if (SaveMetaData(obj, targetPath, xmlControl) && CreateContentFile(sourcePath,targetPath))
                return true;
            else
                return false;
        }

        public List<MetadataItem> Search(string filter1,string filter2)
        {
            if (dir.Exists(Convert.ToString(repositoryDir)))
            { 
                fileList = new List<MetadataItem>();
                foreach (var file in dir.GetFiles(Convert.ToString(repositoryDir), "*"+FILENAMEMETADATA, SearchOption.AllDirectories))
                {
                    var metaDataItem = new MetadataItem();
                    metaDataItem = LoadMetaData(file,xmlControl);
                    metaDataItem.FilePath = GetFilePath(file);
                    metaDataItem.FileGuid = GetFileGuid(file);
                    try
                    {
                        if (metaDataItem != null && MetadataItemFilter(metaDataItem, filter1) && MetadataItemFilter(metaDataItem, filter2))
                        {
                            fileList.Add(metaDataItem);
                        }
                    }
                    catch (Exception ex)
                    {
                        var testableMessageBox = new TestableMessageBox();
                        testableMessageBox.Show($"File: {metaDataItem.FileGuid} is corrupt!");
                    }
                
               
                }
                return fileList;
            }
            else
            {
                var testableMessageBox = new TestableMessageBox();
                testableMessageBox.Show("No File found!");
                return null;
            }
        }

        private bool MetadataItemFilter(MetadataItem data, string requirement)
        {
            if (requirement == null)
            {
                return true;
            }
            else
            {
                if (data.Bezeichung.Contains(requirement))
                {
                    return true;
                }
                else if (data.Stichwoerter.Contains(requirement))
                {
                    return true;
                }
                else if (data.DokumentTyp.Contains(requirement))
                {
                    return true;
                }
                else if (requirement.Equals(""))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
           
        }

        private string GetFilePath(string fileName) //fileName must includ path
        {
            return fileName.Remove(fileName.Length - MAXNUMBERS_OF_LETTERS_FILENAMEMETADATA);
        }

        private string GetFileGuid(string fileName) //fileName must includ path
        {
            var fileGuid = fileName.Split('\\');
            return fileGuid[fileGuid.Length - 1].TrimEnd('_', 'M', 'e', 't', 'a', 'd', 'a', 't', 'a', '.', 'x', 'm', 'l'); 
        }

        private bool SaveMetaData(MetadataItem obj, string targetPath,IDataBaseHandler dataBaseHandler)
        {
            if (obj.ValideMetadata(new TestableMessageBox()))
            {
                try
                {

                    dataBaseHandler.SaveData(obj, targetPath + BACKSLASH + GetFileNameMetadata(currentGuid));
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

        private MetadataItem LoadMetaData(string fileName, IDataBaseHandler dataBaseHandler)
        {
           
                try
                {

                    return dataBaseHandler.LoadData(fileName);
                   
                }
                catch (Exception ex)
                {
                    var testableMessageBox = new TestableMessageBox();
                    testableMessageBox.Show(ex.Message);
                    return null;
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
            return currentGuid + FILENAMECONTENT;
        }

        private string GetFileNameMetadata(string currentGuid)
        {
            return currentGuid + FILENAMEMETADATA;
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
