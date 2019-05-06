using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PingTarget
{
    class Configuracion
    {
        private string host_nacional;
        private string host_internacional;
        private int tiempo;
        private string sonido_nacional;
        private string sonido_internacional;
        private int volumen;      

        public Configuracion()
        {
            this.host_nacional = "127.0.0.1";
            this.host_internacional = "127.0.0.2";
            this.tiempo = 2;
            this.sonido_nacional = "No definido";
            this.sonido_internacional = "No definido";
            this.volumen = 100;
        }
        public string Host_nacional
        {
            get
            {
                return host_nacional;
            }

            set
            {
                host_nacional = value;
            }
        }

        public string Host_internacional
        {
            get
            {
                return host_internacional;
            }

            set
            {
                host_internacional = value;
            }
        }

        public int Tiempo
        {
            get
            {
                return tiempo;
            }

            set
            {
                tiempo = value;
            }
        }

        public string Sonido_nacional
        {
            get
            {
                return sonido_nacional;
            }

            set
            {
                sonido_nacional = value;
            }
        }

        public string Sonido_internacional
        {
            get
            {
                return sonido_internacional;
            }

            set
            {
                sonido_internacional = value;
            }
        }

        public int Volumen
        {
            get
            {
                return volumen;
            }

            set
            {
                volumen = value;
            }
        }
    }
}
