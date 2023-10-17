using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TiendaVirtualCore.Entities.Models;
using TiendaVirtualCore.Servicios.Interfaces;
using TiendaVirtualCore.Web.ViewModels.Ciudad;

namespace TiendaVirtualCore.Web.Controllers
{
    public class CiudadController : Controller
    {
        private readonly IServiciosCiudades _servicio;
        private readonly IServiciosPaises _servicioPaises;
        private readonly IMapper _mapper;

        public CiudadController(IServiciosCiudades servicio, 
                                IMapper mapper,
                                IServiciosPaises servicioPaises)
        {
            _servicio = servicio;
            _servicioPaises = servicioPaises;
            _mapper = mapper;
        }

        public IActionResult Index(string SortBy = "City")
        {
            var listaCiudades = _servicio.GetCiudades();
            var listaCiudadesVm = _mapper.Map<List<CiudadListVm>>(listaCiudades);

            if (SortBy == "City")
            {
                listaCiudadesVm = listaCiudadesVm.OrderBy(c=> c.NombreCiudad).ToList();
            }
            else
            {
                listaCiudadesVm = listaCiudadesVm.OrderBy(c => c.NombrePais)
                    .ThenBy(c => c.NombreCiudad).ToList();
            }
            var ciudadVm = new CiudadSortListVm
            {
                Ciudades = listaCiudadesVm,
                Sorts = new Dictionary<string, string> {
                    {"By City", "City"},
                    {"By Country", "Country"}
            },
                SortBy = SortBy
            };
            return View(ciudadVm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CiudadEditVm ciudadVm = new CiudadEditVm()
            {
                Paises = _servicioPaises.GetPaisesDropDown()
            };
            return View(ciudadVm);
        }
        [HttpPost]
        public IActionResult Create(CiudadEditVm ciudadVm)
        {
            if (!ModelState.IsValid)
            {
                ciudadVm.Paises = _servicioPaises.GetPaisesDropDown();
                return View(ciudadVm);
            }
            Ciudad ciudad = _mapper.Map<Ciudad>(ciudadVm);
            if (_servicio.Existe(ciudad))
            {
                ModelState.AddModelError(string.Empty, "City already exists");
                ciudadVm.Paises = _servicioPaises.GetPaisesDropDown();
                return View(ciudadVm);
            }
            try
            {
                _servicio.Guardar(ciudad);
                TempData["success"] = "City added succesfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                ciudadVm.Paises = _servicioPaises.GetPaisesDropDown();
                return View(ciudadVm);
            }
        }
        [HttpGet]
        public IActionResult Edit(int? ciudadId)
        {
            if (ciudadId == 0 || ciudadId == null)
            {
                return NotFound();
            }
            Ciudad ciudad = _servicio.GetCiudadPorId(ciudadId.Value);
            if (ciudad == null)
            {
                return NotFound();
            }
            CiudadEditVm ciudadVm = _mapper.Map<CiudadEditVm>(ciudad);
            ciudadVm.Paises = _servicioPaises.GetPaisesDropDown();  
            return View(ciudadVm);
        }
        [HttpPost]
        public IActionResult Edit(CiudadEditVm ciudadVm)
        {
            if (!ModelState.IsValid)
            {
                ciudadVm.Paises = _servicioPaises.GetPaisesDropDown();
                return View(ciudadVm);
            }
            Ciudad ciudad = _mapper.Map<Ciudad>(ciudadVm);
            if (_servicio.Existe(ciudad))
            {
                ModelState.AddModelError(string.Empty, "City already exists");
                ciudadVm.Paises = _servicioPaises.GetPaisesDropDown();
                return View(ciudadVm);
            }
            try
            {
                _servicio.Guardar(ciudad);
                TempData["success"] = "City edited succesfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                ciudadVm.Paises = _servicioPaises.GetPaisesDropDown();
                return View(ciudadVm);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? ciudadId)
        {
            if (ciudadId == 0 || ciudadId == null)
            {
                return NotFound();
            }
            Ciudad ciudad = _servicio.GetCiudadPorId(ciudadId.Value);
            Pais pais = _servicioPaises.GetPaisPorId(ciudad.PaisId);
            if (ciudad == null)
            {
                return NotFound();
            }
            CiudadListVm ciudadVm = _mapper.Map<CiudadListVm>(ciudad);
            ciudadVm.NombrePais = pais.NombrePais;
            return View(ciudadVm);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int ciudadId)
        {
            Ciudad ciudad = _servicio.GetCiudadPorId(ciudadId);
            if (ciudad == null)
            {
                return NotFound();
            }
            try
            {
                _servicio.Borrar(ciudad.CiudadId);
                TempData["success"] = "City deleted succesfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                CiudadListVm ciudadVm = _mapper.Map<CiudadListVm>(ciudad);
                return View(ciudadVm);
            }
        }
    }
}
