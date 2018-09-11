

namespace VehiclePark
{
    using System;
    using System.Collections.Generic;

    enum Option
    {
        CreateLevel = 1,
        AddVehiclePermission,
        ParkVehicle,
        UnParkVehicle
    }
    public class ParkingArea
    {
        static void Main(string[] args)
        {
            Stand stand = new Stand();

            while (true)
            {
                Console.WriteLine("1.) Create New Level");
                Console.WriteLine("2.) Add Level Permission");
                Console.WriteLine("3.) Park Vehicle");
                Console.WriteLine("4.) Un Park Vehicle");
                int userOption = Convert.ToInt16(Console.ReadLine());
                switch (userOption)
                {
                    case (int)Option.CreateLevel:
                        int levelId = stand.CreateLevel();
                        Console.WriteLine("Parking level has been successfully created that is is : {0}", levelId);
                        break;

                    case (int)Option.AddVehiclePermission:
                        foreach (var level in stand.parkingLevels)
                        {
                            Console.WriteLine("Level Id => {0} - TotalPermissions{1}", level.Key, level.Value.vehiclePermission.Count);
                        }
                        int levelKey = Convert.ToInt16(Console.ReadLine());
                        Console.Write("Vehicle Type :");
                        string vehicleType = Convert.ToString(Console.ReadLine());
                        Console.Write("No of Allowed Spaces:");
                        int totalAlloweded = Convert.ToInt16(Console.ReadLine());
                        stand.parkingLevels[levelKey].AddVechilePermission(vehicleType, totalAlloweded);
                        break;

                    case (int)Option.ParkVehicle:
                        Console.WriteLine("Welcome");
                        Vehicle vehicle = new Vehicle();
                        Console.Write("Enter Vehicle No :");
                        vehicle.Number = Convert.ToInt16(Console.ReadLine());
                        Console.Write("Enter Vehicle Type :");
                        vehicle.Type = Convert.ToString(Console.ReadLine());
                        
                        Console.WriteLine("Tocken No {0}", stand.Parking(vehicle));
                        break;

                    case (int)Option.UnParkVehicle:
                        Console.WriteLine("Thank You, Come Again ");
                        Console.Write("Enter Vehicle No :");
                        int tockenNo = Convert.ToInt16(Console.ReadLine());
                        stand.UnParking(tockenNo);
                        break;

                    default:
                        foreach (var item in stand.parkingLevels.Values)
                        {
                            foreach (var item1 in item.ParkedVehicle)
                            {
                                Console.WriteLine(item1.Value.Number);
                            }
                        }
                        Console.WriteLine("");
                        break;
                }
            }
        }
    }
}
