namespace Data.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; } = new Guid();
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
    }
}