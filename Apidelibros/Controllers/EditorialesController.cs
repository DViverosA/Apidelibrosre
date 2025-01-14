using Apidelibros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apidelibros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditorialesController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public EditorialesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editorial>>> Get()
        {
            return await _context.editoriales.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Editorial editorial)
        {
            if (editorial == null)
            {
                return BadRequest("Oe pon algo causa");
            }
            try
            {
                await _context.editoriales.AddAsync(editorial);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Edit(Editorial EditorialEditado)
        {
            var EditorialAEditar = await _context.editoriales.FirstOrDefaultAsync(x => x.Id == EditorialEditado.Id);
            if (EditorialAEditar == null)
            {
                return BadRequest("No existe");
            }
            try
            {
                EditorialAEditar.Nombre = EditorialEditado.Nombre;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Editorialquebusco = _context.editoriales.FirstOrDefault(x => x.Id == id);
            if (Editorialquebusco == null)
            {
                return BadRequest("Nel pastel");
            }
            try
            {
                _context.editoriales.Remove(Editorialquebusco);
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
