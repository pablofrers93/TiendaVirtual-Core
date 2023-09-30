using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtualCore.Data.Interfaces;
using TiendaVirtualCore.Entities.Dtos.Ciudad;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data.Repositorios
{
    public class RepositorioCiudades : IRepositorioCiudades
    {
        private readonly NeptunoDbContext _context;
        public RepositorioCiudades(NeptunoDbContext context)
        {
            _context = context;
        }
        public void Agregar(Ciudad ciudad)
        {
            _context.Add(ciudad);
        }

        public void Borrar(int id)
        {
            var ciudadInDb = _context.Ciudades
                .SingleOrDefault(p => p.CiudadId == id);
            if (ciudadInDb == null)
            {
                Exception ex = new Exception("Borrado por otro usuario");
                throw ex;
            }
            _context.Entry(ciudadInDb).State = EntityState.Deleted;
        }

        public void Editar(Ciudad ciudad)
        {
            var ciudadInDb = _context.Ciudades
                .SingleOrDefault(p => p.CiudadId == ciudad.CiudadId);
            if (ciudadInDb == null)
            {
                throw new Exception("Borrado por otro usuario");
            }
            ciudadInDb.NombreCiudad = ciudad.NombreCiudad;
            _context.Entry(ciudadInDb).State = EntityState.Modified;
        }

        public bool EstaRelacionado(Ciudad ciudad)
        {
            return false;
        }

        public bool Existe(Ciudad ciudad)
        {
            if (ciudad.CiudadId == 0)
            {
                return _context.Ciudades
                    .Any(p => p.NombreCiudad == ciudad.NombreCiudad);
            }
            return _context.Ciudades
                .Any(p => p.NombreCiudad == ciudad.NombreCiudad && p.CiudadId != ciudad.CiudadId);
        }

        public int GetCantidad()
        {
            return _context.Ciudades.Count();
        }

        public List<CiudadListDto> GetCiudades()
        {
            return _context.Ciudades
                .OrderBy(p => p.NombreCiudad)
                .Select(p => new CiudadListDto
                {
                    CiudadId = p.CiudadId,
                    NombreCiudad = p.NombreCiudad,
                    NombrePais = p.Pais.NombrePais,
                })
                .ToList();
        }

        public Ciudad GetCiudadPorId(int ciudadId)
        {
            var ciudadInDb = _context.Ciudades
            .SingleOrDefault(p => p.CiudadId == ciudadId);

            if (ciudadInDb == null)
            {
                throw new Exception("Error al buscar la ciudad");
            }
            return ciudadInDb;
        }
    }
}
