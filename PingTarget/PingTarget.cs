using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using NAudio.Wave;

namespace PingTarget
{
    public partial class PingTarget : Form
    {
        private bool estadoVentana;
        private string host;
        private int tiempo;
        private bool mostro_estado_conectado;
        private bool mostro_estado_desconectado;
        private bool cerrar_aplicacion;
        private string host_internacional;
        private bool mostro_estado_conectado_internacional;
        private bool mostro_estado_desconectado_internacional;
        private bool conectado_nacional;
        private bool conectado_internacional;

        private List<string> sonidos_alertas = new List<string>();
        private bool bandera_reproduciendo_sonido_alerta;

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        private Modelo modelo;
        private Configuracion configuracion;


        public PingTarget()
        {
            InitializeComponent();
        }

        private void PosicionarVentana()
        {
            Screen screen = Screen.FromControl(this);
            int deskHeight = screen.WorkingArea.Height;
            int deskWidth = screen.WorkingArea.Width;
            this.Location = new Point(deskWidth - this.Width, deskHeight - this.Height);
        }

        private void ConmutarEstadoVentanaPrincipal() {
            this.estadoVentana = !this.estadoVentana;
            if (this.estadoVentana == true)
            {
                this.Visible = false;
                this.Hide();
                MostrarBalloonTip("informacion", "PingTarget se está ejecutando");
            }
            else
            {               
                this.Visible = true;
                this.Show();
            }            
        }

        public void MostrarBalloonTip(string pIcono,string pTexto)
        {
            switch (pIcono)
            {
                case "error":
                    notifyIconPingTarget.BalloonTipTitle = "Error";
                    notifyIconPingTarget.BalloonTipIcon = ToolTipIcon.Error;
                    break;
                case "informacion":
                    notifyIconPingTarget.BalloonTipTitle = "Información";
                    notifyIconPingTarget.BalloonTipIcon = ToolTipIcon.Info;
                    break;
                case "advertencia":
                    notifyIconPingTarget.BalloonTipTitle = "Advertencia";
                    notifyIconPingTarget.BalloonTipIcon = ToolTipIcon.Warning;
                    break;
                default:
                    notifyIconPingTarget.BalloonTipTitle = "Información";
                    notifyIconPingTarget.BalloonTipIcon = ToolTipIcon.None;
                    break;
            }
            notifyIconPingTarget.BalloonTipText = pTexto;
            notifyIconPingTarget.ShowBalloonTip(10);
        }             

        private void notifyIconPingTarget_MouseClick(object sender, MouseEventArgs e)
        {
            this.ConmutarEstadoVentanaPrincipal();
        }    

