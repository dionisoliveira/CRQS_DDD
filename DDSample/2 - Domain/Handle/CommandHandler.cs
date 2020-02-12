using MediatR;
using DDDSample.Domain.Core.Bus;
using DDDSample.Domain.Core.Commands;
using DDDSample.Domain.Core.Notification;

namespace DDDSample._2__Domain.Handle
{
    public class CommandHandler
    {

        private readonly IMediatorHandler _mediator;
        private readonly DomainNotificationHandler _notifications;

        public IMediatorHandler MediatorHandler
        {
            get
            {
                return _mediator;
            }
        }

        public CommandHandler(IMediatorHandler mediator, INotificationHandler<DomainNotification> notifications)
        {
           
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _mediator.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;
           

            return true ;
        }
    }
}