using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Library.InterfaceTests
{
    using FakeItEasy;
    using NUnit.Framework;
    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.Services;
    using ZbW.Testing.Dms.Client.Services.Interface;
    using ZbW.Testing.Dms.Client.TestableObjects;

    [TestFixture]
    class FileControlTest
    {

        [Test]
        public void Open_CheckDependency_FileOpenCalled()
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
            metaDataItem.FileGuid = "";
            metaDataItem.FilePath = "";
            var fileControl = new FileControl(testaleDirectoryStub, testableGUIDStub, testbleFileStub, metaDataControl, contentFileControlStub, testableMessageBox);

            //act 

           
            fileControl.Open(metaDataItem);
            //assert

            A.CallTo(() => testbleFileStub.Open("_Content.Pdf")).MustHaveHappened();

        }
    }
}
