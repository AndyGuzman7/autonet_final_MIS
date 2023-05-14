using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DAO.Model;
using DAO.Implementacion;
using System.Data;
using Strategys;

namespace Univalle.AutoNetWPF.PartsAdmin
{
    /// <summary>
    /// Lógica de interacción para AddParts.xaml
    /// </summary>
    /// 
   
    public partial class AddParts : Window
    {
        Spare spare;
        SpareImpl spareImpl;
        public event RecargarPagina recargarPagina;
        ImageProvider imageProvider = new ImageProvider();
        bool isCamera = false;
        bool isGallery = false;
        public AddParts()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuadar_Click(object sender, RoutedEventArgs e)
        {
            AñadirProducto();
            this.Close();
        }

        public void AñadirProducto()
        {
            try
            {
                spare = new Spare(txtDescripcion.Text, txtNombreProducto.Text, int.Parse(txtSaldoActual.Text), double.Parse(txtPrecioBase.Text), double.Parse(txtPeso.Text), txtCodigoProducto.Text, int.Parse(txtMarca.Text), int.Parse(txtTipo.Text), 1);
                spareImpl = new SpareImpl();
                int res = spareImpl.Insert(spare);
                int id = spareImpl.GetGenerateId();
                if(res > 0)
                {
                    MessageBox.Show("Registro Insertado con exito");
                    SaveImage(id.ToString());

                }
                if(recargarPagina != null)
                {
                    recargarPagina();
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        void SaveImage(string name)
        {
            if(isCamera)
            {
                imageProvider.SaveImageCaptured(name);
            }
            if(isGallery)
            {
                imageProvider.SaveImageGallery(name);
            }
        }

        private void btnAñadirImagen_Click(object sender, RoutedEventArgs e)
        {
            imageProvider.CloseWebCam();
            imgSpare.Source =  imageProvider.OpenGallery().Source;
            stackPanelButtons.Visibility = Visibility.Collapsed;
            isGallery = true;
            isCamera = false;
        }

        private void btnAñadirImagenGaleria_Click(object sender, RoutedEventArgs e)
        {
            LoadImageProvider();
            imageProvider.OpenDevieCam(1);
            stackPanelButtons.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadImageProvider();
        }

        public void LoadImageProvider()
        {
            imageProvider = new ImageProvider();
            imageProvider.getImage += SetImage;
            //cmbTipos.ItemsSource = imageProvider.GetDeviceCam();
        }

        public void SetImage(BitmapImage bitmapImage)
        {
            this.Dispatcher.Invoke(new Action(() => imgSpare.Source = bitmapImage));
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            imageProvider.CloseWebCam();
        }

        private void btnTomarFotografia_Click(object sender, RoutedEventArgs e)
        {
            imgSpare.Source = imageProvider.CapturedImage().Source;
            isCamera = true;
            isGallery = false;
        }

        private void btnTomarNuevaFoto_Click(object sender, RoutedEventArgs e)
        {
            imageProvider.ReloadCamera();
        }
    }
}
