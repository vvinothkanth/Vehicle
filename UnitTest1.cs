using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehiclePark;

namespace VehicleParkingTestCase
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckIsValidVehicle()
        {

            Level level = new Level();
            Vehicle car = new Vehicle();
            car.Number = 1;
            car.Type = "car";
            level.AddVechilePermission("car", 2);
            level.AddVechilePermission("bike", 5);
            level.AddVechilePermission("bus", 1);
            level.AddVechilePermission("auto", 2);

            level.ParkTheVehicle(car);

            Assert.IsTrue(level.IsParkingSpaceAvailable("car"));

            level.ParkTheVehicle(car);
            level.ParkTheVehicle(car);

            Assert.IsFalse(level.IsParkingSpaceAvailable("car"));

        }

        [TestMethod]
        public void IsValidVehicle()
        {
            Level level = new Level();
            level.AddVechilePermission("car", 2);
            level.AddVechilePermission("bike", 5);
            level.AddVechilePermission("auto", 2);

            Assert.IsTrue(level.IsValidVehicle("Car"));
            Assert.IsTrue(level.IsValidVehicle("BiKe"));
            Assert.IsFalse(level.IsValidVehicle("van"));
            Assert.IsFalse(level.IsValidVehicle("Cycle"));

        }
        [TestMethod]
        public void CheckParkTheVehicle()
        {
            Level level = new Level();
            Vehicle car = new Vehicle();
            car.Number = 1;
            car.Type = "car";

            Assert.AreEqual(1, level.ParkTheVehicle(car));

            Vehicle bus = new Vehicle();
            bus.Number = 1;
            bus.Type = "Bus";
            Assert.AreEqual(2, level.ParkTheVehicle(bus));
        }

        [TestMethod]
        public void CheckIsPossibleToPark()
        {
            Stand stand = new Stand();
            Vehicle auto = new Vehicle();
            auto.Number = 1;
            auto.Type = "auto";
            
            int levelId = stand.CreateLevel();
            stand.parkingLevels[levelId].AddVechilePermission("auto", 1 );

            Assert.IsTrue(stand.IsPossibleToParking(levelId, auto.Type));
            stand.parkingLevels[levelId].ParkTheVehicle(auto);
            stand.parkingLevels[levelId].ParkTheVehicle(auto);

            Assert.IsFalse(stand.IsPossibleToParking(levelId, auto.Type));

        }
    }
}
