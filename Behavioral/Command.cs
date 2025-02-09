using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodeSamples.Behavioral
{
    /*

    The Command design pattern encapsulates a request as an object, allowing users to parameterize clients with different requests, 
    queue requests, log the requests, and support undoable operations. 
    It involves separating objects that issue commands from objects that perform the command.

    Command: This is an interface for executing an operation.
    ConcreteCommand: This class extends the Command interface, implementing the Execute method by invoking the corresponding operation(s) on the Receiver object.
    Receiver: This class knows how to perform the operations associated with carrying out a request. Any class may serve as a Receiver.
    Invoker: This class asks the command to carry out the request.
    Client: The client creates a ConcreteCommand object and sets its receiver.

    */

    // Command Interface
    // It declares a method for executing a command
    public interface ICommand
    {
        void Execute();
    }

    // ConcreteCommand A 
    // It defines a binding between a Receiver Object i.e. Document and an Action i.e. Open
    public class OpenCommand : ICommand
    {
        //Reference of Receiver Object
        private Document document;
        //Initializing the Receiver Object using the Constructor
        public OpenCommand(Document doc)
        {
            document = doc;
        }
        //Execute Method will internally call the Receiver Object Open Method
        public void Execute()
        {
            document.Open();
        }
    }

    //ConcreteCommand B 
    //It defines a binding between a Receiver Object i.e. Document and an Action i.e. Save
    class SaveCommand : ICommand
    {
        //Reference of Receiver Object
        private Document document;
        //Initializing the Receiver Object using the Constructor
        public SaveCommand(Document doc)
        {
            document = doc;
        }
        //Execute Method will internally call the Receiver Object Save Method
        public void Execute()
        {
            document.Save();
        }
    }

    //ConcreteCommand C 
    //It defines a binding between a Receiver Object i.e. Document and an Action i.e. Close
    class CloseCommand : ICommand
    {
        //Reference of Receiver Object
        private Document document;
        //Initializing the Receiver Object using the Constructor
        public CloseCommand(Document doc)
        {
            document = doc;
        }
        //Execute Method will internally call the Receiver Object Close Method
        public void Execute()
        {
            document.Close();
        }
    }

    // Invoker  
    // The Invoker is associated with one or several commands. 
    // It sends a request to the command.
    public class MenuOptions
    {
        private ICommand openCommand;
        private ICommand saveCommand;
        private ICommand closeCommand;
        public MenuOptions(ICommand open, ICommand save, ICommand close)
        {
            this.openCommand = open;
            this.saveCommand = save;
            this.closeCommand = close;
        }
        //The Invoker cannot handle the Request, so it internally calls the Execute Method
        //of the Command Object. 
        public void ClickOpen()
        {
            openCommand.Execute();
        }
        //The Invoker cannot handle the Request, so it internally calls the Execute Method
        //of the Command Object. 
        public void ClickSave()
        {
            saveCommand.Execute();
        }
        //The Invoker cannot handle the Request, so it internally calls the Execute Method
        //of the Command Object. 
        public void ClickClose()
        {
            closeCommand.Execute();
        }
    }

    // Receiver Object 
    // The Receiver contains the business logic. 
    // They know how to perform all kinds of operations
    // They Know how to handle the Request i.e. Performing the actual Operation
    public class Document
    {
        public void Open()
        {
            Console.WriteLine("Document Opened");
        }
        public void Save()
        {
            Console.WriteLine("Document Saved");
        }
        public void Close()
        {
            Console.WriteLine("Document Closed");
        }
    }

    public class Command
    {
        static void Main(string[] args)
        {
            //Create an Instance of Receiver
            Document document = new Document();
            //Create the Command Object by passing the Receiver Instance
            ICommand openCommand = new OpenCommand(document);
            ICommand saveCommand = new SaveCommand(document);
            ICommand closeCommand = new CloseCommand(document);
            //Create the Invoker instance by passing the command objects
            MenuOptions menu = new MenuOptions(openCommand, saveCommand, closeCommand);
            //Giving command to the Invoker to do the operation
            menu.ClickOpen();
            menu.ClickSave();
            menu.ClickClose();
            Console.ReadKey();
        }
    }
}
