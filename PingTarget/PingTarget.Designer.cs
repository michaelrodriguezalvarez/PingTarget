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
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host";
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
            this.buttonComprobar.Location = new System.Drawing.Point(15, 120);
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
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tiempo (Segundos)";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(15, 85);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(58, 20);
            this.textBoxTime.TabIndex = 1;
            this.textBoxTime.Text = "2";
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(116, 120);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(75, 23);
            this.buttonCerrar.TabIndex = 3;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // PingTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 155);
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
    }
}

