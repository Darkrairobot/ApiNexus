

using ApiNexus.Models;

namespace ApiNexus.Repository.Interfaces{
    public interface IProdutoRepository{

        public Task<List<ProdutoModel>> ListarProdutos();

        public Task<ProdutoModel> CadastrarProduto(ProdutoModel produto);

        public Task<ProdutoModel?> DeletarProduto(Guid id_produto);

        public Task<ProdutoModel> AtualizarProduto(ProdutoModel produto);





    }
}