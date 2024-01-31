
using APIREGISTRO.Data;
using APIREGISTRO.Models;
using APIREGISTRO.Service;
using Microsoft.AspNetCore.Mvc;
namespace APIREGISTRO.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
   
    private readonly IProdutoInterface _produtoInterface;
    public ProdutoController(IProdutoInterface produtoInterface){
        _produtoInterface = produtoInterface;
    }

    [HttpGet]
    public async Task<ActionResult<Models.ServiceResponse<List<Produto>>>> GetProduto(){
        
        return Ok(await _produtoInterface.GetListProduto());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Models.ServiceResponse<Produto>>> GetProdutoById(int id){
        
        ServiceResponse<Produto> serviceResponse = await _produtoInterface.GetProdutoById(id);   
        return Ok(serviceResponse);
    }

    [HttpPost]
    public async Task<ActionResult<Models.ServiceResponse<List<Produto>>>> CreateProduto(Produto novoProduto){
        
        return Ok(await _produtoInterface.CreateProduto(novoProduto));
    }

    [HttpPut]
    public async Task<ActionResult<Models.ServiceResponse<List<Produto>>>> UpdateProduto(Produto editadoProduto){
        
        ServiceResponse<List<Produto>> serviceResponse = await _produtoInterface.UpdateProduto(editadoProduto);
        return Ok(serviceResponse);
    }

    [HttpDelete]
    public async Task<ActionResult<Models.ServiceResponse<List<Produto>>>> DeletaProduto(int id){
        
        ServiceResponse<List<Produto>> serviceResponse = await _produtoInterface.DeletaProduto(id);
        return Ok(serviceResponse);
    }
   

}