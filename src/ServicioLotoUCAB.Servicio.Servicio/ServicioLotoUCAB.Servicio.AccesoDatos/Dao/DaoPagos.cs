using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.AccesoDatos.Dao
{
    public class DaoPagos
    {
       
        MySqlConnection conector;
        string respuesta = null;
        MySqlCommand cmd;
        MySqlDataReader lector;       

        public DaoPagos()
        {
            conector = new MySqlConnection(ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString);
        }


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
