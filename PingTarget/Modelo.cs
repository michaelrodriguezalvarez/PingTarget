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
            catch (Exception ex)
            {
                //Error al crear la tabla
            }

        }

        private void CrearConexion()
        {            
            this.conexion = new SQLiteConnection("Data Source=" + this.fichero_configuracion + ";Version=3;");
        }

        private void CrearTabla()
        {
            string sql = @"CREATE TABLE Configuracion (
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
        
        private void GuardarConfiguracion(Configuracion configuracion)
        {
            SQLiteCommand commando = new SQLiteCommand(this.conexion);

            this.conexion.Open();
            
            string sql = @"INSERT INTO Configuracion 
                                        (Host_nacional, Host_internacional, Tiempo, Sonido_nacional, Sonido_internacional, Volumen) 
                                        VALUES ('"+configuracion.Host_nacional+"','"+configuracion.Host_internacional+"',"+configuracion.Tiempo.ToString()+",'"+configuracion.Sonido_nacional+"','"+configuracion.Sonido_internacional+"',"+configuracion.Volumen.ToString()+");";

            SQLiteCommand command = new SQLiteCommand(sql, this.conexion);
            command.ExecuteNonQuery();
            this.conexion.Close();
        }

        private Configuracion ObtenerConfiguracion()
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
                this.configuracion.Tiempo = (int) lector_datos["Tiempo"];
                this.configuracion.Sonido_nacional = (string) lector_datos["Sonido_nacional"];
                this.configuracion.Sonido_internacional = (string) lector_datos["Sonido_internacional"];
                this.configuracion.Volumen = (int) lector_datos["Volumen"];
            }

            this.conexion.Close();

            return this.configuracion;
        }

        public void InicializarBaseDatos()
        {
            CrearBaseDatos();
            CrearConexion();
            CrearTabla();
            GuardarConfiguracion(new Configuracion());
        }
    }
}
