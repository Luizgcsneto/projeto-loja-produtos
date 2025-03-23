using System.Linq.Expressions;
using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces.InterfaceProduct
{
    public interface IProduto : IGeneric<Produto>
    {
        Task<List<Produto>> ListarProdutosUsuario(string userId);
        Task<List<Produto>> ListarProdutos(Expression<Func<Produto,bool>> exProduto);
    }
}
