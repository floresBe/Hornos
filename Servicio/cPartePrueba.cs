using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicio
{
    public class cPartePrueba
    {
        public void Insertar(string noParte, string prueba)
        {
            using (var entidad = new HornosHaltingEntities())
            {
                PartePrueba PartePrueba = null;
                try
                {
                    PartePrueba = new PartePrueba
                    {
                        No_Parte = noParte,
                        No_Prueba = prueba
                    };
                    entidad.PartePruebas.Add(PartePrueba);
                    entidad.SaveChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al accedeer a la base de datos: " + e);
                }
            }
        }

        public List<string> ObtenerPruebasPorParte(string noParte)
        {
            List<string> listaRetorno = null;
            try
            {
                using (var entidad = new HornosHaltingEntities())
                {
                    var consulta = from c in entidad.PartePruebas
                                   where c.No_Parte == noParte
                                   select c.No_Prueba;
                    listaRetorno = consulta.ToList();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al consultar la base de datos: " + e);
                return null;
            }
            return listaRetorno;
        }

    }
}
