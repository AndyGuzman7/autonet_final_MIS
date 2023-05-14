
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategys
{
    public  class LogWrite
    {
        private  string nameMethod;
        private  string NameClass;
        private  int UserId;
        

        public  string NameMethod
        {
            get { return nameMethod; }
            set { nameMethod = value; }
        }
        public LogWrite()
        {

        }
        public LogWrite(string nameClass, int idUser)
        {
            this.NameClass = nameClass;
            this.UserId = idUser;
        }




       


        public  void MensajeInicio()
        {
            
            System.Diagnostics.Debug.WriteLine($"Usuario: {UserId} - Iniciando el metodo: {NameMethod} de {NameClass} - Fecha: { DateTime.Now}");
        }
        public  void MensajeFinalizado()
        {
            System.Diagnostics.Debug.WriteLine($"Usuario: {UserId} - Ejecucion Correcta del metodo: {NameMethod} de {NameClass} - Fecha: { DateTime.Now}");
        }
        public  void MensajeError(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Usuario: {UserId} - ERROR en el metodo: {NameMethod} de {NameClass} - Fecha: { DateTime.Now} - Error = {ex.Message}");
        }

    }
}
