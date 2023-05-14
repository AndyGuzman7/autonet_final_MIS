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
using Univalle.AutoNetWPF.PersonasAdmin.EmployeeT;
using Univalle.AutoNetWPF.PersonAdmin.EmployeeT;

namespace Univalle.AutoNetWPF.PersonasAdmin
{
    /// <summary>
    /// Lógica de interacción para uscEmployee.xaml
    /// </summary>
    public delegate void Activar();
    public partial class uscEmployee : UserControl
    {

        EmployeeImpl employeeImpl;
        SpareImpl spareImpl;

        Spare spare;
        Employeee employee;
        List<Spare> spares;
        List<Employeee> employees;
        public static event Activar activar;
        public uscEmployee()
        {
            InitializeComponent();
        }

        private void btnAñadirCliente_Click(object sender, RoutedEventArgs e)
        {

        }
        public void LoadData()
        {

            employeeImpl = new EmployeeImpl();
            DataTable dataTable = employeeImpl.Select();

            CrearColumansFila(LlenarLista(dataTable).Count);







        }

        public List<Employeee> LlenarLista(DataTable dataTable)
        {
            employees = new List<Employeee>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                employees.Add(new Employeee(byte.Parse(dataTable.Rows[i][0].ToString()),
                                            dataTable.Rows[i][1].ToString(),
                                            dataTable.Rows[i][2].ToString(),
                                            dataTable.Rows[i][3].ToString(),
                                            short.Parse(dataTable.Rows[i][4].ToString()),
                                            byte.Parse(dataTable.Rows[i][5].ToString()),
                                            DateTime.Parse(dataTable.Rows[i][6].ToString()),
                                            DateTime.Parse(dataTable.Rows[i][7].ToString()),
                                            dataTable.Rows[i][8].ToString(),
                                            dataTable.Rows[i][9].ToString(),
                                            DateTime.Parse(dataTable.Rows[i][10].ToString()),
                                            dataTable.Rows[i][11].ToString(),
                                            int.Parse(dataTable.Rows[i][12].ToString()),
                                            dataTable.Rows[i][13].ToString(),
                                            dataTable.Rows[i][14].ToString(),
                                            dataTable.Rows[i][15].ToString(),
                                            float.Parse(dataTable.Rows[i][16].ToString()),
                                            float.Parse(dataTable.Rows[i][15].ToString()),
                                            dataTable.Rows[i][17].ToString()
                                            )); //ci
            }
            return employees;
        }

