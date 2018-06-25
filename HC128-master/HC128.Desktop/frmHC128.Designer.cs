namespace HC128.Desktop
{
    partial class FrmHC128
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
            this.lblIpServer = new System.Windows.Forms.Label();
            this.txtIPServer = new System.Windows.Forms.TextBox();
            this.txtNameImg = new System.Windows.Forms.TextBox();
            this.lblNameImg = new System.Windows.Forms.Label();
            this.btnWebCam = new System.Windows.Forms.Button();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.txtIV = new System.Windows.Forms.TextBox();
            this.lblIV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIpServer
            // 
            this.lblIpServer.AutoSize = true;
            this.lblIpServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpServer.Location = new System.Drawing.Point(9, 459);
            this.lblIpServer.Name = "lblIpServer";
            this.lblIpServer.Size = new System.Drawing.Size(72, 16);
            this.lblIpServer.TabIndex = 3;
            this.lblIpServer.Text = "IP Server";
            // 
            // txtIPServer
            // 
            this.txtIPServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPServer.Location = new System.Drawing.Point(12, 478);
            this.txtIPServer.MaxLength = 15;
            this.txtIPServer.Name = "txtIPServer";
            this.txtIPServer.Size = new System.Drawing.Size(159, 22);
            this.txtIPServer.TabIndex = 4;
            this.txtIPServer.Text = "127.0.0.1:5000";
            // 
            // txtNameImg
            // 
            this.txtNameImg.Location = new System.Drawing.Point(12, 125);
            this.txtNameImg.Name = "txtNameImg";
            this.txtNameImg.Size = new System.Drawing.Size(159, 20);
            this.txtNameImg.TabIndex = 7;
            // 
            // lblNameImg
            // 
            this.lblNameImg.AutoSize = true;
            this.lblNameImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameImg.Location = new System.Drawing.Point(9, 106);
            this.lblNameImg.Name = "lblNameImg";
            this.lblNameImg.Size = new System.Drawing.Size(118, 16);
            this.lblNameImg.TabIndex = 6;
            this.lblNameImg.Text = "Nombre Imagen";
            // 
            // btnWebCam
            // 
            this.btnWebCam.BackColor = System.Drawing.Color.White;
            this.btnWebCam.Image = global::HC128.Desktop.Properties.Resources.camera;
            this.btnWebCam.Location = new System.Drawing.Point(12, 60);
            this.btnWebCam.Name = "btnWebCam";
            this.btnWebCam.Size = new System.Drawing.Size(159, 43);
            this.btnWebCam.TabIndex = 5;
            this.btnWebCam.Text = "Foto WebCam";
            this.btnWebCam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWebCam.UseVisualStyleBackColor = false;
            this.btnWebCam.Click += new System.EventHandler(this.btnWebCam_Click);
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.BackColor = System.Drawing.Color.White;
            this.btnUploadImage.Enabled = false;
            this.btnUploadImage.Image = global::HC128.Desktop.Properties.Resources.upload;
            this.btnUploadImage.Location = new System.Drawing.Point(12, 506);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(159, 43);
            this.btnUploadImage.TabIndex = 2;
            this.btnUploadImage.Text = "Subir Imagen";
            this.btnUploadImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUploadImage.UseVisualStyleBackColor = false;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // picBox
            // 
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(184, -1);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(800, 564);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.BackColor = System.Drawing.Color.White;
            this.btnSelectImage.Image = global::HC128.Desktop.Properties.Resources.folder;
            this.btnSelectImage.Location = new System.Drawing.Point(12, 12);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(159, 43);
            this.btnSelectImage.TabIndex = 0;
            this.btnSelectImage.Text = "Abrir Imagen";
            this.btnSelectImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelectImage.UseVisualStyleBackColor = false;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(12, 167);
            this.txtKey.MaxLength = 4;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(159, 20);
            this.txtKey.TabIndex = 9;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey.Location = new System.Drawing.Point(9, 148);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(46, 16);
            this.lblKey.TabIndex = 8;
            this.lblKey.Text = "Llave";
            // 
            // txtIV
            // 
            this.txtIV.Location = new System.Drawing.Point(12, 209);
            this.txtIV.MaxLength = 4;
            this.txtIV.Name = "txtIV";
            this.txtIV.Size = new System.Drawing.Size(159, 20);
            this.txtIV.TabIndex = 11;
            // 
            // lblIV
            // 
            this.lblIV.AutoSize = true;
            this.lblIV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIV.Location = new System.Drawing.Point(9, 190);
            this.lblIV.Name = "lblIV";
            this.lblIV.Size = new System.Drawing.Size(147, 16);
            this.lblIV.TabIndex = 10;
            this.lblIV.Text = "Vector Inicialización";
            // 
            // FrmHC128
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.txtIV);
            this.Controls.Add(this.lblIV);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.txtNameImg);
            this.Controls.Add(this.lblNameImg);
            this.Controls.Add(this.btnWebCam);
            this.Controls.Add(this.txtIPServer);
            this.Controls.Add(this.lblIpServer);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.btnSelectImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmHC128";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HC-128 Encriptar";
            this.Load += new System.EventHandler(this.FrmHC128_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Label lblIpServer;
        private System.Windows.Forms.TextBox txtIPServer;
        private System.Windows.Forms.Button btnWebCam;
        private System.Windows.Forms.TextBox txtNameImg;
        private System.Windows.Forms.Label lblNameImg;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtIV;
        private System.Windows.Forms.Label lblIV;
    }
}