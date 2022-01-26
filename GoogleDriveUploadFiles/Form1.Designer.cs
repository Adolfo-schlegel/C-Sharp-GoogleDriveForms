namespace GoogleDriveUploadFiles
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.Subir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Ruta = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.createFolder = new System.Windows.Forms.Button();
            this.Download_files = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.ForeColor = System.Drawing.Color.Teal;
            this.btnBuscar.Location = new System.Drawing.Point(10, 34);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(112, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar Archivo";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Subir
            // 
            this.Subir.AutoSize = true;
            this.Subir.BackColor = System.Drawing.Color.Transparent;
            this.Subir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Subir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Subir.ForeColor = System.Drawing.Color.ForestGreen;
            this.Subir.Location = new System.Drawing.Point(10, 209);
            this.Subir.Name = "Subir";
            this.Subir.Size = new System.Drawing.Size(196, 23);
            this.Subir.TabIndex = 1;
            this.Subir.Text = "Subir";
            this.Subir.UseVisualStyleBackColor = false;
            this.Subir.Click += new System.EventHandler(this.Subir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ruta del archivo ->";
            // 
            // Ruta
            // 
            this.Ruta.AutoSize = true;
            this.Ruta.Location = new System.Drawing.Point(124, 9);
            this.Ruta.Name = "Ruta";
            this.Ruta.Size = new System.Drawing.Size(0, 13);
            this.Ruta.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 87);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "------Seleccione carpeta-------";
            // 
            // createFolder
            // 
            this.createFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.createFolder.Location = new System.Drawing.Point(158, 87);
            this.createFolder.Name = "createFolder";
            this.createFolder.Size = new System.Drawing.Size(48, 23);
            this.createFolder.TabIndex = 6;
            this.createFolder.Text = "Create";
            this.createFolder.UseVisualStyleBackColor = true;
            this.createFolder.Click += new System.EventHandler(this.createFolder_Click);
            // 
            // Download_files
            // 
            this.Download_files.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Download_files.Location = new System.Drawing.Point(520, 12);
            this.Download_files.Name = "Download_files";
            this.Download_files.Size = new System.Drawing.Size(131, 23);
            this.Download_files.TabIndex = 7;
            this.Download_files.Text = "Descargar archivos";
            this.Download_files.UseVisualStyleBackColor = true;
            this.Download_files.Click += new System.EventHandler(this.Download_files_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(663, 244);
            this.Controls.Add(this.Download_files);
            this.Controls.Add(this.createFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Ruta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Subir);
            this.Controls.Add(this.btnBuscar);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Google Drive App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button Subir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Ruta;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button createFolder;
        private System.Windows.Forms.Button Download_files;
    }
}

