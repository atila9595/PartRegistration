using APIREGISTRO.Data;
using APIREGISTRO.Models;
using APIREGISTRO.Service;
using Microsoft.EntityFrameworkCore;

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

    async Task<ServiceResponse<List<Produto>>> IProdutoInterface.DeletaProduto(int id)
    {
        ServiceResponse<List<Produto>> serviceResponse = new ServiceResponse<List<Produto>>();

        try
        {
            Produto produto = _context.Produtos.AsNoTracking().FirstOrDefault(x => x.Codigo == id );
            if (produto == null)
            {
                serviceResponse.Mensagem = "Produto não encotrado!";
                serviceResponse.Sucesso = false;
                serviceResponse.Dados = null;

                return serviceResponse;

            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            serviceResponse.Dados = _context.Produtos.ToList();
        }
        catch (System.Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    public async Task<ServiceResponse<Produto>> GetProdutoById(int id)
    {
        ServiceResponse<Produto> serviceResponse = new ServiceResponse<Produto>();

        try
        {
            Produto produto = _context.Produtos.FirstOrDefault(x => x.Codigo == id);
            if (produto == null)
            {
                serviceResponse.Mensagem = "Produto não encotrado!";
                serviceResponse.Sucesso = false;
                serviceResponse.Dados = null;

                return serviceResponse;
            }

            serviceResponse.Dados = produto;
        }
        catch (System.Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }

    async Task<ServiceResponse<List<Produto>>> IProdutoInterface.UpdateProduto(Produto editadoProduto)
    {
        ServiceResponse<List<Produto>> serviceResponse = new ServiceResponse<List<Produto>>();

        try
        {
            Produto produto = _context.Produtos.AsNoTracking().FirstOrDefault(x => x.Codigo == editadoProduto.Codigo);
            if (produto == null)
            {
                serviceResponse.Mensagem = "Produto não encotrado!";
                serviceResponse.Sucesso = false;
                serviceResponse.Dados = null;

            }

            _context.Produtos.Update(editadoProduto);
            await _context.SaveChangesAsync();

            serviceResponse.Dados = _context.Produtos.ToList();
        }
        catch (System.Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }
        
        return serviceResponse;
    }
}