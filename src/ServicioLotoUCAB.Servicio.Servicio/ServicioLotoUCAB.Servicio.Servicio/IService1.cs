using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ServicioLotoUCAB.Servicio.Servicio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Consulta", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string Consulta(string que, string quien);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         string Impresion();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Pago", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string Pago(string serial);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}