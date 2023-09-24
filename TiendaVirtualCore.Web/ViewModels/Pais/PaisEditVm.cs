using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TiendaVirtualCore.Web.ViewModels.Pais
{
    public class PaisEditVm
    {
        public int PaisId { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(50, ErrorMessage = "Debe estar comprendida entre {2} y {1}", MinimumLength = 3)]
        [Display(Name = "País")]
        public string NombrePais { get; set; }
    }
}
