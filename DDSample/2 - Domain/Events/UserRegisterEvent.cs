using System;
using DDDSample.Domain.Core.Events;

namespace DDDSample.Domain.Events
{
    public class UserRegisterEvent : Event
    {
        public int Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }

        public UserRegisterEvent(int id, string name,DateTime birthDate)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
        }

      
    }
}
