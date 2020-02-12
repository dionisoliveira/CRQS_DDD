using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DDDSample.Domain.Events;

namespace DDDSample._2__Domain.EventHandler
{
    public class UserEventHandler : INotificationHandler<UserRegisterEvent>

    {


        public Task Handle(UserRegisterEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }


    }
}