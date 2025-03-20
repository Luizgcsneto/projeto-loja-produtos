using Entities.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceProduto
    {
        Task AddProduto(Produto produto);
        Task UpdateProduto(Produto produto);

        Task DeleteProduto(Produto produto);
    }
}
