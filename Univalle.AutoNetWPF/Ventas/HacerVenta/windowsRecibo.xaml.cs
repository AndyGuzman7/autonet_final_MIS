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

            string path = $@"E:\Archivos Andy\UNIVERSIDAD\3ER-SEMESTRE\BASE DE DATOS II\proyecto\PBDD_AUTONET\PBDD_AUTONET\Univalle.AutoNet\Univalle.AutoNetWPF\Ventas\HacerVenta\{nameRpt}";
            string nameBase = "BDDAUTONET";
            string nameUserBD = "root";
            string passwordBD = "Univalle";
            string nameServerBD = @"ANDYHP\SQLEXPRESS";
            ReportDocument report = new ReportDocument();
            report.Load(path);
            report.SetDatabaseLogon(nameUserBD, passwordBD, nameServerBD, nameBase);
            return report;
        }

    }
}
