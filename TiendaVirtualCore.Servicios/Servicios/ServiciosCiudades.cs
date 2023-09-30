using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtualCore.Data.Interfaces;
using TiendaVirtualCore.Data;
using TiendaVirtualCore.Entities.Dtos.Ciudad;
using TiendaVirtualCore.Entities.Models;
using TiendaVirtualCore.Servicios.Interfaces;

namespace TiendaVirtualCore.Servicios.Servicios
{
    public class ServiciosCiudades : IServiciosCiudades
    {
        private readonly IRepositorioCiudades _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosCiudades(IRepositorioCiudades repositorioCiudades, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorioCiudades;
            _unitOfWork = unitOfWork;
        }
        public void Borrar(int id)
        {
            try
            {
                _repositorio.Borrar(id);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EstaRelacionado(Ciudad ciudad)
        {
            try
            {
                return _repositorio.EstaRelacionado(ciudad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Existe(Ciudad ciudad)
        {
            try
            {
                return _repositorio.Existe(ciudad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetCantidad()
        {
            return _repositorio.GetCantidad();
        }

        public List<CiudadListDto> GetCiudades()
        {
            try
            {
                return _repositorio.GetCiudades();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Ciudad GetCiudadPorId(int ciudadId)
        {
            try
            {
                return _repositorio.GetCiudadPorId(ciudadId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Guardar(Ciudad ciudad)
        {
            try
            {
                if (ciudad.CiudadId == 0)
                {
                    _repositorio.Agregar(ciudad);

                }
                else
                {
                    _repositorio.Editar(ciudad);
                }
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

