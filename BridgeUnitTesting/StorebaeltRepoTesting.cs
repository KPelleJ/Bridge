using _StoreBaeltTicketLibrary_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeUnitTesting
{
    
    public class StorebaeltRepoTesting
    {
        [Test]
        public void GetAll_ReturnsAllVehicles_ShouldPass()
        {
            //Arrange
            StorebaeltTicketRepository testRepo = new();
            var expectedResult = 10;


            //Act
            var actualResult = testRepo.GetAll().Count();


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Add_NewCountShouldBeCorrect_ShouldPass()
        {
            //Arrange
            StorebaeltTicketRepository testRepo = new();
            var expectedResult = 11;


            //Act
            testRepo.Add(new StorebaeltCar("test123", DateTime.Now, false));
            var actualResult = testRepo.GetAll().Count();


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase("AQZ4821")]
        [TestCase("CR67222")]
        [TestCase("BRB4206")]
        [TestCase("KMS7623")]
        [TestCase("BBPP221")]
        [TestCase("WA21312")]
        [TestCase("GGKMS29")]
        public void GetByLicensePlate_ReturnsCorrectVehicle_ShouldPass(string expectedResult)
        {
            //Arrange
            StorebaeltTicketRepository testRepo = new();


            //Act
            var actualResult = testRepo.GetByLicensePlate(expectedResult).ElementAt(0).LicensePlate;


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
