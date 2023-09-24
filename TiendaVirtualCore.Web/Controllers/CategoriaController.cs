using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TiendaVirtualCore.Entities.Models;
using TiendaVirtualCore.Servicios.Interfaces;
using TiendaVirtualCore.Web.ViewModels.Categoria;

namespace TiendaVirtualCore.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IServiciosCategorias _servicio;
        private readonly IMapper _mapper;


        public CategoriaController(IServiciosCategorias servicio, 
            IMapper mapper)
        {
            _servicio = servicio;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var listaCategorias=_servicio.GetCategorias();
            var listaCategoriasVm=_mapper.Map<List<CategoriaListVm>>(listaCategorias);
            return View(listaCategoriasVm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoriaEditVm categoriaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoriaVm);
            }
            Categoria categoria = _mapper.Map<Categoria>(categoriaVm);
            if (_servicio.Existe(categoria))
            {
                ModelState.AddModelError(string.Empty, "Categoria existente!!!");
                return View(categoriaVm);
            }
            try
            {
                _servicio.Guardar(categoria);
                TempData["success"] = "Registro agregado";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public IActionResult Edit(int? categoriaId)
        {
            if (categoriaId==null || categoriaId==0)
            {
                return NotFound();
            }
            var categoria = _servicio.GetCategoriaPorId(categoriaId.Value);
            if (categoria==null)
            {
                return NotFound();
            }
            var categoriaVm = _mapper.Map<CategoriaEditVm>(categoria);
            return View(categoriaVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoriaEditVm categoriaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoriaVm);
            }
            Categoria categoria = _mapper.Map<Categoria>(categoriaVm);
            if (_servicio.Existe(categoria))
            {
                ModelState.AddModelError(string.Empty, "Categoria existente!!!");
                return View(categoriaVm);
            }
            try
            {
                _servicio.Guardar(categoria);
                TempData["success"] = "Registro editado";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public IActionResult Delete(int? categoriaId)
        {
            if (categoriaId == null || categoriaId == 0)
            {
                return NotFound();
            }
            var categoria = _servicio.GetCategoriaPorId(categoriaId.Value);
            if (categoria == null)
            {
                return NotFound();
            }
            var categoriaVm = _mapper.Map<CategoriaEditVm>(categoria);
            return View(categoriaVm);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int categoriaId)
        {
            var categoria = _servicio.GetCategoriaPorId(categoriaId);
            if (categoria == null)
            {
                return NotFound();
            }
            try
            {
                _servicio.Borrar(categoria.CategoriaId);
                TempData["success"] = "Registro borrado";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                var categoriaVm = _mapper.Map<CategoriaEditVm>(categoria);

                return View(categoriaVm);

            }
        }

    }
}
