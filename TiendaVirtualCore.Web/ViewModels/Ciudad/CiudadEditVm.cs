using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TiendaVirtualCore.Web.ViewModels.Ciudad
{
    public class CiudadEditVm
    {
        public int CiudadId { get; set; }
        [DisplayName("City")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(100,ErrorMessage ="Field {0} must be between {2} and {1}", MinimumLength =3)]
        public string NombreCiudad { get; set; }
        [DisplayName("Country")]
        [Range(1, int.MaxValue, ErrorMessage = "Must select a value")]
        public int PaisId { get; set; }
        public byte[]? RowVersion { get; set; }
        public List<SelectListItem>? Paises { get; set; }
    }
}