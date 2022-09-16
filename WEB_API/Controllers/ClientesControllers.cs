using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WEB_API.Controllers
{
    [ApiController]
    [Route("api/Clientes")]
    public class ClientesController : ControllerBase
    {
        private IClienteRepository clienteRepository;

        public ClientesController()
        {
            this.clienteRepository = new ClienteRepository();
        }

        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IEnumerable<Cliente> GetClientes()
        {
            var clientes = clienteRepository.GetClientes();
            if (clientes == null)
            {
                return null;
            }
            return clientes.ToList();

        }
      

        [HttpGet("{id:int}", Name = "ObtenerCliente")]
        public Cliente GetClienteById(Guid id)
        {
           return clienteRepository.GetClienteByID(id);
        }

        [HttpPost]  
        public async Task<ActionResult> Post(Cliente cliente)
        {          
            clienteRepository.InsertCliente(cliente);
            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(Guid id, Cliente cliente)
        {
            var clienteEdit = clienteRepository.GetClientes().First(c => c.Id == cliente.Id);

            if (clienteEdit == null)
                return NotFound();

            clienteRepository.UpdateCliente(clienteEdit);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(Guid id)
        {
            clienteRepository.DeleteCliente(id);
            return NoContent();
        }

    }
}
