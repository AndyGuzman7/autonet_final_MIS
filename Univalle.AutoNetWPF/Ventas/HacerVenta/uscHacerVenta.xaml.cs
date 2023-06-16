using DAO.Implementacion;
using DAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using Univalle.AutoNetWPF.PersonAdmin.ClientT;

namespace Univalle.AutoNetWPF.Ventas.HacerVenta
{
    public delegate void ListaVentas();
    /// <summary>
    /// Lógica de interacción para uscHacerVenta.xaml
    /// </summary>
    public partial class uscHacerVenta : UserControl
    {
        public event ListaVentas listaVentas;
        private Spare spare;
        private SpareImpl spareImpl;
        private List<Spare> listOrder = new List<Spare>();
        private List<Spare> listTotal = new List<Spare>();
        private List<string> listAñadidos = new List<string>();

        List<ExpandoObject> personas = new List<ExpandoObject>();

        List<TrolleySpare> listSparesSales = new List<TrolleySpare>();

        List<TrolleySpare> shoList = new List<TrolleySpare>();

        double pagoCliente = 0;

        private List<OrderSpare> orderSpares = new List<OrderSpare>();

        private OrderSpare orderSpare;

        ClientImpl clientImpl;
        Client datosClienteCompradors = new Client();
        Order ordenPrincipal = new Order();

        public uscHacerVenta()
        {
            InitializeComponent();
            AñadirDatos();
        }

        private void btnAñadirRepuestoLista_Click(object sender, RoutedEventArgs e)
        {
            DialogoHost1.IsOpen = true;
            AñadirDatosListaBuscador();
        }


        public void AñadirDatosListaBuscador()
        {
            DataTable dt = SelecionarDatosDbb();
            List<Spare> sp = LlenarLista(dt);
            //listTotal = LlenarLista(dt);
            Grid grid = new Grid();
            //lstProductos.Items.Clear();
            lstProductos.Items.Clear();
            for (int i = 0; i < sp.Count; i++)
            {

                // if (!shoList.Contains(d => s == sp[i]))
                //{
                grid = new Grid();
                grid.Children.Add(CrearCheckBox(sp[i]));
                lstProductos.Items.Add(grid);

                // }


            }


        }


        public List<Spare> LlenarLista(DataTable dataTable)
        {
            List<Spare> spares = new List<Spare>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                spares.Add(new Spare(
                    int.Parse(dataTable.Rows[i][0].ToString()),
                    int.Parse(dataTable.Rows[i][1].ToString()),
                    int.Parse(dataTable.Rows[i][2].ToString()),

                    dataTable.Rows[i][3].ToString(),
                    dataTable.Rows[i][4].ToString(),

                    int.Parse(dataTable.Rows[i][5].ToString()),

                    double.Parse(dataTable.Rows[i][6].ToString()),
                    double.Parse(dataTable.Rows[i][7].ToString()),

                    dataTable.Rows[i][8].ToString(),


                    byte.Parse(dataTable.Rows[i][9].ToString()),
                    DateTime.Parse(dataTable.Rows[i][10].ToString()),
                    DateTime.Parse(dataTable.Rows[i][11].ToString()),
                    short.Parse(dataTable.Rows[i][12].ToString())));
            }
            return spares;
        }

        public CheckBox CrearCheckBox(Spare sp)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.Tag = sp;
            checkBox.Content = sp.NameProduct;
            checkBox.Margin = new Thickness(5);

