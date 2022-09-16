using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IList<Cliente> _clienteList = new List<Cliente>();

        public void DeleteCliente(Guid clienteId)
        {
            Cliente cliente = _clienteList.First(e => e.Id == clienteId);
            _clienteList.Remove(cliente);
        }      
   
        public Cliente GetClienteByID(Guid clienteId)
        {
            return _clienteList.First(c => c.Id == clienteId);
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _clienteList.ToList();
        }

        public void InsertCliente(Cliente cliente)
        {
            _clienteList.Add(cliente);
        }


        public void UpdateCliente(Cliente cliente)
        {
            var clienteEdit = _clienteList.FirstOrDefault(c => c.Id == cliente.Id);
            if (clienteEdit != null)
            {
                clienteEdit.Nombre = cliente.Nombre;
                clienteEdit.Apellido = cliente.Apellido;
                clienteEdit.Direccion = cliente.Direccion;
            }
        }
    }
}
