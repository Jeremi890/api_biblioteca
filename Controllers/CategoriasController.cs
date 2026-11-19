using Microsoft.AspNetCore.Mvc;
using TallerApi.Models;

namespace TallerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    // Lista en memoria con registros iniciales (mínimo 2 registros)
    private static readonly List<Categoria> _categorias = new()
    {
        new Categoria
        {
            Id = 1,
            Nombre = "Novela Clásica"
        },
        new Categoria
        {
            Id = 2,
            Nombre = "Ciencia Ficción"
        },
        new Categoria
        {
            Id = 3,
            Nombre = "Fantasía y Aventura"
        }
    };

    // GET: api/categorias
    // Consulta todas las categorías registradas
    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> GetCategorias()
    {
        return Ok(_categorias);
    }
}
