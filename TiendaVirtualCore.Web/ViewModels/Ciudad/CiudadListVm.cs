using System.ComponentModel.DataAnnotations;

namespace TiendaVirtualCore.Web.ViewModels.Ciudad
{
    public class CiudadListVm
    {
        public int CiudadId { get; set; }

        [Display(Name = "City")]
        public string NombreCiudad { get; set; }
        [Display(Name ="Country")]
        public string NombrePais { get; set; }
    }
}
