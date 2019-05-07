using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace PingTarget
{
    class Modelo
    {
        private string fichero_configuracion;
        private SQLiteConnection conexion;
        private Configuracion configuracion;

        public Modelo()
        {
            this.fichero_configuracion = "PingTarget.sqlite";
            CrearBaseDatos();
            CrearConexion();
            CrearTabla();
            if (ComprobarExistenciaConfiguracion()==false)
            {
                InicializarConfiguracion();
            }       
        }

        private void CrearBaseDatos()
        {
            try
            {
                if (File.Exists(this.fichero_configuracion)==false)
                {
                    SQLiteConnection.CreateFile(this.fichero_configuracion);
                }
            }
            catch (Exception)
            {
                throw new Exception("No se pudo crear el fichero de configuración. Revise los permisos administrativos.");
            }

        }

        private void CrearConexion()
        {
            try
            {
                this.conexion = new SQLiteConnection("Data Source=" + this.fichero_configuracion + ";Version=3;");
            }
            catch (Exception)
            {

                throw new Exception("No se ha encontrado el fichero de configuración, cierre y ejecute nuevamente la aplicación como posible solución.");
            }         
            
        }

        private void CrearTabla()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Configuracion (
                            Id  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                            Host_nacional  TEXT(100) NOT NULL DEFAULT '127.0.0.1',
                            Host_internacional  TEXT(100) NOT NULL DEFAULT '127.0.0.2',
                            Tiempo  INTEGER NOT NULL DEFAULT 2,
                            Sonido_nacional  TEXT(1000) NOT NULL DEFAULT 'No definido',
                            Sonido_internacional  TEXT(1000) NOT NULL DEFAULT 'No definido',
                            Volumen  INTEGER NOT NULL DEFAULT 100
                            )
                            ;";            
            this.conexion.Open();
            SQLiteCommand command = new SQLiteCommand(sql, this.conexion);
            command.ExecuteNonQuery();
            this.conexion.Close();
        }

        public void GuardarConfiguracion(Configuracion configuracion)
        {
            VaciarTablaConfiguracion();
            SQLiteCommand commando = new SQLiteCommand(this.conexion);

            this.conexion.Open();
            
            string sql = @"INSERT INTO Configuracion 
                                        (Host_nacional, Host_internacional, Tiempo, Sonido_nacional, Sonido_internacional, Volumen) 
                                        VALUES ('"+configuracion.Host_nacional+"','"+configuracion.Host_internacional+"',"+configuracion.Tiempo.ToString()+",'"+configuracion.Sonido_nacional+"','"+configuracion.Sonido_internacional+"',"+configuracion.Volumen.ToString()+");";

            SQLiteCommand command = new SQLiteCommand(sql, this.conexion);
            command.ExecuteNonQuery();
            this.conexion.Close();
        }

        public Configuracion ObtenerTodaLaConfiguracion()
        {
            SQLiteCommand commando = new SQLiteCommand(this.conexion);

            this.conexion.Open();

            commando.CommandText = "SELECT * FROM Configuracion LIMIT 1";

            SQLiteDataReader lector_datos = commando.ExecuteReader();

            while (lector_datos.Read())
            {
                this.configuracion = new Configuracion();

                this.configuracion.Host_nacional = (string) lector_datos["Host_nacional"];
                this.configuracion.Host_internacional = (string) lector_datos["Host_internacional"];
                this.configuracion.Tiempo = int.Parse(lector_datos["Tiempo"].ToString());
                this.configuracion.Sonido_nacional = (string) lector_datos["Sonido_nacional"];
                this.configuracion.Sonido_internacional = (string) lector_datos["Sonido_internacional"];
                this.configuracion.Volumen = int.Parse(lector_datos["Volumen"].ToString());
            }

            this.conexion.Close();

            return this.configuracion;
        }

        public List<string> ObtenerCamposValoresConfiguracion(string [] campos)
        {
            List<string> campos_valores_resultantes = new List<string>();

            if (ComprobarExistenciaDeConfiguracion() == true)
            {
                bool nombres_correctos = true;

                string sub_secuencia_sql = "";

                List<string> nombres_columnas_configuracion = ObtenerNombreColumnasConfiguracion();
                for (int i = 0; i <= campos.Length - 1; i++)
                {
                    if (nombres_columnas_configuracion.IndexOf(campos[i]) == -1)
                    {
                        nombres_correctos = false;
                        break;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            sub_secuencia_sql += campos[i];
                        }
                        else
                        {
                            sub_secuencia_sql += ", " + campos[i];
                        }
                    }
                }

                if (nombres_correctos == true)
                {

                    SQLiteCommand commando = new SQLiteCommand(this.conexion);

                    this.conexion.Open();

                    commando.CommandText = "SELECT "+sub_secuencia_sql+" FROM Configuracion LIMIT 1";

                    SQLiteDataReader lector_datos = commando.ExecuteReader();

                    while (lector_datos.Read())
                    {
                        for (int i = 0; i <= campos.Length - 1; i++)
                        {
                            campos_valores_resultantes.Add(campos[i]);                            
                            campos_valores_resultantes.Add(lector_datos[campos[i]].ToString());
                        }
                    }

                    this.conexion.Close();
                    return campos_valores_resultantes;
                }
                else
                {
                    throw new Exception("No se encuentra el campo especificado dentro de la Configuración.");
                }
            }
            else
            {
                throw new Exception("No se pudo configurar la aplicación, cierre y ejecute nuevamente la aplicación como posible solución.");
            }
        }

        private void VaciarTablaConfiguracion()
        {
            string sql = @"DELETE FROM Configuracion; 
                            UPDATE sqlite_sequence SET seq=0 WHERE name='Configuracion';";
            this.conexion.Open();
            SQLiteCommand command = new SQLiteCommand(sql, this.conexion);
            command.ExecuteNonQuery();
            this.conexion.Close();
        }

        private bool ComprobarExistenciaDeConfiguracion()
        {
            bool existe = true;
            try
            {
                if (File.Exists(this.fichero_configuracion) == false)
                {
                    existe = false;
                }
                else
                {
                    if (object.Equals(ObtenerTodaLaConfiguracion(),null))
                    {
                        existe = false;
                    }                                      
                }
                return existe;
            }
            catch (Exception)
            {
                existe = false;
                return existe;
            }            
        }

        public void ActualizarCamposConfiguracion(string [] campos, string [] nuevos_valores)
        {
            if (ComprobarExistenciaDeConfiguracion()==true)
            {
                bool nombres_correctos = true;

                string sub_secuencia_sql = "";

                List<string> nombres_columnas_configuracion = ObtenerNombreColumnasConfiguracion();
                for (int i = 0; i <= campos.Length-1; i++)
                {
                    if (nombres_columnas_configuracion.IndexOf(campos[i]) == -1)
                    {
                        nombres_correctos = false;
                        break;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            sub_secuencia_sql += campos[i] + " = " + nuevos_valores[i];
                        }
                        else
                        {
                            sub_secuencia_sql += ", " + campos[i] + " = " + nuevos_valores[i];
                        }                        
                    }
                }

                if (nombres_correctos == true)
                {                    
                    SQLiteCommand commando = new SQLiteCommand(this.conexion);
                    this.conexion.Open();
                    string sql = "UPDATE Configuracion SET " + sub_secuencia_sql + ";";
                    SQLiteCommand command = new SQLiteCommand(sql, this.conexion);
                    command.ExecuteNonQuery();
                    this.conexion.Close();
                }
                else
                {
                    throw new Exception("No se encuentra el campo especificado dentro de la Configuración.");
                }
            }
            else
            {
                throw new Exception("No se pudo configurar la aplicación, cierre y ejecute nuevamente la aplicación como posible solución.");
            }            
        }

        private List<string> ObtenerNombreColumnasConfiguracion()
        {
            //Id, Host_nacional, Host_internacional, Tiempo, Sonido_nacional, Sonido_internacional, Volumen
            List<string> nombres_columnas = new List<string>();

            SQLiteCommand commando = new SQLiteCommand(this.conexion);

            this.conexion.Open();

            commando.CommandText = "PRAGMA table_info(Configuracion)";

            SQLiteDataReader lector_datos = commando.ExecuteReader();

            while (lector_datos.Read())
            {
                nombres_columnas.Add((string)lector_datos["name"]);
            }

            this.conexion.Close();

            return nombres_columnas;
        }

        private void InicializarConfiguracion()
        {
            this.configuracion = new Configuracion();
            GuardarConfiguracion(this.configuracion);
        }

        private bool ComprobarExistenciaConfiguracion()
        {
            int cantidad = 0;
            SQLiteCommand commando = new SQLiteCommand(this.conexion);

            this.conexion.Open();

            commando.CommandText = "SELECT COUNT(Id) AS Cantidad FROM Configuracion";

            SQLiteDataReader lector_datos = commando.ExecuteReader();

            while (lector_datos.Read())
            {
                cantidad = int.Parse(lector_datos["Cantidad"].ToString());
            }

            this.conexion.Close();

            return (cantidad == 0) ? false : true ;
        }
    }
}
