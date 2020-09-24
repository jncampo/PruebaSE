using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Text;
using Dapper;
using NegocioEmp.Entidad;

namespace NegocioEmp.DAL
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
				var parametros = new DynamicParameters();
				/*parametros.Add("@P_Id_Empleado", null);
				parametros.Add("@P_Numero_Documento_Empleado", null);
				parametros.Add("@P_Id_Tipo_Documento_Empleado", null);*/
				parametros.Add("@P_Estado_Empleado", true);
				var lstEmpleados = conexion.Query<EmpleadoM>("dbo.SP_EMPLEADO_SELECT", param: parametros, commandType: CommandType.StoredProcedure);
				return lstEmpleados;
			}
		}

		public IEnumerable<EmpleadoM> ObtenerLista(EmpleadoM itemFiltros)
		{
			using (IDbConnection conexion = new SqlConnection(ConexionBD.ObtenerCadenaConexion()))
			{
				conexion.Open();
				var parametros = new DynamicParameters();
				parametros.Add("@P_Id_Empleado", itemFiltros.Id_Empleado);
				parametros.Add("@P_Numero_Documento_Empleado", itemFiltros.Numero_Documento);
				parametros.Add("@P_Id_Tipo_Documento_Empleado", itemFiltros.Id_Tipo_Documento == 0 ? null : (int?)itemFiltros.Id_Tipo_Documento);
				parametros.Add("@P_Estado_Empleado", itemFiltros.Estado_Empleado);
				var lstEmpleados = conexion.Query<EmpleadoM>("dbo.SP_EMPLEADO_SELECT", param: parametros, commandType: CommandType.StoredProcedure);
				return lstEmpleados;
			}
		}

		public EmpleadoM Crear(EmpleadoM item)
		{
			using (IDbConnection conexion = new SqlConnection(ConexionBD.ObtenerCadenaConexion()))
			{
				conexion.Open();
				var parametros = new DynamicParameters();
				parametros.Add("@P_Nombre_Empleado", item.Nombre_Empleado);
				parametros.Add("@P_Apellido_Empledo", item.Apellido_Empleado);
				parametros.Add("@P_Numero_Documento_Empleado", item.Numero_Documento);
				parametros.Add("@P_Id_Tipo_Documento_Empleado", item.Id_Tipo_Documento);
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
				parametros.Add("@P_Id_Empleado", item.Id_Empleado);
				parametros.Add("@P_Nombre_Empleado", item.Nombre_Empleado);
				parametros.Add("@P_Apellido_Empledo", item.Apellido_Empleado);
				parametros.Add("@P_Numero_Documento_Empleado", item.Numero_Documento);
				parametros.Add("@P_Id_Tipo_Documento_Empleado", item.Id_Tipo_Documento);
				parametros.Add("@P_Estado_Empleado", item.Estado_Empleado);
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
