using Domain.Interfaces.InterfaceProduct;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryProduto : RepositoryGeneric<Produto>, IProduto
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public RepositoryProduto()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<List<Produto>> ListarProdutosUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Produtos.Where(p => p.UserId == userId).AsNoTracking().ToListAsync();
            }
        }
    }
}
