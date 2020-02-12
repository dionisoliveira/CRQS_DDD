using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDSample.Domain.Core.Events
{


    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }

}
