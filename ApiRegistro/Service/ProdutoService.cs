using APIREGISTRO.Data;
using APIREGISTRO.Models;
using APIREGISTRO.Service;

namespace APIREGISTRO.Service;

public class ProdutoService : IProdutoInterface
    {

        private readonly ApplicationDbContext _context;
        public ProdutoService(ApplicationDbContext context){
            _context = context;
        }

   

    public async Task<ServiceResponse<List<Produto>>> GetListProduto()
        {
            ServiceResponse<List<Produto>> serviceResponse = new ServiceResponse<List<Produto>>();
            try
            {
                serviceResponse.Dados = _context.Produtos.ToList();
                
            }
            catch (System.Exception e ) 
            {
                
                serviceResponse.Mensagem = e.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }


        

    public async Task<ServiceResponse<List<Produto>>> CreateProduto(Produto novoProduto)
    {
       {
            ServiceResponse<List<Produto>> serviceResponse = new ServiceResponse<List<Produto>>();
            try
            {
                if (novoProduto == null)    
                {
                    serviceResponse.Mensagem = "informe os dados!";
                    serviceResponse.Sucesso = false;
                    serviceResponse.Dados = null;

                    return serviceResponse;
                }
                _context.Add(novoProduto);

                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Produtos.ToList();
            }
            catch (System.Exception e ) 
            {
                
                serviceResponse.Mensagem = e.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }

    Task<ServiceResponse<List<Produto>>> IProdutoInterface.DeletaProduto(int id)
    {
        throw new NotImplementedException();
    }

    Task<ServiceResponse<Produto>> IProdutoInterface.GetProdutoById(int id)
    {
        throw new NotImplementedException();
    }

    Task<ServiceResponse<List<Produto>>> IProdutoInterface.UpdateProduto(Produto editadoProduto)
    {
        throw new NotImplementedException();
    }
}