namespace PingTarget
{
    partial class PingTarget
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PingTarget));
            this.notifyIconPingTarget = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.buttonComprobar = new System.Windows.Forms.Button();
            this.timerPingTarget = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxHostInternacional = new System.Windows.Forms.TextBox();
            this.timerPingTargetInternacional = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.labelEstadoNacional = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelEstadoInternacional = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // notifyIconPingTarget
            // 
            this.notifyIconPingTarget.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconPingTarget.BalloonTipText = "PingTarget se está ejecutando";
            this.notifyIconPingTarget.BalloonTipTitle = "Información";
            this.notifyIconPingTarget.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconPingTarget.Icon")));
            this.notifyIconPingTarget.Text = "PingTarget se está ejecutando";
            this.notifyIconPingTarget.Visible = true;
            this.notifyIconPingTarget.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconPingTarget_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host Nacional";
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(15, 31);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(100, 20);
            this.textBoxHost.TabIndex = 1;
            this.textBoxHost.Text = "127.0.0.1";
            // 
            // buttonComprobar
            // 
            this.buttonComprobar.Location = new System.Drawing.Point(15, 241);
            this.buttonComprobar.Name = "buttonComprobar";
            this.buttonComprobar.Size = new System.Drawing.Size(75, 23);
            this.buttonComprobar.TabIndex = 2;
            this.buttonComprobar.Text = "Comprobar";
            this.buttonComprobar.UseVisualStyleBackColor = true;
            this.buttonComprobar.Click += new System.EventHandler(this.buttonComprobar_Click);
            // 
            // timerPingTarget
            // 
            this.timerPingTarget.Interval = 2000;
            this.timerPingTarget.Tick += new System.EventHandler(this.timerPingTarget_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tiempo (Segundos)";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(15, 145);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(58, 20);
            this.textBoxTime.TabIndex = 1;
            this.textBoxTime.Text = "2";
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(116, 241);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(75, 23);
            this.buttonCerrar.TabIndex = 3;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Host Internacional";
            // 
            // textBoxHostInternacional
            // 
            this.textBoxHostInternacional.Location = new System.Drawing.Point(16, 93);
            this.textBoxHostInternacional.Name = "textBoxHostInternacional";
            this.textBoxHostInternacional.Size = new System.Drawing.Size(100, 20);
            this.textBoxHostInternacional.TabIndex = 5;
            this.textBoxHostInternacional.Text = "127.0.0.2";
            // 
            // timerPingTargetInternacional
            // 
            this.timerPingTargetInternacional.Interval = 2000;
            this.timerPingTargetInternacional.Tick += new System.EventHandler(this.timerPingTargetInternacional_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Estado Nacional";
            // 
            // labelEstadoNacional
            // 
            this.labelEstadoNacional.AutoSize = true;
            this.labelEstadoNacional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstadoNacional.ForeColor = System.Drawing.Color.Red;
            this.labelEstadoNacional.Location = new System.Drawing.Point(133, 181);
            this.labelEstadoNacional.Name = "labelEstadoNacional";
            this.labelEstadoNacional.Size = new System.Drawing.Size(89, 13);
            this.labelEstadoNacional.TabIndex = 6;
            this.labelEstadoNacional.Text = "Desconectado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Estado Internacional";
            // 
            // labelEstadoInternacional
            // 
            this.labelEstadoInternacional.AutoSize = true;
            this.labelEstadoInternacional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstadoInternacional.ForeColor = System.Drawing.Color.Red;
            this.labelEstadoInternacional.Location = new System.Drawing.Point(132, 207);
            this.labelEstadoInternacional.Name = "labelEstadoInternacional";
            this.labelEstadoInternacional.Size = new System.Drawing.Size(89, 13);
            this.labelEstadoInternacional.TabIndex = 6;
            this.labelEstadoInternacional.Text = "Desconectado";
            // 
            // PingTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 276);
            this.Controls.Add(this.labelEstadoInternacional);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelEstadoNacional);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxHostInternacional);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.buttonComprobar);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.textBoxHost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PingTarget";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PingTarget";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PingTarget_FormClosing);
            this.Load += new System.EventHandler(this.PingTarget_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconPingTarget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.Button buttonComprobar;
        private System.Windows.Forms.Timer timerPingTarget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHostInternacional;
        private System.Windows.Forms.Timer timerPingTargetInternacional;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelEstadoNacional;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelEstadoInternacional;
    }
}

