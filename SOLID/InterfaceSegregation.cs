using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.SOLID
{
/*
a class should not be forced to implement interfaces it does not use. Instead, 
interfaces should be small and specific, catering to the needs of the client classes.

This principle ensures that a class is not burdened with methods it does not need, 
keeping the design clean and focused.
*/
    public class InterfaceSegregation
    {
        static void Main(string[] args)
        {
            // Create instances of workers
            var humanWorker = new HumanWorker();
            var robotWorker = new RobotWorker();

            // Manager instance
            var manager = new WorkerManager();

            // Managing work
            manager.ManageWork(humanWorker); // Output: Managing work... Human is working.
            manager.ManageWork(robotWorker); // Output: Managing work... Robot is working.

            // Managing lunch
            manager.ManageLunch(humanWorker); // Output: Managing lunch... Human is eating.

            // Uncommenting the following line will cause a compile-time error:
            // manager.ManageLunch(robotWorker); // RobotWorker does not implement IEatable
        }
    }

    public interface IWorkable
    {
        void Work();
    }

    public interface IEatable
    {
        void Eat();
    }

    public class HumanWorker : IWorkable, IEatable
    {
        public void Work()
        {
            Console.WriteLine("Human is working.");
        }

        public void Eat()
        {
            Console.WriteLine("Human is eating.");
        }
    }

    public class RobotWorker : IWorkable
    {
        public void Work()
        {
            Console.WriteLine("Robot is working.");
        }
    }

    public class WorkerManager
    {
        public void ManageWork(IWorkable worker)
        {
            worker.Work();
        }

        public void ManageLunch(IEatable eater)
        {
            eater.Eat();
        }
    }

}
