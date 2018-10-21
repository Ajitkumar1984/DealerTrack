using Microsoft.VisualStudio.TestTools.UnitTesting;
using DealerTrack.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Moq;

namespace DealerTrackSETest.BusinessLogic.Tests
{
    [TestClass()]
    public class VehicleSalesInformationTests
    {
        private TestContext testContext;
        public TestContext TestContext
        {

            get { return testContext; }
            set { testContext = value; }

        }
       
        [TestMethod]
        public void ReadFile_ValidateHeader()
        {
            string testString = "first Row" + Environment.NewLine + "second Line" + Environment.NewLine + "Third line";
            List<String> errorMessageList = new List<string>();

            Mock<string> mock = new Mock<string>();
            mock.Setup(x => x.CreateReader(It.IsAny<string>())).Returns(new StringReader(testString));

            IOManager testObject = new IOManager(mock.Object);            //Replace with It.IsAny<string>()
            Assert.AreEqual(i, 3);
            Assert.AreEqual(errorMessageList.Count, 0);

        }
    }
}