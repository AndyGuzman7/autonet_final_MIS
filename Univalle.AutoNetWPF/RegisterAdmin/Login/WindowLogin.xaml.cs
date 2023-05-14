 using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using Univalle.AutoNetWPF.RegisterAdmin.RestorePassword;

namespace Univalle.AutoNetWPF
{
    /// <summary>
    /// Lógica de interacción para WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        EmployeeImpl employeeImpl;
        public WindowLogin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
           
            //Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            //e.Handled = true;
        }

        private void TextBlock_TouchLeave(object sender, TouchEventArgs e)
        {
            MessageBox.Show("dfsdf");
        }

        private void Hyperlink_TouchLeave(object sender, TouchEventArgs e)
        {
            MessageBox.Show("dfsdf");
        }

        private void Hyperlink_MouseLeave(object sender, MouseEventArgs e)
        {
            hplLink.Foreground = Brushes.White;
        }

        private void Hyperlink_MouseEnter(object sender, MouseEventArgs e)
        {
            hplLink.Foreground = Brushes.Gray;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtPassword.Password != "" && txtUserName.Text != "")
                {
                    employeeImpl = new EmployeeImpl();
                    DataTable dt =employeeImpl.Login(txtUserName.Text, txtPassword.Password);
                    if (dt.Rows.Count > 0)
                    {

                        Session.IdSession = short.Parse(dt.Rows[0][0].ToString());
                        Session.SessionUserName = dt.Rows[0][1].ToString();
                        Session.SessionRole = dt.Rows[0][2].ToString();
                        ConfigImpl configImpl = new ConfigImpl();
                        DataTable dtConfig = configImpl.SelectConfigData();

                        Config.ClientImagePath = dtConfig.Rows[0][1].ToString();
                        Config.ProductImagePath = dtConfig.Rows[0][0].ToString();
                        
                        
                       
                        /*if(dt.Rows[0][3].ToString().Equals(dt.Rows[0][4].ToString()))
                        {
                            ChangePassword changePassword = new ChangePassword();
                            changePassword.Show();
                            this.Close();
                        }
                        else
                        {*/
                            /*MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();*/
                            WindowTime windowTime = new WindowTime();
                            windowTime.Show();
                            this.Close();
                        /*}*/
                       
                    }
                    else
                    {
                        txtMensaje.Text = "Contraseña o Nombre de usuario incorrectos";
                        
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        private void hplLink_Click(object sender, RoutedEventArgs e)
        {
            RegisterAdmin.RestorePassword.WindowRestorePassword windowRestorePassword = new RegisterAdmin.RestorePassword.WindowRestorePassword();
            windowRestorePassword.Show();
            this.Close();
           
        }
    }
}
