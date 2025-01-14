using Microsoft.AspNetCore.Mvc;
using Apidelibros.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;


namespace Apidelibros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public LibrosController(ApplicationDbContext context) {  _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> Get()
        {
            return await _context.libros.Include(x => x.autor).Include(x => x.editorial).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post (Libro libro)
        {
            var existeAutor = await _context.autores.AnyAsync(x => x.Id == libro.Autorid);
            var existeEditorial = await _context.editoriales.AnyAsync(x => x.Id == libro.Editorialid);
            if (!existeAutor || !existeEditorial)
            {
                return BadRequest("El autor o el editorial no existen");
            }
            else
            {
                try
                {
                    _context.Add(libro);
                    _context.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut]
        public async Task<ActionResult> Edit(Libro LibroEditado)
        {
            var LibroAEditar = await _context.libros.FirstOrDefaultAsync(x => x.Id == LibroEditado.Id);
            if (LibroAEditar == null)
            {
                return NotFound("No se encontró el libro");
            }
            try
            {
                var existeAutor = await _context.autores.AnyAsync(x => x.Id == LibroAEditar.Autorid);
                var existeEditorial = await _context.editoriales.AnyAsync(x => x.Id == LibroAEditar.Editorialid);
                if (!existeAutor || !existeEditorial)
                {
                    return BadRequest("El autor o el editorial no es válido");
                }
                try
                {
                    LibroAEditar.Nombre = LibroEditado.Nombre;
                    LibroAEditar.ISBN = LibroEditado.ISBN;
                    LibroAEditar.Autorid = LibroEditado.Autorid;
                    LibroAEditar.Editorialid = LibroEditado.Editorialid;
                    _context.SaveChangesAsync();
                    return Ok(new { anterior = LibroAEditar, nuevo = LibroEditado });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var LibroABorrar = _context.libros.FirstOrDefault(x => x.Id == id);
            if (LibroABorrar == null) { return BadRequest("El libro no existe"); }
            try
            {
                _context.libros.Remove(LibroABorrar);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
