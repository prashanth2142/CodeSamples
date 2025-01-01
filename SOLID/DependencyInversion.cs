using System;

namespace CodeSamples.SOLID
{
/*
High-level modules should not depend on low-level modules. Both should depend on abstractions.
Abstractions should not depend on details. Details should depend on abstractions.

This principle helps in creating loosely coupled systems by relying on abstractions rather than concrete implementations. 
This is often achieved in C# using interfaces or abstract classes. 


Abstractions Decouple High-Level and Low-Level Modules:
The Notification class does not depend on any specific message service implementation. It only depends on the IMessageService interface.

Flexibility:
You can easily switch between EmailService, SmsService, or any other implementation of IMessageService without changing the Notification class.

Testability:
You can inject a mock or stub of IMessageService for unit testing, improving testability.
*/
    public class DependencyInversion
    {
        static void Main()
        {
            // Inject EmailService
            IMessageService emailService = new EmailService();
            Notification emailNotification = new Notification(emailService);
            emailNotification.Notify("Hello via Email!");

            // Inject SmsService
            IMessageService smsService = new SmsService();
            Notification smsNotification = new Notification(smsService);
            smsNotification.Notify("Hello via SMS!");
        }
    }

    // Abstraction
    public interface IMessageService
    {
        void SendMessage(string message);
    }

    // Low-level module
    public class EmailService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    // Another low-level module
    public class SmsService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }

    // High-level module
    public class Notification
    {
        private readonly IMessageService _messageService;

        // Dependency injection via constructor
        public Notification(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Notify(string message)
        {
            _messageService.SendMessage(message);
        }
    }

}
