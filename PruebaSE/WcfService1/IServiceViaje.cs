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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceViaje
    {

        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: agregue aquí sus operaciones de servicio

        [OperationContract]
        string RegistrarViajes(string  IdEmpleado,string origenViaje,string DestinoViaje,string NombrePasajero,string id_Vehiculo,DateTime HoraInicio,DateTime HoraFin);

        [OperationContract]
        string RegistrarViajes2(int IdTipoDocuemnto,string IdNumeroDocumento, string origenViaje, string DestinoViaje, string NombrePasajero, string Placa, DateTime HoraInicio, DateTime HoraFin);

        [OperationContract]
        IEnumerable<ViajeM> BuscarViajesTodos();

        [OperationContract]
        IEnumerable<ViajeM> BuscarViajes(DateTime RangoInicial, DateTime RangoFinal,string IdVehiculo);

        [OperationContract]
        IEnumerable<ViajeM> BuscarViajes2(DateTime RangoInicial, DateTime RangoFinal, string placa);
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
