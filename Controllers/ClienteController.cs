using ApiNexus.Models;
using ApiNexus.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiNexus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {

        IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        [HttpGet("ListarClientes")]

        public async Task<IActionResult> ListarClientes()
        {
            try
            {
                var listaClientes = await _clienteRepository.ListarClientes();
                if (listaClientes.Count == 0)
                {
                    return NotFound("Nenhum cliente encontrado");
                }
                else
                {
                    return Ok(listaClientes);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao tentar listar clientes: {ex.Message}");
            }
        }


        [HttpGet("PesquisarCliente")]
        public async Task<IActionResult> PesquisarCliente([FromQuery] string parametroPesquisa)
        {

            try
            {
                var resultadoPesquisa = await _clienteRepository.PesquisarCliente(parametroPesquisa);

                if (resultadoPesquisa.Count == 0)
                {
                    return NotFound("Nenhum cliente encontrado com esse parametro");

                }
                else
                {
                    return Ok(resultadoPesquisa);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"erro ao pesquisar Cliente {ex.Message}");
            }


        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CadastrarCliente([FromBody] ClienteModel cliente)
        {
            try
            {
                await _clienteRepository.CadastrarCliente(cliente);

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"erro ao tentar Cadastrar: {ex.Message}");
            }
        }

        [HttpDelete("Deletar/{id_cliente}")]

        public async Task<IActionResult> DeletarCliente([FromRoute] string id_cliente)
        {

            try
            {

                var clienteDeletado = await _clienteRepository.DeletarCliente(id_cliente);

                if (clienteDeletado != null ) return Ok(clienteDeletado);

                return NotFound("Cliente não encontrado");

            }
            catch (Exception ex)
            {
                return BadRequest($"erro ao tentar deletar: {ex.Message}");
            }
        }

        [HttpPut("Atualizar")]

        public async Task<IActionResult> Atualizar([FromBody] ClienteModel cliente)
        {

            try
            {
                await _clienteRepository.AtualizarCliente(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"erro ao tentar atualizar: {ex.Message}");
            }

        }

    }
}
