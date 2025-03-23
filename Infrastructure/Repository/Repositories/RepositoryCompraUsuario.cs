using Domain.Interfaces.InterfaceCompraUsuario;
using Entities.Entities;
using Infrastructure.Repository.Generics;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryCompraUsuario : RepositoryGeneric<CompraUsuario>, ICompraUsuario
    {
    }
}
