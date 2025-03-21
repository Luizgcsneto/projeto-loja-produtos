using Domain.Interfaces.InterfaceProduct;
using Domain.Services;
using Entities.Entities;
using Moq;

namespace LojaProdutosTest
{
    public class ServiceProdutoTest
    {
        private readonly Mock<IProduto> _mockProduto;
        private readonly ServiceProduto _serviceProduto;

        public ServiceProdutoTest()
        {
            _mockProduto = new Mock<IProduto>();
            _serviceProduto = new ServiceProduto(_mockProduto.Object);
       
        }

        [Fact(DisplayName = "Adiciona Quando Produto E Valido")]
        public async Task AddProduto_AdicionaProduto_QuandoEValido()
        {
            // Arrange
            var produto = new Produto
            {
                Nome = "Nome Produto",
                Descricao = "Descricao Produto",
                QtdEstoque = 4,
                Preco = 100.00m
            };

            _mockProduto.Setup(p => p.Add(produto)).Returns(Task.CompletedTask);

            // Act
            await _serviceProduto.AddProduto(produto);

            // Assert
            _mockProduto.Verify(p => p.Add(produto), Times.Once);

        }

        [Fact(DisplayName = "Nao Adiciona Produto Quando Nome E Invalido")]
        public async Task AddProduto_NaoDeveAdicionaProduto_QuandoNomeEInvalido()
        {
            // Arrange
            var produto = new Produto
            {
                Nome = "",
                Descricao = "Descricao Produto",
                QtdEstoque = 4,
                Preco = 100.00m
            };

            _mockProduto.Setup(p => p.Add(produto)).Returns(Task.CompletedTask);

            // Act
            await _serviceProduto.AddProduto(produto);

            // Assert   
            _mockProduto.Verify(p => p.Add(produto), Times.Never);

        }

        [Fact(DisplayName = "Atualiza Produto Quando Nome E Valido")]
        public async Task UpdateProduto_AtualizaProduto_QuandoNomeEValido()
        {
            // Arrange
            var produto = new Produto
            {
                Nome = "Novo Nome",
                Descricao = "Nova Descricao Produto",
                QtdEstoque = 12,
                Preco = 50.00m
            };

            var produtoExistente = new Produto
            {
                Nome = "Produto Antigo",
                Descricao = "Descricao Produto Antigo",
                QtdEstoque = 12,
                Preco = 50.00m
            };

            _mockProduto.Setup(p => p.GetEntityById(produto.Id)).ReturnsAsync(produtoExistente);

            _mockProduto.Setup(p => p.Update(produto)).Returns(Task.CompletedTask);


            // Act
            await _serviceProduto.UpdateProduto(produto);

            // Assert
            _mockProduto.Verify(p => p.Update(produto), Times.Once);
            Assert.Equal(produto.DataCadastro,produtoExistente.DataCadastro);
            Assert.NotNull(produto.DataAlteracao);
        }

        [Fact(DisplayName = "Nao Deve Atualiza Produto Quando Nome E Invalido")]
        public async Task UpdateProduto_NaoDeveAtualizaProduto_QuandoNomeEInvalido()
        {
            // Arrange
            var produto = new Produto
            {
                Nome = "",
                Descricao = "Nova Descricao Produto",
                QtdEstoque = 3,
                Preco = 50.00m
            };

          
            // Act
            await _serviceProduto.UpdateProduto(produto);

            // Assert
            _mockProduto.Verify(p => p.Add(produto), Times.Never);
        }

    }
}