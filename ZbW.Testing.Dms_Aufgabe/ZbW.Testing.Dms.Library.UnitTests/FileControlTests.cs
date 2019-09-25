using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using ZbW.Testing.Dms.Client.Services;
using ZbW.Testing.Dms.Client.TestableObjects;

namespace ZbW.Testing.Dms.Library.UnitTests
{

    using NUnit.Framework;
    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.Services.Interface;

    [TestFixture]
    class FileControlTests
    {
        [Test] public void Save_SaveMethadataCorrect_RetrunTrue()
        {
            //arrange
            var testaleDirectoryStub = A.Fake<TestableDirectory>();
            var testableGUIDStub = A.Fake<TestableGUID>();
            var testableMessageBox = A.Fake<TestableMessageBox>();
            var testbleFileStub = A.Fake<TestableFile>();
            var metaDataControl = new MetaDataControl();
            var contentFileControlStub = A.Fake<ContentFileControl>();
            var metaDataItem = new MetadataItem(true);
            metaDataItem.Bezeichung = "Simon";
            metaDataItem.ValutaDatum = DateTime.Now;
            metaDataItem.DokumentTyp = "Beleg";
            metaDataItem.Stichwoerter = "Test01";
            var fileControl = new FileControl(testaleDirectoryStub, testableGUIDStub, testbleFileStub, metaDataControl, contentFileControlStub, testableMessageBox);

            //act 

            var result = fileControl.Save(metaDataItem, "SomePath");
            //assert
          
            Assert.That(result,Is.True);

        }

        [Test]
        public void Save_SaveMethadataGuidThrowsExceptoin_RetrunFalse()
        {
            //arrange
            var testaleDirectoryStub = A.Fake<TestableDirectory>();
            var testableGUIDStub = A.Fake<TestableGUID>();
            var testableMessageBox = A.Fake<TestableMessageBox>();
            var testbleFileStub = A.Fake<TestableFile>();
            var metaDataControl = new MetaDataControl();
            var contentFileControlStub = A.Fake<ContentFileControl>();
            var xmlControlStub = A.Fake<XmlControl>();
            var metaDataItem = new MetadataItem(true);
            metaDataItem.Bezeichung = "Simon";
            metaDataItem.ValutaDatum = DateTime.Now;
            metaDataItem.DokumentTyp = "Beleg";
            metaDataItem.Stichwoerter = "Test01";
            var fileControl = new FileControl(testaleDirectoryStub, testableGUIDStub, testbleFileStub, metaDataControl, contentFileControlStub, testableMessageBox);

            //act 

            A.CallTo(() => testableGUIDStub.NewGuid()).Throws(new Exception());
            var result = fileControl.Save(metaDataItem, "SomePath");
            //assert

            Assert.That(result, Is.False);

        }

        [Test]
        public void Save_SaveMethadataIncorrect_RetrunFalse()
        {
            //arrange
            var testaleDirectoryStub = A.Fake<TestableDirectory>();
            var testableGUIDStub = A.Fake<TestableGUID>();
            var testableMessageBox = A.Fake<TestableMessageBox>();
            var testbleFileStub = A.Fake<TestableFile>();
            var metaDataControl = new MetaDataControl();
            var contentFileControlStub = A.Fake<ContentFileControl>();
            var xmlControlStub = A.Fake<XmlControl>();
            var metaDataItem = new MetadataItem(true);
            metaDataItem.Bezeichung = "";
            metaDataItem.ValutaDatum = DateTime.Now;
            metaDataItem.DokumentTyp = "Beleg";
            metaDataItem.Stichwoerter = "Test01";
            var fileControl = new FileControl(testaleDirectoryStub, testableGUIDStub, testbleFileStub, metaDataControl, contentFileControlStub, testableMessageBox);

            //act 


            var result = fileControl.Save(metaDataItem, "SomePath");
            //assert

            Assert.That(result, Is.False);

        }

