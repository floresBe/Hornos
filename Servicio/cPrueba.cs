using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicio
{
    public class cPrueba
    {
        public int Insertar(string nombre, string descripcion)
        {
            using (var entidad = new HornosHaltingEntities())
            {
                Prueba prueba = null;
                try
                {
                    prueba = new Prueba
                    {
                        Nombre = nombre,
                        Descripcion = descripcion
                    };
                    entidad.Pruebas.Add(prueba);
                    entidad.SaveChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al accedeer a la base de datos: " + e);
                }
                return prueba.No_Prueba;
            }
        }
        public List<string> ObtenerTodos()
        {
            List<string> listaRetorno = null;
            try
            {
                using (var entidad = new HornosHaltingEntities())
                {
                    var consulta = from c in entidad.Pruebas
                                   select c.Nombre;
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
