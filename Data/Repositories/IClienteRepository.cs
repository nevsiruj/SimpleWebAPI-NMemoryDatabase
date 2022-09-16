using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IClienteRepository 
    {
        IEnumerable<Cliente> GetClientes();
        Cliente GetClienteByID(Guid clienteId);
        void InsertCliente(Cliente cliente);
        void DeleteCliente(Guid clienteId);
        void UpdateCliente(Cliente cliente);
    }
}
