using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using AForge.Imaging.Filters;
//Ver la cámara
using AForge.Video;
using AForge.Video.DirectShow;
//Guardar el video
using AForge.Video.FFMPEG;
using AForge.Video.VFW;
//Detectar movimiento
using AForge.Vision.Motion;
//Detectar rostros
using Emgu.CV;
using Emgu.CV.Structure;


namespace PI_PIA
{
    public partial class Form1 : Form
    {
        //Para detectar la cámara
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        //Para grabar el video
        Bitmap video;
        VideoFileWriter FileWriter = new VideoFileWriter();
        SaveFileDialog saveVideo;
        int a = 5;

        //Detectar Movimiento
        MotionDetector motionDetector;
        float levelMotionDetector;

        //Detectar rostros 
        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");

        ColorMatrix blackWhiteColorMatrix = new ColorMatrix(
            new float[][]{
                new float[]{.3f, .3f, .3f, 0, 0},
                new float[]{.59f, .59f, .59f, 0, 0},
                new float[]{.11f, .11f, .11f, 0, 0},
                new float[]{0, 0, 0, 1, 0},
                new float[]{0, 0, 0, 0, 1}
            });

        ColorMatrix sepiaColorMatrix = new ColorMatrix(
            new float[][]{
                new float[] {0.393f, 0.349f, 0.272f, 0, 0},
                new float[] {0.769f, 0.686f, 0.534f, 0, 0},
                new float[] {0.189f, 0.168f, 0.131f, 0, 0},
                new float[] { 0, 0, 0, 1, 0},
                new float[] { 0, 0, 0, 0, 1}
            });

        ColorMatrix negativeColorMatrix = new ColorMatrix(
            new float[][]{
                new float[] {-1f, 0f, 0f, 0, 0},
                new float[] {0f, -1f, 0f, 0, 0},
                new float[] {0f, 0f, -1f, 0, 0},
                new float[] { 0, 0, 0, 1, 0},
                new float[] { 1, 1, 1, 0, 1}
            });

        ColorMatrix pixeledColorMatrix = new ColorMatrix(
            new float[][]{
                new float[] {0f, 0.2f, 0f, 0, 0},
                new float[] {0.2f, 0.2f, 0.2f, 0, 0},
                new float[] {0f, 0.2f, 0.2f, 0, 0},
                new float[] {0f, 0f, 0f, 1, 0},
                new float[] {0f, 0f, 0f, 0, 1}
            });

        ColorMatrix redColorMatrix = new ColorMatrix(
            new float[][]{
                new float[] {0.9f, 0.075f, 0.075f, 0, 0},
                new float[] {0.9f, 0.2f, 0.2f, 0, 0},
                new float[] {0.9f, 0.2f, 0.2f, 0, 0},
                new float[] { 0, 0, 0, 1, 0},
                new float[] { 0, 0, 0, 0, 1}
            });

        Pixellate filterPixel = new Pixellate();
        //Función para aplicar los filtros de las matrices
        private static Bitmap ApplyColorMatrix(Image sourceImage, ColorMatrix colorMatrix){
            Bitmap bmp32BppSource = GetArgbCopy(sourceImage);
            Bitmap bmp32BppDest = new Bitmap(bmp32BppSource.Width, bmp32BppSource.Height, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(bmp32BppDest)){
                ImageAttributes bmpAttributes = new ImageAttributes();
                bmpAttributes.SetColorMatrix(colorMatrix);

                graphics.DrawImage(bmp32BppSource, new Rectangle(0, 0, bmp32BppSource.Width, bmp32BppSource.Height),
                                    0, 0, bmp32BppSource.Width, bmp32BppSource.Height, GraphicsUnit.Pixel, bmpAttributes);
            }
            bmp32BppSource.Dispose();
            return bmp32BppDest;
        }

