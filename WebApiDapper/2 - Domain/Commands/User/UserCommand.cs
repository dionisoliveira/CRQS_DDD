namespace DDDSample.Domain.Commands
{
    public abstract class UserRegister : DDDSample.Domain.Core.Commands.Command
    {

        public int Id { get; protected set; }

        public string Name { get; protected set; }





       
    }
}
