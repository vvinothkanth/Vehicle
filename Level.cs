//
//
//

namespace VehiclePark
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public class Level
    {
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, int> vehiclePermission = new Dictionary<string, int>();

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<int, Vehicle> ParkedVehicle = new Dictionary<int, Vehicle>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vechicleType"></param>
        /// <returns></returns>
        public bool IsValidVehicle(string vechicleType)
        {
            return vehiclePermission.ContainsKey(vechicleType.ToLower()) ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <returns></returns>
        public bool IsParkingSpaceAvailable(string vehicleType)
        {
            bool isAvailable = false;

            try
            {
                if (vehiclePermission.ContainsKey(vehicleType))
                {
                    var vehicleCount = (from park in ParkedVehicle where park.Value.Type == vehicleType.ToLower() select park.Value.Number).ToList<int>().Count;

                    isAvailable = vehicleCount < vehiclePermission[vehicleType] ? true : false;
                }
            }
            catch (Exception ex)
            {    
                throw new Exception(ex.ToString());
            }

            return isAvailable;
                 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public int ParkTheVehicle(Vehicle vehicle)
        {
            ParkedVehicle.Add(ParkedVehicle.Count + 1, vehicle);
            return ParkedVehicle.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parkedId"></param>
        public void UnParkTheVehicle(int parkedId)
        {
            if (ParkedVehicle.ContainsKey(parkedId))
            {
                //Vehicle vehicle = ParkedVehicle[parkedId];
                ParkedVehicle.Remove(parkedId);
            }
            else
            {
                throw new ArgumentException();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vechicleType"></param>
        /// <param name="allowedCount"></param>
        public void AddVechilePermission(string vechicleType, int allowedCount)
        {
            vehiclePermission.Add(vechicleType, allowedCount);
        }
    }
}
