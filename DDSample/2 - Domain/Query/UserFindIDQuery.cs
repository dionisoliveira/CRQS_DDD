using DDDSample.Domain;

namespace DDDSample._2__Domain.Query
{
    public class UserFindIDQuery : UserRequest<User>
    {
        public int Id { get; set; }

        public UserFindIDQuery(int id)
        {
            Id = id;
        }
       
    }
}
