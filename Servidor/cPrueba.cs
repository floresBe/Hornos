using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servidor
{
    public class cPrueba
    {
        public int Insertar(string nombre, string descripcion)
        {
            using (var entidad = new MuestrasHornosEntities())
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
                return prueba.PK_Prueba;
            }
        }
        public List<string> ObtenerTodos()
        {
            List<string> listaRetorno = null;
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Pruebas
                                   select c.PK_Prueba + " " + c.Nombre;
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