            checkBox.Checked += new RoutedEventHandler(CheckBoxAñadir_Click);
            checkBox.Unchecked += new RoutedEventHandler(CheckBoxEliminarLista_Click);
            return checkBox;
        }


        //añadir item a la lista del buscador
        private void CheckBoxAñadir_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            Spare spare = (Spare)checkBox.Tag;

            shoList.Add(new TrolleySpare(spare));

            /*string content = ((CheckBox)sender).Content.ToString();
            if (!listOrder.Exists(x => x.NameProduct == content))
            {
              

                shoList.Add(spare);
                //listOrder.Add(listTotal.Find(x => x.NameProduct == content));
                //listAñadidos.Add(content);
            }*/


        }

        private void CheckBoxEliminarLista_Click(object sender, RoutedEventArgs e)
        {
            string content = ((CheckBox)sender).Content.ToString();
            if (listOrder.Exists(x => x.NameProduct == content))
            {
                listOrder.Remove(listTotal.Find(x => x.NameProduct == content));
                listAñadidos.Remove(content);
            }

        }

        public void AñadirDatos()
        {
            int height = (int)SystemParameters.PrimaryScreenHeight;
            int width = (int)SystemParameters.PrimaryScreenWidth;
            dataGridProgram.Width = width - 200;
            dataGridProgram.Height = height - 20;
            dataGridProgram.ItemsSource = null;
            //dataGridProgram.ItemsSource= listOrder;



            // Crear un objeto dinámico para la primera persona

            //spareOrder.Spare = 
            //personas.Add(spareOrder);
            dataGridProgram.ItemsSource = shoList;
            DialogoHost1.IsOpen = false;

            double total = 0;

            foreach (var item in shoList)
            {
                total = item.Total + total;
            }



            txbTotalVentaBs.Text = $"Total de la Venta: Bs {total}";
        }




        public DataTable SelecionarDatosDbb()
        {
            DataTable dt = new DataTable();

            try
            {
                spareImpl = new SpareImpl();
                dt = spareImpl.Select();
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

        private void btnConfirmarAñadirProducto_Click(object sender, RoutedEventArgs e)
        {
            AñadirDatos();

        }

        private void btnCancelarAñdirProdcutos_Click(object sender, RoutedEventArgs e)
        {
            DialogoHost1.IsOpen = false;
        }

        public void AñadirListaOrderSpare()
        {
            orderSpares = new List<OrderSpare>();

            foreach (var item in listOrder)
            {
                //orderSpares.Add(new OrderSpare(item.IdSpare, item.Quantity, item.BasePrice, Session.IdSession, item.Total));
                //orderSpares.Add(new OrderSpare(item.IdSpare, item.BasePrice, Session.IdSession));

            }
        }

        /*public double SacarTotal(List<Spare> sp)
        {
            double total = 0;
            foreach (var item in sp)
            {
                total = total + item.Total;
            }
            return total;
   
        }*/
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Spare sp = ((Spare)((Button)e.Source).DataContext);
                int idProduct = sp.IdSpare;
                if (listOrder.Exists(x => x.IdSpare == idProduct))
                {
                    listOrder.Remove(sp);
                    listAñadidos.Remove(sp.NameProduct);
                    AñadirDatos();
                    //txbTotalVentaBs.Text = $"Total de la Venta: Bs {SacarTotal(listOrder)}";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAñadirMas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TrolleySpare sp = ((TrolleySpare)((Button)e.Source).DataContext);

                shoList.Find(x => x.Spare.IdSpare == sp.Spare.IdSpare).MasCantidad();


                /*int idProduct = sp.Spare.IdSpare; 

                Spare spare = listOrder.Find(x => x.IdSpare == idProduct);
                //spare.MasCantidad();*/
                AñadirDatos();
                //txbTotalVentaBs.Text = $"Total de la Venta: Bs {SacarTotal(listOrder)}";
            }
            catch (Exception)
            {

                throw;
            }



        }

        private void btnAñadirMenos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TrolleySpare sp = ((TrolleySpare)((Button)e.Source).DataContext);

                shoList.Find(x => x.Spare.IdSpare == sp.Spare.IdSpare).MenosCantidad();


                /*int idProduct = sp.Spare.IdSpare; 

                Spare spare = listOrder.Find(x => x.IdSpare == idProduct);
                //spare.MasCantidad();*/
                AñadirDatos();
                //txbTotalVentaBs.Text = $"Total de la Venta: Bs {SacarTotal(listOrder)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void PopupBox_OnOpened(object sender, RoutedEventArgs e)
        {

        }

        private void PopupBox_OnClosed(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelarVenta_Click(object sender, RoutedEventArgs e)
        {
            DialogoHost2.IsOpen = false;
        }

        private void btnAbrirPagVenta_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProgram.Items.Count > 0)
            {
                AñadirDatosDetalles();
                DialogoHost2.IsOpen = true;
            }
            else
            {
                NotificacionMensaje("Primero debe de añadir un repuesto a su lista de ventas", 1);
            }

        }

        public void AñadirDatosDetalles()
        {
            AñadirListaOrderSpare();
            double totalPagar = 0;
            double pagoClienteTotal = 0;
            double cambio = 0;

            foreach (TrolleySpare item in shoList)
            {
                totalPagar = totalPagar + item.Total;
            }

            txbVentaTotal.Text = $"Total: Bs {totalPagar}";
            txbVentaPago.Text = $"Pago: BS {pagoCliente}";
            txbVentaCambio.Text = $"Cambio: Bs {pagoCliente - totalPagar}";
        }

        private void btnVentaTerminarVenta_Click(object sender, RoutedEventArgs e)
        {
            AñadirPedidoDateBdd();
            DialogoHost2.IsOpen = false;
            RestablecerPrincipal();
            ReestablecerDialoghost();

        }


        public void ReestablecerDialoghost()
        {
            txtVentaFechaDeVenta.Text = txtVentaPagoCliente.Text = txtVentaNombreClienteBuscar.Text = "";
            gridDataClient.Visibility = Visibility.Collapsed;
            lstVentaListaClientes.Items.Clear();

        }

        public void RestablecerPrincipal()
        {
            txbTotalVentaBs.Text = "Total de la Venta: Bs 0.00";
            dataGridProgram.ItemsSource = null;

            spareImpl = new SpareImpl();
            listOrder = new List<Spare>();
            listTotal = new List<Spare>();
            listAñadidos = new List<string>();

            pagoCliente = 0;

            orderSpares = new List<OrderSpare>();

            orderSpare = new OrderSpare();

            clientImpl = new ClientImpl();
            datosClienteCompradors = new Client();
            ordenPrincipal = new Order();

        }

        public void AñadirPedidoDateBdd()
        {
            int id;
            /*try
            {*/
            double total = 0;
            foreach (var item in shoList)
            {
                var a = new OrderSpare(item.Spare.IdSpare, item.Quantity, item.BasePrice, Session.IdSession, item.Total);
                total += a.Total + total;
                orderSpares.Add(a);
            }

            Order order = new Order(Session.IdSession, datosClienteCompradors.IdClient, pagoCliente, total);

            OrderImpl orderImpl = new OrderImpl();
            id = orderImpl.InsertAvanced(order, orderSpares);
            NotificacionMensaje("Se Realizo una venta", 2);
            enviarEmails1compra();
            windowsRecibo windowsRecibo = new windowsRecibo(id, order, datosClienteCompradors);
            windowsRecibo.Show();

            /* }
             catch (Exception ex)
             {
                 throw ex;
             }*/
        }

        private void btnVentaEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            gridDataClient.Visibility = Visibility.Collapsed;
            gridBuscador.Visibility = Visibility.Visible;
            lstVentaListaClientes.Visibility = Visibility.Visible;
        }

        private void btnVentaCancelarVenta_Click(object sender, RoutedEventArgs e)
        {
            DialogoHost2.IsOpen = false;
            ReestablecerDialoghost();
        }

        private void btnVentaBuscarCliente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtNombreBuscarCliente_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }


        public void SeleccionarLikeDateBdd()
        {
            DataTable dt = new DataTable();
            try
            {
                clientImpl = new ClientImpl();
                dt = clientImpl.SelectLike(txtVentaNombreClienteBuscar.Text);
                CargarDatosListBox(dt);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void CargarDatosListBox(DataTable dt)
        {
            lstVentaListaClientes.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                Client cl = new Client(int.Parse(dt.Rows[i][0].ToString()),
                                                       dt.Rows[i][1].ToString(),
                                                       dt.Rows[i][2].ToString(),
                                                       dt.Rows[i][3].ToString(),


                                                       byte.Parse(dt.Rows[i][4].ToString()),
                                                       DateTime.Parse(dt.Rows[i][5].ToString()),
                                                       DateTime.Parse(dt.Rows[i][6].ToString()),
                                                        short.Parse(dt.Rows[i][7].ToString()),
                                                        dt.Rows[i][8].ToString()
                                                       );
                lstVentaListaClientes.Items.Add(CrearCheckBox2(cl, i));
            }
        }




        public CheckBox CrearCheckBox2(Client dt, int i)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.Content = dt.FistName;
            checkBox.Name = $"idClient{dt.IdClient}";
            checkBox.Margin = new Thickness(5);
            checkBox.Tag = dt;
            checkBox.Checked += new RoutedEventHandler(CheckBoxAñadir2_Click);
            //checkBox.Unchecked += new RoutedEventHandler(CheckBoxEliminarLista_Click);
            return checkBox;
        }

        public DataTable SeleccionarClientDbb()
        {
            DataTable dt = new DataTable();
            try
            {
                clientImpl = new ClientImpl();
                dt = clientImpl.Select();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        private void CheckBoxAñadir2_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            Client cl = checkBox.Tag as Client;


            datosClienteCompradors = cl;

            gridDataClient.Visibility = Visibility.Visible;
            txbVentaNit.Text = $"Nit: {datosClienteCompradors.Nit}";
            txbVentaNombre.Text = $"Nombre: {datosClienteCompradors.FistName}";
            txbVentaApellido.Text = $"Apellido: {datosClienteCompradors.LastName}";
            txtVentaFechaDeVenta.Text = DateTime.Now.ToString("M");
            txtVentaFechaDeVenta.IsEnabled = false;
            gridBuscador.Visibility = Visibility.Hidden;
            lstVentaListaClientes.Visibility = Visibility.Hidden;

        }



        public void enviarEmails1compra()
        {
            string connectionString = @"Server=AndyHP\MSSQLSERVER_PRIV;Database=BDDAUTONET2023;User Id=sa; Password=Univalle";

            // Consulta SQL para obtener los emails
            string query = @"SELECT c.idClient, c.email as email_c
                            FROM Client c
                            INNER JOIN[Order] o ON c.idClient = o.idClient
                            WHERE o.registerDate >= CAST(GETDATE() AS DATE)
                            GROUP BY c.idClient, c.email
                            HAVING COUNT(o.idOrder) = 1;
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
                            string email = reader["email_c"].ToString();
                            string ofertas = "Gracias por su compra. Estas son las ofertas de este mes :)";
                            // Llamar al método para enviar el correo electrónico
                            EmailService.EnviarCorreoContraña2(email, ofertas);




                           
                        }
                    }
                }
            }
        }

        private void txtNombreBuscarCliente_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtVentaNombreClienteBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SeleccionarLikeDateBdd();
        }

        private void lstVentaListaClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtVentaPagoCliente_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtVentaPagoCliente.Text != "")
            {
                if (double.Parse(txtVentaPagoCliente.Text) > 0)
                {
                    pagoCliente = double.Parse(txtVentaPagoCliente.Text);
                    AñadirDatosDetalles();
                }

            }

        }

        private void btnRegistrarCliente_Click(object sender, RoutedEventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.Show();
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
            if (listaVentas != null)
            {
                listaVentas();
            }
        }

        private void Tiempo()
        {
            int delay = 3000;
            Thread.Sleep(delay);
        }

        private void btnListaVentas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGridProgram_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
