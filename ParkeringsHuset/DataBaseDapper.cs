using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ParkeringsHuset
{
    class DataBaseDapper
    {
        static string connString = "data source=.\\SQLEXPRESS; initial catalog = Parking; persist security info = True; Integrated Security = True;";

        public static List<Models.FreeSlots> GetFreeSlots(string CityName, string HouseName)
        {
            var sql = "SELECT STRING_AGG(ps.SlotNumber, ', ') AS Slots FROM Cities c " +
                      "JOIN ParkingHouses ph ON c.Id = ph.CityId " +
                      "JOIN ParkingSlots ps ON ph.id = ps.ParkingHouseId " +
                      "LEFT OUTER JOIN Cars ca ON ps.Id = ca.ParkingSlotsId " +
                      "WHERE c.CityName = '" + CityName + "'" + " AND ph.HouseName = '" + HouseName + "' " +
                      "AND ca.ParkingSlotsId is null";


            var Fslots = new List<Models.FreeSlots>();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                Fslots = connection.Query<Models.FreeSlots>(sql).ToList();
            }
            return Fslots;
        }
        public static List<Models.Car> GetAllCars()
        {
            var sql = "SELECT * FROM Cars";
            var cars = new List<Models.Car>();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                cars = connection.Query<Models.Car>(sql).ToList();
            }
            return cars;
        }

        public static List<Models.AllSpots> GetAllSpots()
        {
            var sql = @"
                        SELECT
                            count(*) AS PlatserPerHus,
                            ph.HouseName,
	                        STRING_AGG(ps.SlotNumber, ', ') AS Slots
                        FROM
                            ParkingHouses ph
                        JOIN
                            ParkingSlots ps ON ph.Id = ps.ParkingHouseId
                        GROUP BY
                            ph.HouseName";

            var spotsPerHouse = new List<Models.AllSpots>();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                spotsPerHouse = connection.Query<Models.AllSpots>(sql).ToList();

            }
            return spotsPerHouse;
        }

        public static int InsertCar(Models.Car car)
        {
            int affectedRows = 0;

            var sql = $"insert into Cars(Plate, Make, Color) values ('{car.Plate}', '{car.Make}', '{car.Color}')";

            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        
        public static List<Models.City> GetAllCitys()
        {
            var sql = "SELECT * FROM Cities";
            var cities = new List<Models.City>();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                cities = connection.Query<Models.City>(sql).ToList();
            }
            return cities;
        }

        public static int InsertCity(Models.City cities)
        {
            int affectedRows = 0;

            var sql = $"insert into Cities(CityName) values ('{cities.CityName}')";

            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        public static List<Models.Parkings> GetAllParkings()
        {
            var sql = "SELECT * FROM Parkings";
            var Parkings = new List<Models.Parkings>();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                Parkings = connection.Query<Models.Parkings>(sql).ToList();
            }
            return Parkings;
        }
        public static int InsertParkings(Models.Parkings parkings)
        {
            int affectedRows = 0;

            var sql = $"insert into Parkings(CityName,HouseName ,SlotNumber , ElectricOutlet,Plate ,CarData) " +
            $"values ('{parkings.CityName}', '{parkings.HouseName}', '{parkings.SlotNumber}'," +
            $" '{parkings.ElectricOutlet}', '{parkings.Plate}', '{parkings.CarData}')";



            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

            public static int ParkCar(int carId, int spotId)
        {
            int affectedRows = 0;
            var sql = $"update Cars set ParkingSlotsId = {spotId} where Id = {carId}";
            using (var connection = new SqlConnection(connString))
            {
                affectedRows = connection.Execute(sql);
            }
            return affectedRows;
        }


    }
}
