using Microsoft.AspNetCore.Mvc;
using TpCrudAsp.Models;
using TpCrudAsp.Datos;

namespace TpCrudAsp.Controllers
{
    public class CrudController : Controller
    {
        AutoDatos autoDatos = new AutoDatos(); //instanciamos autoDatos y usamos los using de models y datos del proyecto
        public IActionResult Index()
        {
            return View();
        }
        [Route("Contacto")]
        public IActionResult Contacto()
        {
            return View();
        }
        [Route("ListadoDeAutos")]
        public IActionResult Listar()
        {
            var oAutos = autoDatos.Listar();
            return View(oAutos);
            //return View();
        }

        [Route("Guardar")]
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarForm(ModelAutos oAutos)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = autoDatos.Guardar(oAutos);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
        [Route("Editar")]
        public IActionResult Editar(int id) // el argumento que se le pasa hay que ponerlo en la vista el asp-route-(argumento)
        {
            var oAutos = autoDatos.Obtener(id);
            return View(oAutos);
        }

        [HttpPost]
        public IActionResult Editar(ModelAutos oAutos)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = autoDatos.Editar(oAutos);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }

        }
        [Route("Eliminar")]
        public IActionResult Eliminar(int id)
        {
            var oAutos = autoDatos.Obtener(id);

            return View(oAutos);
        }

        [HttpPost]
        public IActionResult Eliminar(ModelAutos oAutos)
        {
            var respuesta = autoDatos.Eliminar(oAutos.idAuto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
       

    }
}
