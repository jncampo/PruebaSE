using Dapper;
using NegocioEmp.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEmp.DAL
{
    public class ViajeDAL : IViajeDAL
    {
        public IEnumerable<ViajeM> ObtenerLista()
        {
            using (IDbConnection conexion = new SqlConnection(ConexionBD.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                /*parametros.Add("@P_Id_Empleado", null);
				parametros.Add("@P_Numero_Documento_Empleado", null);
				parametros.Add("@P_Id_Tipo_Documento_Empleado", null);*/
                //parametros.Add("@P_Estado_Empleado", true);
                var LstViajes = conexion.Query<ViajeM>("dbo.SP_VIAJE_SELECT", param: parametros, commandType: CommandType.StoredProcedure);
                return LstViajes;
            }
        }
        public IEnumerable<ViajeM> ObtenerLista(ViajeM itemFiltros)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionBD.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                if (itemFiltros.Id_Viaje != null)
                {
                    parametros.Add("@P_Id_Viaje", Guid.Parse(itemFiltros.Id_Viaje));
                }
                if (itemFiltros.Id_Empleado != null)
                {
                    parametros.Add("@P_Id_Empleado", Guid.Parse(itemFiltros.Id_Empleado));
                }
                if (itemFiltros.Id_Vehiculo != null)
                {
                    parametros.Add("@P_Id_Vehiculo", Guid.Parse(itemFiltros.Id_Vehiculo));
                }
                parametros.Add("@P_Placa_Vehiculo", itemFiltros.Placa_Vehiculo);
                parametros.Add("@P_Hora_Inicio_Viaje", itemFiltros.Hora_Inicio_Viaje);
                parametros.Add("@P_Hora_Fin_Viaje", itemFiltros.Hora_Fin_Viaje);
                //parametros.Add("@P_Estado_Empleado", true);
                var lstEmpleados = conexion.Query<ViajeM>("dbo.SP_VIAJE_SELECT2", param: parametros, commandType: CommandType.StoredProcedure);
                return lstEmpleados;
            }
        }

        public string Crear(ViajeM item)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(ConexionBD.ObtenerCadenaConexion()))
                {
                    conexion.Open();
                    var parametros = new DynamicParameters();
                    //parametros.Add("@ParentGroupId", SqlDbType.UniqueIdentifier).Value = item.Id_Empleado;
                    parametros.Add("@P_Id_Empleado", Guid.Parse(item.Id_Empleado));
                    parametros.Add("@P_Origen_Viaje", item.Origen_Viaje);
                    parametros.Add("@P_Destino_Viaje", item.Destino_Viaje);
                    parametros.Add("@P_Nombre_Pasajero", item.Nombre_Pasajero);
                    parametros.Add("@P_Id_Vehiculo", Guid.Parse(item.Id_Vehiculo));
                    parametros.Add("@P_Hora_Inicio_Viaje", item.Hora_Inicio_Viaje);
                    parametros.Add("@P_Hora_Fin_Viaje", item.Hora_Fin_Viaje);
                    parametros.Add("@P_Estado_Viaje", true);
                    var Persona = conexion.Query("dbo.SP_VIAJE_INSERT", param: parametros, commandType: CommandType.StoredProcedure);
                    return "ok";
                }
            }
            catch(Exception e)
            {
                return "fallo";
            }
        }
    }
}
