using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicio
{
    public class cDefecto
    {
        public int Insertar(string nombre, string descripcion)
        {
            using (var entidad = new MuestrasHornosEntities())
            {
                Defecto defecto = null;
                try
                {
                    defecto = new Defecto
                    {
                        Nombre = nombre,
                        Descripcion = descripcion
                    };
                    entidad.Defectos.Add(defecto);
                    entidad.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al accedeer a la base de datos.");
                }
                return defecto.PK_Defecto;
            }
        }
        public List<string> ObtenerTodos()
        {
            List<string> listaRetorno = null;
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Defectos
                                   select c.PK_Defecto + " " + c.Nombre;
                    listaRetorno = consulta.ToList();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al consultar la base de datos.");
                return null;
            }
            return listaRetorno;
        }


    }
}
