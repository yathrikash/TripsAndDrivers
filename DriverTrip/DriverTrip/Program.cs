using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverTrip
{
    public class Program
    {
        public static Dictionary<string, Trip> trips = new Dictionary<string, Trip>();
        public static List<Driver> drivers = new List<Driver>();
        static void Main(string[] args)
        {
            bool processResults = false;
            string input = "";
            trips = new Dictionary<string, Trip>();
            drivers = new List<Driver>();
            Console.WriteLine("Available commands and formats.");
            Console.WriteLine("Driver <driverName>   ===> this will register driver to the system. ex:- Driver dan ");
            Console.WriteLine("Trip <already registered drivername> <startTime> <endTime> <totalKms>  =======>Adds trip to the driver. ex:- Trip dan 7.15 7.45 18.03"); 
            Console.WriteLine("Done      =====> this will stop getting commands and show the output report. ex:- done");
            Console.WriteLine("Start entering your commands:");
            do
            {
               
                
                input = Console.ReadLine();
                var contents = input.Replace("  "," ").Split(' ');
                switch (contents.Length)
                {
                    case 1:
                        if (input.Trim().Equals("done", StringComparison.InvariantCultureIgnoreCase))
                            processResults = true;
                        else
                            Console.WriteLine("Invalid command,  please try again with valid command.");
                        break;
                    case 2:
                        {
                            if (contents[0].Equals("Driver", StringComparison.InvariantCultureIgnoreCase))
                            {
                                var driver = new Driver { Name = contents[1] };
                                if (!drivers.Contains(driver))
                                {
                                    drivers.Add(driver);
                                    trips.Add(driver.Name, new Trip { Driver = new Driver { Name = driver.Name } });
                                }
                                else
                                {
                                    Console.WriteLine("Driver already added.");
                                }
                            }   
                            else
                            {
                                Console.WriteLine("Invalid command. Please try again.");
                            }
                        }
                        break;
                    case 5:
                        {
                            if (contents[0].Equals("Trip", StringComparison.InvariantCultureIgnoreCase))
                            {
                                var driver = new Driver { Name = contents[1] };
                                if (!double.TryParse(contents[2], out double startTime))
                                    Console.WriteLine("Trip start time is not in the correct format.");

                                if (!double.TryParse(contents[3], out double endTime))
                                    Console.WriteLine("Trip start time is not in the correct format.");

                                if (!double.TryParse(contents[4], out double totalKms))
                                    Console.WriteLine("Trip start time is not in the correct format.");

                                if (drivers.Contains(driver))
                                {
                                    var speed = GetKmph(totalKms, endTime - startTime);
                                    if (speed >= 5 && speed  <= 100) //In the question, constraint given 
                                                                                   //speed less than 5 mph 
                                                                                   //speed greater than 100 mph
                                                                                   //but it is very less for providing inputs, so 
                                                                                   //i am considering it as speed < 5kmph and speed > 100 kmph
                                    {
                                        
                                            var trip = trips.Where(x => x.Value.Driver.Name.Equals(driver.Name,StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().Value;
                                            trip.TotalHours += GetTotalHours( startTime,endTime);
                                            trip.TotalKms += totalKms;
                                            trip.AverageSpeed = GetKmph(trip.TotalKms, trip.TotalHours);
                                            trips[driver.Name] = trip;
                                    }
                                }

                            }
                            else
                                Console.WriteLine("Invalid command. Please try again.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }

            } while (!processResults);

            foreach (var trip in trips.OrderByDescending(x => x.Value.TotalKms))
            {
                Console.WriteLine(trip.Value);
            }
            
            
            Console.ReadLine();
        }


        static double GetTotalHours(double startTime, double endTime)
        {

            return endTime - startTime;
        }

        static double GetKmph(double kms, double totalTimeInHrs)
        {
            return Math.Ceiling(kms / totalTimeInHrs);
        }
    }
    public struct Driver
    {
        public string Name;

        public override bool Equals(object obj)
        {
            return ((Driver)obj).Name == Name;
        }

    }

    public struct Trip
    {
        public Driver Driver;

        public double TotalHours;

        public double TotalKms;

        public double AverageSpeed;

        public override string ToString()
        {
            return $"{Driver.Name} : {Math.Ceiling(TotalKms)} miles" +( AverageSpeed <= 0 ? "" : $" @  {AverageSpeed} kmph");
        }
        public override bool Equals(object obj)
        {
            return ((Trip)obj).Driver.Name == Driver.Name;
        }
    }
}
