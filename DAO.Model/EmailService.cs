using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public delegate void CambiarPantalla();
    public static class EmailService
    {
        public static event CambiarPantalla cambiarPantalla;
        private static string contraseñaGmail = "AUTOnet1172021";
        public static bool  EnviarCorreoContraña(string contraseña, string email)
        {
            bool llave = false;
            string destino = email;
            string remitente = "autonet.2021.serve@gmail.com";
            string asunto = "Nueva contraseña Auto net";
            string cuerpoMensaje = $"Su nueva contraseña es {contraseña}";
            MailMessage ms = new MailMessage(remitente, destino, asunto, cuerpoMensaje);

            SmtpClient smtp = new  SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(remitente, contraseñaGmail);
            try
            {
                Task.Run(() =>
                {
                    smtp.Send(ms);
                    ms.Dispose();
                    if(cambiarPantalla != null)
                    {
                        cambiarPantalla();
                    }
                    
                    llave = true;
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return llave;
        }
        public static bool EnviarCorreoContrañaNameUser(string contraseña, string nameUser, string email)
        {
            bool llave = false;
            string destino = email;
            string remitente = "autonet.2021.serve@gmail.com";
            string asunto = "Datos de registro";
            string cuerpoMensaje = $"Su Nombre Usuario es: {nameUser}\nSu Contraseña es: {contraseña}";
            MailMessage ms = new MailMessage(remitente, destino, asunto, cuerpoMensaje);

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(remitente, contraseñaGmail);
            try
            {
                Task.Run(() =>
                {
                        smtp.Send(ms);
                    ms.Dispose();
                    if (cambiarPantalla != null)
                    {
                        cambiarPantalla();
                    }

                    llave = true;
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return llave;
        }
    }
}
