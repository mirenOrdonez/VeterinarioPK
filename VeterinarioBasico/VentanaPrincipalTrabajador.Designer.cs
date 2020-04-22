namespace VeterinarioBasico
{
    partial class VentanaPrincipalTrabajador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaPrincipalTrabajador));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.apellido2Trabajador = new System.Windows.Forms.Label();
            this.apellido1Trabajador = new System.Windows.Forms.Label();
            this.nombreTrabajador = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8_calendar.ico");
            this.imageList1.Images.SetKeyName(1, "icons8_customer_1.ico");
            this.imageList1.Images.SetKeyName(2, "icons8_dog_paw.ico");
            // 
            // tabPage2
            // 
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1388, 813);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Citas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.apellido2Trabajador);
            this.tabPage1.Controls.Add(this.apellido1Trabajador);
            this.tabPage1.Controls.Add(this.nombreTrabajador);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ImageIndex = 1;
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1388, 813);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mi perfil";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(146)))), ((int)(((byte)(195)))));
            this.button1.Location = new System.Drawing.Point(555, 530);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(229, 98);
            this.button1.TabIndex = 5;
            this.button1.Text = "Correo";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // apellido2Trabajador
            // 
            this.apellido2Trabajador.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.apellido2Trabajador.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apellido2Trabajador.Location = new System.Drawing.Point(681, 390);
            this.apellido2Trabajador.Name = "apellido2Trabajador";
            this.apellido2Trabajador.Size = new System.Drawing.Size(202, 36);
            this.apellido2Trabajador.TabIndex = 4;
            this.apellido2Trabajador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // apellido1Trabajador
            // 
            this.apellido1Trabajador.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.apellido1Trabajador.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apellido1Trabajador.Location = new System.Drawing.Point(473, 390);
            this.apellido1Trabajador.Name = "apellido1Trabajador";
            this.apellido1Trabajador.Size = new System.Drawing.Size(202, 36);
            this.apellido1Trabajador.TabIndex = 3;
            this.apellido1Trabajador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nombreTrabajador
            // 
            this.nombreTrabajador.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.nombreTrabajador.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreTrabajador.Location = new System.Drawing.Point(567, 330);
            this.nombreTrabajador.Name = "nombreTrabajador";
            this.nombreTrabajador.Size = new System.Drawing.Size(202, 36);
            this.nombreTrabajador.TabIndex = 2;
            this.nombreTrabajador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(555, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 218);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1396, 856);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // VentanaPrincipalTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 856);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VentanaPrincipalTrabajador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PK Vet";
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label apellido2Trabajador;
        private System.Windows.Forms.Label apellido1Trabajador;
        private System.Windows.Forms.Label nombreTrabajador;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}