using DAO.Implementacion;
using DAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Univalle.AutoNetWPF.PersonAdmin.ClientT;
using Univalle.AutoNetWPF.Ventas.HacerVenta;

namespace Univalle.AutoNetWPF.Ventas.ListaVentas
{
  
    /// <summary>
    /// Lógica de interacción para uscHacerVenta.xaml
    /// </summary>
    public partial class uscListaVentas : UserControl
    {
        public event HacerVentaEvent hacerVentaEvent;
        public uscListaVentas()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        public void LoadDataGrid()
        {
            int height = (int)SystemParameters.PrimaryScreenHeight;
            int width = (int)SystemParameters.PrimaryScreenWidth;
            dataGridProgram.Width = width - 200;
            dataGridProgram.Height = height - 20;
            dataGridProgram.ItemsSource = null;
            dataGridProgram.ItemsSource = GetOrderSpareDetails().AsDataView();

        }

        public DataTable GetOrderSpareDetails()
        {
            DataTable dt = new DataTable();
            try
            {
                OrderSpareImpl orderSpareImpl = new OrderSpareImpl();
                dt = orderSpareImpl.SelectDetails();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Comuniquese con el encargado de Sistemas");
            }
            return dt;
        }

        public List<OrderSpare> ConvertOrderSpareDetails(DataTable dataTable)
        {
            List<OrderSpare> listOrderSpareDetails = new List<OrderSpare>();



            return listOrderSpareDetails;
        }

        private void txtNombreBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void btnHacerVenta_Click(object sender, RoutedEventArgs e)
        {
            if (hacerVentaEvent != null)
            {
                hacerVentaEvent();
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGenerarRecibo_Click(object sender, RoutedEventArgs e)
        {
            GenerateRecibo(sender, e);

        }


        public void GenerateRecibo(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
            int idOrder = int.Parse(dataRowView["idOrder"].ToString());
            windowsRecibo windowsRecibo = new windowsRecibo(idOrder);
            windowsRecibo.Show();
        }
    }
}
