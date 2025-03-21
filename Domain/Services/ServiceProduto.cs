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
                produto.DataCadastro = DateTime.UtcNow;
                await _produto.Add(produto);
            }

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
                produto.DataAlteracao = DateTime.UtcNow;
                await _produto.Update(produto);
            }
        }

       
    }
}
