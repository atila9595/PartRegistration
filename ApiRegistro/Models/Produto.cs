using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIREGISTRO.Models;

[Table("produtos")]
public class Produto
{   
    [Key]
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }

    public Produto()
    {
        Nome = string.Empty;
        Descricao = string.Empty;
    }
}