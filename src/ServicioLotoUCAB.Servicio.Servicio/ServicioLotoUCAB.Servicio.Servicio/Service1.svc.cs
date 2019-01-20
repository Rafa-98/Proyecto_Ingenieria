using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using ServicioLotoUCAB.Servicio.Logica.Comandos;
using ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService;
using ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.ComandosPagos;
using System;
using System.Net;
using System.ServiceModel.Web;


namespace ServicioLotoUCAB.Servicio.Servicio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        // DEL PROYECTO OFICIALMENTE ---------------------------------------------
       
        public string GestionarPago(string serial)
        {
            ComandoPagos comandoPagos = FabricaComandos.FabricarComandoPagos(serial);
            return comandoPagos.pagar();
        }

        //-------------------------------------------------------------------



















        public string Pago(string serial)
        {
            return BDconector2.pago(serial);
        }

        DaoPagos BDconector2 = new DaoPagos();

            public string Consulta(string que, string quien)
            {
                return BDconector2.rConsult(que, quien);
            }

        public string Impresion()
        {
            return BDconector2.Imprime();
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
        }

    }
    
}
