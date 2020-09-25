using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unidad2Actividad4.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Unidad2Actividad4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Peliculas()
        {
            pixarContext context = new pixarContext();
            var pelicula = context.Pelicula.OrderBy(x => x.Nombre);
            if (pelicula == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(pelicula);
            }
        }
        [Route("{id}")]
        public IActionResult Pelicula(string id)
        {
            var nombre = id.Replace("_", " ").ToLower();
            pixarContext context = new pixarContext();
            var pelicula = context.Pelicula.Include(x => x.Apariciones).ThenInclude(x=>x.IdPersonajeNavigation).FirstOrDefault(x => x.Nombre.ToLower() == nombre);

            if (pelicula == null)
            {
                return RedirectToAction("Peliculas");
            }
            else
            {

                PersonajesViewModels vm = new PersonajesViewModels();
                vm.NombrePelicula = pelicula.Nombre;
                vm.Id = pelicula.Id;
                vm.NombreOriginal = pelicula.NombreOriginal;
                vm.FechaEstreno = pelicula.FechaEstreno;
                vm.Descripcion = pelicula.Descripción;
                vm.Apariciones = pelicula.Apariciones;
                return View(vm);
            }
        }
        
        public IActionResult Cortos()
        {
            pixarContext contexto = new pixarContext();
            CortosViewModel vm = new CortosViewModel();
            vm.Categorias = contexto.Categoria.Include(x => x.Cortometraje);
            return View(vm);
        }
        [Route("{id}/Cortometraje")]
        public IActionResult Cortometraje(string id)
        {
            
            var nombre = id.Replace("_", " ").ToLower();
            pixarContext context = new pixarContext();
            var cortometraje = context.Cortometraje.FirstOrDefault(x=>x.Nombre==nombre);

            if (cortometraje == null)
            {
                return RedirectToAction("Cortos");
            }
            else
            {
                return View(cortometraje);

            }
        }
    }
}
