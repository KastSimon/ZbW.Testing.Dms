using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Library.UnitTests
{
    using FakeItEasy;
    using NUnit.Framework;
    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.Services;
    using ZbW.Testing.Dms.Client.Services.Interface;

    [TestFixture]
    class MetaDataControlTests

    {
        [Test] public void Save_CheckIfMetadataItemValid_RetrunTrue()
        {
            // arrange
            var dataBaseHandlerStub = A.Fake<IDataBaseHandler>();
            var metaDataControl = new MetaDataControl();
            var metadataItem = new MetadataItem();
            metadataItem.Bezeichung = "Simon";
            metadataItem.ValutaDatum = DateTime.Now;
            metadataItem.DokumentTyp = "Beleg";
            metadataItem.Stichwoerter = "Test01";
            bool result;
            // act
            result = metaDataControl.Save(metadataItem, "target", "guid", dataBaseHandlerStub);
            // assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Save_CheckIfMetadataItemValid_RetrunFalse()
        {
            // arrange
            var dataBaseHandlerStub = A.Fake<IDataBaseHandler>();
            var metaDataControl = new MetaDataControl();
            var metadataItem = new MetadataItem(true);
            metadataItem.Bezeichung = "";
            metadataItem.ValutaDatum = DateTime.Now;
            metadataItem.DokumentTyp = "Beleg";
            metadataItem.Stichwoerter = "Test01";
            bool result;
            // act
            result = metaDataControl.Save(metadataItem, "target", "guid", dataBaseHandlerStub);
            // assert
            Assert.That(result, Is.False);
        }
    }
}
