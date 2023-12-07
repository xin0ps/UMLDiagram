namespace ProxyAndFlyWeight
{
    // Flyweight interface
    public interface Car
    {
        void build();
    }

    // Concrete Flyweight
    public class ConcreteCar : Car
    {
        private string model;

        public ConcreteCar(string model)
        {
            this.model = model;
        }

        public void build()
        {
            Console.WriteLine($"Building {model} car");
            // Additional building logic
        }
    }

    // Flyweight factory
    public class CarFactory
    {
        private Dictionary<string, Car> carList;

        public CarFactory()
        {
            carList = new Dictionary<string, Car>();
        }

        public Car getCar(string model)
        {
            if (!carList.ContainsKey(model))
            {
                Car newCar = new ConcreteCar(model);
                carList.Add(model, newCar);
                return newCar;
            }
            else
            {
                return carList[model];
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Client code
            CarFactory carFactory = new CarFactory();

            // Get or create Mercedes car
            Car mercedes = carFactory.getCar("Mercedes");
            Console.WriteLine(mercedes.GetHashCode());



            // Try getting Mercedes again (should return the same instance)
            Car mercedesAgain = carFactory.getCar("Mercedes");
            Console.WriteLine(mercedesAgain.GetHashCode());
            ;
        }
    }
}