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

namespace Univalle.AutoNetWPF.PartsAdmin
{
    /// <summary>
    /// Lógica de interacción para uscPartsType.xaml
    /// </summary>

    
    public partial class uscPartsType : UserControl
    {
        //SpareImpl spareImpl;
        //Spare spare;
        //List<Spare> spares;

        SpareTypeImpl spareTypeImpl;
        SpareType spareType;
        List<SpareType> spareTypes;



        public static event Activar activar;
        public uscPartsType()
        {
            InitializeComponent();
        }

        private void btnRepuestosL_Click(object sender, RoutedEventArgs e)
        {
            AddPartsType addPartsType = new AddPartsType();
            addPartsType.ShowDialog();

        }
        public void LoadData()
        {
            
                spareTypeImpl = new SpareTypeImpl();
                DataTable dataTable = spareTypeImpl.Select();

                CrearColumansFila(LlenarLista(dataTable).Count);
           






        }

        public List<SpareType> LlenarLista(DataTable dataTable)
        {
            spareTypes = new List<SpareType>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                spareTypes.Add( new SpareType(byte.Parse(dataTable.Rows[i][0].ToString()), dataTable.Rows[i][1].ToString(), byte.Parse(dataTable.Rows[i][2].ToString()), short.Parse(dataTable.Rows[i][3].ToString()), byte.Parse(dataTable.Rows[i][4].ToString()), DateTime.Parse(dataTable.Rows[i][5].ToString()), DateTime.Parse(dataTable.Rows[i][6].ToString())));
            }
            return spareTypes;
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


            AñadirContenido(count, cantidaProducto);
        }
        public void AñadirContenido(int cantfila, int cantColumnas)
        {

            MaterialDesignThemes.Wpf.Card[] card = AñadirPropiedadesComponentes(cantColumnas);
            int k = 0;
            for (int i = 0; i < cantfila; i++) // filas
            {
                for (int j = 0; j < cantColumnas; j++) // columnas    
                {
                    Grid.SetRow(card[k], i);
                    Grid.SetColumn(card[k], j);
                    gridParts.Children.Add(card[k]);
                    k++;
                }
            }


        }
        public MaterialDesignThemes.Wpf.Card[] AñadirPropiedadesComponentes(int cant)
        {
            Thickness thicknessM = new Thickness(10);
            List<SpareType> listaSpareTypes = spareTypes;
            TextBlock[] textBlocks = new TextBlock[cant];
            ToolTip[] toolTips = AñadirToolTips(cant);
            Thickness thickness = new Thickness(5);
            Button[] buttons = new Button[cant];
            MaterialDesignThemes.Wpf.Card[] card = new MaterialDesignThemes.Wpf.Card[cant];
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri("pack://application:,,,/PartsAdmin/image/rodamientos.png"));
            myBrush.ImageSource = image.Source;

            for (int i = 0; i < cant; i++)
            {
                buttons[i] = new Button();
                buttons[i].Name = spareTypes[i].NameSpareType;
                buttons[i].Content = spareTypes[i].NameSpareType;
                buttons[i].FontSize = 20;
                buttons[i].Foreground = Brushes.Black;
                buttons[i].Background = null;
                buttons[i].BorderBrush = null;
                buttons[i].Click += new RoutedEventHandler(Button_Click);
                buttons[i].ToolTip = toolTips[i];
                card[i] = new MaterialDesignThemes.Wpf.Card();

                card[i].Margin = thickness;
                //card[i].Background = myBrush;
                //card[i].Background.Opacity = 0.5;
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
            SpareType spareType = new SpareType();
            foreach (var item in spareTypes)
            {
                if (((Button)sender).Name == item.NameSpareType)
                {
                    spareType = item;
                    ViewsPartsType ViewsPartsType = new ViewsPartsType(spareType);
                    ViewsPartsType.recargarPagina += LoadData;
                    ViewsPartsType.ShowDialog();
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

     
    }
}
