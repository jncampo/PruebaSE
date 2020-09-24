using NegocioEmp.BL;
using NegocioEmp.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmpleadosController : Controller
    {
        private WebApplication2Context db = new WebApplication2Context();


        #region eventos
        // GET: Empleados
        public ActionResult Index()
        {
            EmpleadoBL neg = new EmpleadoBL();
            List<EmpleadoM> Lst=neg.ObtenerLista().ToList();
            List<ViewModelEmpleado> Lista = new List<ViewModelEmpleado>();
            foreach(EmpleadoM item in Lst)
            {
                ViewModelEmpleado tem = new ViewModelEmpleado(item);
                Lista.Add(tem);
            }
            return View(Lista);
        }

        // GET: Empleados/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoBL neg = new EmpleadoBL();
            EmpleadoM temp = new EmpleadoM
            {
                Id_Empleado = id,
                Estado_Empleado = true
            };
            temp = neg.ObtenerLista(temp).FirstOrDefault();
            ViewBag.TiposDocumento = ObtenerTipoDocumentos();
            ViewModelEmpleado viewModelEmpleado = new ViewModelEmpleado(temp);
            //ViewModelEmpleado viewModelEmpleado = db.ViewModelEmpleadoes.Find(id);
            if (viewModelEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(viewModelEmpleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            
            ViewBag.TiposDocumento = ObtenerTipoDocumentos();
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Tipo_Documento,Numero_Documento,Nombre,Apellido,EStado")] ViewModelEmpleado viewModelEmpleado)
        {
            if (ModelState.IsValid)
            {
                EmpleadoBL neg = new EmpleadoBL();
                viewModelEmpleado.Estado = true;
                EmpleadoM item = viewModelEmpleado.Castear();
                neg.Crear(item);
                //db.ViewModelEmpleadoes.Add(viewModelEmpleado);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModelEmpleado);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoBL neg = new EmpleadoBL();
            EmpleadoM temp = new EmpleadoM
            {
                Id_Empleado = id,
                Estado_Empleado=true
            };
            temp = neg.ObtenerLista(temp).FirstOrDefault();
            ViewBag.TiposDocumento = ObtenerTipoDocumentos();
            ViewModelEmpleado viewModelEmpleado = new ViewModelEmpleado(temp); //db.ViewModelEmpleadoes.Find(id);
            if (viewModelEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(viewModelEmpleado);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Tipo_Documento,Numero_Documento,Nombre,Apellido,EStado")] ViewModelEmpleado viewModelEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewModelEmpleado).State = EntityState.Modified;
               
                EmpleadoM item = viewModelEmpleado.Castear();
                EmpleadoBL neg = new EmpleadoBL();
                neg.Modificar(item);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModelEmpleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ViewModelEmpleado viewModelEmpleado = db.ViewModelEmpleadoes.Find(id);
            EmpleadoBL neg = new EmpleadoBL();
            EmpleadoM temp = new EmpleadoM
            {
                Id_Empleado = id,
                Estado_Empleado = true
            };
            temp = neg.ObtenerLista(temp).FirstOrDefault();
            ViewModelEmpleado viewModelEmpleado = new ViewModelEmpleado(temp);
            if (viewModelEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(viewModelEmpleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            //ViewModelEmpleado viewModelEmpleado = db.ViewModelEmpleadoes.Find(id);
            EmpleadoBL neg = new EmpleadoBL();
            EmpleadoM temp = new EmpleadoM
            {
                Id_Empleado = id,
                Estado_Empleado = true
            };
            temp = neg.ObtenerLista(temp).FirstOrDefault();
            if(temp!=null)
            {
                temp.Estado_Empleado = false;
                neg.Modificar(temp);
            }
            //db.ViewModelEmpleadoes.Remove(viewModelEmpleado);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion eventos

        #region metodos

        public SelectList ObtenerTipoDocumentos()
        {
            List<ViewModelTipoDocumento> lst = new List<ViewModelTipoDocumento>();

            lst.Add(new ViewModelTipoDocumento { Id=1,Nombre="CEDULA" });
            lst.Add(new ViewModelTipoDocumento { Id = 2, Nombre = "TARJETA DE IDENTIDAD" });
            lst.Add(new ViewModelTipoDocumento { Id = 3, Nombre = "CEDULA EXTRANJERIA" });
            ViewBag.data = new SelectList(lst, "Id", "Nombre");
            return new SelectList(lst, "Id", "Nombre");
        }
        #endregion metodos

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
