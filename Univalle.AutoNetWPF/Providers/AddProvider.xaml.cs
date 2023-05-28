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

namespace Univalle.AutoNetWPF.Providers
{
    public delegate void RecargarDatosProviders();
    /// <summary>
    /// Lógica de interacción para AddProvider.xaml
    /// </summary>
    public partial class AddProvider : Window
    {

        public event RecargarDatosProviders recargarDatosProviders;
        Suppliers factory;
        public event EventHandler<string> WindowClosed;
        SuppliersImpl factoryImpl;
        public AddProvider()
        {
            InitializeComponent();
        }

        private void btnGuadar_Click(object sender, RoutedEventArgs e)
        {
            InsertDataTableFactory();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public void InsertDataTableFactory()
        {
            try
            {
            factory = new Suppliers(txtNombreProveedor.Text, txtDirecciónProveedor.Text, int.Parse(txtCelularProveedor.Text), Session.IdSession, txtNit.Text);
            factoryImpl = new SuppliersImpl();
            int res = factoryImpl.Insert(factory);
            if (res > 0)
            {
                NotificacionMensaje("Registro Exitoso", 2);
                if (recargarDatosProviders != null)
                {
                    recargarDatosProviders();
                }
            }
            }
            catch (Exception)
            {
                NotificacionMensaje("Comuniquese con el encargado de sistemas", 1);
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
            this.Close();
        }

        private void Tiempo()
        {
            int delay = 3000;
            Thread.Sleep(delay);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnClosed(EventArgs e)
        {
            WindowClosed?.Invoke(this, "Hola mundo");
            base.OnClosed(e);
        }


        private void Window_Closed(object sender, EventArgs e)
        {

        }
    }
}
