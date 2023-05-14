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
using System.Windows.Shapes;

namespace Univalle.AutoNetWPF.PersonAdmin.ClientT
{
    /// <summary>
    /// Lógica de interacción para EditClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
        public event RecargarDatosBdd recargarDatosBdd;
        private int idClient;
        ClientImpl clientImpl;
        Client client;
        public EditClient(int idClient)
        {
            InitializeComponent();
            this.idClient = idClient;
           
        }


        public void CargarDatosDBB()
        {
            DataTable dt = SelccionarDatosDbb(idClient);
            if(dt.Rows.Count > 0)
            {
                try
                {
                    txtId.Text = dt.Rows[0][0].ToString();
                    txtNit.Text = dt.Rows[0][1].ToString();
                    txtNombres.Text = dt.Rows[0][2].ToString();
                    txtPrimerApellido.Text = (dt.Rows[0][3].ToString()).Split(' ')[0];
                    txtSegundoApellido.Text = (dt.Rows[0][3].ToString()).Split(' ')[1];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                
            }
            
            
        }

        public DataTable SelccionarDatosDbb(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                clientImpl = new ClientImpl();
                dt = clientImpl.GetId(id);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        private void btnGuadar_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDatosBdd();
        }


        public void ActualizarDatosBdd()
        {
            /*try
            {*/
                clientImpl = new ClientImpl();
                int rest = clientImpl.Update(new Client(int.Parse(txtId.Text),txtNit.Text, txtNombres.Text, txtPrimerApellido.Text + " " + txtSegundoApellido.Text, Session.IdSession));
                if (rest > 0)
                {
                    NotificacionMensaje("Se Modifico un Empleado", 2);
                    if(recargarDatosBdd != null)
                    {
                        recargarDatosBdd();
                    }

                }
           /* }
            catch (Exception ex)
            {
                NotificacionMensaje(ex.Message , 1);
            }*/
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatosDBB(); 
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


    }
}
