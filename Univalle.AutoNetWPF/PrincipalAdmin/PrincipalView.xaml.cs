using DAO.Implementacion;
using MaterialDesignThemes.Wpf;
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
using Univalle.AutoNetWPF.FactoryAdmin;
using Univalle.AutoNetWPF.Login;
using Univalle.AutoNetWPF.Reports;
using Univalle.AutoNetWPF.Ventas.HacerVenta;
using Univalle.AutoNetWPF.Ventas.ListaVentas;
using Univalle.AutoNetWPF.Providers;
using System.Data.SqlClient;
using DAO.Model;
using System.Windows.Threading;
using System.Net.Mail;
using System.Net;

namespace Univalle.AutoNetWPF
{
    public delegate void HacerVentaEvent();
    
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*PartsAdmin.uscParts.activar += ActivarVentanaEdicion;
            PersonasAdmin.uscClient.añadirCliente += ActivarVentanaEdicionEmpleado;*/

        }
       public void metrodget()
        {/*
            try
            {
                DataRowView data = (DataRowView)dgvDatos.SelectedItem;
                byte id = byte.Parse(data.Row.ItemArray[0].ToString());

            }
            catch (Exception)
            {

                MessageBox.Show("");
            }*/
        }

        private void ActivarVentanaEdicionEmpleado()
        {
           
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void btnInicioL_Click(object sender, RoutedEventArgs e)
        {
          
            UserControl usc = null;
            gridMain.Children.Clear();
            usc = new HomeAdmin.uscHome(); 
            if (usc != null)
            {
                gridMain.Children.Add(usc);
                CambiarBotones(1);
                txbNamePage.Text = "Inicio";
            }
            LlamarTiempo();



        }
        private async void LlamarTiempo()
        {
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


        private void CambiarBotones(int num)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#757575");
            Color color2 = (Color)ColorConverter.ConvertFromString("#161513");
            switch (num)
            {
                case 1:
                    txbIncio.Foreground = new SolidColorBrush(color);
                    txbEmpleados.Foreground = new SolidColorBrush(color2);
                    txbClientes.Foreground = new SolidColorBrush(color2);
                    txbVentas.Foreground = new SolidColorBrush(color2);
                    menuItemRepuesto.Foreground = new SolidColorBrush(color2);

                    break;
                case 2:
                    txbIncio.Foreground = new SolidColorBrush(color2);
                    txbEmpleados.Foreground = new SolidColorBrush(color);
                    txbClientes.Foreground = new SolidColorBrush(color2);
                    txbVentas.Foreground = new SolidColorBrush(color2);
                    menuItemRepuesto.Foreground = new SolidColorBrush(color2);

                    break;
                case 3:
                    txbIncio.Foreground = new SolidColorBrush(color2);
                    txbEmpleados.Foreground = new SolidColorBrush(color2);
                    txbClientes.Foreground = new SolidColorBrush(color);
                    txbVentas.Foreground = new SolidColorBrush(color2);
                    menuItemRepuesto.Foreground = new SolidColorBrush(color2);

                    break;
                case 4:
                    txbIncio.Foreground = new SolidColorBrush(color2);
                    txbEmpleados.Foreground = new SolidColorBrush(color2);
                    txbClientes.Foreground = new SolidColorBrush(color2);
                    txbVentas.Foreground = new SolidColorBrush(color);
                    menuItemRepuesto.Foreground = new SolidColorBrush(color2);
                    break;
                case 5:
                    txbIncio.Foreground = new SolidColorBrush(color2);
                    txbEmpleados.Foreground = new SolidColorBrush(color2);
                    txbClientes.Foreground = new SolidColorBrush(color2);
                    txbVentas.Foreground = new SolidColorBrush(color2);
                    menuItemRepuesto.Foreground = new SolidColorBrush(color);
                    break;
            }
        }

        private void btnRepuestosL_Click(object sender, RoutedEventArgs e)
        {


        }

        public void ActivarVentanaEdicion()
        {
            
        }

        private void btnClientesL_Click(object sender, RoutedEventArgs e)
        {
           
            UserControl usc = null;
            gridMain.Children.Clear();
            usc = new PersonasAdmin.uscClient();
            if (usc != null)
            {
                gridMain.Children.Add(usc);
                CambiarBotones(3);
                txbNamePage.Text = "Clientes";
            }
        }

        private void btnRegistros_Click(object sender, RoutedEventArgs e)
        {
            ViewListaVentas();
        }

        public void ViewListaVentas()
        {
            UserControl usc = null;
            gridMain.Children.Clear();
            usc = new uscListaVentas();
            uscListaVentas uscListaVentas = new uscListaVentas();
            if (usc != null)
            {
                uscListaVentas.hacerVentaEvent += HacerVenta;
                gridMain.Children.Add(uscListaVentas);
                CambiarBotones(4);
                txbNamePage.Text = "Lista de Ventas";
            }
        }

        public void HacerVenta()
        {
            uscHacerVenta uscHacerVenta = new uscHacerVenta();
            gridMain.Children.Clear();
            if (uscHacerVenta != null)
            {
                uscHacerVenta.listaVentas += ViewListaVentas;
                gridMain.Children.Add(uscHacerVenta);
                CambiarBotones(4);
                txbNamePage.Text = "Realizar un venta";
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mtAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            gridMain.Children.Clear();
            usc = new AboutAdmin.uscAbout1();
            if (usc != null)
            {
                gridMain.Children.Add(usc);
                
            }
        }

        private void Menu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("comida");
        }

        private void Menu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("comida");
        }

        private void MenuItem_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("comida");
        }

        private void MenuItem_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("comida");
        }

        private void card_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Comdia");
        }

        private void card_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Comdia");
        }

        private void card_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Comdia");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void mITodoLosRepuestos_Click(object sender, RoutedEventArgs e)
        {
         
            UserControl usc = null;
            gridMain.Children.Clear();
            usc = new PartsAdmin.uscParts();
            if (usc != null)
            {
                gridMain.Children.Add(usc);
                CambiarBotones(5);
                txbNamePage.Text = "Repuestos";
            }
        }

        private void mITipoRepuesto_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            usc = new PartsAdmin.uscPartsType();
            if (usc != null)
            {
                gridMain.Children.Add(usc);
                CambiarBotones(5);
                txbNamePage.Text = "Repuestos";
            }
        }

        private void btnEmpleadosL_Click(object sender, RoutedEventArgs e)
        {

            UserControl usc = null;
            gridMain.Children.Clear();
            usc = new PersonasAdmin.uscEmployee();
            if (usc != null)
            {
                gridMain.Children.Add(usc);
                CambiarBotones(2);
                txbNamePage.Text = "Empleados";
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*EmployeeImpl employeeImpl = new EmployeeImpl();
            DataTable dt = employeeImpl.GetId(Session.IdSession);*/

            menuItemHeader.Header = "Usuario: " + Session.SessionUserName + " - Rol: " + Session.SessionRole;
            /*if(dt.Rows[0][0].ToString() == dt.Rows[0][1].ToString())
            {

            }*/

            UserControl usc = null;
            gridMain.Children.Clear();
            usc = new HomeAdmin.uscHome();
            if (usc != null)
            {
                gridMain.Children.Add(usc);
                CambiarBotones(1);
                txbNamePage.Text = "Inicio";
            }

            int hora = DateTime.Now.Hour;
            int min = DateTime.Now.Minute + 1;
            int seg = DateTime.Now.Second;
            TimeSpan s = new TimeSpan(0, hora, min, seg);
            Alarma(s);

        }

        void Alert(object sender, EventArgs e)
        {
            //enviarEmails3compra();
        }

        public void Alarma(TimeSpan sp)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMinutes(2);
            dispatcherTimer.Tick += enviarEmails3compra;
            dispatcherTimer.Start();
            //MessageBox.Show($"Se agrego correctamente una alarma a las {sp} ");
        }

         void enviarEmails3compra(object sender, EventArgs e)
        {
            messageSend.Content = "Se envio los descuentos";
            LlamarTiempo();
            string connectionString = @"Server=AndyHP\MSSQLSERVER_PRIV;Database=BDDAUTONET2023;User Id=sa; Password=Univalle";

            // Consulta SQL para obtener los emails
            string query = @"SELECT c.idClient, c.email AS c_email
                            FROM Client c
                            INNER JOIN[Order] o ON c.idClient = o.idClient
                            WHERE o.registerDate >= CAST(GETDATE() AS DATE)
                            GROUP BY c.idClient, c.email
                            HAVING COUNT(o.idOrder) >= 3;
                            ";
            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Ejecutar la consulta para obtener los emails
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Iterar a través de los resultados y enviar el correo electrónico
                        while (reader.Read())
                        {
                            string email = reader["c_email"].ToString();
                            string ofertas = "Tienes 20% de descuento en tu proxima venta";
                            // Llamar al método para enviar el correo electrónico
                            bool llave = false;
                            string destino = email;
                            string remitente = "autonetsysytem@gmail.com";
                            string contraseñaGmail = "hablcnvfohbdknaf";
                            string asunto = "Descuentos especiales";
                            string cuerpoMensaje = ofertas;
                            MailMessage ms = new MailMessage(remitente, destino, asunto, cuerpoMensaje);

                            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                            smtp.EnableSsl = true;
                            smtp.Credentials = new NetworkCredential(remitente, contraseñaGmail);
                            smtp.Send(ms);
                            ms.Dispose();
                        }
                    }
                }
            }
            
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void mtAdministrarCuenta_Click(object sender, RoutedEventArgs e)
        {
            DataUser dataUser = new DataUser();
            dataUser.Show();
        }

        private void btnInicioL_MouseLeave(object sender, MouseEventArgs e)
        {
            CambiarBotonesDebajo((Button)sender);
        }

        private void btnInicioL_MouseEnter(object sender, MouseEventArgs e)
        {
            CambiarBotonesSobre((Button)sender);
        }

        private void btnEmpleados_MouseEnter(object sender, MouseEventArgs e)
        {
            CambiarBotonesSobre((Button)sender);
        }

        private void btnEmpleados_MouseLeave(object sender, MouseEventArgs e)
        {
            CambiarBotonesDebajo((Button)sender);
        }

        private void btnClientesL_MouseLeave(object sender, MouseEventArgs e)
        {
            CambiarBotonesDebajo((Button)sender);
        }

        private void btnClientesL_MouseEnter(object sender, MouseEventArgs e)
        {
            CambiarBotonesSobre((Button)sender);
        }

        private void btnRegistros_MouseLeave(object sender, MouseEventArgs e)
        {
            CambiarBotonesDebajo((Button)sender);
        }

        private void btnRegistros_MouseEnter(object sender, MouseEventArgs e)
        {
            CambiarBotonesSobre((Button)sender);
        }
        public void CambiarBotonesSobre(Button button)
        {
       
            Color color = (Color)ColorConverter.ConvertFromString("#dedede");

            button.Background = new SolidColorBrush(color);
            button.BorderBrush = Brushes.Transparent;


        }
        public void CambiarBotonesDebajo(Button button)
        {
            button.Background = Brushes.Transparent;
            button.BorderBrush = null;
            button.Margin = new Thickness(0);
            button.Padding = new Thickness(0);
        }

        private void btnLayoutFabricaRepuestos_Click(object sender, RoutedEventArgs e)
        {
            LayoutFabricaMarca();
        }

        public void LayoutFabricaMarca()
        {
            UserControl usc = null;
            gridMain.Children.Clear();
            usc = new uscViewAllFactory(); 
            if (usc != null)
            {
                gridMain.Children.Add(usc);
                CambiarBotones(1);
                txbNamePage.Text = "Marca o Fabrica del Producto";
            }
        }

        private void btnReportes_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            gridMain.Children.Clear();
            usc = new UserReport();
            if (usc != null)
            {
                gridMain.Children.Add(usc);
                CambiarBotones(1);
                txbNamePage.Text = "Reportes";
            }
        }

        private void btnLayoutProveedores_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            gridMain.Children.Clear();
            usc = new UserControl1();
            if (usc != null)
            {
                gridMain.Children.Add(usc);
                CambiarBotones(1);
                txbNamePage.Text = "Proveedores";
            }
        }

        private void Window_Loaded_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
