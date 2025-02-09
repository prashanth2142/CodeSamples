using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Creational
{
    // The AbstractProductA interface
    // Each distinct product of the Course product family should have a base interface.
    // All variants of Course products must implement this ICourse interface.
    public interface ICourse
    {
        string GetCourseName();
        int GetCourseFee();
        string GetCourseDuration();
    }

    // The AbstractProductB interface
    // Each distinct product of the Source product family should have a base interface.
    // All variants of Source products must implement this ISource interface.
    public interface ISource
    {
        string GetSourceName();
    }

    // The ProductA1 class
    // Concrete Products are going to be created by corresponding Concrete Factories.
    // The following FrontEndCourse Product Belongs to the Course product family
    public class FrontEndCourse : ICourse
    {
        public string GetCourseName()
        {
            return "HTML, CSS, and Bootstrap";
        }
        public string GetCourseDuration()
        {
            return "6 Months";
        }
        public int GetCourseFee()
        {
            return 2000;
        }
    }

    // The ProductB1 class
    // Concrete Products are going to be created by corresponding Concrete Factories.
    // The following BackEndCourse Product Belongs to the Course product family
    public class BackEndCourse : ICourse
    {
        public string GetCourseDuration()
        {
            return "6 Months";
        }
        public int GetCourseFee()
        {
            return 1000;
        }
        public string GetCourseName()
        {
            return "C#, Java, and Python";
        }
    }

    // The ProductA2 class
    // Concrete Products are going to be created by corresponding Concrete Factories.
    // The following Online Product Belongs to the Source product family
    public class Online : ISource
    {
        public string GetSourceName()
        {
            return "Dot Net Tutorials Zoom Classes";
        }
    }

    // The ProductB2 class
    // Concrete Products are going to be created by corresponding Concrete Factories.
    // The following Offline Product Belongs to the Source product family
    public class Offline : ISource
    {
        public string GetSourceName()
        {
            return "Dot Net Tutorials Class Room Training";
        }
    }

    // The AbstractFactory interface
    // The Abstract Factory interface declares a set of methods that return different abstract products. 
    // These products are called a family. 
    // A family of products may have several variants
    public interface ISourceCourseFactory
    {
        //Abstract Product A
        ISource GetSource();
        //Abstract Product B
        ICourse GetCourse();
    }

    public class OnlineSourceCourseFactory : ISourceCourseFactory
    {
        public ISource GetSource()
        {
            return new Online();
        }
        public ICourse GetCourse()
        {
            return new BackEndCourse();
        }
    }

    public class OfflineSourceCourseFactory : ISourceCourseFactory
    {
        public ISource GetSource()
        {
            return new Offline();
        }
        public ICourse GetCourse()
        {
            return new FrontEndCourse();
        }
    }

    public class AbstractFactory
    {
        static void Main(string[] args)
        {
            // Fetch the Front End Course and Source Details
            // Creating OfflineSourceCourseFactory instance
            ISourceCourseFactory offlineSourceCourseFactory = new OfflineSourceCourseFactory();
            //offlineSourceCourseFactory.GetCourse() will create and return FrondEndCourse object
            var course = offlineSourceCourseFactory.GetCourse();
            Console.WriteLine("Front End Course and Source Details");
            Console.WriteLine(course.GetCourseName());
            Console.WriteLine(course.GetCourseFee());
            Console.WriteLine(course.GetCourseDuration());
            //offlineSourceCourseFactory.GetSource() will create and return Offline object
            var source = offlineSourceCourseFactory.GetSource();
            Console.WriteLine(source.GetSourceName());
            //Same steps for Online Course and Source Details
            Console.WriteLine("\n----------------------\n");
            Console.WriteLine("Back End Course and Source Details");
            ISourceCourseFactory onlineSourceCourseFactory = new OnlineSourceCourseFactory();
            course = onlineSourceCourseFactory.GetCourse();
            Console.WriteLine(course.GetCourseName());
            Console.WriteLine(course.GetCourseFee());
            Console.WriteLine(course.GetCourseDuration());
            source = onlineSourceCourseFactory.GetSource();
            Console.WriteLine(source.GetSourceName());
            Console.ReadKey();
        }
    }
}
