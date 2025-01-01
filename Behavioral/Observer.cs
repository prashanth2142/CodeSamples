using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Behavioral
{
/*
The Observer pattern is useful because it allows for a flexible relationship between the temperature sensor and display units.
It is beneficial because the sensor interacts with the observer interface, which makes it easy to add or remove display units.
It ensures that all registered display units are updated consistently whenever the temperature changes.
It is a good approach for creating systems where multiple components need to respond to changes in a central data source without being tightly coupled to it.
*/

    // Observer Interface
    public interface IObserver
    {
        void Update(float temperature);
    }

    // Subject Class
    public class TemperatureSensor
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        private float _temperature;

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_temperature);
            }
        }

        public void SetTemperature(float temperature)
        {
            _temperature = temperature;
            NotifyObservers();
        }
    }

    // Concrete Observer Class
    public class DisplayUnit : IObserver
    {
        private readonly string _displayName;

        public DisplayUnit(string name)
        {
            _displayName = name;
        }

        public void Update(float temperature)
        {
            Console.WriteLine($"{_displayName} displays temperature: {temperature}°C");
        }
    }

    public class Observer
    {
        public static void Main(string[] args)
        {
            var sensor = new TemperatureSensor();

            var unitA = new DisplayUnit("Unit A");
            var unitB = new DisplayUnit("Unit B");

            sensor.Attach(unitA);
            sensor.Attach(unitB);

            // Update temperature and notify observers
            sensor.SetTemperature(22.5f);
            sensor.SetTemperature(25.0f);

            Console.ReadKey();
        }
    }
}
