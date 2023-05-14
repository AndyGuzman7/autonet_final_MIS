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
    /// Lógica de interacción para ViewsPartsType.xaml
    /// </summary>
    
    public partial class ViewsPartsType : Window
    {
        SpareType spareTypeDate;
        SpareTypeImpl spareTypeImpl;

        public event RecargarPagina recargarPagina;
        public ViewsPartsType( SpareType spareType)
        {
            InitializeComponent();
            this.spareTypeDate = spareType;
        }

        public void CargarProducto()
        {
            txbnombre.Text = spareTypeDate.NameSpareType;
            txbFechaCreacion.Text = spareTypeDate.RegistrationDate.ToString();
            txbFechaModificacion.Text = spareTypeDate.DateUpdate.ToString();
            txbEmpleado.Text = spareTypeDate.IdEmploye.ToString();
            txbCategoria.Text = spareTypeDate.IdSpareCategory.ToString();

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            EditPartsType editPartType = new EditPartsType(spareTypeDate);
            editPartType.recargarPagina += RecargarPagina;
            editPartType.ShowDialog();
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
            if (MessageBox.Show("Esta Realmente segur@\nde eliminar el producto", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    spareTypeImpl = new SpareTypeImpl();
                    int res = spareTypeImpl.Delete(spareTypeDate);
                    if (res > 0)
                    {
                        if (recargarPagina != null)
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

            }

        }
    }
}
