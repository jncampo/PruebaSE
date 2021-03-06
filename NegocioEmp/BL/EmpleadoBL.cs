﻿using NegocioEmp.DAL;
using NegocioEmp.Entidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioEmp.BL
{
    public class EmpleadoBL:IEmpleadoBL
    {
        /// <summary>
        /// 
        /// </summary>
        public EmpleadoBL()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmpleadoM> ObtenerLista()
        {

            IEmpleadoDAL instancia = new EmpleadoDAL();
            return instancia.ObtenerLista();

        }

        public IEnumerable<EmpleadoM> ObtenerLista(EmpleadoM item)
        {

            IEmpleadoDAL instancia = new EmpleadoDAL();
            return instancia.ObtenerLista(item);

        }

        public void Eliminar(EmpleadoM item)
        {
            IEmpleadoDAL instancia = new EmpleadoDAL();
            instancia.Eliminar(item);
        }

        public EmpleadoM Crear(EmpleadoM item)
        {
            IEmpleadoDAL instancia = new EmpleadoDAL();
            return instancia.Crear(item);
        }

        public EmpleadoM Modificar(EmpleadoM item)
        {
            IEmpleadoDAL instancia = new EmpleadoDAL();
            return instancia.Modificar(item);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
