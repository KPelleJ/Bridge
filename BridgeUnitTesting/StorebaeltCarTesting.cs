using _StoreBaeltTicketLibrary_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeUnitTesting
{
    public class StorebaeltCarTesting
    {
        [TestCase(2025, 3, 8)]
        [TestCase(2025, 3, 9)]
        public void StorebaeltCar_PriceWeekendWithBrobizz_CorrectPrice_ShouldPass(int year, int month, int day)
        {
            //Arrange
            StorebaeltCar testCar = new("tester", new DateTime(year, month, day), true);
            double expectedResult = Math.Abs(230 * 0.85 * 0.9);

            //Act
            var actualResult = testCar.Price();


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(2025, 3, 8)]
        [TestCase(2025, 3, 9)]
        public void StorebaeltCar_PriceWeekendNoBrobizz_CorrectPrice_ShouldPass(int year, int month, int day)
        {
            //Arrange
            StorebaeltCar testCar = new("tester", new DateTime(year, month, day), false);
            double expectedResult = Math.Abs(230 * 0.85);

            //Act
            var actualResult = testCar.Price();


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
