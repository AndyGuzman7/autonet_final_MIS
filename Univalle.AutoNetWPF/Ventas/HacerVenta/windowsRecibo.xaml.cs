using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        private Order order;
        private Client client;
        public windowsRecibo(int idOrder, Order order,Client client)
        {
            InitializeComponent();
            this.idOrder = idOrder;
            this.order = order;
            this.client = client;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string nameRpt = "CrystalReport_recibo.rpt";
            ReportDocument report = InitCrystalReport(nameRpt);

            report.SetParameterValue("@idOrder", Convert.ToString(idOrder));
            VisorDelReporte.ViewerCore.ReportSource = report;

            string fecha = DateTime.Now.ToString("yyyyMMddHHmmss");
            string nombre = order.IdClient.ToString() + order.IdEmploye.ToString() + idOrder.ToString();

            string nombreUnico = fecha + "_" + nombre;


            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string targetFolder = "Univalle.AutoNetWPF";
            string pathO = System.IO.Path.GetFullPath(System.IO.Path.Combine(projectPath, "..\\..\\..\\" + targetFolder));
            string path = $@"{pathO}\Reports\FilePdf\{nombreUnico}.pdf";
            string pdfFilePath = "ruta_del_archivo_pdf.pdf"; // Ruta donde se guardará el archivo PDF
            report.ExportToDisk(ExportFormatType.PortableDocFormat, path);




            using (MailMessage mail = new MailMessage())
            {

                string destino = client.Email;
                string remitente = "autonetsysytem@gmail.com";
                string contraseñaGmail = "hablcnvfohbdknaf";

                mail.From = new MailAddress(destino);
                mail.To.Add(client.Email);
                mail.Subject = "Recibo de Compra";

                // Adjuntar el archivo PDF
                Attachment attachment = new Attachment(path);
                mail.Attachments.Add(attachment);

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(remitente, contraseñaGmail);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

            // Eliminar el archivo PDF después de enviarlo por correo
            System.IO.File.Delete(pdfFilePath);
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
            //report.SaveAs("Comida111111111.pdf");
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
