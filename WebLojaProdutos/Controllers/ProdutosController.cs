using ApplicationApp.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebLojaProdutos.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        
        private readonly InterfaceProdutoApp _interfaceProdutoApp;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProdutosController(InterfaceProdutoApp interfaceProdutoApp,
                                  UserManager<ApplicationUser> userManager)
        {
            _interfaceProdutoApp = interfaceProdutoApp;
            _userManager = userManager;
        }
        // GET: ProdutosController
        public async Task<IActionResult> Index()
        {
            var idUsuario = await retornarIdUsuarioLogado();

            return View(await _interfaceProdutoApp.ListarProdutosUsuario(idUsuario));
        }

        // GET: ProdutosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _interfaceProdutoApp.GetEntityById(id));
        }

        // GET: ProdutosController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: ProdutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            try
            {
                var idUsuario = await retornarIdUsuarioLogado();

                produto.UserId = idUsuario;
                await _interfaceProdutoApp.AddProduto(produto);
                TempData["SuccessMessage"] = "Produto cadastrado com sucesso!";

                if (produto.Notificacoes.Any())
                {
                    foreach(var item in produto.Notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                    }

                    return View("Create",produto);
                }

               
            }
            catch
            {
                return View("Create", produto);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutosController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _interfaceProdutoApp.GetEntityById(id));
        }

        // POST: ProdutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            try
            {

                await _interfaceProdutoApp.UpdateProduto(produto);
                TempData["SuccessMessage"] = "Produto atualizado com sucesso!";

                if (produto.Notificacoes.Any())
                {
                    foreach (var item in produto.Notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                    }

                    return View("Edit", produto);
                }


            }
            catch
            {
                return View("Edit", produto);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutosController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _interfaceProdutoApp.GetEntityById(id));
        }

        // POST: ProdutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Produto produto)
        {
            try
            {
                var produtoDeletar = await _interfaceProdutoApp.GetEntityById(id);
                if (produtoDeletar.QtdEstoque > 0) 
                {
                    
                    TempData["ErrorMessage"] = "Não é possível excluir produtos que tem unidades em estoque.";
                    return RedirectToAction(nameof(Index));
                }
                await _interfaceProdutoApp.Delete(produtoDeletar);
                TempData["SuccessMessage"] = "Produto excluído com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<string> retornarIdUsuarioLogado()
        {
            var idUsuario = await _userManager.GetUserAsync(User);

            return idUsuario.Id;
        }

        [AllowAnonymous]
        [HttpGet("/api/ListarProdutosComEstoque")]
        public async Task<JsonResult> ListarProdutosComEstoque()
        {
            return Json(await _interfaceProdutoApp.ListarProdutosComEstoque());
        }
    }
}
