using BEUEjercicio;
using BEUEjercicio.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Mvc;
using WebApiEscolastico.Models;

namespace WebApiEscolastico.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class AlumnoController : ApiController
    {
        [ResponseType(typeof(Alumno))]
        public IHttpActionResult Get()
        {
            List<Alumno> todos = AlumnoBLL.List();
            return Json(todos);
        }

        [ResponseType(typeof(Alumno))]
        public IHttpActionResult Delete(int id)
        {
            Message result = new Message();
            try
            {
                AlumnoBLL.Delete(id);
                result.title = "¡Correcto!";
                result.text = "El alumno fue eliminado correctamente";
                result.icon = "success";
            }
            catch (Exception ex) {
                result.title = "¡Error!";
                result.text = "Hubo un error al intentar eliminar ";
                result.console = ex.Message;
                result.icon = "error";
            }            
            return Json(result);
        }


    }
}