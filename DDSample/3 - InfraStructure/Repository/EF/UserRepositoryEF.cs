using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample._2__Domain.Interface.Repository;
using DDDSample.Domain;


namespace DDDSample._3___InfraStructure.Repository.EF
{
    public class UserRepositoryEF : Repository<User>, IUserRepositoryEF
    {
        public UserRepositoryEF(UserDbContext context)
           : base(context)
        {

        }

        public User BuscarDadosDoUsuario(string codigoUsuario)
        {
            var result  = this.GetAll();
            return result.FirstOrDefault();
        }
    }
}