        [Test]
        public void Delete_DeleteFile_RetrunTrue()
        {
            //arrange
            var testaleDirectoryStub = A.Fake<TestableDirectory>();
            var testableGUIDStub = A.Fake<TestableGUID>();
            var testableMessageBox = A.Fake<TestableMessageBox>();
            var testbleFileStub = A.Fake<TestableFile>();
            var metaDataControl = new MetaDataControl();
            var contentFileControlStub = A.Fake<ContentFileControl>();
            var xmlControlStub = A.Fake<XmlControl>();
            var metaDataItem = new MetadataItem(true);
            metaDataItem.Bezeichung = "";
            metaDataItem.ValutaDatum = DateTime.Now;
            metaDataItem.DokumentTyp = "Beleg";
            metaDataItem.Stichwoerter = "Test01";
            var fileControl = new FileControl(testaleDirectoryStub, testableGUIDStub, testbleFileStub, metaDataControl, contentFileControlStub, testableMessageBox);

            //act 


            var result = fileControl.Delete("SomePath");
            //assert

            Assert.That(result, Is.True);

        }

        [Test]
        public void Delete_DeleteFileThrowsException_RetrunFalse()
        {
            //arrange
            var testaleDirectoryStub = A.Fake<TestableDirectory>();
            var testableGUIDStub = A.Fake<TestableGUID>();
            var testbleFileStub = A.Fake<TestableFile>();
            var testableMessageBox = A.Fake<TestableMessageBox>();
            var metaDataControl = new MetaDataControl();
            var contentFileControlStub = A.Fake<ContentFileControl>();
            var metaDataItem = new MetadataItem(true);
            metaDataItem.Bezeichung = "";
            metaDataItem.ValutaDatum = DateTime.Now;
            metaDataItem.DokumentTyp = "Beleg";
            metaDataItem.Stichwoerter = "Test01";
            var fileControl = new FileControl(testaleDirectoryStub, testableGUIDStub, testbleFileStub, metaDataControl, contentFileControlStub, testableMessageBox);

            //act 

            A.CallTo(() => testbleFileStub.Delete("SomePath")).Throws(new Exception());
            var result = fileControl.Delete("SomePath");
            //assert

            Assert.That(result, Is.False);

        }


        [Test]
        public void GetFilePath_ReturnRightPath_RetrunTrue()
        {
            //arrange
            var testaleDirectoryStub = A.Fake<TestableDirectory>();
            var testableGUIDStub = A.Fake<TestableGUID>();
            var testbleFileStub = A.Fake<TestableFile>();
            var testableMessageBox = A.Fake<TestableMessageBox>();
            var metaDataControl = new MetaDataControl();
            var contentFileControlStub = A.Fake<ContentFileControl>();
            var metaDataItem = new MetadataItem(true);
            metaDataItem.Bezeichung = "";
            metaDataItem.ValutaDatum = DateTime.Now;
            metaDataItem.DokumentTyp = "Beleg";
            metaDataItem.Stichwoerter = "Test01";
            var fileControl = new FileControl(testaleDirectoryStub, testableGUIDStub, testbleFileStub, metaDataControl, contentFileControlStub, testableMessageBox);

            //act 

            var result = fileControl.GetFilePath("aaaaaaaaa_aaaaaaaaa_aaaaaaaaa_aaaaaaaaa_aaaaaaaaa_");
            //assert

            Assert.That(result=="a",Is.True);

        }

