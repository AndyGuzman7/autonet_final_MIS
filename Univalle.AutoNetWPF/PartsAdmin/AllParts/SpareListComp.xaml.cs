using DAO.Implementacion;
using DAO.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Univalle.AutoNetWPF.PartsAdmin.AllParts
{
    public delegate void DialogSpare(List<Spare> spares = null);
    /// <summary>
    /// Lógica de interacción para SpareListComp.xaml
    /// </summary>
    public partial class SpareListComp : UserControl
    {

        public static readonly DependencyProperty MyDataProperty =
        DependencyProperty.Register("Data", typeof(List<Spare>), typeof(SpareListComp), new PropertyMetadata(new List<Spare>()));

        public List<Spare> Data
        {
            get { return (List<Spare>)GetValue(MyDataProperty); }
            set { SetValue(MyDataProperty, value); shopSpare = Data; }
        }





        public event DialogSpare DialogSpareAcept;
        public event DialogSpare DialogSpareCancel;
        private List<Spare> shopSpare = new List<Spare>();
        public SpareListComp()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataSpares();
        }
        public DataTable SelectSpare()
        {
            DataTable dt = new DataTable();

            try
            {
                SpareImpl spareImpl = new SpareImpl();

                dt = spareImpl.Select();
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public List<Spare> GetSpares(DataTable dataTable)
        {
            List<Spare> spares = new List<Spare>();

            foreach (DataRow item in dataTable.Rows)
            {
                spares.Add(new Spare().FromDataTable(item));
            }

            return spares;
        }


        private void LoadDataSpares()
        {
            DataTable dt = SelectSpare();
            List<Spare> listSpares = GetSpares(dt);

            lstProductos.Items.Clear();
            for (int i = 0; i < listSpares.Count; i++)
            {
                if (!shopSpare.Exists(s => s.IdSpare == listSpares[i].IdSpare))
                {
                    lstProductos.Items.Add(CrearCheckBox(listSpares[i]));
                }

            }

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


        private void CheckBoxAñadir_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            Spare spare = (Spare)checkBox.Tag;


            if (shopSpare.Exists(s => s.IdSpare == spare.IdSpare)) return;
            shopSpare.Add(spare);
        }

        private void CheckBoxEliminarLista_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            Spare spare = (Spare)checkBox.Tag;


            if (shopSpare.Exists(s => s.IdSpare == spare.IdSpare)) return;
            shopSpare.Remove(spare);
        }

        private void btnCancelarAñdirProdcutos_Click(object sender, RoutedEventArgs e)
        {
            if (DialogSpareCancel == null) return;
            DialogSpareCancel(null);
        }

        private void btnConfirmarAñadirProducto_Click(object sender, RoutedEventArgs e)
        {
            if (DialogSpareAcept == null) return;
            DialogSpareAcept(shopSpare);
        }
    }
}
