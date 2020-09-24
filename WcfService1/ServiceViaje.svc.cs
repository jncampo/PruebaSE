using NegocioEmp.BL;
using NegocioEmp.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IServiceViaje
    {
        public string RegistrarViajes(string IdEmpleado, string origenViaje, string DestinoViaje, string NombrePasajero, string id_Vehiculo, DateTime HoraInicio, DateTime HoraFin)
        {
            ViajeBL Negocio = new ViajeBL();
            return Negocio.RegistrarViajes( IdEmpleado,  origenViaje,  DestinoViaje,  NombrePasajero,  id_Vehiculo,  HoraInicio,  HoraFin);
            
        }

        public string RegistrarViajes2(int IdTipoDocuemnto, string IdNumeroDocumento, string origenViaje, string DestinoViaje, string NombrePasajero, string Placa, DateTime HoraInicio, DateTime HoraFin)
        {
            return "ok";
        }

        public IEnumerable<ViajeM> BuscarViajesTodos()
        {
            //List<ViajeM> Lst = new List<ViajeM>();
            ViajeBL Negocio = new ViajeBL();
            return  Negocio.BuscarViajesTodos(); 
        }
        public IEnumerable<ViajeM> BuscarViajes(DateTime RangoInicial, DateTime RangoFinal, string IdVehiculo)
        {
            ViajeBL Negocio = new ViajeBL();
            return Negocio.BuscarViajes( RangoInicial,  RangoFinal,  IdVehiculo);

        }
        public IEnumerable<ViajeM> BuscarViajes2(DateTime RangoInicial, DateTime RangoFinal, string placa)
        {
            ViajeBL Negocio = new ViajeBL();
            return Negocio.BuscarViajes2(RangoInicial, RangoFinal, placa);

        }
        /*public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }*/


    }
}
