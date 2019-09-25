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
        private MetaDataControl metaDataControl = new MetaDataControl();
        private ContentFileControl contentFileControl = new ContentFileControl();
        private XmlControl xmlControl = new XmlControl();
        private const int MAXNUMBERS_OF_LETTERS_FILENAMEMETADATA = 49;
        private const string BACKSLASH = "\\";
        private string currentGuid;
        private TestableGUID guid = new TestableGUID();
        private TestableDirectory dir = new TestableDirectory();
        private TestableFile file = new TestableFile();
        private List<MetadataItem> fileList;
        private TestableMessageBox testableMessageBox = new TestableMessageBox();

        public FileControl(TestableDirectory dir, TestableGUID guid, TestableFile file, MetaDataControl metaDataControl, ContentFileControl contentFileControl, TestableMessageBox testableMessageBox)
        {
            AppSettingsReader appSettingsReader = new AppSettingsReader();
            repositoryDir = appSettingsReader.GetValue("RepositoryDir", typeof(string));
            this.guid = guid;
            this.dir = dir;
            this.file = file;
            this.metaDataControl = metaDataControl;
            this.contentFileControl = contentFileControl;
            this.testableMessageBox = testableMessageBox;
        }

        public FileControl()
        {
            AppSettingsReader appSettingsReader = new AppSettingsReader();
            repositoryDir = appSettingsReader.GetValue("RepositoryDir", typeof(string));
        }

        public virtual bool Save(MetadataItem obj,string sourcePath)
        {
            try
            {
                currentGuid = Convert.ToString(guid.NewGuid());
                var targetPath = creatFileFolder(obj);
                if (metaDataControl.Save(obj, targetPath, currentGuid, xmlControl))
                {
                    contentFileControl.Create(sourcePath, targetPath, currentGuid, file);
                    return true;
                }
                else
                    return false;
            }
            catch (ArgumentNullException ex)
            {
                testableMessageBox.Show("Es muss eine Datei ausgewählt werden");
                return false;
            }
            catch (Exception ex)
            {
                testableMessageBox.Show(ex.Message);
                return false;
            }
            

        }

        public virtual bool Delete(string sourcePath)
        {
            try
            {
                file.Delete(sourcePath);
                return true;
            }
            catch (ArgumentNullException ex)
            {
                testableMessageBox.Show("Es muss eine Datei ausgewählt werden");
                return false;
            }
            catch (Exception ex)
            {
                testableMessageBox.Show(ex.Message);
                return false;
            }
        }

        public virtual List<MetadataItem> Search(string filter1,string filter2)
        {
            if (dir.Exists(Convert.ToString(repositoryDir)))
            { 
                fileList = new List<MetadataItem>();
                foreach (var file in dir.GetFiles(Convert.ToString(repositoryDir), "*"+metaDataControl.GetFileEnding, SearchOption.AllDirectories))
                {
                    var metaDataItem = new MetadataItem();
                    try
                    {
                        metaDataItem = metaDataControl.Load(file, xmlControl);
                        metaDataItem.FilePath = GetFilePath(file);
                        metaDataItem.FileGuid = GetFileGuid(file);

                        if (MetadataItemFilter(metaDataItem, filter1) && MetadataItemFilter(metaDataItem, filter2))
                        {
                            fileList.Add(metaDataItem);
                        }
                    }
                    catch (Exception ex)
                    {
                        testableMessageBox.Show($"File: {metaDataItem.FileGuid} is corrupt!");
                    }
                
               
                }
                return fileList;
            }
            else
            {
                testableMessageBox.Show("No File found!");
                return null;
            }
        }

        public virtual List<MetadataItem> Reset()
        {
            fileList = new List<MetadataItem>();
            return fileList;
        }

        public virtual void Open(MetadataItem metaDataItem)
        {
            file.Open(metaDataItem.FilePath + metaDataItem.FileGuid + contentFileControl.GetFileEnding);
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

        public bool MetadataItemFilter(MetadataItem data, string requirement)
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

        public string GetFilePath(string fileName) //fileName must includ path
        {
            return fileName.Remove(fileName.Length - MAXNUMBERS_OF_LETTERS_FILENAMEMETADATA);
        }

        public string GetFileGuid(string fileName) //fileName must includ path
        {
            var fileGuid = fileName.Split('\\');
            return fileGuid[fileGuid.Length - 1].TrimEnd('_', 'M', 'e', 't', 'a', 'd', 'a', 't', 'a', '.', 'x', 'm', 'l');
        }


    }
}
