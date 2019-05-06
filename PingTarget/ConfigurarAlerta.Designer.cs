namespace PingTarget
{
    partial class ConfigurarAlerta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurarAlerta));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialogNacional = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogInternacional = new System.Windows.Forms.OpenFileDialog();
            this.buttonCargarSonidoNacional = new System.Windows.Forms.Button();
            this.buttonCargarSonidoInternacional = new System.Windows.Forms.Button();
            this.labelSonidoNacional = new System.Windows.Forms.Label();
            this.labelSonidoInternacional = new System.Windows.Forms.Label();
            this.buttonRestablecer = new System.Windows.Forms.Button();
            this.buttonConfigurar = new System.Windows.Forms.Button();
            this.textBoxNacional = new System.Windows.Forms.TextBox();
            this.textBoxInternacional = new System.Windows.Forms.TextBox();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.trackBarVolumen = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumen)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sonido para Nacional";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sonido para Internacional";
            // 
            // openFileDialogNacional
            // 
            this.openFileDialogNacional.Filter = "Fichero MP3|*.mp3";
            this.openFileDialogNacional.Title = "Seleccione un fichero de audio";
            // 
            // openFileDialogInternacional
            // 
            this.openFileDialogInternacional.Filter = "Fichero MP3|*.mp3";
            this.openFileDialogInternacional.Title = "Seleccione un fichero de audio";
            // 
            // buttonCargarSonidoNacional
            // 
            this.buttonCargarSonidoNacional.Location = new System.Drawing.Point(216, 37);
            this.buttonCargarSonidoNacional.Name = "buttonCargarSonidoNacional";
            this.buttonCargarSonidoNacional.Size = new System.Drawing.Size(35, 23);
            this.buttonCargarSonidoNacional.TabIndex = 2;
            this.buttonCargarSonidoNacional.Text = "...";
            this.buttonCargarSonidoNacional.UseVisualStyleBackColor = true;
            this.buttonCargarSonidoNacional.Click += new System.EventHandler(this.buttonCargarSonidoNacional_Click);
            // 
            // buttonCargarSonidoInternacional
            // 
            this.buttonCargarSonidoInternacional.Location = new System.Drawing.Point(215, 109);
            this.buttonCargarSonidoInternacional.Name = "buttonCargarSonidoInternacional";
            this.buttonCargarSonidoInternacional.Size = new System.Drawing.Size(34, 23);
            this.buttonCargarSonidoInternacional.TabIndex = 4;
            this.buttonCargarSonidoInternacional.Text = "...";
            this.buttonCargarSonidoInternacional.UseVisualStyleBackColor = true;
            this.buttonCargarSonidoInternacional.Click += new System.EventHandler(this.buttonCargarSonidoInternacional_Click);
            // 
            // labelSonidoNacional
            // 
            this.labelSonidoNacional.AutoSize = true;
            this.labelSonidoNacional.Location = new System.Drawing.Point(15, 64);
            this.labelSonidoNacional.Name = "labelSonidoNacional";
            this.labelSonidoNacional.Size = new System.Drawing.Size(80, 13);
            this.labelSonidoNacional.TabIndex = 0;
            this.labelSonidoNacional.Text = "No configurado";
            // 
            // labelSonidoInternacional
            // 
            this.labelSonidoInternacional.AutoSize = true;
            this.labelSonidoInternacional.Location = new System.Drawing.Point(13, 136);
            this.labelSonidoInternacional.Name = "labelSonidoInternacional";
            this.labelSonidoInternacional.Size = new System.Drawing.Size(80, 13);
            this.labelSonidoInternacional.TabIndex = 0;
            this.labelSonidoInternacional.Text = "No configurado";
            // 
            // buttonRestablecer
            // 
            this.buttonRestablecer.Image = global::PingTarget.Properties.Resources.delete;
            this.buttonRestablecer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRestablecer.Location = new System.Drawing.Point(98, 213);
            this.buttonRestablecer.Name = "buttonRestablecer";
            this.buttonRestablecer.Size = new System.Drawing.Size(88, 23);
            this.buttonRestablecer.TabIndex = 7;
            this.buttonRestablecer.Text = "Restablecer";
            this.buttonRestablecer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRestablecer.UseVisualStyleBackColor = true;
            this.buttonRestablecer.Click += new System.EventHandler(this.buttonRestablecer_Click);
            // 
            // buttonConfigurar
            // 
            this.buttonConfigurar.Image = global::PingTarget.Properties.Resources.bell;
            this.buttonConfigurar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonConfigurar.Location = new System.Drawing.Point(9, 213);
            this.buttonConfigurar.Name = "buttonConfigurar";
            this.buttonConfigurar.Size = new System.Drawing.Size(83, 23);
            this.buttonConfigurar.TabIndex = 6;
            this.buttonConfigurar.Text = "Configurar";
            this.buttonConfigurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonConfigurar.UseVisualStyleBackColor = true;
            this.buttonConfigurar.Click += new System.EventHandler(this.buttonConfigurar_Click);
            // 
            // textBoxNacional
            // 
            this.textBoxNacional.Location = new System.Drawing.Point(15, 38);
            this.textBoxNacional.Name = "textBoxNacional";
            this.textBoxNacional.Size = new System.Drawing.Size(195, 20);
            this.textBoxNacional.TabIndex = 1;
            // 
            // textBoxInternacional
            // 
            this.textBoxInternacional.Location = new System.Drawing.Point(15, 110);
            this.textBoxInternacional.Name = "textBoxInternacional";
            this.textBoxInternacional.Size = new System.Drawing.Size(195, 20);
            this.textBoxInternacional.TabIndex = 3;
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Image = global::PingTarget.Properties.Resources.close_16x16;
            this.buttonCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCerrar.Location = new System.Drawing.Point(192, 213);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(60, 23);
            this.buttonCerrar.TabIndex = 8;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // trackBarVolumen
            // 
            this.trackBarVolumen.Location = new System.Drawing.Point(119, 162);
            this.trackBarVolumen.Name = "trackBarVolumen";
            this.trackBarVolumen.Size = new System.Drawing.Size(130, 45);
            this.trackBarVolumen.TabIndex = 5;
            this.trackBarVolumen.Value = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Volumen Sonido";
            // 
            // ConfigurarAlerta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 253);
            this.Controls.Add(this.trackBarVolumen);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.textBoxInternacional);
            this.Controls.Add(this.textBoxNacional);
            this.Controls.Add(this.buttonRestablecer);
            this.Controls.Add(this.labelSonidoInternacional);
            this.Controls.Add(this.labelSonidoNacional);
            this.Controls.Add(this.buttonCargarSonidoInternacional);
            this.Controls.Add(this.buttonCargarSonidoNacional);
            this.Controls.Add(this.buttonConfigurar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurarAlerta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Configurar Alerta";
            this.Load += new System.EventHandler(this.ConfigurarAlerta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialogNacional;
        private System.Windows.Forms.OpenFileDialog openFileDialogInternacional;
        private System.Windows.Forms.Button buttonConfigurar;
        private System.Windows.Forms.Button buttonCargarSonidoNacional;
        private System.Windows.Forms.Button buttonCargarSonidoInternacional;
        private System.Windows.Forms.Label labelSonidoNacional;
        private System.Windows.Forms.Label labelSonidoInternacional;
        private System.Windows.Forms.Button buttonRestablecer;
        private System.Windows.Forms.TextBox textBoxNacional;
        private System.Windows.Forms.TextBox textBoxInternacional;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.TrackBar trackBarVolumen;
        private System.Windows.Forms.Label label3;
    }
}