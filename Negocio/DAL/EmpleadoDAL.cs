using Negocio.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Text;
using Dapper;

namespace Negocio.DAL
{
    public class EmpleadoDAL:IEmpleadoDAL
    {
		public EmpleadoDAL()
		{

		}
		public IEnumerable<EmpleadoM> ObtenerLista()
		{
			using (IDbConnection conexion = new SqlConnection(ConexionBD.ObtenerCadenaConexion()))
			{
				conexion.Open();
				var lstEmpleados = conexion.Query<EmpleadoM>("dbo.SP_EMPLEADO_SELECT", commandType: CommandType.StoredProcedure);
				return lstEmpleados;
			}
		}

		public EmpleadoM Crear(EmpleadoM item)
		{
			using (IDbConnection conexion = new SqlConnection(ConexionBD.ObtenerCadenaConexion()))
			{
				conexion.Open();
				var parametros = new DynamicParameters();
				parametros.Add("@p_cedula", item.Id_Empleado);
				parametros.Add("@p_cedula", item.Id_Empleado);
				parametros.Add("@p_cedula", item.Id_Empleado);
				parametros.Add("@p_cedula", item.Id_Empleado);
				parametros.Add("@p_cedula", item.Id_Empleado);
				parametros.Add("@p_cedula", item.Id_Empleado);
				parametros.Add("@p_cedula", item.Id_Empleado);
				parametros.Add("@p_cedula", item.Id_Empleado);
				var Persona = conexion.Query("dbo.SP_EMPLEADO_INSERT", param: parametros, commandType: CommandType.StoredProcedure);
				return item;
			}
		}
		public EmpleadoM Modificar(EmpleadoM item)
		{
			using (IDbConnection conexion = new SqlConnection(ConexionBD.ObtenerCadenaConexion()))
			{
				conexion.Open();
				var parametros = new DynamicParameters();
				//parametros.Add("@p_cedula", item.Cedula);
				//parametros.Add("@p_nombre", item.Nombre);
				//parametros.Add("@p_telefono", item.Telefono);
				var Persona = conexion.Query("dbo.SP_EMPLEADO_UPDATE", param: parametros, commandType: CommandType.StoredProcedure);
				return item;
			}
		}

		/// <summary>
		/// EL BORRADO ES UN BORRADO LOGICO POR LO TANTO SE DESACTIVA EL REGISTRO
		/// </summary>
		/// <param name="item"></param>
		public void Eliminar(EmpleadoM item)
		{
			using (IDbConnection conexion = new SqlConnection(ConexionBD.ObtenerCadenaConexion()))
			{
				conexion.Open();
				var parametros = new DynamicParameters();
				//parametros.Add("@p_cedula", item.Cedula);
				var Persona = conexion.Query<EmpleadoM>("dbo.SP_EMPLEADO_UPDATE", param: parametros, commandType: CommandType.StoredProcedure);

			}
		}

		public EmpleadoM Detalle(EmpleadoM item)
		{
			return null;
		}
	}
}
