using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Behavioral
{
    /* 

   1. Multiple Handlers for a Request: When multiple objects can handle a request, 
      but the specific handler isn’t known in advance, the request can be passed along a chain of handlers until one handles it.
   2. Decoupling Request Senders and Receivers: If you want to decouple the sender of a request from its receivers. 
      The sender doesn’t need to know which part of the chain will handle the request, promoting loose coupling in the system.
   3. Conditional Handling of Requests: In scenarios where the handling of a request depends on a set of conditions or criteria that only the handlers can evaluate. 
      Each handler in the chain can decide whether to process the request or pass it along.
   4. Dynamic Handling: If the handling logic needs to be changed or reconfigured dynamically at runtime,
      the Chain of Responsibility allows for adding or removing handlers from the chain.

    */

    // Handler Abstract Class
    // The Default Chaining Behavior can be implemented inside the abstract handler class.
    public abstract class Handler
    {
        //The NextHandler will hold the reference of the next handler
        public Handler NextHandler;
        //Initializing NextHandler reference using the class constructor
        public void SetNextHandler(Handler NextHandler)
        {
            this.NextHandler = NextHandler;
        }
        //The following Method needs to be implemented by the Child handler Classes
        //The following method is going to handle a request.
        public abstract void DispatchNote(long requestedAmount);
    }

    // Concrete Handlers
    public class TwoThousandHandler : Handler
    {
        public override void DispatchNote(long requestedAmount)
        {
            //First Check the Number of 2000 Notes To Be Dispatched
            long numberofNotesToBeDispatched = requestedAmount / 2000;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two Thousand notes are dispatched by TwoThousandHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two Thousand note is dispatched by TwoThousandHandler");
                }
            }
            //Then check the Pending amount
            long pendingAmountToBeProcessed = requestedAmount % 2000;
            //If the Pending amount is greater than 0, then call the next handler to handle the request
            if (pendingAmountToBeProcessed > 0)
            {
                //For TwoThousandHandler, the next handler is FiveHundredHandler 
                NextHandler.DispatchNote(pendingAmountToBeProcessed);
            }
        }
    }

    //Concrete Handler 2
    //The following class implement the Handler abstract class and 
    //Provide Implementation for DispatchNote abstract method
    public class FiveHundredHandler : Handler
    {
        public override void DispatchNote(long requestedAmount)
        {
            //First Check the Number of 500 Notes To Be Dispatched
            long numberofNotesToBeDispatched = requestedAmount / 500;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Five Hundred notes are dispatched by FiveHundredHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Five Hundred note is dispatched by FiveHundredHandler");
                }
            }
            //Then check the Pending amount
            long pendingAmountToBeProcessed = requestedAmount % 500;
            //If Pending amount is greater than 0, then call the next handler to handle the request
            if (pendingAmountToBeProcessed > 0)
            {
                //For FiveHundredHandler, the next handler is TwoHundredHandler  
                NextHandler.DispatchNote(pendingAmountToBeProcessed);
            }
        }
    }

    //Concrete Handler 3
    //The following class implement the Handler abstract class and 
    //Provide Implementation for DispatchNote abstract method
    public class TwoHundredHandler : Handler
    {
        public override void DispatchNote(long requestedAmount)
        {
            //First Check the Number of 200 Notes To Be Dispatched
            long numberofNotesToBeDispatched = requestedAmount / 200;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two Hundred notes are dispatched by TwoHundredHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two Hundred note is dispatched by TwoHundredHandler");
                }
            }
            //Then check the Pending amount
            long pendingAmountToBeProcessed = requestedAmount % 200;
            //If the Pending amount is greater than 0, then call the next handler to handle the request
            if (pendingAmountToBeProcessed > 0)
            {
                //For TwoHundredHandler, the next handler is HundredHandler 
                NextHandler.DispatchNote(pendingAmountToBeProcessed);
            }
        }
    }

    //Concrete Handler 4
    //The following class implement the Handler abstract class and 
    //Provide Implementation for DispatchNote abstract method
    public class HundredHandler : Handler
    {
        public override void DispatchNote(long requestedAmount)
        {
            //First Check the Number of 100 Notes To Be Dispatched
            long numberofNotesToBeDispatched = requestedAmount / 100;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Hundred notes are dispatched by HundredHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Hundred note is dispatched by HundredHandler");
                }
            }
            //No Need to Check the Next Handler
        }
    }

    // This class managed the sequence in which all the handlers are going to be chained together
    // This class initiates the request to a ConcreteHandler object on the chain
    public class ATM
    {
        private TwoThousandHandler twoThousandHandler = new TwoThousandHandler();
        private FiveHundredHandler fiveHundredHandler = new FiveHundredHandler();
        private TwoHundredHandler twoHundredHandler = new TwoHundredHandler();
        private HundredHandler hundredHandler = new HundredHandler();
        public ATM()
        {
            // Prepare the chain of Handlers
            // Here, we need to set the next handler of each handler
            twoThousandHandler.SetNextHandler(fiveHundredHandler);
            fiveHundredHandler.SetNextHandler(twoHundredHandler);
            twoHundredHandler.SetNextHandler(hundredHandler);
        }
        //The following method handle the request and passes it to the first handler in the chain of responsibility.
        public void Withdraw(long requestedAmount)
        {
            //First check whether the amount is Divisible by 100 or not
            if (requestedAmount % 100 == 0)
            {
                twoThousandHandler.DispatchNote(requestedAmount);
            }
            else
            {
                Console.WriteLine($"You Enter Invalid Amount: {requestedAmount}");
            }
        }
    }

    public class ChainOfResponsibility
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();
            Console.WriteLine("Requested Amount 4600");
            atm.Withdraw(4600);
            Console.WriteLine("\nRequested Amount 1900");
            atm.Withdraw(1900);
            Console.WriteLine("\nRequested Amount 600");
            atm.Withdraw(600);
            Console.WriteLine("\nRequested Amount 750");
            atm.Withdraw(750);
            Console.Read();
        }
    }
}
