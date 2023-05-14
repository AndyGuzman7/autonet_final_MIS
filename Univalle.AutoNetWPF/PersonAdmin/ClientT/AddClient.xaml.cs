using DAO.Implementacion;
using DAO.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Univalle.AutoNetWPF.PersonAdmin.ClientT
{
    /// <summary>
    /// Lógica de interacción para AddClient.xaml
    /// </summary>
    public delegate void RecargarDatosBdd();
    public partial class AddClient : Window
    {
        public event RecargarDatosBdd recargarDatosBdd;
        public AddClient()
        {
            InitializeComponent();
        }
        Client client;
        ClientImpl clientImpl;

       // public event RecargarPaginaEmpleado recargarPaginaEmpleado;

        private void btnGuadar_Click(object sender, RoutedEventArgs e)
        {
            AñadirClienteBDD();
            
        }

        public void LimpiarParametros()
        {
            txtNit.Text = "";
            txtNombres.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
        }

        public void AñadirClienteBDD()
        {
            try
            {
                client = new Client(txtNit.Text, txtNombres.Text, txtPrimerApellido.Text + " " + txtSegundoApellido.Text, Session.IdSession);
                clientImpl = new ClientImpl();                         
                
                int res = clientImpl.Insert(client);
                if (res > 0)
                {
                    if (recargarDatosBdd != null)
                    {
                        recargarDatosBdd();
                    }
                    LimpiarParametros();
                    NotificacionMensaje("Se añadio un cliente", 2);
                }
                
            }
            catch (Exception ex)
            {
                NotificacionMensaje($"{ex.Message}", 1);
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private async void NotificacionMensaje(string mensaje, int tipo)
        {
            sBMMensaje.Content = mensaje;
            switch(tipo)
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
