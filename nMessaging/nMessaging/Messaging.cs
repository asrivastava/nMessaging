using System;
using System.Collections.Generic;

namespace nMessaging
{
    public class InMemoryBus : ICommandBus, IEventAggregator
    {
        private static Dictionary<Type, object> _handlers = new Dictionary<Type, object>();
        private static Dictionary<Type, List<object>> _subscribers = new Dictionary<Type, List<object>>();

        public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent
        {
            if (_subscribers.ContainsKey(typeof(TEvent)))
            {
                var handlers = _subscribers[typeof(TEvent)];
                handlers.Add(handler);
            }
            else
            {
                var handlers = new List<Object>();
                handlers.Add(handler);
                _subscribers[typeof(TEvent)] = handlers;
            }
        }

        public void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent: IEvent
        {
            if (_subscribers.ContainsKey(typeof(TEvent)))
            {
                var handlers = _subscribers[typeof(TEvent)];
                handlers.Remove(handler);

                if (handlers.Count == 0)
                {
                    _subscribers.Remove(typeof(TEvent));
                }
            }
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            if (_subscribers.ContainsKey(typeof(TEvent)))
            {
                var handlers = _subscribers[typeof(TEvent)];
                foreach (Action<TEvent> handler in handlers)
                {
                    //Async call
                    handler.BeginInvoke(@event, null, null);
                }
            }
        }

        public void Register<T>(Action<T> handler) where T : ICommand
        {
            _handlers[typeof(T)] = handler;
        }
        
        public void Send<T>(T message) where T : ICommand
        {
            var action = _handlers[typeof (T)] as Action<T>;
            
            //Pre-processing
            if(action!=null) action.Invoke(message);
            //post-processing
        }
    }
}
