using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceCompraUsuario;
using Entities.Entities;

namespace ApplicationApp.OpenApp
{
    public class AppCompraUsuario : InterfaceCompraUsuarioApp
    {
        private readonly ICompraUsuario _IcompraUsuario;
        public AppCompraUsuario(ICompraUsuario IcompraUsuario)
        {
            _IcompraUsuario = IcompraUsuario;
        }
        public async Task Add(CompraUsuario entity)
        {
            await _IcompraUsuario.Add(entity);
        }

        public async Task Delete(CompraUsuario entity)
        {
            await _IcompraUsuario.Delete(entity);
        }

        public async Task<List<CompraUsuario>> GetAll()
        {
            return await _IcompraUsuario.GetAll();
        }

        public async Task<CompraUsuario> GetEntityById(int id)
        {
            return await _IcompraUsuario.GetEntityById(id);
        }

        public async Task Update(CompraUsuario entity)
        {
            await _IcompraUsuario.Update(entity);
        }
    }
}
