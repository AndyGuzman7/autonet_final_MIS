﻿using DAO.Implementacion;
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
    /// <summary>
    /// Lógica de interacción para CompraProveedor.xaml
    /// </summary>
    public partial class CompraProveedor : Window
    {
        private Suppliers suppliers;
        private SuppliersImpl suppliersImpl;
        public CompraProveedor()
        {
            InitializeComponent();
        }

        private void btnGuadar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {

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

        private void cbxProveedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Suppliers suppliers = comboBox.SelectedItem as Suppliers;
            
        }

        private void btnVistaProducto_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
