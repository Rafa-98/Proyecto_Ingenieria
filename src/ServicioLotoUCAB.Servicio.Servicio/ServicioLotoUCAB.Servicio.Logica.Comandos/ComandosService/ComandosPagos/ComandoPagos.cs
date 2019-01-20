using ServicioLotoUCAB.Servicio.AccesoDatos;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.ComandosPagos
{
    public class ComandoPagos
    {
        private DaoPagos DBpagos;
        private string serial;

        public ComandoPagos(string serial)
        {
            DBpagos = FabricaDAO.crearDaoPagos();
            this.serial = serial;
        }

        public string pagar()
        {
            try {
                DBpagos.cambiarEstatusTicketPerdedores();               
                return "Por ahora, solo se cambio el estatus de los ticket perdedores";
            }            
            catch (Exception ex)
            {
                return ex.Message;
            }
        }        

    }
}