        private static Bitmap GetArgbCopy(Image sourceImage){
            Bitmap bmpNew = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(bmpNew)){
                graphics.DrawImage(sourceImage, new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), GraphicsUnit.Pixel);
                graphics.Flush();
            }
            return bmpNew;
        }

        private void btnFindPicture_Click(object sender, EventArgs e){
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if(file.ShowDialog() == DialogResult.OK){
                pbOriginalImage.Image = new Bitmap(file.FileName);
                pbOriginalImage.SizeMode = PictureBoxSizeMode.Zoom;
                pbOriginalImage.Height = 500;
                pbOriginalImage.Width = 500;

                pbFilteredImage.Image = new Bitmap(file.FileName);
                pbFilteredImage.SizeMode = PictureBoxSizeMode.Zoom;
                pbFilteredImage.Height = 500;
                pbFilteredImage.Width = 500;

                txtFileName.Text = file.FileName;
            }
        }

        public Form1(){
            InitializeComponent();
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e){

        }

        private void Form1_Load(object sender, EventArgs e){
            //Inicializar detectar movimiento
            motionDetector = new MotionDetector(new TwoFramesDifferenceDetector(), new MotionBorderHighlighting());
            levelMotionDetector = 0;
            //Genero los dispositivos de cámara
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cbCameras.Items.Add(filterInfo.Name);
            cbCameras.SelectedIndex = 0;
            //Se inicializa las propiedades de la cam
            videoCaptureDevice = new VideoCaptureDevice();
            //Para que el filtro a usar sea nulo
            cbFilters.SelectedIndex = 5;

            //Face Recognition
            //haar = new CascadeClassifier("haarcascade_frontalface_default.xml");
            //timer1.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e){
            
            if(pbFilteredImage.Image != null){
                //Se define el filtro seleccionado según el combo box
                switch (cbFilters.SelectedIndex)
                {
                    case 0:                        
                        pbFilteredImage.Image = ApplyColorMatrix(pbFilteredImage.Image, blackWhiteColorMatrix);
                        break;                        
                    case 1:
                        pbFilteredImage.Image = ApplyColorMatrix(pbFilteredImage.Image, sepiaColorMatrix);
                        break;
                    case 2:
                        pbFilteredImage.Image = ApplyColorMatrix(pbFilteredImage.Image, negativeColorMatrix);
                        break;
                    case 3:
                        Bitmap imagensita = AForge.Imaging.Image.Clone(new Bitmap(pbFilteredImage.Image), PixelFormat.Format24bppRgb);
                        pbFilteredImage.Image = filterPixel.Apply(imagensita);
                        //pbFilteredImage.Image = ApplyColorMatrix(pbFilteredImage.Image, pixeledColorMatrix);
                        break;
                    case 4:
                        pbFilteredImage.Image = ApplyColorMatrix(pbFilteredImage.Image, redColorMatrix);
                        break;
                    default:
                        pbFilteredImage.Image = pbOriginalImage.Image;
                        break;
                }

            }
            a = cbFilters.SelectedIndex;
        }

        private void groupBox2_Enter(object sender, EventArgs e){

        }

        private void btnTurnOnCam_Click(object sender, EventArgs e){
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbCameras.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
            videoCaptureDevice.VideoResolution = videoCaptureDevice.VideoCapabilities[8];
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs){
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            pbOriginalImage.Image = image;
            //if (video == null)
                //video = (Bitmap)pbOriginalImage.Image;
        }

        private void btnTurnOffCam_Click(object sender, EventArgs e){
            if (videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.Stop();
            pbOriginalImage.Image = null;
        }

        private void btnTakePicture_Click(object sender, EventArgs e){
            if (videoCaptureDevice.IsRunning){
                pbFilteredImage.Image = pbOriginalImage.Image;
            }
        }

        private void VideoCaptureDevice_NewFrame1(object sender, NewFrameEventArgs eventArgs){
            if (btnStopRecording.Visible){
                switch (a){
                    case 0: //Filtro Blanco y negro
                        {
                            pbFilteredImage.Image = ApplyColorMatrix((Bitmap)eventArgs.Frame.Clone(), blackWhiteColorMatrix);
                            video = (Bitmap)pbFilteredImage.Image;
                            FileWriter.WriteVideoFrame(video);
                            break;
                        }
                    case 1:
                        {
                            pbFilteredImage.Image = ApplyColorMatrix((Bitmap)eventArgs.Frame.Clone(), sepiaColorMatrix);
                            video = (Bitmap)pbFilteredImage.Image;
                            FileWriter.WriteVideoFrame(video);
                            break;
                        }
                    case 2:
                        {
                            pbFilteredImage.Image = ApplyColorMatrix((Bitmap)eventArgs.Frame.Clone(), negativeColorMatrix);
                            video = (Bitmap)pbFilteredImage.Image;
                            FileWriter.WriteVideoFrame(video);
                            break;
                        }
                    case 3:
                        {
                            Bitmap imagensita = AForge.Imaging.Image.Clone(new Bitmap((Bitmap)eventArgs.Frame.Clone()), PixelFormat.Format24bppRgb);
                            pbFilteredImage.Image = filterPixel.Apply(imagensita);
                            video = (Bitmap)pbFilteredImage.Image;
                            FileWriter.WriteVideoFrame(video);
                            break;
                        }
                    case 4:
                        {
                            pbFilteredImage.Image = ApplyColorMatrix((Bitmap)eventArgs.Frame.Clone(), redColorMatrix);
                            video = (Bitmap)pbFilteredImage.Image;
                            FileWriter.WriteVideoFrame(video);
                            break;
                        }
                    case 5: //Sin filtros
                        {
                            pbFilteredImage.Image = (Bitmap)eventArgs.Frame.Clone();
                            video = (Bitmap)eventArgs.Frame.Clone();
                            FileWriter.WriteVideoFrame(video);
                            break;
                        }
                }
                //pbFilteredImage.Image = (Bitmap)eventArgs.Frame.Clone();
                //video = (Bitmap)eventArgs.Frame.Clone();
                //FileWriter.WriteVideoFrame(video);
            }           
        }

        private void VideoCaptureDevice_Photo(object sender, NewFrameEventArgs eventArgs){
            
        }

        private void btnRecord_Click(object sender, EventArgs e){
            btnStopRecording.Visible = true;           
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame1;

            saveVideo = new SaveFileDialog();
            saveVideo.Filter = "Avi files(*.avi)|*.avi";
            if (saveVideo.ShowDialog() == System.Windows.Forms.DialogResult.OK){
                int h = videoCaptureDevice.VideoResolution.FrameSize.Height;
                int w = videoCaptureDevice.VideoResolution.FrameSize.Width;
                FileWriter.Open(saveVideo.FileName, w, h, 25, VideoCodec.Default, 5000000);
                FileWriter.WriteVideoFrame(video);
            }
        }

        private void btnStopRecording_Click(object sender, EventArgs e){
            btnStopRecording.Visible = false;
            btnRecord.Visible = true;
            FileWriter.Close();
            pbFilteredImage.Image = null;
        }

        private void btnDetectMovement_Click(object sender, EventArgs e)
        {
            vspVideo.Visible = true;
            vspVideo.VideoSource = videoCaptureDevice;
            vspVideo.Start();
        }

        private void VideoCaptureDevice_NewFrame2(object sender, NewFrameEventArgs eventArgs)
        {
            //pbOriginalImage.Image = motionDetector.ProcessFrame((Bitmap)eventArgs.Frame.Clone());
            
        }

        private void vspVideo_NewFrame(object sender, ref Bitmap image)
        {
            levelMotionDetector = motionDetector.ProcessFrame(image);
        }

        private void btnStopMovementDetection_Click(object sender, EventArgs e)
        {
            vspVideo.Visible = false;
            //vspVideo.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void btnDetectFaces_Click(object sender, EventArgs e)
        {
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame3;
        }

        private void VideoCaptureDevice_NewFrame3(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            Image<Bgr, byte> grayImage = bitmap.ToImage<Bgr, byte>();

            Rectangle[] rectangles = cascadeClassifier.DetectMultiScale(grayImage, 1.2, 1);
            foreach(Rectangle rectangle in rectangles)
            {
                using(Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using(Pen pen = new Pen(Color.Red, 1))
                    {
                        graphics.DrawRectangle(pen, rectangle);
                    }
                }
            }
            pbFilteredImage.Image = bitmap;
        }
    }
}
