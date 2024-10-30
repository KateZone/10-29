using System;
using System.Collections.Generic;

namespace Virtual_Race_Championship
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car> { new Car("Green", 5), new Car("Blue", 6), new Car("Red", 7) };
            int trackLength = 25;

            Console.WriteLine("Start the race (press <Enter> to proceed)");
            Console.ReadLine();

            Random random = new Random();
            while (true)
            {
                Console.Clear();
                DisplayTrack(cars);
                          
                foreach (var car in cars)
                {
                    int eventValue = random.Next(1, 4); // 1 = Rain, 2 = Boost Zone, 3 = Normal
                    switch (eventValue)
                    {
                        case 1:
                            if (car.Color == "Red")
                            {
                                car.Speed -= 1;
                            }
                            break;
                        case 2:
                            if (car.Color == "Green")
                            {
                                car.Speed += 2;
                            }
                            break;
                        default:
                            break;
                    }

                    car.Position += car.Speed;

                    if (car.Position >= trackLength)
                    {
                        Console.Clear();
                        DisplayTrack(cars);
                        Console.WriteLine($"{car.Color} Car Wins!");
                        Console.ReadKey(); 
                        return;
                    }
                }

                Console.ReadLine();
            }
        }

        static void DisplayTrack(List<Car> cars)
        {
            Console.WriteLine("Race Track:--------------------------");
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Color} Car: " + new string(' ', car.Position) + "X");
            }
        }
    }

    public class Car
    {
        public string Color { get; set; }
        public int Speed { get; set; }
        public int Position { get; set; }

        public Car(string color, int speed)
        {
            Color = color;
            Speed = speed;
            Position = 0;
        }
    }
}
