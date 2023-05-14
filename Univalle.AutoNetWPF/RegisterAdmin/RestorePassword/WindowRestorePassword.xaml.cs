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
using System.Windows.Shapes;
using DAO.Implementacion;
using DAO.Model;
using Univalle.AutoNetWPF.Login;

namespace Univalle.AutoNetWPF.RegisterAdmin.RestorePassword
{
    /// <summary>
    /// Lógica de interacción para WindowRestorePassword.xaml
    /// </summary>
    
    public partial class WindowRestorePassword : Window
    {
        
        EmployeeImpl employeeImpl;
        public WindowRestorePassword()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Volver();
        }
        public void Volver()
        {
            WindowLogin windowLogin = new WindowLogin();
            windowLogin.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtEmail.Text != "")
                {
                    employeeImpl = new EmployeeImpl();
                    DataTable dt = employeeImpl.CompareEmail(txtEmail.Text);
                    if (dt.Rows.Count > 0)
                    {
                        string nuevaContraseña = Password.GenerarPassword(7);
                        employeeImpl.UpdateRestorePassword(txtEmail.Text, nuevaContraseña );

                        EmailService.EnviarCorreoContraña(nuevaContraseña, txtEmail.Text);
                        //EmailService.cambiarPantalla += Volver;
                    }
                    else
                    {
                        txtMensaje.Text = "Correo inexistente";

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
