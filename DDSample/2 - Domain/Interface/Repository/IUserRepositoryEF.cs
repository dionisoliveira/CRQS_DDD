

namespace DDDSample._2__Domain.Interface.Repository
{
    public interface IUserRepositoryEF : IRepository<DDDSample.Domain.User>
    {
        DDDSample.Domain.User BuscarDadosDoUsuario(string codigoUsuario);
    }
}
