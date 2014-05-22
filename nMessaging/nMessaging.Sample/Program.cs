using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nMessaging;
using nMessaging.Sample;

namespace nMessaging.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var messageBus = new InMemoryBus();
            messageBus.Register<FirstCommand>(new FirstService().HandleFirstCommand);
            messageBus.Register<SecondCommand>(new FirstService().HandleSecondCommand);

            messageBus.Subscribe<MyEvent>(new EventHandlers().FirstHandler);
            messageBus.Subscribe<MyEvent>(new EventHandlers().SecondHandler);
            
            Console.WriteLine("Enter any key to publish Event");
            messageBus.Publish(new MyEvent());
            
            //TODO: use lamda exp based fluent stype configuration
            //messageBus.Register<FirstMessage>(m=>FirstService.Handle);
            
            //TODO: Convention based auto registration
            messageBus.Register<ThirdCommand>(new ThirdCommandHandler().Handle);
            
            Console.WriteLine("Enter any key to send the first message");
            Console.ReadKey();
            messageBus.Send(new FirstCommand());
            
            Console.WriteLine("Enter any key to send the second message");
            Console.ReadKey();
            messageBus.Send(new SecondCommand());

            Console.WriteLine("Enter any key to send the third message");
            Console.ReadKey();
            messageBus.Send(new ThirdCommand());
            
            Console.ReadKey();
        }

        
    }

    
}
