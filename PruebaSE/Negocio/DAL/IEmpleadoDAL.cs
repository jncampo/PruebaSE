using Negocio.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.DAL
{
    public interface IEmpleadoDAL
    {
        IEnumerable<EmpleadoM> ObtenerLista();
        void Eliminar(EmpleadoM item);
        EmpleadoM Crear(EmpleadoM item);
        EmpleadoM Modificar(EmpleadoM item);
    }
}
