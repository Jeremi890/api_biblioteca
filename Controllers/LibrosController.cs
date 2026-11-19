using Microsoft.AspNetCore.Mvc;
using TallerApi.Models;

namespace TallerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{
    // Lista en memoria con registros iniciales (mínimo 2 registros)
    private static readonly List<Libro> _libros = new()
    {
        new Libro
        {
            Id = 1,
            Titulo = "Cien años de soledad",
            Autor = "Gabriel García Márquez",
            Disponible = true
        },
        new Libro
        {
            Id = 2,
            Titulo = "Don Quijote de la Mancha",
            Autor = "Miguel de Cervantes",
            Disponible = false
        },
        new Libro
        {
            Id = 3,
            Titulo = "El principito",
            Autor = "Antoine de Saint-Exupéry",
            Disponible = true
        }
    };

    // GET: api/libros
    // Consulta todos los libros registrados
    [HttpGet]
    public ActionResult<IEnumerable<Libro>> GetLibros()
    {
        return Ok(_libros);
    }

    // GET: api/libros/{id}
    // Consulta un libro específico por su identificador
    [HttpGet("{id}")]
    public ActionResult<Libro> GetLibroPorId(int id)
    {
        var libro = _libros.FirstOrDefault(l => l.Id == id);
        if (libro == null)
        {
            return NotFound(new { mensaje = $"No se encontró ningún libro con el Id {id}." });
        }

        return Ok(libro);
    }

    // POST: api/libros
    // Registra un nuevo libro en la lista en memoria
    [HttpPost]
    public ActionResult<Libro> CrearLibro([FromBody] Libro nuevoLibro)
    {
        if (nuevoLibro == null)
        {
            return BadRequest(new { mensaje = "Los datos del libro son inválidos." });
        }

        // Si el Id no se especifica o ya existe, generamos un Id consecutivo
        int nuevoId = _libros.Count > 0 ? _libros.Max(l => l.Id) + 1 : 1;
        nuevoLibro.Id = nuevoId;

        _libros.Add(nuevoLibro);

        return CreatedAtAction(nameof(GetLibroPorId), new { id = nuevoLibro.Id }, nuevoLibro);
    }
}