        [Test]
        public void GetFileGuid_ReturnRightGuid_RetrunTrue()
        {
            //arrange
            var testaleDirectoryStub = A.Fake<TestableDirectory>();
            var testableGUIDStub = A.Fake<TestableGUID>();
            var testbleFileStub = A.Fake<TestableFile>();
            var testableMessageBox = A.Fake<TestableMessageBox>();
            var metaDataControl = new MetaDataControl();
            var contentFileControlStub = A.Fake<ContentFileControl>();
            var metaDataItem = new MetadataItem(true);
            metaDataItem.Bezeichung = "";
            metaDataItem.ValutaDatum = DateTime.Now;
            metaDataItem.DokumentTyp = "Beleg";
            metaDataItem.Stichwoerter = "Test01";
            var fileControl = new FileControl(testaleDirectoryStub, testableGUIDStub, testbleFileStub, metaDataControl, contentFileControlStub, testableMessageBox);

            //act 

            var result = fileControl.GetFileGuid("Correct\\A_Metadata.xml");
            //assert

            Assert.That(result == "A", Is.True);

        }

        [Test]
        public void MethadataFilter_CheckBezeichung_RetrunTrue()
        {
            //arrange
            var testaleDirectoryStub = A.Fake<TestableDirectory>();
            var testableGUIDStub = A.Fake<TestableGUID>();
            var testbleFileStub = A.Fake<TestableFile>();
            var testableMessageBox = A.Fake<TestableMessageBox>();
            var metaDataControl = new MetaDataControl();
            var contentFileControlStub = A.Fake<ContentFileControl>();
            var metaDataItem = new MetadataItem(true);
            metaDataItem.Bezeichung = "Simon";
            metaDataItem.ValutaDatum = DateTime.Now;
            metaDataItem.DokumentTyp = "Beleg";
            metaDataItem.Stichwoerter = "Test01";
            var fileControl = new FileControl(testaleDirectoryStub, testableGUIDStub, testbleFileStub, metaDataControl, contentFileControlStub, testableMessageBox);

            //act 

            var result = fileControl.MetadataItemFilter(metaDataItem,"Simon");
            //assert

            Assert.That(result, Is.True);

        }


        [Test]
        public void MethadataFilter_CheckDokumentTyp_RetrunTrue()
        {
            //arrange
            var testaleDirectoryStub = A.Fake<TestableDirectory>();
            var testableGUIDStub = A.Fake<TestableGUID>();
            var testbleFileStub = A.Fake<TestableFile>();
            var testableMessageBox = A.Fake<TestableMessageBox>();
            var metaDataControl = new MetaDataControl();
            var contentFileControlStub = A.Fake<ContentFileControl>();
            var metaDataItem = new MetadataItem(true);
            metaDataItem.Bezeichung = "Simon";
            metaDataItem.ValutaDatum = DateTime.Now;
            metaDataItem.DokumentTyp = "Beleg";
            metaDataItem.Stichwoerter = "Test01";
            var fileControl = new FileControl(testaleDirectoryStub, testableGUIDStub, testbleFileStub, metaDataControl, contentFileControlStub, testableMessageBox);

            //act 

            var result = fileControl.MetadataItemFilter(metaDataItem, "Beleg");
            //assert

            Assert.That(result, Is.True);

        }

        [Test]
        public void MethadataFilter_CheckStichwoerter_RetrunTrue()
        {
            //arrange
            var testaleDirectoryStub = A.Fake<TestableDirectory>();
            var testableGUIDStub = A.Fake<TestableGUID>();
            var testbleFileStub = A.Fake<TestableFile>();
            var testableMessageBox = A.Fake<TestableMessageBox>();
            var metaDataControl = new MetaDataControl();
            var contentFileControlStub = A.Fake<ContentFileControl>();
            var metaDataItem = new MetadataItem(true);
            metaDataItem.Bezeichung = "Simon";
            metaDataItem.ValutaDatum = DateTime.Now;
            metaDataItem.DokumentTyp = "Beleg";
            metaDataItem.Stichwoerter = "Test01";
            var fileControl = new FileControl(testaleDirectoryStub, testableGUIDStub, testbleFileStub, metaDataControl, contentFileControlStub, testableMessageBox);

            //act 

            var result = fileControl.MetadataItemFilter(metaDataItem, "Test01");
            //assert

            Assert.That(result, Is.True);

        }

