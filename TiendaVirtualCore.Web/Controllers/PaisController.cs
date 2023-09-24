using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TiendaVirtualCore.Entities.Models;
using TiendaVirtualCore.Servicios.Interfaces;
using TiendaVirtualCore.Web.ViewModels.Pais;
using TiendaVirtualCore.Web.ViewModels.Pais;

namespace TiendaVirtualCore.Web.Controllers
{
    public class PaisController : Controller
    {
        private readonly IServiciosPaises _servicio;
        private readonly IMapper _mapper;

        public PaisController(IServiciosPaises servicio, IMapper mapper)
        {
            _servicio = servicio;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var listaPaises = _servicio.GetPaises();
            var listaPaisesVm = _mapper.Map<List<PaisListVm>>(listaPaises);
            return View(listaPaisesVm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PaisEditVm paisVm)
        {
            if (!ModelState.IsValid)
            {
                return View(paisVm);
            }
            Pais pais = _mapper.Map<Pais>(paisVm);
            if (_servicio.Existe(pais))
            {
                ModelState.AddModelError(string.Empty, "País existente");
                return View(paisVm);
            }
            try
            {
                _servicio.Guardar(pais);
                TempData["success"] = "Registro agregado";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult Delete(int? paisId)
        {
            if (paisId == null || paisId == 0)
            {
                return NotFound();
            }
            var pais = _servicio.GetPaisPorId(paisId.Value);
            if (pais == null)
            {
                return NotFound();
            }
            var paisVm = _mapper.Map<PaisEditVm>(pais);
            return View(paisVm);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int paisId)
        {
            var pais = _servicio.GetPaisPorId(paisId);
            if (pais == null)
            {
                return NotFound();
            }
            try
            {
                _servicio.Borrar(pais.PaisId);
                TempData["success"] = "Registro borrado";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                var paisVm = _mapper.Map<PaisEditVm>(pais);

                return View(paisVm);

            }
        }
    }
}
