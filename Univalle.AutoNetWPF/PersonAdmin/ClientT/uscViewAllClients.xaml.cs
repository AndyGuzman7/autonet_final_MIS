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

namespace Univalle.AutoNetWPF.PersonasAdmin
{
    /// <summary>
    /// Lógica de interacción para uscClient.xaml
    /// </summary>

    

   
    public partial class uscClient : UserControl
    {


        private int idClient;
        ClientImpl clientImpl;
        public uscClient()
        {
            InitializeComponent();
        }

        

        private void btnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.recargarDatosBdd += CargarDatos;
            addClient.Show();

        }

        private void btnBorrarCliente_Click(object sender, RoutedEventArgs e)
        {

        }

        public void CargarDatos()
        {
            DataTable dt = SeleccionarDatosBDD();

            int height = (int)SystemParameters.PrimaryScreenHeight;
            int width = (int)SystemParameters.PrimaryScreenWidth;
            dataGridProgram.Width = width - 200;
            dataGridProgram.Height = height - 20;

            dataGridProgram.ItemsSource = dt.AsDataView();
        }

        public DataTable SeleccionarDatosBDD()
        {
            DataTable dt = new DataTable();
            try
            {
                clientImpl = new ClientImpl();
                dt = clientImpl.Select();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Comuniquese con el encargado de Sistemas");
            }
            return dt;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();
        }

        private void btnEditarCiente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                int idClient = int.Parse(dataRowView[0].ToString());
                //MessageBox.Show(idClient.ToString());
                EditClient editClient = new EditClient(idClient);
                editClient.recargarDatosBdd += CargarDatos;
                editClient.Show();

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void btnBorrarCliente_Click_1(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
            int idClient = int.Parse(dataRowView[0].ToString());
            this.idClient = idClient;
            DialogoHost1.IsOpen = true;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtNombreBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnCancelarEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            DialogoHost1.IsOpen = false;
        }

        private void btnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            EliminarDatoBdd(idClient);

        }

        public void EliminarDatoBdd(int id)
        {
            try
            {
                clientImpl = new ClientImpl();
                int res = clientImpl.DeleteForId(id);
                if (res > 0)
                {
                    NotificacionMensaje("Se elimino un Cliente", 2);
                    CargarDatos();
                    DialogoHost1.IsOpen = false;
                    
                }
            }
            catch (Exception ex)
            {
                NotificacionMensaje(ex.Message, 1);
            }

        }

        private async void NotificacionMensaje(string mensaje, int tipo)
        {
            sBMMensaje.Content = mensaje;
            switch (tipo)
            {
                case 1:
                    //Alerta
                    snackbarMessage.Background = Brushes.Red;
                    break;
                case 2:
                    snackbarMessage.Background = Brushes.Green;
                    break;
            }

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
