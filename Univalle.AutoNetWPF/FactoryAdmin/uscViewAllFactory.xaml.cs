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

namespace Univalle.AutoNetWPF.FactoryAdmin
{
    /// <summary>
    /// Lógica de interacción para uscViewAllFactory.xaml
    /// </summary>
    public partial class uscViewAllFactory : UserControl
    {
        Factory factory;
        FactoryImpl factoryImpl;
        Factory factoryDelete;

        public uscViewAllFactory()
        {
            InitializeComponent();
        }

        

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Factory ft = ((Factory)((Button)e.Source).DataContext);
            factoryDelete = ft;
            VentanaEditar(ft);
        }

        public void VentanaEditar(Factory ft)
        {
            EditFactory editFactory = new EditFactory(ft);
            editFactory.recargarDatosBdd += CargarDatos;
            editFactory.Show();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Factory ft = ((Factory)((Button)e.Source).DataContext);
            factoryDelete = ft;
            DialogoHost1.IsOpen = true;
        }

        private void btnRepuestosL_Click(object sender, RoutedEventArgs e)
        {

        }

        public void VentanaAñadir()
        {
            AddFactoryxaml addFactory = new AddFactoryxaml();
            addFactory.recargarDatosBdd += CargarDatos;
            addFactory.Show();
        }


        public void CargarDatos()
        {
            DataTable dt = SelectDataTableFactory();
            List<Factory> ft = ConvertirDataTable(dt);

            dataGridProgram.ItemsSource = ft;

        }


        public List<Factory> ConvertirDataTable(DataTable dt)
        {
            List<Factory> f = new List<Factory>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                factory = new Factory(int.Parse(dt.Rows[i][0].ToString()), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), short.Parse(dt.Rows[i][3].ToString()), byte.Parse(dt.Rows[i][4].ToString()), DateTime.Parse(dt.Rows[i][5].ToString()), DateTime.Parse(dt.Rows[i][6].ToString()));
                f.Add(factory);
            }
            return f;
        }
        public void DeleteTableFactory(Factory ft)
        {
            try
            {
                factoryImpl = new FactoryImpl();
                int res = factoryImpl.Delete(ft);
                if (res > 0)
                {
                    NotificacionMensaje("Se elimino un registro", 2);
                    CargarDatos();
                }
            }
            catch (Exception)
            {
                NotificacionMensaje("Comuniquese con el respondable de sistemas", 1);
            }
        }


        public DataTable SelectDataTableFactory()
        {
            DataTable dt = new DataTable();
            try
            {
                factoryImpl = new FactoryImpl();
                dt =factoryImpl.Select();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

       

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtNombreBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();
        }

        private void btnAñadirMarca_Click(object sender, RoutedEventArgs e)
        {
            VentanaAñadir();
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

        private void btnEliminarMarca_Click(object sender, RoutedEventArgs e)
        {
            DialogoHost1.IsOpen = false;
            DeleteTableFactory(factoryDelete);

        }

        private void btnCancelarEliminarMarca_Click(object sender, RoutedEventArgs e)
        {
            DialogoHost1.IsOpen = false;
        }
    }
}
