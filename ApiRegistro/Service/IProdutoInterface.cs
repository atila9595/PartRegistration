using APIREGISTRO.Models;

namespace APIREGISTRO.Service;

public interface IProdutoInterface
{
    Task<ServiceResponse<List<Produto>>> GetListProduto();
    Task<ServiceResponse<List<Produto>>> CreateProduto(Produto novoProduto);
    Task<ServiceResponse<Produto>> GetProdutoById(int id);
    Task<ServiceResponse<List<Produto>>> UpdateProduto(Produto editadoProduto);
    Task<ServiceResponse<List<Produto>>> DeletaProduto(int id);
    
} 