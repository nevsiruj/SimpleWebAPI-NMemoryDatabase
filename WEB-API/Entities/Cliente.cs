namespace WEB_API.Entities
{
    public class Cliente
    {
        public Cliente(Guid id, string nombre, string apellido, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
        }

        public Guid Id { get; set; } 
        public string Nombre { get; set; } = string.Empty;  
        public string Apellido { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
    }
}
