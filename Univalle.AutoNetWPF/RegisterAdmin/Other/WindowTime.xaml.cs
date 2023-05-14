using System;
using System.Collections.Generic;
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

namespace Univalle.AutoNetWPF.Login
{
    /// <summary>
    /// Lógica de interacción para WindowTime.xaml
    /// </summary>
    public partial class WindowTime : Window
    {
        public WindowTime()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LlamarTiempo();

          
        }


        private async void LlamarTiempo()
        {
            Task task = new Task(Tiempo);
            task.Start();
            await task;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Tiempo()
        {
            int delay = 3000;
            Thread.Sleep(delay);
        }
    }
}
