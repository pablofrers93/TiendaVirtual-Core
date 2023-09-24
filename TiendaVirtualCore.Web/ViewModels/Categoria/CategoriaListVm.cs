using System.ComponentModel.DataAnnotations;

namespace TiendaVirtualCore.Web.ViewModels.Categoria
{
    public class CategoriaListVm
    {
        public int CategoriaId { get; set; }

        [Display(Name ="Categoría")]
        public string NombreCategoria { get; set; }

    }
}
