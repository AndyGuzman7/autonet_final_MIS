using CrystalDecisions.CrystalReports.Engine;
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

namespace Univalle.AutoNetWPF.Ventas.HacerVenta
{
    /// <summary>
    /// Lógica de interacción para windowsRecibo.xaml
    /// </summary>
    public partial class windowsRecibo : Window
    {
        private int idOrder;
        public windowsRecibo(int idOrder)
        {
            InitializeComponent();
            this.idOrder = idOrder;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string nameRpt = "CrystalReport_recibo.rpt";
            ReportDocument report = InitCrystalReport(nameRpt);

            report.SetParameterValue("@idOrder", Convert.ToString(idOrder));
            VisorDelReporte.ViewerCore.ReportSource = report;
        }

        public ReportDocument InitCrystalReport(string nameRpt)
        {

            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string targetFolder = "Univalle.AutoNetWPF";
            string pathO = System.IO.Path.GetFullPath(System.IO.Path.Combine(projectPath, "..\\..\\..\\" + targetFolder));


            string path = $@"{pathO}\Reports\{nameRpt}";
            string nameBase = "BDDAUTONET2023";
            string nameUserBD = "sa";
            string passwordBD = "Univalle";
            string nameServerBD = @"AndyHP\MSSQLSERVER_PRIV";
            ReportDocument report = new ReportDocument();
            report.Load(path);
            report.SetDatabaseLogon(nameUserBD, passwordBD, nameServerBD, nameBase);
            report.SaveAs("Comida111111111.pdf");
            return report;
        }

        //"E:\\Archivos Andy\\UNIVERSIDAD\\7MO-SEMESTRE\\MANAGMENT INFORMATION SYSTEMS\\ProyectoFinalMateria\\Univalle.AutoNet\\Univalle.AutoNetWPF\\Reports\\CrystalReport_recibo.rpt"
        /*
         string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string targetFolder = "Univalle.AutoNetWPF";
            string pathO = System.IO.Path.GetFullPath(System.IO.Path.Combine(projectPath, "..\\..\\..\\" + targetFolder));


            string path = $@"{pathO}\Reports\{nameRpt}";
            string nameBase = "BDDAUTONET2023";
            string nameUserBD = "sa";
            string passwordBD = "Univalle";
            string nameServerBD = @"AndyHP\MSSQLSERVER_PRIV";
            ReportDocument report = new ReportDocument();
            report.Load(path);
            report.SetDatabaseLogon(nameUserBD, passwordBD, nameServerBD, nameBase);
            return report;
         
         
         
         */
    }
}
