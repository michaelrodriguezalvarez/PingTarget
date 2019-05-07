using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PingTarget
{
    public partial class ConfigurarAlerta : Form
    {
        private PingTarget pingTarget;
        private Modelo modelo;
        private Configuracion configuracion;
        public ConfigurarAlerta(PingTarget pingTarget)
        {
            InitializeComponent();
            this.pingTarget = pingTarget;
            if (object.Equals(this.modelo, null))
            {
                this.modelo = new Modelo();
            }
            this.configuracion = modelo.ObtenerTodaLaConfiguracion();
        }

        private void buttonCargarSonidoNacional_Click(object sender, EventArgs e)
        {
            if (openFileDialogNacional.ShowDialog() == DialogResult.OK)
            {
                textBoxNacional.Text = openFileDialogNacional.FileName;
                labelSonidoNacional.Text = openFileDialogNacional.SafeFileName;
            }
        }

        private void buttonCargarSonidoInternacional_Click(object sender, EventArgs e)
        {
            if (openFileDialogInternacional.ShowDialog() == DialogResult.OK)
            {
                textBoxInternacional.Text = openFileDialogInternacional.FileName;
                labelSonidoInternacional.Text = openFileDialogInternacional.SafeFileName;
            }
        }

        private void buttonRestablecer_Click(object sender, EventArgs e)
        {
            this.EliminarFicheroAudio(this.ObtenerNombreAudioConfigurado("nacional"));
            this.EliminarFicheroAudio(this.ObtenerNombreAudioConfigurado("internacional"));
            openFileDialogNacional.Reset();
            textBoxNacional.Text = openFileDialogNacional.FileName;
            labelSonidoNacional.Text = "No definido";
            openFileDialogInternacional.Reset();
            textBoxInternacional.Text = openFileDialogInternacional.FileName;
            labelSonidoInternacional.Text = "No definido";
            trackBarVolumen.Value = 10;
            this.SalvarConfiguracion();
            this.pingTarget.MostrarBalloonTip("advertencia", "No se han configurado los ficheros de audio para las alertas");

        }

        private void buttonConfigurar_Click(object sender, EventArgs e)
        {
            if (openFileDialogNacional.SafeFileName == "" && openFileDialogInternacional.SafeFileName == "")
            {
                if (labelSonidoNacional.Text == "No definido" && labelSonidoInternacional.Text == "No definido")
                {
                    this.SalvarConfiguracion();
                    this.pingTarget.MostrarBalloonTip("advertencia", "No se han configurado los ficheros de audio para las alertas");
                }
                else
                {
                    this.SalvarConfiguracion();
                    this.pingTarget.MostrarBalloonTip("informacion", "Se han configurado los ficheros de audio para las alertas");
                }
            }
            else
            {
                if (openFileDialogNacional.FileName != "")
                {
                    string fichero_anterior = this.ObtenerNombreAudioConfigurado("nacional");
                    if (ComprobarFicherosAudioIguales()==false)
                    {
                        EliminarFicheroAudio(fichero_anterior);
                    }                    
                    SalvarFicheroAudio(openFileDialogNacional);
                }

                if (openFileDialogInternacional.FileName != "")
                {
                    string fichero_anterior = this.ObtenerNombreAudioConfigurado("internacional");                    
                    if (ComprobarFicherosAudioIguales() == false)
                    {
                        EliminarFicheroAudio(fichero_anterior);
                    }
                    SalvarFicheroAudio(openFileDialogInternacional);
                }
                this.SalvarConfiguracion();
                this.pingTarget.MostrarBalloonTip("informacion", "Se han configurado los ficheros de audio para las alertas");
            }
            this.pingTarget.EjecutarNuevaConfiguracionAlerta();
            this.Close();
        }

        private void SalvarFicheroAudio(OpenFileDialog fileDialog)
        {
            try
            {
                File.Copy(fileDialog.FileName, fileDialog.SafeFileName, true);
            }
            catch (Exception)
            {
                this.pingTarget.MostrarBalloonTip("error", "No se pudo guardar el fichero de audio");
            }
        }

        private void EliminarFicheroAudio(string nombreFichero)
        {
            try
            {
                if (nombreFichero != "" && File.Exists(nombreFichero))
                {
                    File.Delete(nombreFichero);
                }
            }
            catch (Exception)
            {
                this.pingTarget.MostrarBalloonTip("error", "No se pudo remover el fichero de audio");
            }
        }

        private void CargarConfiguracion()
        {
            try
            {
                this.configuracion = this.modelo.ObtenerTodaLaConfiguracion();

                labelSonidoNacional.Text = this.configuracion.Sonido_nacional;
                labelSonidoInternacional.Text = this.configuracion.Sonido_internacional;
                int volumen_almacenado = this.configuracion.Volumen;
                trackBarVolumen.Value = (volumen_almacenado == 0) ? 0 : (volumen_almacenado) / 10;                
            }
            catch (Exception ex)
            {
                this.pingTarget.MostrarBalloonTip("error", ex.Message);
            }
        }

        private void SalvarConfiguracion()
        {
            try
            {
                this.configuracion = this.modelo.ObtenerTodaLaConfiguracion();

                this.configuracion.Sonido_nacional = labelSonidoNacional.Text;
                this.configuracion.Sonido_internacional = labelSonidoInternacional.Text;
                this.configuracion.Volumen = trackBarVolumen.Value * 10;

                this.modelo.GuardarConfiguracion(this.configuracion);
            }
            catch (Exception ex)
            {
                this.pingTarget.MostrarBalloonTip("error", ex.Message);
            }
        }

        private void ConfigurarAlerta_Load(object sender, EventArgs e)
        {
            this.CargarConfiguracion();
        }

        private string ObtenerNombreAudioConfigurado(string objetivo)
        {  string nombre = "No definido";
            try
            {                
                if (objetivo == "nacional")
                {
                    List<string> resultado_campos_valores_configuracion = this.modelo.ObtenerCamposValoresConfiguracion(new string[] { "Sonido_nacional" });
                    nombre = resultado_campos_valores_configuracion.ElementAt(1).ToString();
                }
                else
                {
                    List<string> resultado_campos_valores_configuracion = this.modelo.ObtenerCamposValoresConfiguracion(new string[] { "Sonido_internacional" });
                    nombre = resultado_campos_valores_configuracion.ElementAt(1).ToString();
                }
                
            }
            catch (Exception)
            {
                this.pingTarget.MostrarBalloonTip("error", "Error al cargar la configuración relacionada con el audio.");           
            }
            return nombre;
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ComprobarFicherosAudioIguales()
        {
            return (ObtenerNombreAudioConfigurado("nacional") == ObtenerNombreAudioConfigurado("internacional")) ? true : false ;
        }
    }
}
