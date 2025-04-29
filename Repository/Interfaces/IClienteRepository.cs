using ApiNexus.Models;

namespace ApiNexus.Repository.Interfaces
{
    public interface IClienteRepository
    {


        Task<List<ClienteModel>> PesquisarCliente(string parametroPesquisa);


        Task<List<ClienteModel>> ListarClientes();

        Task<ClienteModel> CadastrarCliente(ClienteModel cliente);

        Task<ClienteModel?> DeletarCliente(string id_cliente);

        Task<ClienteModel> AtualizarCliente(ClienteModel cliente);


    }
}
