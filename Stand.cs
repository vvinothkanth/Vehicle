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
    public class Stand
    {
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<int, Level> parkingLevels = new Dictionary<int, Level>();

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<int, Tocken> tockens = new Dictionary<int, Tocken>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CreateLevel()
        {
            Level level = new Level();
            parkingLevels.Add(parkingLevels.Count + 1, level);
            return parkingLevels.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenNo"></param>
        /// <param name="parkedId"></param>
        /// <returns></returns>
        public int AddTocken(Tocken tocken)
        {
            tockens.Add(tockens.Count + 1, tocken);
            return tockens.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="levelId"></param>
        /// <param name="vechicleType"></param>
        /// <returns></returns>
        public bool IsPossibleToParking(int levelId, string vechicleType)
        {
            bool isAvailable = false;
            try
            {
                if (parkingLevels.ContainsKey(levelId))
                {
                    if (parkingLevels[levelId].vehiclePermission.ContainsKey(vechicleType))
                    {
                        isAvailable = parkingLevels[levelId].IsValidVehicle(vechicleType) && parkingLevels[levelId].IsParkingSpaceAvailable(vechicleType) ? true : false;
                    }
                    else
                    {
                        throw new ArgumentException("Vechicle Type Is Not Found");
                    }
                }
                else
                {
                    throw new ArgumentException("Key Not Found Error");
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
        public int Parking(Vehicle vehicle)
        {
            int tockenNo = 0;
            try
            {

                foreach (var level in parkingLevels)
                {
                    if (IsPossibleToParking(level.Key, vehicle.Type))
                    {
                        Tocken tocken = new Tocken();
                        tocken.levelId = level.Key;
                        tocken.ParkedId = level.Value.ParkTheVehicle(vehicle);
                        tockens.Add(tockens.Count + 1, tocken);
                        tockenNo = tockens.Count;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }


            return tockenNo;
            
        }

        public int UnParking(int tockenNo)
        {
            parkingLevels[tockens[tockenNo].levelId].UnParkTheVehicle(tockens[tockenNo].ParkedId);
            return tockenNo;
        }
    }
}
