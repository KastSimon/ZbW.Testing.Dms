using System;
using System.Windows;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using ZbW.Testing.Dms.Client.TestableObjects;

namespace ZbW.Testing.Dms.Library.InterfaceTests
{
    using NUnit.Framework;
    using ZbW.Testing.Dms.Client.Model;

    [TestFixture]
    class MetadataItemTests
    {
        [Test] public void ValideMetadata_CheckDependency_TestableMessageBoxCalled()
        { 
            // arrange
            var metadataItem = new MetadataItem("Simon",DateTime.Now,"","");
            var testableMessageBoxMock = A.Fake<TestableMessageBox>();
            // act
            var result = metadataItem.ValideMetadata(testableMessageBoxMock);

            // assert
            A.CallTo(() => testableMessageBoxMock.Show("Es müssen alle Pflichtfelder ausgefüllt werden")).MustHaveHappened();
        }

       

      


    }
}
