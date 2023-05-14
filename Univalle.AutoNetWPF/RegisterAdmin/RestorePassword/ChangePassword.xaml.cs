using DAO.Implementacion;
using DAO.Model;
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

namespace Univalle.AutoNetWPF.RegisterAdmin.RestorePassword
{
    /// <summary>
    /// Lógica de interacción para ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            EmployeeImpl employeeImpl = new EmployeeImpl();
            try
            {
                if(txtEmail.Password != " ")
                {
                    
                    int rest = employeeImpl.UpdatePassword(txtEmail.Password, Session.IdSession);
                    if (rest > 0)
                    {
                        
                        WindowLogin windowLogin = new WindowLogin();
                        windowLogin.Show();
                        this.Close();
                    }
                }
                else
                {
                    txtMensaje.Text = "No se permite vacio";
                }
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
