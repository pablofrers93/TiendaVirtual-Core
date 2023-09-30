namespace TiendaVirtualCore.Entities.Models
{
    public class Ciudad
    {
        public int PaisId { get; set; }
        public string NombreCiudad { get; set; }
        public int CiudadId { get; set; }
        public Pais? Pais { get; set; }
        public byte[]? RowVersion { get; set; }              
    }
}
