using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nMessaging.Sample
{

    public class FirstService
    {
        public void HandleFirstCommand(FirstCommand message)
        {
            Console.WriteLine("First Command Handled..");
        }

        public void HandleSecondCommand(SecondCommand message)
        {
            Console.WriteLine("Second Command Handled..");
        }
    }

    public class ThirdCommandHandler//:IHandleCommand<ThirdCommandHandler>
    {
        public void Handle(ThirdCommand messge)
        {
            Console.WriteLine("Third Command Handled..");
        }
    }
    
}
