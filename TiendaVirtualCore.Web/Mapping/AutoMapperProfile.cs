using AutoMapper;
using TiendaVirtualCore.Entities.Dtos.Categoria;
using TiendaVirtualCore.Entities.Models;
using TiendaVirtualCore.Web.ViewModels.Categoria;

namespace TiendaVirtualCore.Web.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            LoadCategoriasMapping();
        }

        private void LoadCategoriasMapping()
        {
            CreateMap<CategoriaListDto, CategoriaListVm>();
            CreateMap<CategoriaEditVm, Categoria>().ReverseMap();
        }
    }
}
