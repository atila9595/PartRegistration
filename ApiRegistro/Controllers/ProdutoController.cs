using System;
using System.Threading.Tasks;
using APIREGISTRO.Data;
using APIREGISTRO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProdutoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CriarProduto([FromBody] ProdutoRequest produtoRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var novoProduto = new Produto
        {
            Nome = produtoRequest.Nome,
            Descricao = produtoRequest.Descricao,
            Preco = produtoRequest.Preco
        };

        _context.Produtos.Add(novoProduto);

        try
        {
            await _context.SaveChangesAsync();
            return CreatedAtAction("ObterProduto", new { id = novoProduto.Id }, novoProduto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao criar e adicionar produto: {ex.Message}");
        }
    }

}