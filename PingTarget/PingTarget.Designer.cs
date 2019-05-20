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
            this.timerPingTarget = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxHostInternacional = new System.Windows.Forms.TextBox();
            this.timerPingTargetInternacional = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.labelEstadoNacional = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelEstadoInternacional = new System.Windows.Forms.Label();
            this.pictureBoxTiempo = new System.Windows.Forms.PictureBox();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.buttonComprobar = new System.Windows.Forms.Button();
            this.timerSonidosAlertas = new System.Windows.Forms.Timer(this.components);
            this.buttonAlertas = new System.Windows.Forms.Button();
            this.labelEnunciadoEstado = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.numericUpDownTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTiempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host Nacional";
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(122, 6);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(100, 20);
            this.textBoxHost.TabIndex = 1;
            this.textBoxHost.Text = "127.0.0.1";
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
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tiempo (Segundos)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Host Internacional";
            // 
            // textBoxHostInternacional
            // 
            this.textBoxHostInternacional.Location = new System.Drawing.Point(122, 38);
            this.textBoxHostInternacional.Name = "textBoxHostInternacional";
            this.textBoxHostInternacional.Size = new System.Drawing.Size(100, 20);
            this.textBoxHostInternacional.TabIndex = 2;
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
            this.label4.Location = new System.Drawing.Point(6, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Estado Nacional";
            // 
            // labelEstadoNacional
            // 
            this.labelEstadoNacional.AutoSize = true;
            this.labelEstadoNacional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstadoNacional.ForeColor = System.Drawing.Color.Red;
            this.labelEstadoNacional.Location = new System.Drawing.Point(133, 106);
            this.labelEstadoNacional.Name = "labelEstadoNacional";
            this.labelEstadoNacional.Size = new System.Drawing.Size(89, 13);
            this.labelEstadoNacional.TabIndex = 0;
            this.labelEstadoNacional.Text = "Desconectado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Estado Internacional";
            // 
            // labelEstadoInternacional
            // 
            this.labelEstadoInternacional.AutoSize = true;
            this.labelEstadoInternacional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstadoInternacional.ForeColor = System.Drawing.Color.Red;
            this.labelEstadoInternacional.Location = new System.Drawing.Point(132, 132);
            this.labelEstadoInternacional.Name = "labelEstadoInternacional";
            this.labelEstadoInternacional.Size = new System.Drawing.Size(89, 13);
            this.labelEstadoInternacional.TabIndex = 0;
            this.labelEstadoInternacional.Text = "Desconectado";
            // 
            // pictureBoxTiempo
            // 
            this.pictureBoxTiempo.Image = global::PingTarget.Properties.Resources.Time_16x16;
            this.pictureBoxTiempo.Location = new System.Drawing.Point(196, 74);
            this.pictureBoxTiempo.Name = "pictureBoxTiempo";
            this.pictureBoxTiempo.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxTiempo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxTiempo.TabIndex = 7;
            this.pictureBoxTiempo.TabStop = false;
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Image = global::PingTarget.Properties.Resources.close_16x16;
            this.buttonCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCerrar.Location = new System.Drawing.Point(162, 158);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(61, 23);
            this.buttonCerrar.TabIndex = 6;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // buttonComprobar
            // 
            this.buttonComprobar.Image = global::PingTarget.Properties.Resources.checkbox_16x16;
            this.buttonComprobar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonComprobar.Location = new System.Drawing.Point(72, 158);
            this.buttonComprobar.Name = "buttonComprobar";
            this.buttonComprobar.Size = new System.Drawing.Size(84, 23);
            this.buttonComprobar.TabIndex = 5;
            this.buttonComprobar.Text = "Comprobar";
            this.buttonComprobar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonComprobar.UseVisualStyleBackColor = true;
            this.buttonComprobar.Click += new System.EventHandler(this.buttonComprobar_Click);
            // 
            // timerSonidosAlertas
            // 
            this.timerSonidosAlertas.Interval = 500;
            this.timerSonidosAlertas.Tick += new System.EventHandler(this.timerSonidosAlertas_Tick);
            // 
            // buttonAlertas
            // 
            this.buttonAlertas.Image = global::PingTarget.Properties.Resources.bell;
            this.buttonAlertas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAlertas.Location = new System.Drawing.Point(9, 158);
            this.buttonAlertas.Name = "buttonAlertas";
            this.buttonAlertas.Size = new System.Drawing.Size(57, 23);
            this.buttonAlertas.TabIndex = 4;
            this.buttonAlertas.Text = "Alerta";
            this.buttonAlertas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAlertas.UseVisualStyleBackColor = true;
            this.buttonAlertas.Click += new System.EventHandler(this.buttonAlertas_Click);
            // 
            // labelEnunciadoEstado
            // 
            this.labelEnunciadoEstado.AutoSize = true;
            this.labelEnunciadoEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnunciadoEstado.Location = new System.Drawing.Point(121, 190);
            this.labelEnunciadoEstado.Name = "labelEnunciadoEstado";
            this.labelEnunciadoEstado.Size = new System.Drawing.Size(50, 13);
            this.labelEnunciadoEstado.TabIndex = 8;
            this.labelEnunciadoEstado.Text = "Estado:";
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.ForeColor = System.Drawing.Color.Red;
            this.labelEstado.Location = new System.Drawing.Point(171, 190);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(53, 13);
            this.labelEstado.TabIndex = 9;
            this.labelEstado.Text = "Inactivo";
            // 
            // numericUpDownTime
            // 
            this.numericUpDownTime.Location = new System.Drawing.Point(135, 72);
            this.numericUpDownTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTime.Name = "numericUpDownTime";
            this.numericUpDownTime.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownTime.TabIndex = 10;
            this.numericUpDownTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // PingTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 209);
            this.Controls.Add(this.numericUpDownTime);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.labelEnunciadoEstado);
            this.Controls.Add(this.buttonAlertas);
            this.Controls.Add(this.pictureBoxTiempo);
            this.Controls.Add(this.labelEstadoInternacional);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelEstadoNacional);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxHostInternacional);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.buttonComprobar);
            this.Controls.Add(this.textBoxHost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PingTarget";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PingTarget";
            this.TopMost = true;
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.PingTarget_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PingTarget_FormClosing);
            this.Load += new System.EventHandler(this.PingTarget_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTiempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTime)).EndInit();
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
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHostInternacional;
        private System.Windows.Forms.Timer timerPingTargetInternacional;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelEstadoNacional;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelEstadoInternacional;
        private System.Windows.Forms.PictureBox pictureBoxTiempo;
        private System.Windows.Forms.Timer timerSonidosAlertas;
        private System.Windows.Forms.Button buttonAlertas;
        private System.Windows.Forms.Label labelEnunciadoEstado;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.NumericUpDown numericUpDownTime;
    }
}

