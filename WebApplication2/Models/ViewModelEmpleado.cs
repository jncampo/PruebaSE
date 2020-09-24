using NegocioEmp.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ViewModelEmpleado
    {
        public string Id { get; set; }
        public int Id_Tipo_Documento { get; set; }
        public string Nombre_Tipo_Documento { get; set; }
        public string Numero_Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Estado { get; set; }

        public ViewModelEmpleado()
        {

        }
        public ViewModelEmpleado(EmpleadoM item)
        {
            Id = item.Id_Empleado;
            Id_Tipo_Documento = item.Id_Tipo_Documento;
            Nombre_Tipo_Documento = "";
            Numero_Documento = item.Numero_Documento;
            Nombre = item.Nombre_Empleado;
            Apellido = item.Apellido_Empleado;
            Estado = item.Estado_Empleado;

        }

        public EmpleadoM Castear()
        {
            EmpleadoM item = new EmpleadoM
            {
                Id_Empleado = Id,
                Id_Tipo_Documento = Id_Tipo_Documento,
                Numero_Documento = Numero_Documento,
                Nombre_Empleado = Nombre,
                Apellido_Empleado = Apellido,
                Estado_Empleado = Estado
            };
            return item;
        }
    }
}