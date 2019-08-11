﻿using System;
using System.Windows;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using ZbW.Testing.Dms.Client.TestableObjects;

namespace ZbW.Testing.Dms.Library.UnitTests
{
    using NUnit.Framework;
    using ZbW.Testing.Dms.Client.Model;

    [TestFixture]
    class MetadataItemTests
    {
        [Test] public void ValideMetadata_ValideData_RetrunTrue()
        { 
            // arrange
            var metadataItem = new MetadataItem("Simon",DateTime.Now,"Beleg","Test01");
            var testableMessageBoxStub = A.Fake<TestableMessageBox>();
            // act
            var result = metadataItem.ValideMetadata(testableMessageBoxStub);

            // assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ValideMetadata_NoCue_RetrunTrue()
        {
            // arrange
            var metadataItem = new MetadataItem("Simon", DateTime.Now, "Beleg", "");
            var testableMessageBoxStub = A.Fake<TestableMessageBox>();
            // act
            var result = metadataItem.ValideMetadata(testableMessageBoxStub);

            // assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ValideMetadata_NoName_RetrunFalse()
        {
            // arrange
            var metadataItem = new MetadataItem("", DateTime.Now, "Beleg", "Test01");
            var testableMessageBoxStub = A.Fake<TestableMessageBox>();
            // act
            var result = metadataItem.ValideMetadata(testableMessageBoxStub);

            // assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ValideMetadata_DateIsNull_RetrunFalse()
        {
            // arrange
            var metadataItem = new MetadataItem("Simon", null, "Beleg", "Test01");
            var testableMessageBoxStub = A.Fake<TestableMessageBox>();
            // act
            var result = metadataItem.ValideMetadata(testableMessageBoxStub);

            // assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ValideMetadata_NoSelecedTypItems_RetrunFalse()
        {
            // arrange
            var metadataItem = new MetadataItem("Simon", DateTime.Now, "", "Test01");
            var testableMessageBoxStub = A.Fake<TestableMessageBox>();
            // act
            var result = metadataItem.ValideMetadata(testableMessageBoxStub);

            // assert
            Assert.That(result, Is.False);
        }

      


    }
}
