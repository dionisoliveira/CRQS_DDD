using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample._2__Domain.Query;
using DDDSample.Domain.Core.Commands;
using DDDSample.Domain.Core.Events;

namespace DDDSample.Domain.Core.Bus
{
    public interface IMediatorHandler : IMediator
    {
        Task SendCommand<T>(T command) where T : DDDSample.Domain.Core.Commands.Command;
        Task RaiseEvent<T>(T @event) where T : Event;

        
    }
}
