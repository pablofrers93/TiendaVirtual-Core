using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtualCore.Data;
using TiendaVirtualCore.Data.Interfaces;
using TiendaVirtualCore.Data.Repositorios;
using TiendaVirtualCore.Entities.Dtos.Pais;
using TiendaVirtualCore.Entities.Models;
using TiendaVirtualCore.Servicios.Interfaces;

namespace TiendaVirtualCore.Servicios.Servicios
{
    public class ServiciosPaises : IServiciosPaises
    {
        private readonly IRepositorioPaises _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosPaises(IRepositorioPaises repositorioPaises, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorioPaises;
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

        public bool EstaRelacionado(Pais pais)
        {
            try
            {
                return _repositorio.EstaRelacionado(pais);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Existe(Pais pais)
        {
            try
            {
                return _repositorio.Existe(pais);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PaisListDto> GetPaises()
        {
            try
            {
                return _repositorio.GetPaises();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Pais GetPaisPorId(int paisId)
        {
            try
            {
                return _repositorio.GetPaisPorId(paisId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Guardar(Pais pais)
        {
            try
            {
                if (pais.PaisId == 0)
                {
                    _repositorio.Agregar(pais);

                }
                else
                {
                    _repositorio.Editar(pais);
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
