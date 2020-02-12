using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDSample._2__Domain.Query
{
    public class UserRequest<T> : IRequest<T>
    {
    }
}
