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

namespace Univalle.AutoNetWPF.FactoryAdmin
{
    /// <summary>
    /// Lógica de interacción para EditFactory.xaml
    /// </summary>
    public partial class EditFactory : Window
    {
        public event RecargarDatosBdd recargarDatosBdd;
        Factory factory;
        FactoryImpl factoryImpl;
        public EditFactory(Factory factory)
        {
            InitializeComponent();
            CargarDatosComponentes(factory);
        }

        public void CargarDatosComponentes(Factory ft)
        {
            txtIdFactory.Text = ft.IdFactory.ToString();
            txtNombreFabrica.Text = ft.NameFactory;
            txtNombreCiudadProcedencia.Text = ft.NameCityOrCountry;
        }

       

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuadar_Click(object sender, RoutedEventArgs e)
        {
            UpdateTableFactory();
        }

        

        public void UpdateTableFactory()
        {
            try
            {
                factory = new Factory(int.Parse(txtIdFactory.Text), txtNombreFabrica.Text, txtNombreCiudadProcedencia.Text, Session.IdSession);
                factoryImpl = new FactoryImpl();
                int res = factoryImpl.Update(factory);
                if(res > 0)
                {
                   
                    if(recargarDatosBdd != null)
                    {
                        recargarDatosBdd();
                    }
                    NotificacionMensaje("Se Actualizo un registro", 2);
                }
            }
            catch (Exception)
            {
                NotificacionMensaje("Comuniquese con el responsable de sistemas", 1);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

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
