﻿using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BridgeUnitTesting
{
    public class CarTests
    {
        [Test]
        public void Car_Price_CorrectPrice_ShouldPass()
        {
            //Assign
            Car testCar = new("test", DateTime.Now);
            double expectedResult = 230;

            //Act
            var actualResult = testCar.Price();


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Car_VehicleType_CorrectType_ShouldPass()
        {
            //Assign
            Car testCar = new("test", DateTime.Now);
            string expectedResult = "Car";

            //Act
            var actualResult = testCar.VehicleType();


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase("@@@@@")]
        [TestCase("-----")]
        [TestCase("ABC$%--123")]
        public void Car_LicensePlate_IllegalCharacters_ShouldThrowException(string licensePlate)
        {
            //Assign


            //Act
            TestDelegate actualResult = () => new Car(licensePlate, DateTime.Now);


            //Assert
            Assert.Throws<ArgumentException>(actualResult);
        }
    }
}
