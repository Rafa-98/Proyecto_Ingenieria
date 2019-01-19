using ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService;
using ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.ComandosPagos;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos
{
    public class FabricaComandos
    {
        public static ComandoGetData FabricarComandoGetData(int value)
        {
            return new ComandoGetData(value);
        }

        public static ComandoPagos FabricarComandoPagos()
        {
            return new ComandoPagos("120");
        }

        
    }
}
