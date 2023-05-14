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
    /// Lógica de interacción para EditPartsType.xaml
    /// </summary>
    public partial class EditPartsType : Window
    {
        public event RecargarPagina recargarPagina;
        SpareType spareTypeDate;
        SpareTypeImpl spareTypeImpl;
        public EditPartsType(SpareType spareType)
        {
            InitializeComponent();
            this.spareTypeDate = spareType;
        }

        private void btnGuadar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                spareTypeDate.NameSpareType = txtNombreTipoProducto.Text;
                spareTypeDate.IdSpareCategory = byte.Parse(txbCategoria.Text);
                spareTypeDate.IdEmploye = 1;

                spareTypeImpl = new SpareTypeImpl();


                
                int res = spareTypeImpl.Update(spareTypeDate);
                if (res > 0)
                {
                    MessageBox.Show("Producto modificado con exito");
                    if (recargarPagina != null)
                    {
                        recargarPagina();
                    }
                    this.Close();
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();
        }
        public void CargarDatos()
        {
            txtNombreTipoProducto.Text = spareTypeDate.NameSpareType;
            txbCategoria.Text = spareTypeDate.IdSpareCategory.ToString();
            

        }
    }
}
