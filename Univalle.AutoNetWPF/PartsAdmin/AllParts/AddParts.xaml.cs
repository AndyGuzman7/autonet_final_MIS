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
        FactoryImpl factoryImpl;
        SpareTypeImpl spareTypeImpl;
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
                spare = new Spare(
                        txtDescripcion.Text,
                        txtNombreProducto.Text,
                        int.Parse(txtSaldoActual.Text),
                        double.Parse(txtPrecioBase.Text),
                        double.Parse(txtPeso.Text),
                        txtCodigoProducto.Text,
                        int.Parse(cmbMarca.SelectedValue.ToString()),
                        int.Parse(cmbTipo.SelectedValue.ToString()),
                        1
                    );

                    //MessageBox.Show(spare.Description + "\n" + spare.NameProduct + "\n" + spare.CurrentBalance + "\n" + spare.BasePrice + "\n" + spare.Weight + "\n" + spare.ProductCode + "\n" + cmbMarca.SelectedValue.ToString() + "\n" + cmbTipo.SelectedValue.ToString() + "\n" + spare.IdEmploye);

                    spareImpl = new SpareImpl();
                    int res = spareImpl.Insert(spare);
                    //int id = spareImpl.GetGenerateId();

                    if (res > 0)
                    {
                        MessageBox.Show("Registro Insertado con éxito");
                        //SaveImage(id.ToString());
                    }

                    if (recargarPagina != null)
                    {
                        recargarPagina();
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public List<Factory> ConvertirDataTableFactory(DataTable dt)
        {
            Factory factory;
            List<Factory> f = new List<Factory>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                factory = new Factory(int.Parse(dt.Rows[i][0].ToString()),
                                      dt.Rows[i][1].ToString(),
                                      dt.Rows[i][2].ToString(),
                                      byte.Parse(dt.Rows[i][3].ToString()),
                                      DateTime.Parse(dt.Rows[i][4].ToString()),
                                      DateTime.Parse(dt.Rows[i][5].ToString()),
                                      short.Parse(dt.Rows[i][6].ToString()));
                f.Add(factory);              
            }
            return f;
        }

        public List<SpareType> ConvertirDataTableCategory(DataTable dt)
        {
            SpareType spareType;
            
            List<SpareType> f = new List<SpareType>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                spareType = new SpareType(byte.Parse(dt.Rows[i][0].ToString()),
                                          dt.Rows[i][1].ToString(),
                                          short.Parse(dt.Rows[i][2].ToString()),
                                          byte.Parse(dt.Rows[i][5].ToString()),
                                          DateTime.Parse(dt.Rows[i][3].ToString()),
                                          DateTime.Parse(dt.Rows[i][4].ToString()));
                f.Add(spareType);
            }
            return f;
        }

        public DataTable SelectFactory()
        {
            factoryImpl = new FactoryImpl();
            return factoryImpl.Select();
        }
        public DataTable SelectCategory()
        {
            spareTypeImpl = new SpareTypeImpl();
            return spareTypeImpl.Select();
        }
       



        /*void SaveImage(string name)
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
        */
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbMarca.ItemsSource = ConvertirDataTableFactory(SelectFactory());
            cmbTipo.ItemsSource = ConvertirDataTableCategory(SelectCategory());
            //LoadImageProvider();
        }

        /*public void LoadImageProvider()
        {
            imageProvider = new ImageProvider();
            imageProvider.getImage += SetImage;
            //cmbTipos.ItemsSource = imageProvider.GetDeviceCam();
        }

        public void SetImage(BitmapImage bitmapImage)
        {
            this.Dispatcher.Invoke(new Action(() => imgSpare.Source = bitmapImage));
        }*/

        private void Window_Closed(object sender, EventArgs e)
        {
            //imageProvider.CloseWebCam();
        }

        private void cmbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            SpareType spareType = comboBox.SelectedItem as SpareType;
        }

        private void cmbMarca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Factory factory = comboBox.SelectedItem as Factory;
        }

        /*private void btnTomarFotografia_Click(object sender, RoutedEventArgs e)
        {
            imgSpare.Source = imageProvider.CapturedImage().Source;
            isCamera = true;
            isGallery = false;
        }

        private void btnTomarNuevaFoto_Click(object sender, RoutedEventArgs e)
        {
            imageProvider.ReloadCamera();
        }*/
    }
}
