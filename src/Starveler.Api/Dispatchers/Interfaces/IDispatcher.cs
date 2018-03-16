using Starveler.Common.Events.Interfaces;

namespace Starveler.Api.Dispatchers.Interfaces
{
    public interface IDispatcher<T> where T : IEvent
    {
         void Dispatch(T @event);
    }
}