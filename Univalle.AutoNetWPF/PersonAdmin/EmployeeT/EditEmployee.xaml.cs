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

namespace Univalle.AutoNetWPF.PersonasAdmin.EmployeeT
{
    /// <summary>
    /// Lógica de interacción para EditEmployee.xaml
    /// </summary>
    public delegate void RecargarPaginaEmpleado();
    public partial class EditEmployee : Window
    {
        public event RecargarPaginaEmpleado recargarPaginaEmpleado;
        Employeee employeee;
        EmployeeImpl employeeImpl;
        public EditEmployee( Employeee employeee)
        {
            InitializeComponent();
            this.employeee = employeee;
        }

        private void btnGuadar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                employeee.FirstName = txtNombres.Text;
                employeee.LastName = txtPrimerApellido.Text +" "+ txtSegundoApellido.Text;
                employeee.Address = txtDireccion.Text;
                employeee.BirthDate = dtpFechaNacimiento.DisplayDate;
                employeee.Ci = txtCi.Text;
                employeee.Email = txtCorreo.Text;
                employeee.Gender = (cmbGenero.Text == "Masculino") ? "M" : "F";
                employeee.NameUser = txtNombreUusuario.Text;
                employeee.Password = txtPassword.Password;
                employeee.Phone = int.Parse(txtTelefono.Text);
                employeee.UserType = cmbTipoUsuario.Text;
                employeeImpl = new EmployeeImpl();
                int res = employeeImpl.Update(employeee);
                if (res > 0)
                {
                    if(recargarPaginaEmpleado != null)
                    {
                        recargarPaginaEmpleado();
                    }
                    this.Close();
                    
                }
                /*employeee.NameProduct = txtNombreProducto.Text;
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
                if (res > 0)
                {
                    MessageBox.Show("Producto modificado con exito");
                    if (recargarPagina != null)
                    {
                        recargarPagina();
                    }
                    this.Close();
                }*/



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

            CargarCombobox();
            CargarDatos();
        }
        public void CargarDatos()
        {
            txtNombres.Text = employeee.FirstName;
            txtPrimerApellido.Text = employeee.LastName.Split(' ')[0];
            txtSegundoApellido.Text = employeee.LastName.Split(' ')[1];
            txtNombreUusuario.Text = employeee.NameUser;
            switch (employeee.UserType)
            {
                case "Administrador":
                    cmbTipoUsuario.SelectedIndex = 0;
                    break;
                case "Vendedor":
                    cmbTipoUsuario.SelectedIndex = 1;
                    break;
                case "Editor Productos":
                    cmbTipoUsuario.SelectedIndex = 2;
                    break;
            }
            txtCi.Text = employeee.Ci;
            txtCorreo.Text = employeee.Email;
            if(employeee.Gender == "Masculino" || employeee.Gender == "M")
            {
                cmbGenero.SelectedIndex = 0;
            }
            else
            {
                cmbGenero.SelectedIndex = 1;
            }

            txtTelefono.Text = employeee.Phone.ToString();
            dtpFechaNacimiento.SelectedDate = employeee.BirthDate;
            txtDireccion.Text = employeee.Address;
            txtPassword.Password = employeee.Password;
        }

        public void CargarCombobox()
        {
            
            List<string> listaTypeusers = new List<string>() { "Administrador", "Vendedor", "Editor" };
            for (int i = 0; i < listaTypeusers.Count; i++)
            {
                cmbTipoUsuario.Items.Insert(i, listaTypeusers[i]);
            }
            cmbGenero.Items.Insert(0, "Masculino");
            cmbGenero.Items.Insert(1, "Femenino");
        }
    }
}