        private void PingTarget_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.cerrar_aplicacion == false)
            {
                e.Cancel = true;
                this.ConmutarEstadoVentanaPrincipal();
            }
        }       

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.cerrar_aplicacion = true;
            this.Close();
        }

        private void buttonComprobar_Click(object sender, EventArgs e)
        {
            try
            {
                this.tiempo = int.Parse(textBoxTime.Text);
                if (timerPingTarget.Enabled == false)
                {                    
                    this.timerPingTarget.Enabled = true;                    
                    this.timerPingTarget.Interval = this.tiempo * 1000;                    
                    this.timerPingTarget.Start();
                   
                }

                if (timerPingTargetInternacional.Enabled == false)
                {               
                    this.timerPingTargetInternacional.Enabled = true;
                    this.timerPingTargetInternacional.Interval = this.tiempo * 1000;
                    this.timerPingTargetInternacional.Start();
                }
                                
                this.host = textBoxHost.Text;
                this.host_internacional = textBoxHostInternacional.Text;
                this.ConmutarEstadoVentanaPrincipal();
                this.mostro_estado_conectado = false;
                this.mostro_estado_desconectado = false;
                this.mostro_estado_conectado_internacional = false;
                this.mostro_estado_desconectado_internacional = false;
                this.conectado_nacional = false;
                this.conectado_internacional = false;
                this.SalvarConfiguracion();
            }
            catch (System.FormatException)
            {   
                textBoxTime.Text = configuracion.Tiempo.ToString();
                this.MostrarBalloonTip("error", "Especifique el tiempo en segundos correctamente.");
            }
        }       

        private void timerPingTarget_Tick(object sender, EventArgs e)
        {
            Ping Pings = new Ping();
            int timeout = 10;

            try
            {
                if (Pings.Send(this.host, timeout).Status == IPStatus.Success)
                {
                    if (this.mostro_estado_conectado == false)
                    {
                        this.MostrarBalloonTip("informacion", "Conectado con el host nacional " + this.host);
                        this.mostro_estado_conectado = true;
                        this.mostro_estado_desconectado = false;
                        this.conectado_nacional = true;

                        string sonido_nacional = CargarSonido("nacional");
                        if (File.Exists(sonido_nacional))
                        {
                            sonidos_alertas.Add(sonido_nacional);
                            if (timerSonidosAlertas.Enabled == false)
                            {
                                timerSonidosAlertas.Enabled = true;
                            }
                        }                                                 
                    }
                }
                else
                {
                    if (this.mostro_estado_desconectado == false)
                    {
                        this.MostrarBalloonTip("informacion", "Desconectado con el host nacional " + this.host);
                        this.mostro_estado_conectado = false;
                        this.mostro_estado_desconectado = true;
                        this.conectado_nacional = false;
                    }
                }
            }
            catch (System.Net.NetworkInformation.PingException)
            {
                if (this.mostro_estado_desconectado == false)
                {
                    this.MostrarBalloonTip("informacion", "Desconectado con el host nacional " + this.host);
                    this.mostro_estado_conectado = false;
                    this.mostro_estado_desconectado = true;
                    this.conectado_nacional = false;
                }
            }
            this.ActualizarEstados();
        }
        private void PingTarget_Load(object sender, EventArgs e)
        {
            this.estadoVentana = false;
            this.mostro_estado_conectado = false;
            this.mostro_estado_desconectado = false;
            this.mostro_estado_conectado_internacional = false;
            this.mostro_estado_desconectado_internacional = false;
            this.conectado_nacional = false;
            this.conectado_internacional = false;
            this.PosicionarVentana();
            this.ConmutarEstadoVentanaPrincipal();
            this.CargarConfiguracion();
            this.ActualizarEstados();            
        }
        private void CargarConfiguracion()
        {
            try
            {
                if (object.Equals(this.modelo,null))
                {
                    this.modelo = new Modelo();                    
                }
                this.configuracion = modelo.ObtenerTodaLaConfiguracion();
                textBoxHost.Text = configuracion.Host_nacional;
                textBoxHostInternacional.Text = configuracion.Host_internacional;
                textBoxTime.Text = configuracion.Tiempo.ToString();

            }
            catch (Exception ex)
            {
                this.MostrarBalloonTip("error", ex.Message);
            }
        }

        private void SalvarConfiguracion()
        {
            try
            {
                this.configuracion = modelo.ObtenerTodaLaConfiguracion();
                this.configuracion.Host_nacional = this.host;
                this.configuracion.Host_internacional = this.host_internacional;
                this.configuracion.Tiempo = this.tiempo;
                this.modelo.GuardarConfiguracion(this.configuracion);
            }
            catch (Exception ex)
            {
                this.MostrarBalloonTip("error", ex.Message);
            }
        }

        private void timerPingTargetInternacional_Tick(object sender, EventArgs e)
        {
            Ping Pings = new Ping();
            int timeout = 10;

            try
            {
                if (Pings.Send(this.host_internacional, timeout).Status == IPStatus.Success)
                {
                    if (this.mostro_estado_conectado_internacional == false)
                    {
                        this.MostrarBalloonTip("informacion", "Conectado con el host internacional " + this.host_internacional);
                        this.mostro_estado_conectado_internacional = true;
                        this.mostro_estado_desconectado_internacional = false;
                        this.conectado_internacional = true;

                        string sonido_internacional = CargarSonido("internacional");
                        if (File.Exists(sonido_internacional))
                        {
                            sonidos_alertas.Add(sonido_internacional);
                            if (timerSonidosAlertas.Enabled == false)
                            {
                                timerSonidosAlertas.Enabled = true;
                            }
                        }
                    }
                }
                else
                {
                    if (this.mostro_estado_desconectado_internacional == false)
                    {
                        this.MostrarBalloonTip("informacion", "Desconectado con el host internacional " + this.host_internacional);
                        this.mostro_estado_conectado_internacional = false;
                        this.mostro_estado_desconectado_internacional = true;
                        this.conectado_internacional = false;
                    }
                }
            }
            catch (System.Net.NetworkInformation.PingException)
            {
                if (this.mostro_estado_desconectado_internacional == false)
                {
                    this.MostrarBalloonTip("informacion", "Desconectado con el host internacional " + this.host_internacional);
                    this.mostro_estado_conectado_internacional = false;
                    this.mostro_estado_desconectado_internacional = true;
                    this.conectado_internacional = false;
                }
            }
            this.ActualizarEstados();
        }

        private void ActualizarEstados()
        {
            if (this.conectado_nacional == true)
            {
                labelEstadoNacional.Text = "Conectado";
                labelEstadoNacional.ForeColor = Color.Green;
            }else
            {

                labelEstadoNacional.Text = "Desconectado";
                labelEstadoNacional.ForeColor = Color.Red;
            }

            if (this.conectado_internacional == true)
            {
                labelEstadoInternacional.Text = "Conectado";
                labelEstadoInternacional.ForeColor = Color.Green;
            }
            else
            {

                labelEstadoInternacional.Text = "Desconectado";
                labelEstadoInternacional.ForeColor = Color.Red;
            }
        }
 
        private void ReproducirSonido(string ficheroSonido)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(ficheroSonido);


                if (object.Equals(this.modelo, null))
                {
                    this.modelo = new Modelo();
                }
                List<string> resultado_campos_valores_configuracion = this.modelo.ObtenerCamposValoresConfiguracion(new string[] { "Volumen" });

                int volumen_almacenado = int.Parse(resultado_campos_valores_configuracion.ElementAt(1).ToString());
                audioFile.Volume = (volumen_almacenado > 0) ? (float)volumen_almacenado / 100 : 0.0f;
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
            bandera_reproduciendo_sonido_alerta = true;
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
            bandera_reproduciendo_sonido_alerta = false;
            
        }

        private string CargarSonido(string contexto)
        {
            string sonido = "";
            try
            {
                if (contexto == "nacional")
                {
                    List<string> resultado_campos_valores_configuracion = this.modelo.ObtenerCamposValoresConfiguracion(new string[] { "Sonido_nacional" });
                    sonido = resultado_campos_valores_configuracion.ElementAt(1).ToString();
                }
                else
                {
                    List<string> resultado_campos_valores_configuracion = this.modelo.ObtenerCamposValoresConfiguracion(new string[] { "Sonido_internacional" });
                    sonido = resultado_campos_valores_configuracion.ElementAt(1).ToString();
                }               
            }
            catch (Exception ex)
            {
                this.MostrarBalloonTip("error", ex.Message);
            }
            return sonido;
        }

        private void timerSonidosAlertas_Tick(object sender, EventArgs e)
        {
            if (sonidos_alertas.Count > 0 && bandera_reproduciendo_sonido_alerta == false)
            {
                string sonido_a_reproducir = sonidos_alertas.First();
                sonidos_alertas.Remove(sonido_a_reproducir);
                ReproducirSonido(sonido_a_reproducir);
                timerSonidosAlertas.Interval = 2000;
            }
            else
            {
                if (sonidos_alertas.Count == 0 && bandera_reproduciendo_sonido_alerta == false)
                {
                    timerSonidosAlertas.Interval = 500;
                    timerSonidosAlertas.Enabled = false;
                }                
            }            
        }

        private void buttonAlertas_Click(object sender, EventArgs e)
        {
            ConfigurarAlerta configurarAlerta = new ConfigurarAlerta(this);
            configurarAlerta.StartPosition = FormStartPosition.CenterParent;
            configurarAlerta.TopMost = true;
            configurarAlerta.ShowDialog();            
        }

        private void PingTarget_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            Ayuda ayuda = new Ayuda();
            ayuda.StartPosition = FormStartPosition.CenterParent;
            ayuda.TopMost = true;
            ayuda.ShowDialog();
        }
    }
}
