using OresundBronTicketLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeUnitTesting
{
    public class OresundTesting
    {
        [TestCase(460, false)]
        [TestCase(178, true)]
        public void OresundCar_PriceIsCorrect_ShouldPass(double expectedPrice, bool brobizz)
        {
            //Arrange
            OresundCar testCar = new("tester", DateTime.Now, brobizz);


            //Act
            var actualResult = testCar.Price();


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedPrice));
        }

        [Test]
        public void OresundCar_TypeIsCorrect_ShouldPass()
        {
            //Arrange
            OresundCar testCar = new("tester", DateTime.Now, false);
            string expectedResult = "Oresund Car";

            //Act
            var actualResult = testCar.VehicleType();


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(235, false)]
        [TestCase(92, true)]
        public void OresundMC_PriceIsCorrect_ShouldPass(double expectedPrice, bool brobizz)
        {
            //Arrange
            OresundMC testMC = new("tester", DateTime.Now, brobizz);


            //Act
            var actualResult = testMC.Price();


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedPrice));
        }

        [Test]
        public void OresundMC_TypeIsCorrect_ShouldPass()
        {
            //Arrange
            OresundMC testMC = new("tester", DateTime.Now, false);
            string expectedResult = "Oresund MC";

            //Act
            var actualResult = testMC.VehicleType();


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
