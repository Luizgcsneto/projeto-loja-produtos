var objetoVenda = new Object()

objetoVenda.AdicionaCarrinho = function(idProduto) {

    var nome = $('#nome_' + idProduto).val()
    var qtd = $('#qtd_' + idProduto).val() 

    $.ajax({
        type: 'POST',
        url: '/api/AdicionarProdutoCarrinho',
        dataType: 'JSON',
        contentType: 'application/x-www-form-urlencoded',
        cache: false,
        async: true,
        data: {
            'id': idProduto, 'nome': nome, 'qtd': qtd
        },
        success: function (data) {

            if (data.sucesso) {
                alert('Produto adicionado ao carrinho')
            } else {
                alert('Usuário não logado')
            }

        },
        error: function (xhr, status, error) {
            console.log(xhr.responseText)
            alert('Ocorreu um erro ao adicionar o produto ao carrinho: ' + xhr.responseText);
        }
    }); 

};

objetoVenda.CarregarProdutos = function () {
    $.ajax({
        type: 'GET',
        url: '/api/ListarProdutosComEstoque',
        dataType: 'JSON',
        cache: false,
        async: true,
        success: function (data) {

            var htmlContent = "";

            data.forEach(function (entity) {
                htmlContent += '<div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">'

                var idNome = 'nome_' + entity.id
                var idQtd = 'qtd_' + entity.id

                htmlContent += '<label id="' + idNome + '">Produto: ' + entity.nome + '</label><br/>'
                htmlContent += '<label> valor: ' + entity.preco + ' </label><br/>';

                htmlContent += 'Quantidade: <input type="number" value="1" id="' + idQtd + '" /><br/>'

                htmlContent += "<input type='button' onclick='objetoVenda.AdicionaCarrinho(" + entity.id + ")' value ='Comprar'> </br> ";

                htmlContent += ' </div>';
            });

            $('#divVenda').html(htmlContent)
        }
    });
};

$(function () {
    objetoVenda.CarregarProdutos()
});