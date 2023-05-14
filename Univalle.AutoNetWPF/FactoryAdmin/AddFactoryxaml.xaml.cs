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
using System.Windows.Shapes;

namespace Univalle.AutoNetWPF.FactoryAdmin
{
    /// <summary>
    /// Lógica de interacción para AddFactoryxaml.xaml
    /// </summary>
    public delegate void RecargarDatosBdd();
    public partial class AddFactoryxaml : Window
    {
        public event RecargarDatosBdd recargarDatosBdd;
        Factory factory;
        FactoryImpl factoryImpl;
        public AddFactoryxaml()
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
            /*try
            {*/
                factory = new Factory(txtNombreFabrica.Text, txtNombreCiudadProcedencia.Text, Session.IdSession);
                factoryImpl = new FactoryImpl();
                int res = factoryImpl.Insert(factory);
                if(res > 0)
                {
                    NotificacionMensaje("Registro Exitoso", 2);
                    if(recargarDatosBdd != null)
                    {
                        recargarDatosBdd();
                    }
                }
            /*}
            catch (Exception)
            {
                NotificacionMensaje("Comuniquese con el encargado de sistemas", 1);
            }*/
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
