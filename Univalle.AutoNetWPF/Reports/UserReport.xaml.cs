using CrystalDecisions.CrystalReports.Engine;
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

namespace Univalle.AutoNetWPF.Reports
{
    /// <summary>
    /// Lógica de interacción para UserReport.xaml
    /// </summary>
    public partial class UserReport : UserControl
    {

        Spare spareGlobal = new Spare();
        private string reportName;
        public UserReport()
        {
            InitializeComponent();
        }

        public ReportDocument InitCrystalReport(string nameRpt)
        {

            string path = $@"E:\Archivos Andy\UNIVERSIDAD\3ER-SEMESTRE\BASE DE DATOS II\proyecto\PBDD_AUTONET\PBDD_AUTONET\Univalle.AutoNet\Univalle.AutoNetWPF\Reports\{nameRpt}";
            string nameBase = "BDDAUTONET";
            string nameUserBD = "root";
            string passwordBD = "Univalle";
            string nameServerBD = @"ANDYHP\SQLEXPRESS";
            ReportDocument report = new ReportDocument();
            report.Load(path);
            report.SetDatabaseLogon(nameUserBD, passwordBD, nameServerBD, nameBase);
            return report;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


        }





        private void btnReportOne_Click(object sender, RoutedEventArgs e)
        {
            DialogoHostTime.IsOpen = true;
            DialogoHostTime.Visibility = Visibility.Visible;
            reportName = "CrystalReport_reportOne.rpt";
        }



        private void btnCancelarReporteOne_Click_1(object sender, RoutedEventArgs e)
        {
            DialogoHostTime.IsOpen = false;
        }

        private void btnReporteOne_Click(object sender, RoutedEventArgs e)
        {
            gridGif.Visibility = Visibility.Collapsed;
            DialogoHostTime.IsOpen = false;

            DateTime fechaInicio = fechaInicioDT.SelectedDate.Value;
            DateTime fechaFinal = fechaFinalDT.SelectedDate.Value;

            string nameRpt = reportName;
            ReportDocument report = InitCrystalReport(nameRpt);
            report.SetParameterValue("@inicio", Convert.ToString(fechaInicio));
            report.SetParameterValue("@final", Convert.ToString(fechaFinal));
            //report.Refresh();
            VisorDelReporte.ViewerCore.ReportSource = report;
        }

        private void btnAñadirProducto_Click(object sender, RoutedEventArgs e)
        {
            Spare dataRowView = (Spare)((Button)e.Source).DataContext;
            spareGlobal = dataRowView;
            txtProductSelect.Text = spareGlobal.NameProduct;
        }

        private void btnReporteThree_Click(object sender, RoutedEventArgs e)
        {
            //VisorDelReporte.ViewerCore.ReportSource = null;
            gridGif.Visibility = Visibility.Collapsed;
            DialogoHostTime.IsOpen = false;

            DateTime fechaInicio = fechaInicioDTThree.SelectedDate.Value;
            DateTime fechaFinal = fechaFinalDTThree.SelectedDate.Value;

            string nameRpt = "CrystalReport_repotThree.rpt";
            ReportDocument report = InitCrystalReport(nameRpt);
            report.SetParameterValue("@inicio", Convert.ToString(fechaInicio));
            report.SetParameterValue("@final", Convert.ToString(fechaFinal));
            report.SetParameterValue("@idSpare", Convert.ToString(spareGlobal.IdSpare));
            //report.Refresh();
            VisorDelReporte.ViewerCore.ReportSource = report;
        }

        private void btnCancelarReporteThree_Click(object sender, RoutedEventArgs e)
        {
            DialogoHostTime3.IsOpen = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReportTheree_Click(object sender, RoutedEventArgs e)
        {
            dataGridProgram.ItemsSource = GetSpare();
            DialogoHostTime3.IsOpen = true;
        }


        List<Spare> GetSpare()
        {
            List<Spare> spares = new List<Spare>();
            DataTable dtSpare = new DataTable();
            try
            {
                
                SpareImpl spareImpl = new SpareImpl();
                dtSpare = spareImpl.Select();
                spares = ConvertSpareDataTable(dtSpare);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return spares;
        }


        List<Spare> ConvertSpareDataTable(DataTable dtSpare)
        {
            List<Spare> listSpares = new List<Spare>();
            Spare spare = new Spare();
            for (int i = 0; i < dtSpare.Rows.Count; i++)
            {

                spare = new Spare(int.Parse(dtSpare.Rows[i]["idSpare"].ToString()), dtSpare.Rows[i]["nameProduct"].ToString());
                listSpares.Add(spare);
            }

            return listSpares;
        }

        private void btnReportTwo_Click(object sender, RoutedEventArgs e)
        {
            DialogoHostTime.IsOpen = true;
            DialogoHostTime.Visibility = Visibility.Visible;
            reportName = "CrystalReport_reportTwo.rpt";
        }
    }
}
