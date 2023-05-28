using DAO.Implementacion;
using DAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Univalle.AutoNetWPF.FactoryAdmin;

namespace Univalle.AutoNetWPF.Providers
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        Suppliers factory;
       
        SuppliersImpl factoryImpl;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void btnAñadirProveedor_Click(object sender, RoutedEventArgs e)
        {
            AddProvider addFactory = new AddProvider();
            addFactory.recargarDatosProviders += CargarDatos;
            addFactory.Show();
        }

        private void CargarDatos()
        {
            DataTable dt = SelectDataTableFactory();
            List<Suppliers> ft = ConvertirDataTable(dt);

            dataGridProgram.ItemsSource = ft;
        }

        public DataTable SelectDataTableFactory()
        {
            DataTable dt = new DataTable();
            try
            {
                factoryImpl = new SuppliersImpl();
                dt = factoryImpl.Select();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public List<Suppliers> ConvertirDataTable(DataTable dt)
        {
            List<Suppliers> f = new List<Suppliers>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                factory = new Suppliers(int.Parse(dt.Rows[i][0].ToString()), 
                                        dt.Rows[i][1].ToString(), 
                                        dt.Rows[i][2].ToString(), 
                                        int.Parse(dt.Rows[i][3].ToString()),
                                        dt.Rows[i][4].ToString(),
                                        DateTime.Parse(dt.Rows[i][5].ToString()),
                                        short.Parse(dt.Rows[i][6].ToString()),
                                        byte.Parse(dt.Rows[i][7].ToString()),
                                        DateTime.Parse(dt.Rows[i][8].ToString()));
                f.Add(factory);
            }
            return f;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();
        }

        private void txtNombreBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelarEliminarMarca_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminarMarca_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
