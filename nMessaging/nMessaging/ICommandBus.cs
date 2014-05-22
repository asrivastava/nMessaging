
using System;

namespace nMessaging
{
   public interface ICommandBus
    {
        void Register<T>(Action<T> handler) where T : ICommand;
        void Send<T>(T message) where T : ICommand;
    }
}
