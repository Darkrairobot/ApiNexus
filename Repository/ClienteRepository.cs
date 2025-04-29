using ApiNexus.Context;
using ApiNexus.Models;
using ApiNexus.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiNexus.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;
        public ClienteRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ClienteModel>> PesquisarCliente(string parametroPesquisa)
        {

            try
            {
                return await _context.cadcli.Where(x => x.nome.Contains(parametroPesquisa) || x.CPF_CNPJ.Contains(parametroPesquisa) || x.email.Contains(parametroPesquisa)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<List<ClienteModel>> ListarClientes()
        {

            try
            {
                return await _context.cadcli.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        public async Task<ClienteModel> CadastrarCliente(ClienteModel cliente)
        {


            try
            {
                cliente.id_cliente = Guid.NewGuid();
           
                cliente.dataCadastro = DateTime.Now;
                cliente.dataAtualizacao = DateTime.Now;
                await _context.cadcli.AddAsync(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public async Task<ClienteModel?> DeletarCliente(string id_cliente)
        {
            try
            {
                
                ClienteModel? cliente = await _context.cadcli.FirstOrDefaultAsync(x => x.id_cliente.ToString() == id_cliente);

                if (cliente != null)
                {
                    _context.cadcli.Remove(cliente);
                    await _context.SaveChangesAsync();

                    return cliente;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteModel> AtualizarCliente(ClienteModel cliente)
        {

            try
            {
                _context.cadcli.Update(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
