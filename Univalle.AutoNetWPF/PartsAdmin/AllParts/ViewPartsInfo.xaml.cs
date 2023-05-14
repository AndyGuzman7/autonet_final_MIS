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

namespace Univalle.AutoNetWPF.PartsAdmin
{
    /// <summary>
    /// Lógica de interacción para ViewParts.xaml
    /// </summary>
    /// 

    public delegate void RecargarPagina();
    public partial class ViewParts : Window
    {
        Spare spareDate;
        SpareImpl spareImpl;

        public event RecargarPagina recargarPagina;
        public ViewParts(Spare spare)
        {
            InitializeComponent();
            this.spareDate = spare;
        }

        public void CargarProducto()
        {
            txbnombre.Text = spareDate.NameProduct;
            txbCantidaStock.Text = spareDate.CurrentBalance.ToString();
            txbCodigoProducto.Text = spareDate.ProductCode;
            txbMarca.Text = spareDate.IdFactory.ToString();
            txbPeso.Text = spareDate.Weight.ToString();
            txbTipoRepuesto.Text = spareDate.IdSpareType.ToString();
            lblPrecioBase.Content = spareDate.BasePrice;
            
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            
            EditParts editPart = new EditParts(spareDate);
            editPart.recargarPagina += RecargarPagina;
            this.Close();
            editPart.ShowDialog();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarProducto();
        }
        public void RecargarPagina()
        {
            recargarPagina();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            /*if(MessageBox.Show("Esta Realmente segur@\nde eliminar el producto", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) ==MessageBoxResult.Yes)
            {
                try
                {
                    spareImpl = new SpareImpl();
                    int res = spareImpl.Delete(spareDate);
                    if(res > 0)
                    {
                        if(recargarPagina != null)
                        {
                            recargarPagina();
                        }
                        this.Close();
                        MessageBox.Show(res + "Registros Elimanado");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }

            }*/
                    
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("funciona");
        }
    }
}