        /* <MenuItem Name="btnMasTardeHoy" Icon="{materialDesign:PackIcon Kind=ClockOut}"  Foreground="Black"  Header="Mas tarde hoy" Click="btnMasTardeHoy_Click"/>
                                                        <Separator/>
                                                        <MenuItem Name="btnMañanaAviso" Icon="{materialDesign:PackIcon Kind=ClockCheckOutline}" Foreground="Black" Header="Mañana 09:00"  Click="btnMañanaAviso_Click" />
                                                        <Separator/>
                                                        <MenuItem Name="btnProximaSemanaAviso" Icon="{materialDesign:PackIcon Kind=ClockArrow}" Header="Proxima semana 09:00"  Foreground="Black" Click="btnProximaSemanaAviso_Click"   />
                                                        <Separator/>
                                                        <MenuItem Name="btnEscogerFechaYHora" Icon="{materialDesign:PackIcon Kind=ClipboardClockOutline}" Header="Elegir una fecha y hora"  Foreground="Black" Click="btnEscogerFechaYHora_Click" />
                                                        
*/

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
        }
        public void CrearColumansFila(int rowI)
        {
            gridEmployees.Children.Clear();
            gridEmployees.RowDefinitions.Clear();
            gridEmployees.ColumnDefinitions.Clear();
            int columnJ = 1;
            int cantidaProducto = rowI;
            int count = 0;
            while (rowI > 0)
            {
                rowI = rowI - 1;
                count++;
            }

            ColumnDefinition[] columnDefinitions;
            RowDefinition[] rowDefinitions;
            rowDefinitions = new RowDefinition[count]; // filas
            columnDefinitions = new ColumnDefinition[columnJ];// columnas
            gridEmployees.Height = count * 100;

            //gridParts.ShowGridLines = true;
            Thickness thickness = new Thickness(80);

            for (int i = 0; i < count; i++)
            {
                rowDefinitions[i] = new RowDefinition();

                gridEmployees.RowDefinitions.Add(rowDefinitions[i]);
            }
            for (int i = 0; i < columnJ; i++)
            {
                columnDefinitions[i] = new ColumnDefinition();
                gridEmployees.ColumnDefinitions.Add(columnDefinitions[i]);
            }


            AñadirContenido(count, columnJ, cantidaProducto);
        }
        public void AñadirContenido(int cantfila, int cantColumnas, int cantidadComponentes)
        {

            MaterialDesignThemes.Wpf.Card[] card = AñadirPropiedadesComponentes(cantidadComponentes);
            int k = 0;
            for (int i = 0; i < cantfila; i++) // filas
            {
                for (int j = 0; j < cantColumnas; j++) // columnas    
                {
                    Grid.SetRow(card[k], i);
                    Grid.SetColumn(card[k], j);
                    gridEmployees.Children.Add(card[k]);
                    k++;
                }
            }


        }
        public MaterialDesignThemes.Wpf.Card[] AñadirPropiedadesComponentes(int cant)
        {
            Thickness thicknessM = new Thickness(10);
            List<Employeee> listaEmployee = employees;
            TextBlock[] textBlocks = new TextBlock[cant];
            ToolTip[] toolTips = AñadirToolTips(cant);
            Thickness thickness = new Thickness(5);
            Button[] buttons = new Button[cant];
            StackPanel[] stackPanels = new StackPanel[cant];
            MaterialDesignThemes.Wpf.Card[] card = new MaterialDesignThemes.Wpf.Card[cant];
            //ImageBrush myBrush = new ImageBrush();
            //Image image = new Image();
            //image.Source = new BitmapImage(new Uri("pack://application:,,,/PartsAdmin/rodamientos.png"));
            //myBrush.ImageSource = image.Source;

            for (int i = 0; i < cant; i++)
            {
                buttons[i] = new Button();
                buttons[i].Name = listaEmployee[i].NameUser;
                buttons[i].Content = listaEmployee[i].FirstName + " " + listaEmployee[i].LastName;
                buttons[i].FontSize = 20;
                buttons[i].Foreground = Brushes.Black;
                buttons[i].Background = null;
                buttons[i].BorderBrush = null;
                buttons[i].Click += new RoutedEventHandler(Button_Click);
                buttons[i].ToolTip = toolTips[i];
                card[i] = new MaterialDesignThemes.Wpf.Card();

                card[i].Margin = thickness;
                stackPanels[i] = new StackPanel();
                stackPanels[i].Orientation = Orientation.Horizontal;
                Image image = new Image();
                image.Source = new BitmapImage(new Uri("pack://application:,,,/PersonAdmin/image/iconoVacio.png"));
                image.Width = 70;
                image.Margin = new Thickness(10, 0, 10, 0);
                stackPanels[i].Children.Add(image);
                stackPanels[i].Children.Add(buttons[i]);

                //card[i].Background = myBrush;
                //card[i].Background.Opacity = 0.5;
                card[i].Content = stackPanels[i];
                card[i].VerticalContentAlignment = VerticalAlignment.Center;

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
            Employeee employeee = new Employeee();
            foreach (var item in employees)
            {
                if (((Button)sender).Name == item.NameUser)
                {
                    employeee = item;
                    PersonasAdmin.Employee.ViewEmployeeDetails viewEmployeeDetails = new Employee.ViewEmployeeDetails(employeee);
                    //PersonasAdmin. viewParts = new ViewParts(spareDate);
                    viewEmployeeDetails.recargarPagina += LoadData;
                    //viewParts.recargarPagina += LoadData;
                    viewEmployeeDetails.ShowDialog();
                    //viewParts.ShowDialog();
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

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnAñadirEmpleado_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeSimple addEmployee = new AddEmployeeSimple();
            addEmployee.Show();
        }
    }
}
