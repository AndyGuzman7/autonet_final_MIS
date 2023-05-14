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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAO.Model;
using DAO.Implementacion;
using System.Data;
using System.Text.RegularExpressions;

namespace Univalle.AutoNetWPF.PartsAdmin
{
    /// <summary>
    /// Lógica de interacción para uscParts.xaml
    /// </summary>

    public delegate void Activar();
    public partial class uscParts : UserControl
    {
        SpareImpl spareImpl;
        Spare spare;
        List<Spare> spares;
        public static event Activar activar;
        public uscParts()
        {
            InitializeComponent();
            
        }

        private void btnRepuestosL_Click(object sender, RoutedEventArgs e)
        {
            AddParts addParts = new AddParts();
            addParts.recargarPagina += LoadData;
            addParts.ShowDialog();
            
        }

        DataTable SelectSpare()
        {
            DataTable dt = new DataTable();
            try
            {
                spareImpl = new SpareImpl();
                dt = spareImpl.Select();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comuniquese con el encargado de Sistemas");
            }
            return dt;
        }

        public  void LoadData()
        {



            int height = (int)SystemParameters.PrimaryScreenHeight;
            int width = (int)SystemParameters.PrimaryScreenWidth;
            dataGridProgram.Width = width - 200;
            dataGridProgram.Height = height - 20;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Nombre Repuesto";
            textBlock.FontFamily = new FontFamily("Motserrat");
            textBlock.FontSize = 17;
            textBlock.Margin = new Thickness(5);
            textBlock.VerticalAlignment = VerticalAlignment.Center;

            MaterialDesignThemes.Wpf.PackIcon packIcon = new MaterialDesignThemes.Wpf.PackIcon();
            packIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Nut;
            packIcon.Foreground = Brushes.Blue;
            packIcon.Margin = new Thickness(5);
            packIcon.Width = 17;
            packIcon.Height = 17;
            packIcon.VerticalAlignment = VerticalAlignment.Center;

            StackPanel st1 = new StackPanel();
           
            st1.Children.Add(packIcon);
            st1.Children.Add(textBlock);
            st1.Orientation = Orientation.Horizontal;

            st1.VerticalAlignment = VerticalAlignment.Center;


            dtdd.Header = st1;


           
            dataGridProgram.ItemsSource = SelectSpare().DefaultView; 
             
        }
        public void LoadDataLike(DataTable dt)
        {
            int height = (int)SystemParameters.PrimaryScreenHeight;
            int width = (int)SystemParameters.PrimaryScreenWidth;
            dataGridProgram.Width = width - 200;
            dataGridProgram.Height = height - 20;
            dataGridProgram.ItemsSource = dt.AsDataView();
           
        }

        List<Spare> ConvertDataTable(DataTable dataTable)
        {
            List<Spare> spares = new List<Spare>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                spares.Add(new Spare(int.Parse(dataTable.Rows[i][0].ToString()), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString(), int.Parse(dataTable.Rows[i][3].ToString()), double.Parse(dataTable.Rows[i][4].ToString()), double.Parse(dataTable.Rows[i][5].ToString()), dataTable.Rows[i][6].ToString(), int.Parse(dataTable.Rows[i][7].ToString()), int.Parse(dataTable.Rows[i][8].ToString()), byte.Parse(dataTable.Rows[i][9].ToString()), DateTime.Parse(dataTable.Rows[i][10].ToString()), DateTime.Parse(dataTable.Rows[i][11].ToString()), short.Parse(dataTable.Rows[i][12].ToString()), new List<string>() { "10", "30", "80", "100" }));
            }
            return spares;
        }

