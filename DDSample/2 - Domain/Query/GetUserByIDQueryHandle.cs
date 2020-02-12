using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DDDSample.Domain.Interface;
using DDDSample.Domain;

namespace DDDSample._2__Domain.Query
{
    public class GetUserByIDQueryHandle : IRequestHandler<UserFindIDQuery, User>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIDQueryHandle(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Domain.User> Handle(UserFindIDQuery query, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userRepository.FindUser(query.Id));
        }
    }
}