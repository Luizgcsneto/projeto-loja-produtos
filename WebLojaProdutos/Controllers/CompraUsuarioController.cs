using ApplicationApp.Interfaces;
using Entities.Entities;
using Entities.Entities.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebLojaProdutos.Controllers
{
    public class CompraUsuarioController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly InterfaceCompraUsuarioApp _InterfaceComraUsuarioApp;
        public CompraUsuarioController(UserManager<ApplicationUser> userManager,
                                       InterfaceCompraUsuarioApp interfaceComraUsuarioApp)
        {
            _userManager = userManager;
            _InterfaceComraUsuarioApp = interfaceComraUsuarioApp;
        }

        [HttpPost("/api/AdicionarProdutoCarrinho")]
        public async Task<JsonResult> AdicionarProdutoCarrinho(string id, string nome, string qtd)
        {
            var usuario = await _userManager.GetUserAsync(User);

            if(usuario != null)
            {
                await _InterfaceComraUsuarioApp.Add(new CompraUsuario
                {
                    ProdutoId = Convert.ToInt32(id),
                    QtdCompra = Convert.ToInt32(qtd),
                    Estado = EstadoCompra.Produto_Carrinho,
                    UserId = usuario.Id.ToString()
                });
                return Json(new { sucesso = true });
            }

            return Json(new { sucesso = false });
        }
    }
}
