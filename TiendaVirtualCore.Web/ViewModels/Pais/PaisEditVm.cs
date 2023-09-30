using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TiendaVirtualCore.Web.ViewModels.Pais
{
    public class PaisEditVm
    {
        public int PaisId { get; set; }
        [Required(ErrorMessage = "Field required")]
        [StringLength(50, ErrorMessage = "Field must be between {2} and {1}", MinimumLength = 3)]
        [Display(Name = "Country")]
        public string NombrePais { get; set; }
    }
}
