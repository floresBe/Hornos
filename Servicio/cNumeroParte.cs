using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicio
{
    class cNumeroParte
    {
        public int Insertar(string numeroParte, string detalles, string fecha, string empleado)
        {
            NumeroParte noParte = null;
            try
            {
                using (var entidad = new HornosHaltingEntities())
                {
                    noParte = new NumeroParte
                    {
                        No_Parte = numeroParte,
                        Detalles = detalles,
                        UsuarioAlta = empleado,
                        FechaAlta = fecha
                    };
                    entidad.NumeroPartes.Add(noParte);
                    entidad.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
                return 0;
            }
            return 1;
        }

        public List<string> obtenerTodos()
        {
            List<NumeroParte> lista = null;
            List<string> numeroParte = new List<string>();
            try
            {
                lista = new List<NumeroParte>();
                using (var entidad = new HornosHaltingEntities())
                {
                    var consulta = from c in entidad.NumeroPartes
                                   select c;
                    lista = consulta.ToList();
                    foreach (var item in lista)
                    {
                        numeroParte.Add(item.No_Parte.ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
            }
            return numeroParte;
        }
    }
}
