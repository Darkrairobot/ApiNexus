using ApiNexus.Models;

namespace ApiNexus.Repository.Interfaces
{
    public interface IUsuarioRepository
    {

        Task<UsuarioModel> encontrarPorId(Guid id);
        Task<List<UsuarioModel>> encontrarTodos();
        Task<UsuarioModel> adicionar(UsuarioModel cliente);
        Task<UsuarioModel> atualizar(UsuarioModel cliente);
        Task<bool> deletar(Guid id);

        Task<UsuarioModel> login(string email, string senha);

    }
}
