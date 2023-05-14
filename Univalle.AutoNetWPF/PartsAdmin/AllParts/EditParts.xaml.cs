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
using System.Threading;

namespace Univalle.AutoNetWPF.PartsAdmin
{
    /// <summary>
    /// Lógica de interacción para EditPart.xaml
    /// </summary>
    public partial class EditParts : Window
    {
        public event RecargarPagina recargarPagina;
        Spare spareDate;
        SpareImpl spareImpl;
        
        public EditParts(Spare spare)
        {
            InitializeComponent();
            this.spareDate = spare;
        }

        private void btnGuadar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                spareDate.NameProduct = txtNombreProducto.Text;
                spareDate.BasePrice = double.Parse(txtPrecioBase.Text);
                spareDate.CurrentBalance = int.Parse(txtSaldoActual.Text);
                spareDate.Description = txtDescripcion.Text;
                spareDate.IdEmploye = 1;
                spareDate.IdFactory = int.Parse(txtFabrica.Text);
                spareDate.Weight = double.Parse(txtPeso.Text);
                spareDate.ProductCode = txtCodigoProducto.Text;
                spareDate.IdSpareType = int.Parse(txtTipoRepuesto.Text);
                spareImpl = new SpareImpl();
                int res = spareImpl.Update(spareDate);
                if(res > 0)
                {
                    LlamarTiempo();
                    //MessageBox.Show("Producto modificado con exito");
                    if(recargarPagina != null)
                    {
                        recargarPagina();
                    }
                    //this.Close();
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
            txtNombreProducto.Text = spareDate.NameProduct;
            txtDescripcion.Text = spareDate.Description;
            txtSaldoActual.Text = spareDate.CurrentBalance.ToString();
            txtCodigoProducto.Text = spareDate.ProductCode;
            txtFabrica.Text = spareDate.IdFactory.ToString();
            txtPeso.Text = spareDate.Weight.ToString();
            txtTipoRepuesto.Text = spareDate.IdSpareType.ToString();
            txtPrecioBase.Text = spareDate.BasePrice.ToString();
        }
        private async void LlamarTiempo()
        {
            snackbarMessage.IsActive = true;
            Task task = new Task(Tiempo);
            task.Start();
            await task;
            snackbarMessage.IsActive = false;
        }

        private void Tiempo()
        {
            int delay = 3000;
            Thread.Sleep(delay);
        }
    }
}
