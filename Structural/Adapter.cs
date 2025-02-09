using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Structural
{
    /*
    The Adapter Design Pattern is a structural design pattern that allows objects with incompatible interfaces 
    to work together by providing a "middle layer" or an adapter. This pattern translates one interface into another that a client expects.

    Target: Defines the domain-specific interface used by the client.
    Adaptee: An existing class that needs adapting.
    Adapter: A class that implements the Target interface and adapts the Adaptee to the Target.
    Client: Interacts with the Target interface.
    */

    // Target Interface
    public interface IPaymentProcessor
    {
        void ProcessPayment(string paymentDetails);
    }

    // Adaptee (Existing Class)
    public class ThirdPartyPaymentService
    {
        public void MakePayment(string details)
        {
            Console.WriteLine($"Payment processed using ThirdPartyPaymentService: {details}");
        }
    }

    // Adapter
    public class PaymentAdapter : IPaymentProcessor
    {
        private readonly ThirdPartyPaymentService _thirdPartyService;

        public PaymentAdapter(ThirdPartyPaymentService thirdPartyService)
        {
            _thirdPartyService = thirdPartyService;
        }

        public void ProcessPayment(string paymentDetails)
        {
            // Adapt the method call to the third-party service
            _thirdPartyService.MakePayment(paymentDetails);
        }
    }



    public class Adapter
    {
        static void Main(string[] args)
        {
            // Third-party service
            ThirdPartyPaymentService thirdPartyService = new ThirdPartyPaymentService();

            // Adapter that adapts the third-party service to IPaymentProcessor
            IPaymentProcessor paymentProcessor = new PaymentAdapter(thirdPartyService);

            // Client code using the unified interface
            paymentProcessor.ProcessPayment("Order12345");

            Console.ReadKey();
        }
    }
}
