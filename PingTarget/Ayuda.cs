using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PingTarget
{
    public partial class Ayuda : Form
    {
        public Ayuda()
        {
            InitializeComponent();
        }

        private void linkLabelGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelGithub.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/michaelrodriguezalvarez/PingTarget");
        }

        private void linkLabelIssueGithub1_Click(object sender, EventArgs e)
        {            
            linkLabelIssueGithub1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/michaelrodriguezalvarez/PingTarget/issues");
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/michaelrodriguezalvarez/PingTarget/issues");
        }

        private void linkLabelColaboradores_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelColaboradores.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/michaelrodriguezalvarez/PingTarget/graphs/contributors");
        }

        private void Ayuda_Load(object sender, EventArgs e)
        {
            labelTitulo.Text = System.Windows.Forms.Application.ProductName +" "+System.Windows.Forms.Application.ProductVersion;
        }
    }
}
