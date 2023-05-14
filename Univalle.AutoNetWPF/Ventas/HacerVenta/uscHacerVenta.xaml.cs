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

        double pagoCliente = 0;

        private List<OrderSpare> orderSpares = new List<OrderSpare>();

        private OrderSpare orderSpare;

        ClientImpl clientImpl;
        Client datosClienteComprador = new Client();
        Order ordenPrincipal = new Order();

        public uscHacerVenta()
        {
            InitializeComponent();
            AñadirDatos();
        }

        private void btnAñadirRepuestoLista_Click(object sender, RoutedEventArgs e)
        {
            DialogoHost1.IsOpen = true;
            AñadirDatosLista();
        }


        public void AñadirDatosLista()
        {
            DataTable dt = SelecionarDatosDbb();
            List<Spare> sp = LlenarLista(dt);
            listTotal = LlenarLista(dt);
            Grid grid = new Grid();
            //lstProductos.Items.Clear();
            lstProductos.Items.Clear();
            for (int i = 0; i < sp.Count; i++)
            {
               
                if(!listAñadidos.Contains(sp[i].NameProduct))
                {
                    grid = new Grid();
                    grid.Children.Add(CrearCheckBox(sp[i]));
                    lstProductos.Items.Add(grid);
                   
                }
                
                
            }


        }


        public List<Spare> LlenarLista(DataTable dataTable)
        {
             List<Spare> spares = new List<Spare>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                spares.Add(new Spare(int.Parse(dataTable.Rows[i][0].ToString()), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString(), int.Parse(dataTable.Rows[i][3].ToString()), double.Parse(dataTable.Rows[i][4].ToString()), double.Parse(dataTable.Rows[i][5].ToString()), dataTable.Rows[i][6].ToString(), int.Parse(dataTable.Rows[i][7].ToString()), int.Parse(dataTable.Rows[i][8].ToString()), byte.Parse(dataTable.Rows[i][9].ToString()), DateTime.Parse(dataTable.Rows[i][10].ToString()), DateTime.Parse(dataTable.Rows[i][11].ToString()), short.Parse(dataTable.Rows[i][12].ToString())));
            }
            return spares;
        }

        public CheckBox CrearCheckBox(Spare sp)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.Content = sp.NameProduct;
            checkBox.Margin = new Thickness(5);

            checkBox.Checked += new RoutedEventHandler(CheckBoxAñadir_Click);
            checkBox.Unchecked += new RoutedEventHandler(CheckBoxEliminarLista_Click);
            return checkBox;
        }

        private void CheckBoxAñadir_Click(object sender, RoutedEventArgs e)
        {

            string content = ((CheckBox)sender).Content.ToString();
            if (!listOrder.Exists(x => x.NameProduct == content))
            {
                listOrder.Add(listTotal.Find(x => x.NameProduct == content));
                listAñadidos.Add(content);
            }
            
          
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
            dataGridProgram.ItemsSource= listOrder;
            DialogoHost1.IsOpen = false;
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
            txbTotalVentaBs.Text = $"Total de la Venta: Bs {SacarTotal(listOrder)}";
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
                orderSpares.Add(new OrderSpare(item.IdSpare, item.Quantity, item.BasePrice, Session.IdSession, item.Total));
            }
        }

        public double SacarTotal(List<Spare> sp)
        {
            double total = 0;
            foreach (var item in sp)
            {
                total = total + item.Total;
            }
            return total;
   
        }

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
                    txbTotalVentaBs.Text = $"Total de la Venta: Bs {SacarTotal(listOrder)}";
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
                Spare sp = ((Spare)((Button)e.Source).DataContext);
                int idProduct = sp.IdSpare;
                Spare spare = listOrder.Find(x => x.IdSpare == idProduct);
                spare.MasCantidad();
                AñadirDatos();
                txbTotalVentaBs.Text = $"Total de la Venta: Bs {SacarTotal(listOrder)}";
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
                Spare sp = ((Spare)((Button)e.Source).DataContext);
                int idProduct = sp.IdSpare;
                Spare spare = listOrder.Find(x => x.IdSpare == idProduct);
                spare.MenosCantidad();
                AñadirDatos();
                txbTotalVentaBs.Text = $"Total de la Venta: Bs {SacarTotal(listOrder)}";
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
            if(dataGridProgram.Items.Count > 0)
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

            foreach (var item in orderSpares)
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
            txtVentaFechaDeVenta.Text = txtVentaPagoCliente.Text = txtVentaNombreClienteBuscar.Text ="";
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
             datosClienteComprador = new Client();
             ordenPrincipal = new Order();

    }
    
        public void AñadirPedidoDateBdd()
        {
            int id;
            try
            {
                Order order = new Order(Session.IdSession, datosClienteComprador.IdClient, pagoCliente);
                OrderImpl orderImpl = new OrderImpl();
                id = orderImpl.InsertAvanced(order, orderSpares);
                NotificacionMensaje("Se Realizo una venta", 2);
                windowsRecibo windowsRecibo = new windowsRecibo(id);
                windowsRecibo.Show();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                lstVentaListaClientes.Items.Add(CrearCheckBox2(dt, i));
            }
        }

        public CheckBox CrearCheckBox2(DataTable dt, int i)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.Content = dt.Rows[i][6];
            checkBox.Name = $"idClient{dt.Rows[i][0]}";
            checkBox.Margin = new Thickness(5);

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

            string id = ((CheckBox)sender).Name.ToString();
            datosClienteComprador = new Client();
            DataTable dt = SeleccionarClientDbb();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if($"idClient{dt.Rows[i][0]}" == id)
                {
                    datosClienteComprador = new Client(int.Parse(dt.Rows[i][0].ToString()),
                                                                 dt.Rows[i][1].ToString(),
                                                       short.Parse(dt.Rows[i][2].ToString()),
                                                       byte.Parse(dt.Rows[i][3].ToString()),
                                                       DateTime.Parse(dt.Rows[i][4].ToString()),
                                                       DateTime.Parse(dt.Rows[i][5].ToString()),
                                                       dt.Rows[i][6].ToString(),
                                                       dt.Rows[i][7].ToString()
                                                       );
                    gridDataClient.Visibility = Visibility.Visible;
                    txbVentaNit.Text = $"Nit: {datosClienteComprador.Nit}";
                    txbVentaNombre.Text = $"Nombre: {datosClienteComprador.FistName}";
                    txbVentaApellido.Text = $"Apellido: {datosClienteComprador.LastName}";
                    txtVentaFechaDeVenta.Text = DateTime.Now.ToString("M");
                    txtVentaFechaDeVenta.IsEnabled = false;
                    gridBuscador.Visibility = Visibility.Hidden;
                    lstVentaListaClientes.Visibility = Visibility.Hidden;
                    break;
                }
            }
            //MessageBox.Show(id);
            /*if (!listOrder.Exists(x => x.NameProduct == content))
            {
                listOrder.Add(listTotal.Find(x => x.NameProduct == content));
                listAñadidos.Add(content);
            }*/
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
            if(txtVentaPagoCliente.Text != "")
            {
                if(double.Parse(txtVentaPagoCliente.Text) > 0)
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
            if(listaVentas != null)
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
    }
}
