using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample.Domain.Core.Events;

namespace DDDSample.Domain.Events
{
    public class UserDeleteEvent : Event
    {
        public UserDeleteEvent(int id)
        {
            Id = id;
            AggregateId = Guid.NewGuid();
        }

        public int Id { get; set; }
    }

}
