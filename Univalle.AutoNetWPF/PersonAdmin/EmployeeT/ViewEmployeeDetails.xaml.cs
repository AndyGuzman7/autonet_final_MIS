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
using Univalle.AutoNetWPF.PersonAdmin.EmployeeT;

namespace Univalle.AutoNetWPF.PersonasAdmin.Employee
{
    /// <summary>
    /// Lógica de interacción para ViewEmployeeDetails.xaml
    /// </summary>
    public delegate void RecargarPagina();
    public partial class ViewEmployeeDetails : Window
    {
        Employeee employeee;
        EmployeeImpl employeeImpl;

        public event RecargarPagina recargarPagina;
        public ViewEmployeeDetails( Employeee employeee)
        {
            InitializeComponent();
            this.employeee = employeee;
        }
        public void CargarDatos()
        {
            txbNombre.Text = employeee.FirstName;
            txbApellido.Text = employeee.LastName;
            txbCorreo.Text = employeee.Email;
            txbDireccion.Text = employeee.Address;
            txbFechaNacimiento.Text = employeee.BirthDate.ToString();
            txbGenero.Text = employeee.Gender;
            txbTelefono.Text = employeee.Phone.ToString();
            txbTipoUsuario.Text = employeee.UserType.ToString();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Esta Realmente segur@\nde eliminar el Empleado", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    employeeImpl = new EmployeeImpl();
                    int res = employeeImpl.Delete(employeee);
                    if (res > 0)
                    {
                        if (recargarPagina != null)
                        {
                            recargarPagina();
                        }
                        this.Close();
                        MessageBox.Show(res + "Registros Elimanado");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }

            }

        
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            EditEmployeeSimple editEmployeeSimple = new EditEmployeeSimple(employeee);
            editEmployeeSimple.Show();
            this.Close();
        }
        public void RecargarPagina()
        {
            recargarPagina();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();
        }
    }
}
