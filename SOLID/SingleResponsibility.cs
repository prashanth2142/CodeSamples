using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.SOLID
{
/* 
A class should have only one reason to change.
This means a class should have only one responsibility or purpose. 
By adhering to this principle, you can make your code more maintainable, modular, and easier to test.
*/
    public class SingleResponsibility
    {
        public class InvoiceGenerator
        {
            public void GenerateInvoice()
            {
                // Logic to generate an invoice
                Console.WriteLine("Invoice generated.");
            }
        }

        public class InvoiceRepository
        {
            public void SaveToDatabase()
            {
                // Logic to save the invoice to the database
                Console.WriteLine("Invoice saved to database.");
            }
        }

        public class EmailService
        {
            public void SendEmail()
            {
                // Logic to send the invoice via email
                Console.WriteLine("Invoice email sent.");
            }
        }

        static void Main(string[] args)
        {
            var invoiceGenerator = new InvoiceGenerator();
            var invoiceRepository = new InvoiceRepository();
            var emailService = new EmailService();

            invoiceGenerator.GenerateInvoice();
            invoiceRepository.SaveToDatabase();
            emailService.SendEmail();
        }

    }
}
