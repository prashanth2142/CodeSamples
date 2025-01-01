using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Behavioral
{

/*
Mediator:  This will be an Interface that defines the operations that colleague objects can call for communication. 
In our example, it is the IFacebookGroupMediator Interface.
ConcreteMediator:  This class will implement the communication operations of the Mediator Interface. 
In our example, it is the ConcreteFacebookGroupMediator class.
Colleague: It is an abstract class, and Concrete Colleague classes will implement this abstract class. 
In our example, it is the User abstract class.
ConcreteColleage1 / ConcreteColleage2: These are classes that implement the Colleague interface. 
If a concrete colleague (let’s say ConcreteColleage1) wants to communicate with another concrete colleague (let’s say ConcreteColleage2), 
they will not communicate directly; instead, they will communicate via the ConcreteMediator. In our example, it is the ConcreteUser class.
*/

    //Mediator Interface
    //This is going to be an Interface that defines operations 
    //which can be called by colleague objects for communication.
    public interface IFacebookGroupMediator
    {
        //This Method is used to send the Message who are registered with the Facebook Group
        void SendMessage(string msg, User user);
        //This method is used to register a user with the Facebook Group
        void RegisterUser(User user);
    }

    // Concrete Mediator
    // This is going to be a class implementing the communication operations of the Mediator Interface.
    public class ConcreteFacebookGroupMediator : IFacebookGroupMediator
    {
        //The following variable is going to hold the list of objects to whom we want to communicate
        private List<User> UsersList = new List<User>();
        //The following method simply registers the user with Mediator
        public void RegisterUser(User user)
        {
            //Adding the user
            UsersList.Add(user);
            //Registering the user with Mediator
            user.Mediator = this;
        }
        //The following method is going to send the message in the group i.e. to the group users
        public void SendMessage(string message, User user)
        {
            foreach (User u in UsersList)
            {
                //Message should not be received by the user sending it
                if (u != user)
                {
                    u.Receive(message);
                }
            }
        }
    }

    // Colleague
    // This is going to be an abstract class that defines a property that holds a reference to a mediator.    
    public abstract class User
    {
        //This Property holds the name of the user
        protected string Name;
        //This Property is going to set and get the Mediator Instance
        //This Property value is going to be set when we register a user with the Mediator
        public IFacebookGroupMediator Mediator { get; set; }

        //Initializing the name using Constructor
        public User(string name)
        {
            this.Name = name;
        }
        //The following Methods are going to be Implemented by the Concrete Colleague
        public abstract void Send(string message);
        public abstract void Receive(string message);
    }

    //Concrete Colleague
    //These are the classes that communicate with each other via the mediator.
    public class ConcreteUser : User
    {
        //Parameterized Constructor is required to set the base class Name Property
        public ConcreteUser(string Name) : base(Name)
        {
        }
        //Overriding the Receive Method
        //This method is going to use by the Mediator to send the message to each member of the group
        public override void Receive(string message)
        {
            Console.WriteLine(this.Name + ": Received Message:" + message);
        }
        //This method is used to send the message to the Mediator by a user
        public override void Send(string message)
        {
            Console.WriteLine(this.Name + ": Sending Message=" + message + "\n");
            Mediator.SendMessage(message, this);
        }
    }

    public class Mediator
    {
        static void Main(string[] args)
        {
            //Create an Instance of Mediator i.e. Creating a Facebook Group
            IFacebookGroupMediator facebookMediator = new ConcreteFacebookGroupMediator();
            //Create instances of Colleague i.e. Creating users
            User Ram = new ConcreteUser("Ram");
            User Dave = new ConcreteUser("Dave");
            User Smith = new ConcreteUser("Smith");
            User Rajesh = new ConcreteUser("Rajesh");
            User Sam = new ConcreteUser("Sam");
            User Pam = new ConcreteUser("Pam");
            User Anurag = new ConcreteUser("Anurag");
            User John = new ConcreteUser("John");
            //Registering the users with the Mediator i.e. Facebook Group
            facebookMediator.RegisterUser(Ram);
            facebookMediator.RegisterUser(Dave);
            facebookMediator.RegisterUser(Smith);
            facebookMediator.RegisterUser(Rajesh);
            facebookMediator.RegisterUser(Sam);
            facebookMediator.RegisterUser(Pam);
            facebookMediator.RegisterUser(Anurag);
            facebookMediator.RegisterUser(John);
            //One of the users Sending one Message in the Facebook Group
            Dave.Send("dotnettutorials.net - this website is very good to learn Design Pattern");
            Console.WriteLine();
            //Another user Sending another Message in the Facebook Group
            Rajesh.Send("What is Design Patterns? Please explain ");
            Console.Read();
        }
    }
}
