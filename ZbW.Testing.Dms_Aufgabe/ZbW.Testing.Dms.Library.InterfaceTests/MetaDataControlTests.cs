using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using ZbW.Testing.Dms.Client.Services.Interface;

namespace ZbW.Testing.Dms.Library.InterfaceTests
{
    using NUnit.Framework;
    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.Services;

    [TestFixture]
    class MetaDataControlTests
    {
        [Test]
        public void Save_CheckDependency_DataBaseHandler_MethodeSaveCalled()
        {
            // arrange
            var dataBaseHandlerMock = A.Fake<IDataBaseHandler>();
            var metaDataControl = new MetaDataControl();
            var metadataItem = new MetadataItem();
            metadataItem.Bezeichung = "Simon";
            metadataItem.ValutaDatum = DateTime.Now;
            metadataItem.DokumentTyp = "Beleg";
            metadataItem.Stichwoerter = "Test01";
            // act
            metaDataControl.Save(metadataItem, "target", "guid", dataBaseHandlerMock);
            // assert
            A.CallTo(() => dataBaseHandlerMock.SaveData(metadataItem, "target\\guid_Metadata.xml")).MustHaveHappened();

        }

        [Test]
        public void Load_CheckDependency_DataBaseHandler_MethodeLoadCalled()
        {
            // arrange
            var dataBaseHandlerMock = A.Fake<IDataBaseHandler>();
            var metaDataControl = new MetaDataControl();
            // act
            metaDataControl.Load("file",dataBaseHandlerMock);
            // assert
            A.CallTo(() => dataBaseHandlerMock.LoadData("file")).MustHaveHappened();

        }
    }
}
