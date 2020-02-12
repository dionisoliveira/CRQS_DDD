using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DDDSample.Domain.Core.Bus;
using DDDSample.Domain.Core.Events;

namespace DDDSample.CrossCutting.Bus
{
    public sealed class MyMediatorBase : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public MyMediatorBase(IEventStore eventStore, IMediator mediator)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : DDDSample.Domain.Core.Commands.Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            return _mediator.Publish(@event);
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            return _mediator.Send(request, cancellationToken);
        }

        public Task<object> Send(object request, CancellationToken cancellationToken = default)
        {
            return _mediator.Send(request, cancellationToken);
        }

        public Task Publish(object notification, CancellationToken cancellationToken = default)
        {
            return _mediator.Publish(notification, cancellationToken);
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            return _mediator.Publish<TNotification>(notification, cancellationToken);
        }
    }
}
