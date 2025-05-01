
using ApiNexus.Context;
using ApiNexus.Models;
using ApiNexus.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiNexus.Repository{

    public class ProdutoRepository : IProdutoRepository{

        private readonly DataContext _context;

        public ProdutoRepository(DataContext context){

            _context = context;

        }

        public async Task<List<ProdutoModel>> ListarProdutos(){
            
            try{
                return await _context.cadpro.ToListAsync();
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }

        }

        public async Task<ProdutoModel> CadastrarProduto(ProdutoModel produto){
            try{

                await _context.cadpro.AddAsync(produto);

                await _context.SaveChangesAsync();

                return produto; 

            }catch(Exception ex){
                throw new Exception($"Erro: {ex.Message}. Detalhes: {ex.InnerException?.Message ?? "Sem detalhes adicionais."}");
            }
        }

        public async Task<ProdutoModel?> DeletarProduto(Guid id_produto){
            try{

                ProdutoModel? produto = await _context.cadpro.FirstOrDefaultAsync(p => p.id_produto == id_produto);

                if(produto != null){
                    _context.Remove(produto);

                    await _context.SaveChangesAsync();
                }

                return null;

                
            
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoModel> AtualizarProduto(ProdutoModel produto){
            
            try{


                _context.cadpro.Update(produto);

                await _context.SaveChangesAsync();

                return produto;


            }catch(Exception ex){
                throw new Exception(ex.Message);
            }


        }

    }

}