using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;

namespace Clases
{
    public class Muestra : XPObject
    {
        public Muestra() { }
        public Muestra(Session sesion) : base(sesion) { }

        private string _noCiclo;
        public string noCiclo
        {
            get { return _noCiclo; }
            set { SetPropertyValue("NumeroCiclo", ref _noCiclo, value); }       
        }

        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set { SetPropertyValue("Nombre", ref _nombre, value); }
        }

        private string _fecha;
        public string fecha
        {
            get { return _fecha; }
            set { SetPropertyValue("Fecha", ref _fecha, value); }
        }

        private string _hora;
        public string hora
        {
            get { return _hora; }
            set { SetPropertyValue("Hora", ref _hora, value); }
        }

        private string _temperatura;
        public string temperatura
        {
            get { return _temperatura; }
            set { SetPropertyValue("Temperatura", ref _temperatura, value); }
        }

        private string _presion;
        public string presion
        {
            get { return _presion; }
            set { SetPropertyValue("Presion", ref _presion, value); }
        }
    }
}
