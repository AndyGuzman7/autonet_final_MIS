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

namespace Univalle.AutoNetWPF.PartsAdmin
{
    /// <summary>
    /// Lógica de interacción para AddPartsType.xaml
    /// </summary>
    public partial class AddPartsType : Window
    {
        SpareType spareType;
        SpareTypeImpl spareTypeImpl;
        public event RecargarPagina recargarPagina;
        public AddPartsType()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuadar_Click(object sender, RoutedEventArgs e)
        {
            AñadirProducto();
            this.Close();
        }

        public void AñadirProducto()
        {
            try
            {
                spareType = new SpareType(txtNombreTipo.Text, byte.Parse(txtCategoria.Text), 1);
                spareTypeImpl = new SpareTypeImpl();
                int res = spareTypeImpl.Insert(spareType);
                if (res > 0)
                {
                    MessageBox.Show("Registro Insertado con exito");
                }
                if (recargarPagina != null)
                {
                    recargarPagina();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
