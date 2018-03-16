using System.Threading.Tasks;
using Starveler.Common.Events.Interfaces;

namespace Starveler.Service.Handlers.Interfaces
{
    public interface IEventHandler<T> where T : IEvent
    {
         Task Handle(T @event);
    }
}