using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;

namespace ApplicationApp.OpenApp
{
    public class AppProduto : InterfaceProdutoApp
    {
        private readonly IProduto _iproduto;
        private readonly IServiceProduto _iServiceProduto;
        public AppProduto(IProduto iproduto,
            IServiceProduto iServiceProduto)
        {
            _iproduto = iproduto;
            _iServiceProduto = iServiceProduto;
        }
    

        public async Task AddProduto(Produto produto)
        {
            await _iServiceProduto.AddProduto(produto);
        }

        public async Task UpdateProduto(Produto produto)
        {
            await _iServiceProduto.UpdateProduto(produto);
        }

        public async Task DeleteProduto(Produto produto)
        {
            await _iServiceProduto.DeleteProduto(produto);
        }

        public async Task Add(Produto entity)
        {
            await _iproduto.Add(entity);
        }
        public async Task Delete(Produto entity)
        {
            await _iproduto.Delete(entity);
        }

        public async Task<List<Produto>> GetAll()
        {
           return await _iproduto.GetAll();
        }

        public async Task<Produto> GetEntityById(int id)
        {
            return await _iproduto.GetEntityById(id);
        }

        public async Task Update(Produto entity)
        {
            await _iproduto.Update(entity);
        }

     
    }
}
