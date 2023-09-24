using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtualCore.Entities.Dtos.Pais;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Servicios.Interfaces
{
    public interface IServiciosPaises
    {
        List<PaisListDto> GetPaises();
        void Guardar(Pais pais);
        void Borrar(int id);
        bool Existe(Pais pais);
        Pais GetPaisPorId(int paisId);
        bool EstaRelacionado(Pais pais);
    }
}
