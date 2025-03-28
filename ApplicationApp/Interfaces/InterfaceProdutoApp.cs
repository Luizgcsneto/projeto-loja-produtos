﻿using Entities.Entities;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceProdutoApp : InterfaceGenericApp<Produto>
    {
        Task AddProduto(Produto produto);
        Task UpdateProduto(Produto produto);

        Task<List<Produto>> ListarProdutosUsuario(string userId);

        Task<List<Produto>> ListarProdutosComEstoque();

    }
}