        public List<Spare> LlenarLista(DataTable dataTable)
        {
            spares = new List<Spare>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                spares.Add(new Spare(int.Parse(dataTable.Rows[i][0].ToString()), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString(), int.Parse(dataTable.Rows[i][3].ToString()), double.Parse(dataTable.Rows[i][4].ToString()), double.Parse(dataTable.Rows[i][5].ToString()), dataTable.Rows[i][6].ToString(), int.Parse(dataTable.Rows[i][7].ToString()), int.Parse(dataTable.Rows[i][8].ToString()), byte.Parse(dataTable.Rows[i][9].ToString()), DateTime.Parse(dataTable.Rows[i][10].ToString()), DateTime.Parse(dataTable.Rows[i][11].ToString()), short.Parse(dataTable.Rows[i][12].ToString())));
            }
            return spares;
        }


        public void Editar()
        {
            if (activar != null)
            {
                activar();
            }
            else
            {
                MessageBox.Show("No hay ninguna ventana");
            }
            //UserControl usc = null;
            ////gridMainParts.Children.Clear();
            //usc = new PartsAdmin.uscPartsEdit();
            //if (usc != null)
            //{
            //    gridMainParts.Children.Add(usc);
            //}
        }
        public void CrearColumansFila(int rowI)
        {
            gridParts.Children.Clear();
            gridParts.RowDefinitions.Clear();
            gridParts.ColumnDefinitions.Clear();
            int columnJ = 5;
            int cantidaProducto = rowI;
            int count = 0;
            while (rowI > 0)
            {
                rowI = rowI - 5;
                count++;
            }

            ColumnDefinition[] columnDefinitions;
            RowDefinition[] rowDefinitions;
            rowDefinitions = new RowDefinition[count]; // filas
            columnDefinitions = new ColumnDefinition[columnJ];// columnas
            gridParts.Height = count * 100;

            //gridParts.ShowGridLines = true;
            Thickness thickness = new Thickness(80);

            for (int i = 0; i < count; i++)
            {
                rowDefinitions[i] = new RowDefinition();
                
                gridParts.RowDefinitions.Add(rowDefinitions[i]);
            }
            for (int i = 0; i < columnJ; i++)
            {
                columnDefinitions[i] = new ColumnDefinition();
                gridParts.ColumnDefinitions.Add(columnDefinitions[i]);
            }

            //MessageBox.Show(count.ToString()+ " " +columnJ.ToString());
            AñadirContenido(count, columnJ, cantidaProducto );
        }
        public void AñadirContenido(int cantfila, int cantColumnas, int cantidad)
        {

            MaterialDesignThemes.Wpf.Card[] card = AñadirPropiedadesComponentes(cantidad);
            int k = 0;
            for (int i = 0; i < cantfila; i++) // filas
            {
                for (int j = 0; j < cantColumnas; j++) // columnas    
                {
                    if(k != cantidad)
                    {
                        Console.WriteLine("Card=> " + k + "Columnas=>" + j + "Fila =>" + i + "Cantidad" + cantidad);
                        Grid.SetRow(card[k], i);
                        Grid.SetColumn(card[k], j);
                        gridParts.Children.Add(card[k]);

                        k++;
                    }
                   
                }
                
            }
            
            
        }
        public MaterialDesignThemes.Wpf.Card[] AñadirPropiedadesComponentes(int cant)
        {
            Thickness thicknessM = new Thickness(10);
            List<Spare> listaSpares = spares;
            TextBlock [] textBlocks = new TextBlock[cant];
            ToolTip[] toolTips = AñadirToolTips(cant);
            Thickness thickness = new Thickness(5);
            Button[] buttons = new Button[cant];
            MaterialDesignThemes.Wpf.Card[] card = new MaterialDesignThemes.Wpf.Card[cant];
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri("pack://application:,,,/PartsAdmin/image/rodamientos.png"));
            myBrush.ImageSource = image.Source;
            char[] charsToTrim = { '*', ' ', '\'' };
            for (int i = 0; i < cant; i++)
            {
                buttons[i] = new Button();
                buttons[i].Name = Regex.Replace(listaSpares[i].NameProduct, @"\s", "");
                buttons[i].Content = listaSpares[i].NameProduct;
                buttons[i].FontSize = 20;
                buttons[i].Foreground = Brushes.Black;
                buttons[i].Background = null;
                buttons[i].BorderBrush = null;
                buttons[i].Click += new RoutedEventHandler(Button_Click);
                buttons[i].ToolTip = toolTips[i];
                card[i] = new MaterialDesignThemes.Wpf.Card();
               
                card[i].Margin = thickness;
                card[i].Background = myBrush;
                card[i].Background.Opacity = 0.5;
                card[i].Content = buttons[i];
                
            }
            return card;
        }
        public TextBlock[] AñadirTextBlock(int m)
        {
            TextBlock[] textBlocks = new TextBlock[m];
            Thickness thickness = new Thickness(10);
            for (int i = 0; i < m; i++)
            {
                textBlocks[i] = new TextBlock();
                textBlocks[i].Text = @"Fila1
Fila2";
                textBlocks[i].Margin = thickness;
                textBlocks[i].Width = 150;
                textBlocks[i].TextWrapping = TextWrapping.Wrap;
                textBlocks[i].Foreground = Brushes.Black;
            }
            return textBlocks;
        }
        public StackPanel[] AñadirStackPanel(int m)
        {
            TextBlock[] textBlocks = AñadirTextBlock(m);
            StackPanel[] stackPanels = new StackPanel[m];
            for (int i = 0; i < m; i++)
            {
                stackPanels[i] = new StackPanel();
                stackPanels[i].Orientation = Orientation.Horizontal;
                stackPanels[i].Children.Add(textBlocks[i]);
            }

            return stackPanels;
        }
        public ToolTip[] AñadirToolTips(int m)
        {
            StackPanel[] stackPanels = AñadirStackPanel(m);
            ToolTip[] toolTips = new ToolTip[m];
            for (int i = 0; i < m; i++)
            {
                toolTips[i] = new ToolTip();
                toolTips[i].Content = "prueba";
                toolTips[i].OverridesDefaultStyle = true;
                toolTips[i].HasDropShadow = true;
                toolTips[i].Content = stackPanels[i];
            }
            return toolTips;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Spare spareDate = new Spare();
            foreach (var item in spares)
            {
                if(((Button)sender).Name == Regex.Replace(item.NameProduct, @"\s", ""))
                {
                    spareDate = item;
                    ViewParts viewParts = new ViewParts(spareDate);
                    viewParts.recargarPagina += LoadData;
                    viewParts.ShowDialog();
                    break;
                }

            }
            
           
            //viewParts.CargarProducto()
            //Editar();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            ///SelectLike();
            /*foreach (DataRowView item in dataGridProgram.Items)
            {
                Console.WriteLine(item.Row[0][""])
            }*/
        }

        public void SelectLike()
        {
                DataTable dt = new DataTable();
                try
                {
                    spareImpl = new SpareImpl();
                    dt = spareImpl.SelectLike(txtNombreBuscar.Text);
                    dataGridProgram.ItemsSource = dt.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Comuniquese con el encargado de sistemas");
                }
            
            
        }

        private void txtNombreBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelectLike();
        }

        private void Style_BadgeChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAñadirMas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAñadirMenos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnVistaProducto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                List<Spare> ls = LlenarLista(SelectSpare());
                foreach (var item in ls)
                {
                    if(item.IdSpare == int.Parse(dataRowView[0].ToString()))
                    {
                        ViewParts viewParts = new ViewParts(item);
                        viewParts.recargarPagina += LoadData;
                        viewParts.ShowDialog();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmbTipos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            MessageBox.Show(comboBox.SelectedItem.ToString());
        }
    }
}
