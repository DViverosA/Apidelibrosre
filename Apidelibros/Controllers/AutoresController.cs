using Apidelibros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apidelibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public AutoresController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> Get()
        {
            return await _context.autores.ToListAsync();
        }
       
        
        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            if (autor == null)
            {
                return BadRequest("Pero pon algo pues");
            }
            try
            {
                await _context.autores.AddAsync(autor);
                await _context.SaveChangesAsync();
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public async Task<ActionResult> Edit(Autor AutorEditado)
        {
            var AutorAEditar = await _context.autores.FirstOrDefaultAsync(x => x.Id == AutorEditado.Id);
            if (AutorAEditar == null)
            {
                return BadRequest("El autor no existe");
            }
            try
            {
                AutorAEditar.Nombre=AutorEditado.Nombre;
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
            var AutorQueBusco = _context.autores.FirstOrDefault(x => x.Id == id);
            if (AutorQueBusco == null)
            {
                return BadRequest("El autor no existe");
            }
            try
            {
                _context.autores.Remove(AutorQueBusco);
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
