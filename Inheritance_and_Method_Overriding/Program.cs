using System;

namespace Lab10.Inheritance
{
    class Vehicle
    {
        protected int speed;
        protected int fuel;

        public Vehicle(int speed, int fuel)
        {
            this.speed = speed;
            this.fuel = fuel;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Vehicle Info -> Speed: {speed}, Fuel: {fuel}");
        }

        public virtual void Drive()
        {
            fuel -= 5;
            Console.WriteLine("Vehicle is moving...");
        }
    }

    class Car : Vehicle
    {
        private int passengers;

        public Car(int speed, int fuel, int passengers) : base(speed, fuel)
        {
            this.passengers = passengers;
        }

        public override void Drive()
        {
            fuel -= 10;
            Console.WriteLine("Car is moving with passenger");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Car Info -> Speed: {speed}, Fuel: {fuel}, Passengers: {passengers}");
        }
    }

    class Truck : Vehicle
    {
        private int cargoWeight;

        public Truck(int speed, int fuel, int cargoWeight) : base(speed, fuel)
        {
            this.cargoWeight = cargoWeight;
        }

        public override void Drive()
        {
            fuel -= 15;
            Console.WriteLine("Truck is moving with cargo");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Truck Info -> Speed: {speed}, Fuel: {fuel}, CargoWeight: {cargoWeight}");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Start of program\n");
            Vehicle[] fleet = new Vehicle[]
            {
                new Vehicle(40, 100),
                new Car(60, 80, 4),
                new Truck(50, 120, 2000)
            };

            foreach (var v in fleet)
            {
                v.Drive();
                v.ShowInfo();
                Console.WriteLine();
            }

            Console.WriteLine("End of program");
        }
    }
}
