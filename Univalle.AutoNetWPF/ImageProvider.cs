using AForge.Video;
using AForge.Video.DirectShow;
using DAO.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Images = System.Windows.Controls.Image;

namespace Strategys
{
    public delegate void NextPrimeDelegate();
    public delegate void ImageProviders(BitmapImage bitmapImage);
    public class ImageProvider
    {
        public Images imageMain;
        public event ImageProviders getImage;
        private string path = @"C:\Users\hp\source\repos\camaraweb\camaraweb\image";
        private string pathImage;
        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice videoCaptureDevice;
        private BitmapImage bitmapImage;
        private Bitmap bitmap;
        private Bitmap bitmapAuxiliar;
        private bool isCapturedImage = true;


        public ImageProvider()
        {

        }

        public ImageProvider(string path, FilterInfoCollection filterInfoCollection, VideoCaptureDevice videoCaptureDevice, BitmapImage bitmapImage, Bitmap bitmap, Bitmap bitmapAuxiliar)
        {
            this.path = path;
            this.filterInfoCollection = filterInfoCollection;
            this.videoCaptureDevice = videoCaptureDevice;
            this.bitmapImage = bitmapImage;
            this.bitmap = bitmap;
            this.bitmapAuxiliar = bitmapAuxiliar;
        }


        public List<string> GetDeviceCam()
        {
            List<string> listString = new List<string>();
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            for (int i = 0; i < filterInfoCollection.Count; i++)
            {
                listString.Add(filterInfoCollection[i].Name);
            }

            return listString;
        }

        public Images CapturedImage()
        {
            Images images = new Images();
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                var memory = new MemoryStream();

                this.bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                images.Source = bitmapImage;
                this.bitmapAuxiliar = this.bitmap;
                isCapturedImage = false;

            }
            return images;
        }

        public void OpenDevieCam(int index)
        {
            CloseWebCam();
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            string nameVideoInputDevice = filterInfoCollection[index].MonikerString;
            videoCaptureDevice = new VideoCaptureDevice(nameVideoInputDevice);
            videoCaptureDevice.NewFrame += new NewFrameEventHandler(CapturedVideo);
            videoCaptureDevice.Start();

        }

        public Images OpenGallery()
        {
            Images image = new Images();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de Imagen|*.png";
            bool key = (bool)ofd.ShowDialog();

            if (key)
            {
                this.pathImage = ofd.FileName;
                image.Source = new BitmapImage(new Uri(pathImage));
            }

            return image;
        }

        public void SaveImageGallery(string nameFile)
        {
            
            File.Copy(pathImage, $@"{Config.ProductImagePath}\{nameFile}.png");
        }




        public void CapturedVideo(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            var memory = new MemoryStream();

            bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
            memory.Position = 0;

            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = memory;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            bitmapImage.Freeze();
            SetImageCapture(bitmapImage);
            this.bitmap = bitmap;
        }
        public void ReloadCamera()
        {
            isCapturedImage = true;
        }


        void SetImageCapture(BitmapImage bitmapImage)
        {
            if (getImage != null && isCapturedImage)
            {
                getImage(bitmapImage);
            }
        }


        public void CloseWebCam()
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.SignalToStop();
                videoCaptureDevice = null;
            }
        }


        public void SaveImageCaptured(string nameFile)
        {
            if (this.bitmap != null)
            {
                bitmapAuxiliar.Save($@"{Config.ProductImagePath}\{nameFile}.png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
