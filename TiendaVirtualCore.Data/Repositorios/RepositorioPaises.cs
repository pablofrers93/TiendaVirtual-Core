using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtualCore.Data.Interfaces;
using TiendaVirtualCore.Entities.Dtos.Pais;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data.Repositorios
{
    public class RepositorioPaises : IRepositorioPaises
    {
        private readonly NeptunoDbContext _context;
        public RepositorioPaises(NeptunoDbContext context)
        {
            _context = context;
        }
        public void Agregar(Pais pais)
        {
            _context.Add(pais);
        }

        public void Borrar(int id)
        {
            var paisInDb = _context.Paises
                .SingleOrDefault(p => p.PaisId == id);
            if (paisInDb == null)
            {
                Exception ex = new Exception("Borrado por otro usuario");
                throw ex;
            }
            _context.Entry(paisInDb).State = EntityState.Deleted;
        }

        public void Editar(Pais pais)
        {
            var paisInDb = _context.Paises
                .SingleOrDefault(p => p.PaisId == pais.PaisId);
            if (paisInDb == null)
            {
                throw new Exception("Borrado por otro usuario");
            }
            paisInDb.NombrePais = pais.NombrePais;
            _context.Entry(paisInDb) .State = EntityState.Modified;
        }

        public bool EstaRelacionado(Pais pais)
        {
            return _context.Ciudades.Any(c => c.PaisId == pais.PaisId);
        }

        public bool Existe(Pais pais)
        {
            if (pais.PaisId == 0)
            {
                return _context.Paises
                    .Any(p => p.NombrePais == pais.NombrePais);
            }
            return _context.Paises
                .Any(p => p.NombrePais == pais.NombrePais && p.PaisId != pais.PaisId);
        }

        public List<PaisListDto> GetPaises()
        {
            return _context.Paises
                .OrderBy(p => p.NombrePais)
                .Select(p => new PaisListDto
                {
                    PaisId = p.PaisId,
                    NombrePais = p.NombrePais,
                })
                .ToList();
        }

        public List<SelectListItem> GetPaisesDropDown()
        {
            return _context.Paises.OrderBy(p=>p.NombrePais).Select(p => new SelectListItem
            {
                Text = p.NombrePais,
                Value = p.PaisId.ToString()
            }).ToList();
        }

        public Pais GetPaisPorId(int paisId)
        {
            var paisInDb = _context.Paises
            .SingleOrDefault(p => p.PaisId == paisId);

            if (paisInDb == null)
            {
                throw new Exception("Error al buscar el pais");
            }
            return paisInDb;
        }
    }
}
