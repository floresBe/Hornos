using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicio
{
    public class cPruebaPieza
    {
        public void Insertar(string fechaPrueba, string pieza, int pruebaRealizada, int aprobada, int defecto)
        {
            PruebaPieza prueba = null;
            string[] sfecha = DateTime.Now.ToString().Split();
            string fecha = sfecha[0];
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    prueba = new PruebaPieza
                    {
                        FechaCaptura = fecha,
                        FechaPrueba = fechaPrueba,
                        PK_Prueba = pruebaRealizada,
                        No_Serie = pieza,
                        Aprobada = aprobada,
                        Defecto = defecto
                    };
                    entidad.PruebaPiezas.Add(prueba);
                    entidad.SaveChanges();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error al acceder a la base de datos:" + e);
                return;
            }

            return;
        }
    }
}
