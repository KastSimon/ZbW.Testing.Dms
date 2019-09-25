using System;
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
    using ZbW.Testing.Dms.Client.Services;

    [TestFixture]
    class ContentFileControlTests
    {
        [Test]
        public void Creat_CheckDependency_TestableFile_MethodCopyCalled()
        {
            // arrange
            var contenFileControl = new ContentFileControl();
            var fileMock = A.Fake<TestableFile>();
            // act
            contenFileControl.Create("source","target","guid", fileMock);
            // assert
            A.CallTo(() => fileMock.Copy("source", "target\\guid_Content.Pdf")).MustHaveHappened();
        }
    }
}
