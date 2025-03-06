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
            MC testMC = new("test", DateTime.Now, false);
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
            MC testMC = new("test", DateTime.Now, false);
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
            //Act
            TestDelegate actualResult = () => new MC(licenseplate, DateTime.Now, false);


            //Assert
            Assert.Throws<ArgumentException>(actualResult);
        }

        [Test]
        public void MC_PriceWithBrobizzDiscount_RightPrice_ShouldPass()
        {
            //Assign
            MC testMC = new("tester", DateTime.Now, true);
            double expectedResult = 120 * 0.9;


            //Act
            var actualResult = testMC.Price();


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
