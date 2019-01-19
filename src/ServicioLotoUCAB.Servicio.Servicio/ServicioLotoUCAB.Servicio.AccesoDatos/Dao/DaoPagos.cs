using MySql.Data.MySqlClient;
using ServicioLotoUCAB.Servicio.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.AccesoDatos.Dao
{
    public class DaoPagos
    {
       
        MySqlConnection conector = null;
        string respuesta = null;
        int suma = 0;
        MySqlCommand cmd = null;
        MySqlDataReader lector = null;
        string serial;

        public DaoPagos()
        {
            conector = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySql.Equipo9"].ConnectionString);
        }

        
        // LO OFICIAL DEL PROYECTO --------------------------------------------------------------------        

        public string pago(string serial)
        {
            this.serial = serial;
            string transaccion = "Vacio";
            transaccion = actualizarEstatus();
            return transaccion;
        }

        public string actualizarEstatus()
        {
            Resultado resultado;
            Sorteo sorteo;
            Jugada jugada;

            try
            {
                conector.Open();
                cmd = new MySqlCommand("UPDATE tb_resultado,tb_sorteo,tb_jugada,tb_dia_sorteo set tb_jugada.ESTATUS = 0 where tb_resultado.ID_RESULTADO = 2 and tb_resultado.ID_SORTEO = tb_dia_sorteo.ID_SORTEO and tb_jugada.ID_DIASORTEO = tb_dia_sorteo.ID_DIASORTEO and tb_jugada.ID_ITEM <> tb_resultado.ID_ITEM", conector);
                lector = cmd.ExecuteReader();
                return "Transaccion realizada con exito!";
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ha ocurrido un error...\n");
                return ex.Message;
            }
            finally
            {
                conector.Close();
                lector.Close();
            }
        }

        // ------------------------------------------------------------------------------


        public string rConsult(string que, string quien)
        {
            try
            {
                conector.Open();
                cmd = new MySqlCommand("SELECT " + que + " FROM " + quien, conector);                
                lector = cmd.ExecuteReader();               
                while (lector.Read())
                {
                    for (int i = 0; i != lector.FieldCount; i++)
                        respuesta += lector.GetString(i) + ", ";
                    respuesta += "// ";
                }
                lector.Close();
                conector.Close();
                Console.Write(respuesta);
                return respuesta;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                conector.Close();
            }
        }

        public string Imprime()
        {
            try
            {                
                ArrayList dias = new ArrayList();               
                conector.Open();
                cmd = new MySqlCommand("SELECT ID_DIA, NOMBRE  FROM TB_DIA", conector);
                lector = cmd.ExecuteReader();
                int cuenta = 0;
                while (lector.Read())
                {
                   cuenta++;
                    Dia dia = new Dia();                   
                    dia.id_dia = lector.GetInt32(0);
                    dia.nombre = lector["NOMBRE"].ToString();
                    dias.Add(dia);
                    suma += lector.FieldCount;
                }                
                cuenta = 0;
                foreach (Dia diaL in dias) {
                    cuenta++;
                    Debug.WriteLine("ID del dia: "+diaL.id_dia);
                    Debug.WriteLine("Nombre: "+diaL.nombre);
                }               
                lector.Close();
                conector.Close();
                return ("Operacion realizada exitosamente");                                                                                         
            }
            catch (Exception ex)
            {                
                return ex.Message;                                
            }
            finally
            {                
                conector.Close();
            }
        }

        public string Consulta()
        {
            try
            {
                conector.Open();
                cmd = new MySqlCommand("SELECT NOMBRE FROM PERSONA", conector);
                lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    for (int i = 0; i != lector.FieldCount; i++)
                    {
                        respuesta += lector.GetString(i) + ", ";
                        Console.Write(respuesta);
                    }
                    respuesta += "// ";
                }
                lector.Close();
                conector.Close();
                return respuesta;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                conector.Close();
            }
        }
    }
}
