using ApiNexus.Models;
using ApiNexus.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNexus.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller{

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository) {
            _produtoRepository = produtoRepository;
         }

        [HttpGet("ListarProdutos")]
        public async Task<IActionResult> ListarProdutos() {

            try{

                var produtos = await _produtoRepository.ListarProdutos();

                return Ok(produtos);

            }catch(Exception ex){
                return BadRequest(ex.Message);
            }

         }

         [HttpPost("CadastrarProduto")]
         public async Task<IActionResult> CadastrarProduto([FromBody] ProdutoModel produto) {

            try
{
    if (await _produtoRepository.CadastrarProduto(produto) != null)
    {
        return Ok("Produto cadastrado com sucesso");
    }
    else
    {
        return NotFound("Produto não encontrado");
    }
}
catch (Exception ex)
{
    // Logando o erro completo para depuração
    // Você pode usar ILogger aqui ou outra ferramenta de log que estiver utilizando no seu projeto
    Console.WriteLine(ex.ToString()); // Exemplo simples para depuração

    // Retornando mensagem de erro mais detalhada
    return BadRequest(ex.Message);
}


         }

    }

}

