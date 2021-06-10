using HomeAPI.Controllers;
using HomeAPI.Data;
using HomeAPI.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace HomeAPI.Tests
{
    [TestClass]
    public class BoxRepositoryTesting
    {
        [TestMethod]
        public void GetDHTValuesByDate_ReturnsFilteredResults()
        {
            //Arrange
            //Act
            //Assert
            var mockRepo = new Mock<IBoxRepository>();
            var context = new Mock<HomeContext>();
          //  var boxController = new BoxController(context.Object, mockRepo.Object);

           // var result =  boxController.GetDHTS();
        }
    }
}
