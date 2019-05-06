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
        public ConfigurarAlerta(PingTarget pingTarget)
        {
            InitializeComponent();
            this.pingTarget = pingTarget;
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
            labelSonidoNacional.Text = "No configurado";
            openFileDialogInternacional.Reset();
            textBoxInternacional.Text = openFileDialogInternacional.FileName;
            labelSonidoInternacional.Text = "No configurado";
            trackBarVolumen.Value = 10;
            this.SalvarConfiguracion();
            this.pingTarget.MostrarBalloonTip("advertencia", "No se han configurado los ficheros de audio para las alertas");

        }

        private void buttonConfigurar_Click(object sender, EventArgs e)
        {
            if (openFileDialogNacional.SafeFileName == "" && openFileDialogInternacional.SafeFileName == "")
            {
                if (labelSonidoNacional.Text == "No configurado" && labelSonidoInternacional.Text == "No configurado")
                {
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
            this.Close();
        }

        private void SalvarFicheroAudio(OpenFileDialog fileDialog)
        {
            try
            {
                File.Copy(fileDialog.FileName, fileDialog.SafeFileName, true);
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                this.pingTarget.MostrarBalloonTip("error", "No se pudo remover el fichero de audio");
            }
        }

        private void CargarConfiguracion()
        {
            try
            {
                StreamReader fichero = new StreamReader("PigTargetNacionalAudio.conf");
                labelSonidoNacional.Text = fichero.ReadLine();
                fichero.Close();
                StreamReader fichero_internacional = new StreamReader("PigTargetInternacionalAudio.conf");
                labelSonidoInternacional.Text = fichero_internacional.ReadLine();
                fichero_internacional.Close();
                if (File.Exists("PigTargetVolumen.conf"))
                {
                    StreamReader fichero_volumen = new StreamReader("PigTargetVolumen.conf");
                    string volumen_almacenado = fichero_volumen.ReadLine();
                    trackBarVolumen.Value = (volumen_almacenado == "0") ? 0 : int.Parse(volumen_almacenado) / 10;
                    fichero_volumen.Close();
                }else
                {
                    trackBarVolumen.Value = 10;
                }
                
            }
            catch (Exception ex)
            {

            }
        }

        private void SalvarConfiguracion()
        {
            try
            {
                StreamWriter fichero = new StreamWriter("PigTargetNacionalAudio.conf");
                fichero.WriteLine(labelSonidoNacional.Text);
                fichero.Close();
                StreamWriter fichero_internacional = new StreamWriter("PigTargetInternacionalAudio.conf");
                fichero_internacional.WriteLine(labelSonidoInternacional.Text);
                fichero_internacional.Close();
                StreamWriter fichero_volumen = new StreamWriter("PigTargetVolumen.conf");
                fichero_volumen.WriteLine(trackBarVolumen.Value*10);
                fichero_volumen.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void ConfigurarAlerta_Load(object sender, EventArgs e)
        {
            this.CargarConfiguracion();
        }

        private string ObtenerNombreAudioConfigurado(string objetivo)
        {
            try
            {
                string nombre = "";
                if (objetivo == "nacional")
                {
                    StreamReader fichero = new StreamReader("PigTargetNacionalAudio.conf");
                    nombre = fichero.ReadLine();
                    fichero.Close();
                }
                else
                {
                    StreamReader fichero_internacional = new StreamReader("PigTargetInternacionalAudio.conf");
                    nombre = fichero_internacional.ReadLine();
                    fichero_internacional.Close();
                }
                return nombre;
            }
            catch (Exception ex)
            {
                return "";           
            }

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
