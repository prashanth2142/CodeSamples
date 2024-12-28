using System;
using System.Security.Policy;

namespace CodeSamples.Creational
{
    // 1. Product Interface
    public interface ITransport
    {
        void Deliver();
    }

    // 2. Concrete Products

    public class Truck : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Delivering by land in a truck.");
        }
    }

    public class Ship : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Delivering by sea in a ship.");
        }
    }

    // 3. Creator Class

    public abstract class Logistics
    {
        // Factory method
        public abstract ITransport CreateTransport();

        public void PlanDelivery()
        {
            // Call the factory method to create a transport object
            ITransport transport = CreateTransport();
            // Now use the transport
            transport.Deliver();
        }

        public virtual void Test()
        {
            Console.Write("test123");
        }
    }

    // 4. Concreate Creators

    public class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Truck();  // Create Truck transport
        }

        public override void Test()
        {
            Console.Write("Test");
        }
    }

    public class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Ship();  // Create Ship transport
        }
    }

    // 5. Client Code

    class FactoryMethodExampleProgram
    {
        static void Main(string[] args)
        {
            // Road logistics example
            Logistics roadLogistics = new RoadLogistics();
            roadLogistics.PlanDelivery();
            //roadLogistics.Test();

            // Sea logistics example
            Logistics seaLogistics = new SeaLogistics();
            seaLogistics.PlanDelivery();

            ITransport it1 = new Ship();
            ITransport it2 = new Truck();
            it1.Deliver();
            it2.Deliver();

            Console.ReadKey();
        }

    }

    //The Factory Method Design Pattern is a creational pattern that provides an interface for creating objects in a superclass,
    //but allows subclasses to alter the type of objects that will be created.It promotes loose coupling by eliminating the need for a client to explicitly specify which class of object to create.

    //ITransport is the product interface, which both Truck and Ship implement.
    //Logistics is the abstract creator class, and it defines the factory method CreateTransport().
    //RoadLogistics and SeaLogistics are concrete creators that implement the factory method to return Truck and Ship respectively.
    //The client (Main method) uses these concrete creators to plan deliveries, without needing to know the specifics of how the delivery is done.
}