using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ProyectoS.Clases
{
    public class ConectorBD
    {

        MySqlConnectionStringBuilder builder;
        MySqlConnection conector;
        string respuesta = null;
        MySqlCommand cmd;
        MySqlDataReader lector;

        public ConectorBD(string servidor, uint puerto, string iD, string contraseña, string baseDeDatos)
        {        
            builder = new MySqlConnectionStringBuilder()
            {
                Server = servidor,
                Port = puerto,
                UserID = iD,
                Password = contraseña,
                Database = baseDeDatos,
            };

            conector = new MySqlConnection(builder.ToString());            
        }

        public string Consultar(string command)
        {            

            try
            {
                conector.Open();
                // cmd = new MySqlCommand("SELECT nombre FROM alumnos", conector);
                cmd = new MySqlCommand(command, conector);
                lector = cmd.ExecuteReader();
                int c = 0;

                while (lector.Read())
                {
                    for (int i=0; i != lector.FieldCount; i++) 
                        respuesta += lector.GetString(i) + ", ";                   
                    respuesta += "// ";
                    
                }              
                lector.Close();
                conector.Close();
                return respuesta;
            }catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                conector.Close();
            }

        }

        public string Operar(string command)
        {
            try
            {
                conector.Open();
                cmd = new MySqlCommand(command, conector);
                lector = cmd.ExecuteReader();
                lector.Close();
                conector.Close();
                return "Operacion realizada exitosamente!";
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

        public string rConsult(string que, string quien)
        {
            try
            {
                conector.Open();
                 /*cmd = new MySqlCommand("SELECT '"+que+"' FROM '"+quien+"'", conector);*/
                cmd = new MySqlCommand("SELECT " + que + " FROM " + quien, conector);
                /*cmd = new MySqlCommand(que, conector);*/
                /*cmd = new MySqlCommand(command, conector);*/
                lector = cmd.ExecuteReader();
               // int c = 0;

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

        public void cerrarConexion()
        {
            conector.Close();
        }

    }
}