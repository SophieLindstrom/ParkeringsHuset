using System;
using System.Diagnostics;

namespace ParkeringsHuset
{
    
    class Program
    {
        private static string CityMenu() // här har jag försökt få in en switch där man ska välja en stad
                                       // -> ett specifik parkeringshus -> och se vilka platser som är lediga.
                                       // Vet inte hur man gör detta.
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Stockholm");
            Console.WriteLine("2) Göteborg");
            Console.WriteLine("3) Malmö");
            Console.WriteLine("4) Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    return "Stockholm";
                case "2":
                    return "Göteborg";
                case "3":
                    return "Malmö";
                default:
                    return String.Empty;
            }
            
        }
        private static string HouseMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Elefanten");
            Console.WriteLine("2) Triangeln");
            Console.WriteLine("3) ParkAden");
            Console.WriteLine("4) AdaGaraget");
            
            switch (Console.ReadLine())
            {
                case "1":
                    return "Elefanten";
                case "2":
                   
                    return "Triangeln";
                case "3":
                    
                    return "ParkAden";
                case "4":
                    return "AdaGaraget";
                default:
                    return String.Empty;
            }
        }
        static void Main(string[] args)
        {
            string CityName = string.Empty;
            string HouseName = string.Empty;

            CityName = CityMenu();
            if (CityName != string.Empty)
            {
                HouseName = HouseMenu();
            }

            if (CityName == string.Empty || HouseName == string.Empty)
            {
                Console.WriteLine("Exit");
                System.Environment.Exit(1);
            }
            var Fslots = DataBaseDapper.GetFreeSlots(CityName, HouseName);

            Console.WriteLine($"Lediga parkeringsplatser i {HouseName} i {CityName}: ");
            
            foreach (var Fslot in Fslots)
            {
                Console.WriteLine($"{Fslot.Slots}");
            }

            //Console.WriteLine("Alla bilar: ");
          
            //var cars = DataBaseDapper.GetAllCars();

            //foreach (var car in cars)
            //{
            //    Console.WriteLine($"{car.Id}\t{car.Plate}\t{car.Make}\t{car.Color}\t{car.ParkingSlotsId}");
            //}
        
            //var allParkingspots = DataBaseDapper.GetAllSpots();

            //foreach (var house in allParkingspots)
            //{
            //    Console.WriteLine($"{house.HouseName}   \t{house.PlatserPerHus}\t{house.Slots}");
            //}

            //// Lägg till ny bil
            //Random rnd = new Random();
            //var rNumber = rnd.Next(100, 999);

            //var newCar = new Models.Car
            //{
            //    Plate = "XPW" + rNumber,
            //    Make = "Honda",
            //    Color = "Röd"
            //};
            //int rowsAffected = DataBaseDapper.InsertCar(newCar);
            //Console.WriteLine("Antal bilar tillagda: " + rowsAffected);
            //Console.WriteLine("----------------------------------------------");


            //Console.WriteLine("Alla städer: ");
            //var cities = DataBaseDapper.GetAllCitys();

            //foreach (var City in cities)
            //{
            //    Console.WriteLine($"{City.Id}\t{City.CityName}");
            //}
         

            //var newCity = new Models.City
            //{
            //    CityName = "Lund" 
            //};

            //int rowsAffected1 = DataBaseDapper.InsertCity(newCity);
            //Console.WriteLine("Antal städer tillagda: " + rowsAffected1);
            //Console.WriteLine("----------------------------------------------");

            //Console.WriteLine("Alla parkeringar: ");
            //var Parkings = DataBaseDapper.GetAllParkings();

            //foreach (var parkings in Parkings)

            //{
                
            //    Console.WriteLine($"{parkings.Id}\t{parkings.CityName}\n {parkings.HouseName}\n {parkings.SlotNumber}\n" +
            //    $" \n{parkings.ElectricOutlet} \n{parkings.Plate} \n{parkings.CarData}");

            //}

            //Console.WriteLine("------------------------------------------------------------------------");

            //// Lägg till nytt parkeringshus

            //var newParkings = new Models.Parkings

            //{
            //    CityName = "Västerårs",
            //    HouseName = "P-husDäcket",
            //    SlotNumber = 8,
            //    ElectricOutlet = true,
            //    Plate = "AAA111",
            //    CarData = "MiniCooper,Rosa"
            //};

            //int rowsAffected2 = DataBaseDapper.InsertParkings(newParkings);

            //Console.WriteLine("Antal parkering tillagd: " + rowsAffected);

            //Console.WriteLine("----------------------------------------------------------------");
            //Console.WriteLine("----------------------------------------------------------------");

            //// Parkera bil
            //rowsAffected = DataBaseDapper.ParkCar(6, 12);
            //Console.WriteLine("Antal bilar parkerade: " + rowsAffected);

        }

    }
}
