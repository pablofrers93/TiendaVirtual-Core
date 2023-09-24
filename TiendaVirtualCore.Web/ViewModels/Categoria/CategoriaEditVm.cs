using System.ComponentModel.DataAnnotations;

namespace TiendaVirtualCore.Web.ViewModels.Categoria
{
    public class CategoriaEditVm
    {
        public int CategoriaId { get; set; }

        [Display(Name = "Categoría")]
        [Required(ErrorMessage ="El campo es requerido")]
        [StringLength(50,ErrorMessage ="Debe estar comprendida entre {2} y {1}",MinimumLength =3)]
        public string NombreCategoria { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(120, ErrorMessage = "El campo no puede superar los {1} caracteres")]
        public string? Descripcion { get; set; }

    }
}
