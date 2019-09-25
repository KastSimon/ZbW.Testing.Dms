using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FakeItEasy;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Library.InterfaceTests
{
    using NUnit.Framework;
    using System.IO;
    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.TestableObjects;

    [TestFixture]
    class XmlControlTests
    {


        [Test]
        public void LoadXmlFile_CheckDataFromFile_ReturnTestFile()
        {
            // arrange
            var dataBaseHandler = new XmlControl();
            var metaDataItem = new MetadataItem();

            // act
            metaDataItem = dataBaseHandler.LoadData(@"DMSTest\243c2b52-ea6d-4d50-9e39-4ae29f37fc68_Metadata.xml");

            // assert
            Assert.IsNotNull(metaDataItem);
            Assert.AreEqual("Simon", metaDataItem.User);
            Assert.AreEqual("BezeichnungsTest", metaDataItem.Bezeichung);
        }

        [Test]
        public void SaveXmlFile_CheckDataFromSavedFile_ReturnTestFile()
        {
            // arrange
            var dataBaseHandler = new XmlControl();
            var metaDataItem = new MetadataItem();
            metaDataItem.User = "Simon";
            metaDataItem.Bezeichung = "BezeichnungsTestSave";
            metaDataItem.ValutaDatum = DateTime.Now;
            metaDataItem.DokumentTyp = "Quittungen";
            metaDataItem.Stichwoerter = "Test Quittungen";

            // act
            dataBaseHandler.SaveData(metaDataItem, @"DMSTest\243c2b52-ea6d-4d50-9e39-4ae29f37fc67_Metadata.xml");
            var metaDataItemTest = dataBaseHandler.LoadData(@"DMSTest\243c2b52-ea6d-4d50-9e39-4ae29f37fc67_Metadata.xml");

            // assert
            Assert.IsNotNull(metaDataItemTest);
            Assert.AreEqual("Simon", metaDataItemTest.User);
            Assert.AreEqual("BezeichnungsTestSave", metaDataItemTest.Bezeichung);
        }
    }
}
