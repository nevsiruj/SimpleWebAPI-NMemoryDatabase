using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using WEB_API.Entities;
using static WEB_API.Entities.ClienteDBContext;

namespace WEB_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {

        private readonly ClienteDBContext _context;

        public ClientesController(ClienteDBContext context)
        {
            _context = context;
           
        }

        //public void SeedData()
        //{
        //    _context.Clientes.Add(new Cliente()
        //    {
        //        Id = Guid.NewGuid(),
        //        Nombre = "Melden",
        //        Apellido = "Ortega",
        //        Direccion = "Puerreydon 277"
        //    });
        //}

        //IList<Cliente> clientes = new List<Cliente>()
        //{
        //    new Cliente()
        //    {
        //        Id = Guid.NewGuid(),
        //        Nombre = "Lucas",
        //        Apellido = "Rodriguez",
        //        Direccion = "Puerreydon 277"                
        //    }
        //};


        //[HttpGet]
        //public IEnumerable<Cliente> GetClientes()
        //{

        //    var cliente1 = new Cliente()
        //    {
        //        Id = Guid.NewGuid(),
        //        Nombre = "Melden",
        //        Apellido = "Ortega",
        //        Direccion = "Puerreydon 277"
        //    };
        //    _context.Clientes.Add(cliente1);

        //    return _context.Clientes;
        //}

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            var cliente1 = new Cliente(Guid.NewGuid(), "Melden", "Ortega", "Puerreydon 277");
            _context.Clientes.Add(cliente1);            

            return _context.Clientes;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> PostCliente([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee([FromRoute] Guid id, [FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != cliente.Id)
            //{
            //    return BadRequest();
            //}

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok(cliente);
        }


        private bool ClienteExists(Guid id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }

    }
}
