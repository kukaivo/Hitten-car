using System;
using System.Collections.Generic;

namespace CarProject2
{
    class Car : Vehicle
    {

        static List<Car> allCars = new List<Car>();
        public static int totalCars = 0;


        public Car(string make, string model, double price) : base(make, model, price)
        {

            this.type = "car";
            allCars.Add(this);
            totalCars++;
        }

        public static void AddCar()
        {
            Console.WriteLine("Please enter a car MAKE (Honda,Toyota,Audi etc.)");
            string mk = Console.ReadLine();
            Console.WriteLine("Please enter a car MODEL (Prius, Passat, Corsa etc.)");
            string md = Console.ReadLine();
            Console.WriteLine("Please enter a PRICE");
            try
            {
                double pr = Convert.ToDouble(Console.ReadLine());
                Car carobj = new Car( mk, md, pr);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please re-enter the car details correctly");
                AddCar();
            }
        }

        public static void RemoveCar()
        {
            bool found = false;
            Console.WriteLine("Please enter CAR id");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var car in allCars)
            {

                if (car.id == id)
                {
                    allCars.Remove(car);
                    totalCars--;
                    totalVehicles--;
                    Console.WriteLine($"{car.model},{car.make}, has been removed");
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                Console.WriteLine($"Car with id {id} not found");
            }


        }
        public static void PrintAllCars()
        {
            foreach (Car car in Car.allCars)
            {
                car.PrintVehicle();
            }
        }

        public static void SoldCars()
        {
            List<Car> soldCars = new List<Car>();

            foreach (var car in allCars)
            {
                if (car.sold == true)
                {
                    soldCars.Add(car);
                }
            }

            if (soldCars.Count == 0)
            {
                Console.WriteLine("No cars have been sold");
            }
            else
            {
                Console.WriteLine("The following cars have been sold:");
                foreach (Car car in soldCars)
                {
                    car.PrintVehicle();
                }
                Console.WriteLine("-----------END OF LIST------------");
            }
        }
        public static void FindCar(int id)
        {
            bool found = false;


            foreach (var car in allCars)
            {
                if (car.id == id)
                {
                    found = true;
                    car.PrintVehicle();
                }
            }

            if (found != true)
            {
                Console.WriteLine("Car not found.");
            }

        }
    }
}
