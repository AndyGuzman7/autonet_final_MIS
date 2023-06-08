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
using System.Windows.Shapes;

namespace Univalle.AutoNetWPF.PartsAdmin.AllParts
{

    public delegate void ReloadPageSpares();
    /// <summary>
    /// Lógica de interacción para CompraProveedor.xaml
    /// </summary>
    public partial class CompraProveedor : Window
    {
        public event ReloadPageSpares ReloadPage;
        private Suppliers suppliers;
        List<TrolleySpare> list = new List<TrolleySpare>();
        private SuppliersImpl suppliersImpl;
        private SuppliersSpareImpl suppliersSpareImpl;
        private List<Spare> spares = new List<Spare>();
        List<SuppliersSpare> li = new List<SuppliersSpare>();
        public CompraProveedor()
        {
            InitializeComponent();
        }

        private void btnGuadar_Click(object sender, RoutedEventArgs e)
        {
            suppliers = cbxProveedor.SelectedItem as Suppliers;
            suppliersSpareImpl = new SuppliersSpareImpl();
            suppliersSpareImpl.InsertAvanced(list, suppliers);
            this.Close();
            if (ReloadPage == null) return;
            ReloadPage();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private DataTable SelectProviders()
        {
            suppliersImpl = new SuppliersImpl();

            var d = suppliersImpl.Select();

            return d;
        }




        public List<Suppliers> ConvertirDataTable(DataTable dt)
        {
            Suppliers suppliers;
            List<Suppliers> f = new List<Suppliers>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                suppliers = new Suppliers(int.Parse(dt.Rows[i][0].ToString()),
                                        dt.Rows[i][1].ToString(),
                                        dt.Rows[i][2].ToString(),
                                        int.Parse(dt.Rows[i][3].ToString()),
                                        dt.Rows[i][4].ToString(),
                                        DateTime.Parse(dt.Rows[i][5].ToString()),
                                        short.Parse(dt.Rows[i][6].ToString()),
                                        byte.Parse(dt.Rows[i][7].ToString()),
                                        DateTime.Parse(dt.Rows[i][8].ToString()));
                f.Add(suppliers);
            }
            return f;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxProveedor.ItemsSource = ConvertirDataTable(SelectProviders());
        }





        private SuppliersSpare SpareToSuplierSpare(Spare spare)
        {
            //short idEmploye, byte status, DateTime registrationDate, DateTime dateUpdate)
            return new SuppliersSpare(spare.IdSpare, spare.NameProduct, 0, 1, spare.BasePrice, spare.BasePrice, Session.IdSession, 1, DateTime.Now, DateTime.Now);
        }

        private void cbxProveedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Suppliers suppliers = comboBox.SelectedItem as Suppliers;

        }

        private void btnVistaProducto_Click(object sender, RoutedEventArgs e)
        {

        }



        private void dataGridProgram_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void btnAddProductList_Click(object sender, RoutedEventArgs e)
        {
            SpareListComp spareListComp = new SpareListComp();

            gridDialog.Children.Clear();
            if (spareListComp != null)
            {
                spareListComp.DialogSpareCancel += EventDialogCancel;
                spareListComp.DialogSpareAcept += EventDialogAccept;
                spareListComp.Data = spares;
                gridDialog.Children.Add(spareListComp);
                DialogoHost1.IsOpen = true;
             
            }

        }

        private void EventDialogAccept(List<Spare> spares = null)
        {
            this.spares = spares;
            CloseDialog();
            AddSpareToTrolleySpare();
            LoadSpareDataGrid();
        }


        private void AddSpareToTrolleySpare()
        {
            for (int i = 0; i < spares.Count; i++)
            {
                if(!list.Exists(x => x.Spare.IdSpare == spares[i].IdSpare))
                {
                    list.Add(new TrolleySpare(spares[i]));
                }
            }
            //list = spares.Select(s => new TrolleySpare(s)).ToList();

        }


        private void EventDialogCancel(List<Spare> spares = null)
        {
            CloseDialog();
        }

        private void CloseDialog()
        {
            DialogoHost1.IsOpen = false;
            gridDialog.Children.Clear();
        }



        private void LoadSpareDataGrid()
        {
            

            
            dataGridProgram.ItemsSource = null;
            dataGridProgram.ItemsSource = list;
        }

        private void txtCant_SelectionChanged(object sender, RoutedEventArgs e)
        {

            TextBox textBox = sender as TextBox;
            TrolleySpare sp = ((TrolleySpare)((TextBox)e.Source).DataContext);
            if(textBox.Text == "")
            {
                return;
            }

            list.Find(x => x.Spare.IdSpare == sp.Spare.IdSpare).ChangeQuantity(int.Parse(textBox.Text));

            //MessageBox.Show(sp.NameProduct);
        }
    }
}
