﻿using System;
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
using System.IO;

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
        string host_internacional;
        bool mostro_estado_conectado_internacional;
        bool mostro_estado_desconectado_internacional;
        bool conectado_nacional;
        bool conectado_internacional;

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
                    this.timerPingTarget.Enabled = true;                    
                    this.timerPingTarget.Interval = this.tiempo * 1000;                    
                    this.timerPingTarget.Start();
                   
                }

                if (timerPingTargetInternacional.Enabled == false)
                {
                    this.tiempo = int.Parse(textBoxTime.Text);
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
                        this.MostrarBalloonTip("informacion", "Conectado con el host nacional " + this.host);
                        this.mostro_estado_conectado = true;
                        this.mostro_estado_desconectado = false;
                        this.conectado_nacional = true;
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
            catch (System.Net.NetworkInformation.PingException pex)
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
                StreamReader fichero = new StreamReader("PigTarget.conf");
                textBoxHost.Text = fichero.ReadLine();
                fichero.Close();
                StreamReader fichero_internacional = new StreamReader("PigTargetInternacional.conf");
                textBoxHostInternacional.Text = fichero_internacional.ReadLine();
                fichero_internacional.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void SalvarConfiguracion()
        {
            try
            {
                StreamWriter fichero = new StreamWriter("PigTarget.conf");
                fichero.WriteLine(this.host);
                fichero.Close();
                StreamWriter fichero_internacional = new StreamWriter("PigTargetInternacional.conf");
                fichero_internacional.WriteLine(this.host_internacional);
                fichero_internacional.Close();
            }
            catch (Exception ex)
            {

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
            catch (System.Net.NetworkInformation.PingException pex)
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
    }
}
