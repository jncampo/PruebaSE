using NegocioEmp.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NegocioEmp.DAL
{
    public interface IEmpleadoDAL
    {
        IEnumerable<EmpleadoM> ObtenerLista();
        IEnumerable<EmpleadoM> ObtenerLista(EmpleadoM itemFiltros);
        void Eliminar(EmpleadoM item);
        EmpleadoM Crear(EmpleadoM item);
        EmpleadoM Modificar(EmpleadoM item);
    }
}