        [Test]
        public void MethadataFilter_CheckNothingFound_RetrunFalse()
        {
            //arrange
            var testaleDirectoryStub = A.Fake<TestableDirectory>();
            var testableGUIDStub = A.Fake<TestableGUID>();
            var testbleFileStub = A.Fake<TestableFile>();
            var testableMessageBox = A.Fake<TestableMessageBox>();
            var metaDataControl = new MetaDataControl();
            var contentFileControlStub = A.Fake<ContentFileControl>();
            var metaDataItem = new MetadataItem(true);
            metaDataItem.Bezeichung = "Simon";
            metaDataItem.ValutaDatum = DateTime.Now;
            metaDataItem.DokumentTyp = "Beleg";
            metaDataItem.Stichwoerter = "Test01";
            var fileControl = new FileControl(testaleDirectoryStub, testableGUIDStub, testbleFileStub, metaDataControl, contentFileControlStub, testableMessageBox);

            //act 

            var result = fileControl.MetadataItemFilter(metaDataItem, "xy");
            //assert

            Assert.That(result, Is.False);

        }

        [Test]
        public void MethadataFilter_CheckNull_RetrunTrue()
        {
            //arrange
            var testaleDirectoryStub = A.Fake<TestableDirectory>();
            var testableGUIDStub = A.Fake<TestableGUID>();
            var testbleFileStub = A.Fake<TestableFile>();
            var testableMessageBox = A.Fake<TestableMessageBox>();
            var metaDataControl = new MetaDataControl();
            var contentFileControlStub = A.Fake<ContentFileControl>();
            var metaDataItem = new MetadataItem(true);
            metaDataItem.Bezeichung = "Simon";
            metaDataItem.ValutaDatum = DateTime.Now;
            metaDataItem.DokumentTyp = "Beleg";
            metaDataItem.Stichwoerter = "Test01";
            var fileControl = new FileControl(testaleDirectoryStub, testableGUIDStub, testbleFileStub, metaDataControl, contentFileControlStub, testableMessageBox);

            //act 

            var result = fileControl.MetadataItemFilter(metaDataItem, null);
            //assert

            Assert.That(result, Is.True);

        }

        [Test]
        public void Search_MethadataTrhowException_RetrunNull()
        {
            //arrange
            var testaleDirectoryStub = A.Fake<TestableDirectory>();
            var testableGUIDStub = A.Fake<TestableGUID>();
            var testbleFileStub = A.Fake<TestableFile>();
            var testableMessageBox = A.Fake<TestableMessageBox>();
            var metaDataControl = new MetaDataControl();
            var contentFileControlStub = A.Fake<ContentFileControl>();
            var fileControl = new FileControl(testaleDirectoryStub, testableGUIDStub, testbleFileStub, metaDataControl, contentFileControlStub, testableMessageBox);

            //act 

      
            var result = fileControl.Search("","");
            //assert

            Assert.That(result, Is.Null);

        }

        [Test]
        public void Reset_ReturnResetList_RetrunTrue()
        {
            //arrange
            var testaleDirectoryStub = A.Fake<TestableDirectory>();
            var testableGUIDStub = A.Fake<TestableGUID>();
            var testbleFileStub = A.Fake<TestableFile>();
            var testableMessageBox = A.Fake<TestableMessageBox>();
            var metaDataControl = new MetaDataControl();
            var contentFileControlStub = A.Fake<ContentFileControl>();
            var metaDataItem = new MetadataItem(true);
            metaDataItem.Bezeichung = "Simon";
            metaDataItem.ValutaDatum = DateTime.Now;
            metaDataItem.DokumentTyp = "Beleg";
            metaDataItem.Stichwoerter = "Test01";
            var fileControl = new FileControl(testaleDirectoryStub, testableGUIDStub, testbleFileStub, metaDataControl, contentFileControlStub, testableMessageBox);

            //act 

            var result = fileControl.Reset();
            //assert

            Assert.That(result != null, Is.True);

        }
    }


}
