using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;

namespace Clases
{
    public class Ciclo : XPObject
    {
        public Ciclo() { }
        public Ciclo(Session sesion) : base(sesion) { }

        private string _noCiclo;
        public string noCiclo
        {
            get { return _noCiclo; } 
            set { SetPropertyValue("NumeroCiclo", ref _noCiclo, value); }
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

        private string _noParte;
        public string noParte
        {
            get { return _noParte; }
            set { SetPropertyValue("NumeroParte", ref _noParte, value); }
        }

        private int _piezasEntrantes;
        public int piezasEntrantes
        {
            get { return _piezasEntrantes; }
            set { SetPropertyValue("PiezasEntrantes", ref _piezasEntrantes, value); }
        }

        private int _piezasMalas;
        public int piezasMalas
        {
            get { return _piezasMalas; }
            set { SetPropertyValue("PiezasMalas", ref _piezasMalas, value); }
        }

    }

}


