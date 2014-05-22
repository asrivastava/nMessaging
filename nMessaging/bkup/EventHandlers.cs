using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nMessaging.Sample
{
    public class EventHandlers
    {
        public void FirstHandler(MyEvent @event)
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("MyEvent-FirstHandler");
        }
        public void SecondHandler(MyEvent @event)
        {
            Console.WriteLine("MyEvent-SecondHandler");
        }
    }
}
