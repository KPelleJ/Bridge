using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeUnitTesting
{
    public class MCTesting
    {
        [Test]
        public void MC_Price_CorrectPrice_ShouldPass()
        {
            //Assign
            MC testMC = new("test", DateTime.Now);
            double expectedResult = 120;


            //Act
            var actualResult = testMC.Price();


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void MC_VehicleType_CorrectType_ShouldPass()
        {
            //Assign
            MC testMC = new("test", DateTime.Now);
            string expectedResult = "MC";


            //Act
            var actualResult = testMC.VehicleType();


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase("@@@@@@")]
        [TestCase("-----")]
        [TestCase("OBE231321")]
        public void MC_LicensePlate_InvalidCharacters_ShouldThrowException(string licenseplate)
        {
            //Assign



            //Act
            TestDelegate actualResult = () => new MC(licenseplate, DateTime.Now);


            //Assert
            Assert.Throws<ArgumentException>(actualResult);
        }
    }
}
