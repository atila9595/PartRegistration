
using APIREGISTRO.Data;
using APIREGISTRO.Models;
using APIREGISTRO.Service;
using Microsoft.AspNetCore.Mvc;
namespace APIREGISTRO.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    /*
    private readonly ApplicationDbContext _context;

    public ProdutoController(ApplicationDbContext context)
    {
        _context = context;
    }
    */
    private readonly IProdutoInterface _produtoInterface;
    public ProdutoController(IProdutoInterface produtoInterface){
        _produtoInterface = produtoInterface;
    }

    [HttpGet]
    public async Task<ActionResult<Models.ServiceResponse<List<Produto>>>> GetProduto(){
        
        return Ok(await _produtoInterface.GetListProduto());
    }

    [HttpPost]
    public async Task<ActionResult<Models.ServiceResponse<List<Produto>>>> CreateProduto(Produto novoProduto){
        
        return Ok(await _produtoInterface.CreateProduto(novoProduto));
    }
   

}