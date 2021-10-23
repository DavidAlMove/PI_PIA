namespace PI_PIA
{
    partial class Form1
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
            this.OFD_Image = new System.Windows.Forms.OpenFileDialog();
            this.pbOriginalImage = new System.Windows.Forms.PictureBox();
            this.pbFilteredImage = new System.Windows.Forms.PictureBox();
            this.btnFindPicture = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.cbFilters = new System.Windows.Forms.ComboBox();
            this.gbVideo = new System.Windows.Forms.GroupBox();
            this.btnStopMovementDetection = new System.Windows.Forms.Button();
            this.btnDetectMovement = new System.Windows.Forms.Button();
            this.btnStopRecording = new System.Windows.Forms.Button();
            this.cbCameras = new System.Windows.Forms.ComboBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnTurnOffCam = new System.Windows.Forms.Button();
            this.btnTakePicture = new System.Windows.Forms.Button();
            this.btnTurnOnCam = new System.Windows.Forms.Button();
            this.btnSavePicture = new System.Windows.Forms.Button();
            this.gbOriginalImage = new System.Windows.Forms.GroupBox();
            this.vspVideo = new AForge.Controls.VideoSourcePlayer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnDetectFaces = new System.Windows.Forms.Button();
            this.btnStopDetectFaces = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFilteredImage)).BeginInit();
            this.gbVideo.SuspendLayout();
            this.gbOriginalImage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OFD_Image
            // 
            this.OFD_Image.FileName = "openFileDialog1";
            this.OFD_Image.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // pbOriginalImage
            // 
            this.pbOriginalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOriginalImage.Location = new System.Drawing.Point(6, 19);
            this.pbOriginalImage.Name = "pbOriginalImage";
            this.pbOriginalImage.Size = new System.Drawing.Size(500, 500);
            this.pbOriginalImage.TabIndex = 0;
            this.pbOriginalImage.TabStop = false;
            // 
            // pbFilteredImage
            // 
            this.pbFilteredImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFilteredImage.Location = new System.Drawing.Point(18, 57);
            this.pbFilteredImage.Name = "pbFilteredImage";
            this.pbFilteredImage.Size = new System.Drawing.Size(500, 500);
            this.pbFilteredImage.TabIndex = 1;
            this.pbFilteredImage.TabStop = false;
            // 
            // btnFindPicture
            // 
            this.btnFindPicture.Location = new System.Drawing.Point(12, 12);
            this.btnFindPicture.Name = "btnFindPicture";
            this.btnFindPicture.Size = new System.Drawing.Size(95, 23);
            this.btnFindPicture.TabIndex = 2;
            this.btnFindPicture.Text = "Abrir archivo";
            this.btnFindPicture.UseVisualStyleBackColor = true;
            this.btnFindPicture.Click += new System.EventHandler(this.btnFindPicture_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(113, 14);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(556, 20);
            this.txtFileName.TabIndex = 3;
            // 
            // cbFilters
            // 
            this.cbFilters.FormattingEnabled = true;
            this.cbFilters.Items.AddRange(new object[] {
            "Blanco y Negro",
            "Sepia",
            "Negativo",
            "Pixelado",
            "Rojos",
            "None"});
            this.cbFilters.Location = new System.Drawing.Point(18, 19);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(169, 21);
            this.cbFilters.TabIndex = 4;
            this.cbFilters.Text = "Seleccione un filtro...";
            this.cbFilters.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // gbVideo
            // 
            this.gbVideo.Controls.Add(this.btnStopDetectFaces);
            this.gbVideo.Controls.Add(this.btnDetectFaces);
            this.gbVideo.Controls.Add(this.btnStopMovementDetection);
            this.gbVideo.Controls.Add(this.btnDetectMovement);
            this.gbVideo.Controls.Add(this.btnStopRecording);
            this.gbVideo.Controls.Add(this.cbCameras);
            this.gbVideo.Controls.Add(this.btnRecord);
            this.gbVideo.Controls.Add(this.btnTurnOffCam);
            this.gbVideo.Controls.Add(this.btnTakePicture);
            this.gbVideo.Controls.Add(this.btnTurnOnCam);
            this.gbVideo.Location = new System.Drawing.Point(1151, 306);
            this.gbVideo.Name = "gbVideo";
            this.gbVideo.Size = new System.Drawing.Size(172, 336);
            this.gbVideo.TabIndex = 5;
            this.gbVideo.TabStop = false;
            this.gbVideo.Text = "Cámara de Video";
            // 
            // btnStopMovementDetection
            // 
            this.btnStopMovementDetection.Location = new System.Drawing.Point(6, 196);
            this.btnStopMovementDetection.Name = "btnStopMovementDetection";
            this.btnStopMovementDetection.Size = new System.Drawing.Size(75, 55);
            this.btnStopMovementDetection.TabIndex = 7;
            this.btnStopMovementDetection.Text = "Dejar de Detectar Movimiento";
            this.btnStopMovementDetection.UseVisualStyleBackColor = true;
            this.btnStopMovementDetection.Click += new System.EventHandler(this.btnStopMovementDetection_Click);
            // 
            // btnDetectMovement
            // 
            this.btnDetectMovement.Location = new System.Drawing.Point(6, 150);
            this.btnDetectMovement.Name = "btnDetectMovement";
            this.btnDetectMovement.Size = new System.Drawing.Size(75, 39);
            this.btnDetectMovement.TabIndex = 6;
            this.btnDetectMovement.Text = "Detectar Movimiento";
            this.btnDetectMovement.UseVisualStyleBackColor = true;
            this.btnDetectMovement.Click += new System.EventHandler(this.btnDetectMovement_Click);
            // 
            // btnStopRecording
            // 
            this.btnStopRecording.Location = new System.Drawing.Point(87, 150);
            this.btnStopRecording.Name = "btnStopRecording";
            this.btnStopRecording.Size = new System.Drawing.Size(75, 40);
            this.btnStopRecording.TabIndex = 5;
            this.btnStopRecording.Text = "Detener Grabacion";
            this.btnStopRecording.UseVisualStyleBackColor = true;
            this.btnStopRecording.Visible = false;
            this.btnStopRecording.Click += new System.EventHandler(this.btnStopRecording_Click);
            // 
            // cbCameras
            // 
            this.cbCameras.FormattingEnabled = true;
            this.cbCameras.Location = new System.Drawing.Point(6, 19);
            this.cbCameras.Name = "cbCameras";
            this.cbCameras.Size = new System.Drawing.Size(156, 21);
            this.cbCameras.TabIndex = 4;
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(87, 104);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(75, 40);
            this.btnRecord.TabIndex = 3;
            this.btnRecord.Text = "Grabar Video";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnTurnOffCam
            // 
            this.btnTurnOffCam.Location = new System.Drawing.Point(6, 104);
            this.btnTurnOffCam.Name = "btnTurnOffCam";
            this.btnTurnOffCam.Size = new System.Drawing.Size(75, 40);
            this.btnTurnOffCam.TabIndex = 2;
            this.btnTurnOffCam.Text = "Apagar Cámara";
            this.btnTurnOffCam.UseVisualStyleBackColor = true;
            this.btnTurnOffCam.Click += new System.EventHandler(this.btnTurnOffCam_Click);
            // 
            // btnTakePicture
            // 
            this.btnTakePicture.Location = new System.Drawing.Point(87, 58);
            this.btnTakePicture.Name = "btnTakePicture";
            this.btnTakePicture.Size = new System.Drawing.Size(75, 40);
            this.btnTakePicture.TabIndex = 1;
            this.btnTakePicture.Text = "Tomar Fotografía";
            this.btnTakePicture.UseVisualStyleBackColor = true;
            this.btnTakePicture.Click += new System.EventHandler(this.btnTakePicture_Click);
            // 
            // btnTurnOnCam
            // 
            this.btnTurnOnCam.Location = new System.Drawing.Point(6, 58);
            this.btnTurnOnCam.Name = "btnTurnOnCam";
            this.btnTurnOnCam.Size = new System.Drawing.Size(75, 40);
            this.btnTurnOnCam.TabIndex = 0;
            this.btnTurnOnCam.Text = "Encender Cámara";
            this.btnTurnOnCam.UseVisualStyleBackColor = true;
            this.btnTurnOnCam.Click += new System.EventHandler(this.btnTurnOnCam_Click);
            // 
            // btnSavePicture
            // 
            this.btnSavePicture.Location = new System.Drawing.Point(395, 17);
            this.btnSavePicture.Name = "btnSavePicture";
            this.btnSavePicture.Size = new System.Drawing.Size(123, 23);
            this.btnSavePicture.TabIndex = 6;
            this.btnSavePicture.Text = "Guardar Imagen";
            this.btnSavePicture.UseVisualStyleBackColor = true;
            // 
            // gbOriginalImage
            // 
            this.gbOriginalImage.Controls.Add(this.pbOriginalImage);
            this.gbOriginalImage.Location = new System.Drawing.Point(12, 104);
            this.gbOriginalImage.Name = "gbOriginalImage";
            this.gbOriginalImage.Size = new System.Drawing.Size(522, 538);
            this.gbOriginalImage.TabIndex = 7;
            this.gbOriginalImage.TabStop = false;
            this.gbOriginalImage.Text = "Imagen Original";
            // 
            // vspVideo
            // 
            this.vspVideo.Location = new System.Drawing.Point(18, 49);
            this.vspVideo.Name = "vspVideo";
            this.vspVideo.Size = new System.Drawing.Size(500, 372);
            this.vspVideo.TabIndex = 9;
            this.vspVideo.Text = "videoSourcePlayer1";
            this.vspVideo.VideoSource = null;
            this.vspVideo.Visible = false;
            this.vspVideo.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.vspVideo_NewFrame);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vspVideo);
            this.groupBox1.Controls.Add(this.pbFilteredImage);
            this.groupBox1.Controls.Add(this.btnSavePicture);
            this.groupBox1.Controls.Add(this.cbFilters);
            this.groupBox1.Location = new System.Drawing.Point(568, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 568);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Imagen Filtrada";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnDetectFaces
            // 
            this.btnDetectFaces.Location = new System.Drawing.Point(6, 262);
            this.btnDetectFaces.Name = "btnDetectFaces";
            this.btnDetectFaces.Size = new System.Drawing.Size(75, 55);
            this.btnDetectFaces.TabIndex = 8;
            this.btnDetectFaces.Text = "Detectar Caras";
            this.btnDetectFaces.UseVisualStyleBackColor = true;
            this.btnDetectFaces.Click += new System.EventHandler(this.btnDetectFaces_Click);
            // 
            // btnStopDetectFaces
            // 
            this.btnStopDetectFaces.Location = new System.Drawing.Point(87, 262);
            this.btnStopDetectFaces.Name = "btnStopDetectFaces";
            this.btnStopDetectFaces.Size = new System.Drawing.Size(75, 55);
            this.btnStopDetectFaces.TabIndex = 9;
            this.btnStopDetectFaces.Text = "Dejas de Detectar Caras";
            this.btnStopDetectFaces.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 665);
            this.Controls.Add(this.gbOriginalImage);
            this.Controls.Add(this.gbVideo);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnFindPicture);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFilteredImage)).EndInit();
            this.gbVideo.ResumeLayout(false);
            this.gbOriginalImage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OFD_Image;
        private System.Windows.Forms.PictureBox pbOriginalImage;
        private System.Windows.Forms.PictureBox pbFilteredImage;
        private System.Windows.Forms.Button btnFindPicture;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.ComboBox cbFilters;
        private System.Windows.Forms.GroupBox gbVideo;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnTurnOffCam;
        private System.Windows.Forms.Button btnTakePicture;
        private System.Windows.Forms.Button btnTurnOnCam;
        private System.Windows.Forms.Button btnSavePicture;
        private System.Windows.Forms.GroupBox gbOriginalImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbCameras;
        private System.Windows.Forms.Button btnStopRecording;
        private System.Windows.Forms.Button btnDetectMovement;
        private AForge.Controls.VideoSourcePlayer vspVideo;
        private System.Windows.Forms.Button btnStopMovementDetection;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStopDetectFaces;
        private System.Windows.Forms.Button btnDetectFaces;
    }
}

