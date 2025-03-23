using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;

namespace Domain.Services
{
    public class ServiceProduto : IServiceProduto
    {
        private readonly IProduto _produto;
        public ServiceProduto(IProduto produto)
        {
            _produto = produto;
        }
        public async Task AddProduto(Produto produto)
        {
            var validaNome = produto.validaPropriedadeString(produto.Nome, "Nome");

            var validaDescricao = produto.validaPropriedadeString(produto.Descricao, "Descricao");

            var ValidaQtdEstoque = produto.validaPropriedadeInt(produto.QtdEstoque, "QtdEstoque");

            var validaPreco = produto.validaPropriedadeDecimal(produto.Preco, "Preco");

            if (validaNome && validaDescricao && ValidaQtdEstoque && validaPreco)
            {
                produto.DataCadastro = DateTime.Now;
                produto.DataAlteracao = DateTime.Now;
                produto.Estado = true;
                await _produto.Add(produto);
            }

        }

        public async Task<List<Produto>> ListarProdutosComEstoque()
        {
            return await _produto.ListarProdutos(p => p.QtdEstoque > 0);
        }

        public async Task UpdateProduto(Produto produto)
        {
            var validaNome = produto.validaPropriedadeString(produto.Nome, "Nome");

            var validaDescricao = produto.validaPropriedadeString(produto.Descricao, "Descricao");

            var validaPreco = produto.validaPropriedadeDecimal(produto.Preco, "Preco");

            if (validaNome && validaDescricao && validaPreco)
            {
                var dataCadastrado = await _produto.GetEntityById(produto.Id);
                produto.DataCadastro = dataCadastrado.DataCadastro;
                produto.DataAlteracao = DateTime.Now;
                await _produto.Update(produto);
            }
        }

       
    }
}
