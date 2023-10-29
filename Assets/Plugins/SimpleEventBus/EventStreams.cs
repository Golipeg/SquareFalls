using SimpleEventBus.Interfaces;

namespace SimpleEventBus
{
    public static class EventStreams
    {
        public static IEventBus EventBus { get; } = new EventBus();
        
        
    }
}