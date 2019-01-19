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
            DBpagos = new DaoPagos();
            this.serial = serial;
        }

        public float pagar()
        {
            return 0;
        }

    }
}
