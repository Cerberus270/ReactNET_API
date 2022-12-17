using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactNET_API.Context;
using ReactNET_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactNET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {
        private readonly AppDbContext _context;
        public GestoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<GestoresController>
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                return Ok(await _context.gestores_bd.ToListAsync());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<GestoresController>/5
        [HttpGet("{id}", Name = "GetGestor")]
        public ActionResult Get(int id)
        {
            try
            {
                var gestor = _context.gestores_bd.FirstOrDefault(x => x.id == id);
                return Ok(gestor);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<GestoresController>
        [HttpPost]
        public ActionResult Post([FromBody] GestoresBD gestor)
        {
            try
            {
                _context.gestores_bd.Add(gestor);
                _context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);
            } catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<GestoresController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] GestoresBD gestor)
        {
            try
            {
                if (gestor.id == id)
                {
                    _context.Entry(gestor).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);
                } else
                {
                    return BadRequest();
                }
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<GestoresController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var gestor = _context.gestores_bd.FirstOrDefault(g => g.id == id);
                if(gestor != null)
                {
                    _context.gestores_bd.Remove(gestor);
                    _context.SaveChanges();
                    return Ok(id);
                } else
                {
                    return BadRequest();
                }
            } catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
