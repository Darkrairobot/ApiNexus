using ApiNexus.Context;
using ApiNexus.Models;
using ApiNexus.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiNexus.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly DataContext _context;
        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UsuarioModel> encontrarPorId(Guid id)
        {
            return await _context.caduse.FirstOrDefaultAsync(x => x.id_user == id);
        }

        public async Task<List<UsuarioModel>> encontrarTodos()
        {
            return await _context.caduse.ToListAsync();
        }

        public async Task<UsuarioModel> adicionar(UsuarioModel cliente)
        {
            await _context.caduse.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<UsuarioModel> atualizar(UsuarioModel usuario)
        {
            var clienteBanco = await encontrarPorId(usuario.id_user);
            if (clienteBanco == null) return null;
            clienteBanco = usuario;
            _context.caduse.Update(clienteBanco);
            await _context.SaveChangesAsync();
            return clienteBanco;
        }

        public async Task<bool> deletar(Guid id)
        {
            var clienteBanco = await encontrarPorId(id);
            if (clienteBanco == null) throw new Exception("Cliente não encontrado");
            _context.caduse.Remove(clienteBanco);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> login(string email, string senha)
        {
            var cliente = await _context.caduse.FirstOrDefaultAsync(x => x.email == email && x.senha == senha);
            if (cliente == null) return null;
            return cliente;
        }

    }
}
