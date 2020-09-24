using NegocioEmp.DAL;
using NegocioEmp.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEmp.BL
{
    public class ViajeBL:IViajeBL
    {
       
        public string RegistrarViajes(string IdEmpleado, string origenViaje, string DestinoViaje, string NombrePasajero, string IdVehiculo, DateTime HoraInicio, DateTime HoraFin)
        {
            ViajeM item = new ViajeM
            {
                Id_Empleado = IdEmpleado,
                Origen_Viaje = origenViaje,
                Destino_Viaje = DestinoViaje,
                Nombre_Pasajero = NombrePasajero,
                Id_Vehiculo = IdVehiculo,
                Hora_Inicio_Viaje = HoraInicio,
                Hora_Fin_Viaje = HoraFin

            };

            IViajeDAL instancia = new ViajeDAL();
            return instancia.Crear(item);
        }

      
        public string RegistrarViajes2(int IdTipoDocuemnto, string IdNumeroDocumento, string origenViaje, string DestinoViaje, string NombrePasajero, string Placa, DateTime HoraInicio, DateTime HoraFin)
        {
            return "ok";
        }

        public IEnumerable<ViajeM> BuscarViajesTodos()
        {
            IViajeDAL instancia = new ViajeDAL();

            return instancia.ObtenerLista();
        }
        public IEnumerable<ViajeM> BuscarViajes(DateTime RangoInicial, DateTime RangoFinal, string IdVehiculo)
        {
            IViajeDAL instancia = new ViajeDAL();
            ViajeM filtro = new ViajeM
            {
                Id_Vehiculo = IdVehiculo,
                Hora_Inicio_Viaje = RangoInicial,
                Hora_Fin_Viaje = RangoFinal
            };
            return instancia.ObtenerLista(filtro);

        }
        public IEnumerable<ViajeM> BuscarViajes2(DateTime RangoInicial, DateTime RangoFinal, string placa)
        {
            IViajeDAL instancia = new ViajeDAL();
            ViajeM filtro = new ViajeM
            {
                Placa_Vehiculo = placa,
                Hora_Inicio_Viaje = RangoInicial,
                Hora_Fin_Viaje = RangoFinal
            };
            return instancia.ObtenerLista(filtro);

        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
