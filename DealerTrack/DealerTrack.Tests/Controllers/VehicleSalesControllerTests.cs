using Microsoft.VisualStudio.TestTools.UnitTesting;
using DealerTrack.Controllers;
using DealerTrack.BusinessLogic;
using System.Web.Routing;
using System.Web.Mvc;
using System.Web;
using Moq;
using DealerTrack.ViewModel;
using System.IO;

namespace DealerTrackSETest.Controllers.Tests
{
    [TestClass()]
    public class VehicleSalesControllerTests
    {
        private TestContext testContext;
        public TestContext TestContext
        {

            get { return testContext; }
            set { testContext = value; }

        }
        [TestMethod()]
        public void Upload_Action_Should_Store_Files_In_The_Upload_Folder()
        {  
            //Object and variale declration
            VehicleSalesInformation vehicleSalesInformation = new VehicleSalesInformation();
            VehicleSalesViewModel vehicleSalesViewModel = new VehicleSalesViewModel();
            string solution_dir = TestContext.TestDir+ "\\Uploads";
            string filename = "testfile.csv";

            var httpContextMock = new Mock<HttpContextBase>();
            var serverMock = new Mock<HttpServerUtilityBase>();
            serverMock.Setup(x => x.MapPath("~/Uploads")).Returns(solution_dir);
            httpContextMock.Setup(x => x.Server).Returns(serverMock.Object);

            var sut = new VehicleSalesController(vehicleSalesInformation);
            sut.ControllerContext = new ControllerContext(httpContextMock.Object, new RouteData(), sut);

            var fileMock = new Mock<HttpPostedFileBase>();
            fileMock.Setup(x => x.FileName).Returns(filename);
            vehicleSalesViewModel.File = fileMock.Object;
            var actual = sut.Index(vehicleSalesViewModel);
            fileMock.Verify(x => x.SaveAs(solution_dir+"\\"+filename));           
        }

       
    }
}