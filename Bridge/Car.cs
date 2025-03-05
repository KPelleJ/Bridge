﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bridge
{
    /// <summary>
    /// Car sub class that inherits from the Vehicle base class. Base ticket price of car is 230
    /// </summary>
    public class Car:Vehicle
    {
        public Car(string licensePlate, DateTime date, bool brobizz):base(licensePlate, date, 230, brobizz)
        {
        }

        public override string VehicleType()
        {
            return "Car";
        }
    }
}
