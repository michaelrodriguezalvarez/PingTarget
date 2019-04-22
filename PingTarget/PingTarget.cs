using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;

namespace PingTarget
{
    public partial class PingTarget : Form
    {
        bool estadoVentana;
        string host;
        int tiempo;
        bool mostro_estado_conectado;
        bool mostro_estado_desconectado;
        bool cerrar_aplicacion;
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

        private void MostrarBalloonTip(string pIcono,string pTexto)
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
                if (timerPingTarget.Enabled == false)
                {
                    this.tiempo = int.Parse(textBoxTime.Text);
                    timerPingTarget.Enabled = true;                    
                    this.timerPingTarget.Interval = this.tiempo * 1000;
                    timerPingTarget.Start();
                }
                this.host = textBoxHost.Text;
                this.ConmutarEstadoVentanaPrincipal();
                this.mostro_estado_conectado = false;
                this.mostro_estado_desconectado = false;
            }
            catch (System.FormatException fex)
            {
                textBoxTime.Text = "2";
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
                        this.MostrarBalloonTip("informacion", "Conectado con " + this.host);
                        this.mostro_estado_conectado = true;
                        this.mostro_estado_desconectado = false;
                    }
                }
                else
                {
                    if (this.mostro_estado_desconectado == false)
                    {
                        this.MostrarBalloonTip("informacion", "Desconectado con " + this.host);
                        this.mostro_estado_conectado = false;
                        this.mostro_estado_desconectado = true;
                    }
                }
            }
            catch (System.Net.NetworkInformation.PingException pex)
            {
                if (this.mostro_estado_desconectado == false)
                {
                    this.MostrarBalloonTip("informacion", "Desconectado con " + this.host);
                    this.mostro_estado_conectado = false;
                    this.mostro_estado_desconectado = true;
                }
            }
        }

        private void PingTarget_Load(object sender, EventArgs e)
        {
            this.estadoVentana = false;
            this.mostro_estado_conectado = false;
            this.mostro_estado_desconectado = false;
            this.PosicionarVentana();
            this.ConmutarEstadoVentanaPrincipal();
        }
    }
}
