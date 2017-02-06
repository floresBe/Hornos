using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servidor
{
    public class cParteCiclo
    {
        /// <summary>
        /// Regresa una lista con los ciclos con valores nulos
        /// </summary>
        /// <returns></returns>
        public List<ParteCiclo> ObtenerCiclosVacios()
        {
            List<ParteCiclo> lista = null;
            try
            {
                lista = new List<ParteCiclo>();
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.ParteCicloes
                                   where c.Piezas_Entrantes.Equals(null)
                                   where c.Piezas_Malas.Equals(null)
                                   where c.Piezas_Rebraze.Equals(null)
                                   orderby c.No_Ciclo
                                   select c;
                    lista = consulta.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al consultar la base de datos.");
            }
            return lista;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreCiclo"></param>
        /// <returns></returns>
        public string ObtenerTodoslosDatos(string nombreCiclo)
        {
            string info = null;
            List<ParteCiclo> lista = null;
            string horno = nombreCiclo.Remove(3);
            int noCiclo = Convert.ToInt32(nombreCiclo.Remove(1, 2));
            try
            {
                lista = new List<ParteCiclo>();
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.ParteCicloes
                                   where c.Horno == horno
                                   where c.No_Ciclo == noCiclo
                                   orderby c.No_Ciclo
                                   select c;
                    lista = consulta.ToList();

                }
                foreach (var item in lista)
                {
                    info = item.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
                return null;
            }
            return info;
        }
        /// <summary>
        /// Actualiza un ciclo
        /// </summary>
        /// <param name="pk">Llave principal de ciclo</param>
        /// <param name="maquina">Maquina en la que el ciclo se llevo a cabo</param>
        /// <param name="parte">Número de parte que se corrio en el ciclo</param>
        /// <param name="entrantes">Cantidad de piezas entrantes al horno</param>
        /// <param name="malas">Cantidad de piezas malas que salieron del horno</param>
        /// <param name="rebraze">Cantidad de piezas a rebraze</param>
        public void ActualizarCiclo(string horno, int noCiclo, string parte, int entrantes, int malas, int rebraze)
        {
            List<ParteCiclo> lista = null;
            try
            {
                lista = new List<ParteCiclo>();
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.ParteCicloes
                                   where c.Horno == horno
                                   where c.No_Ciclo == noCiclo
                                   select c;
                    lista = consulta.ToList();
                    foreach (var item in lista)
                    {
                        item.No_Serie = parte;
                        item.Piezas_Entrantes = entrantes;
                        item.Piezas_Malas = malas;
                        item.Piezas_Rebraze = rebraze;
                    }
                    entidad.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
            }
        }
        /// <summary>
        /// Regresa una lista con las fechas en las que existen ciclos vacíos
        /// </summary>
        /// <returns></returns>
        public List<string> ObtenerFechas()
        {
            List<ParteCiclo> detalleCiclos = null;
            List<string> listaConsulta = null;
            List<string> fechas = null;
            cCiclo cilco = new cCiclo();

            try
            {
                detalleCiclos = new List<ParteCiclo>();
                detalleCiclos = ObtenerCiclosVacios();
                listaConsulta = new List<string>();

                foreach (var item in detalleCiclos)
                {
                    listaConsulta.Add(item.Horno.ToString() + item.No_Ciclo.ToString());
                }

                foreach (var item in listaConsulta)
                {
                    fechas.Add(cilco.obtenerFechaDeCiclo(item));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
                return null;
            }
            return fechas;
        }
        /// <summary>
        /// Regresa una lista con los ciclos vacios de la fecha ingresada por parametro
        /// </summary>
        /// <param name="fecha">Fecha de busqueda</param>
        /// <returns></returns>
        public List<string> ObtenerCiclosVaciosDeFecha(string fecha, string horno)
        {
            List<string> slistaciclos = null;
            var lista = new List<string>();
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Ciclos
                                   where c.Fecha.Contains(fecha)
                                   where c.Horno == horno
                                   orderby c.No_Ciclo
                                   select c;
                    var listaCiclos = consulta.ToList<Ciclo>();
                    if (listaCiclos == null || listaCiclos.Count == 0)
                    {
                        MessageBox.Show("No existen ciclos en la fecha seleccionada.");
                        return null;
                    }
                    else
                    {
                        slistaciclos = new List<string>();
                        foreach (var item in listaCiclos)
                        {
                            slistaciclos.Add((item.Horno + " " + item.No_Ciclo).ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
                return null;
            }
            return slistaciclos;
        }
        /// <summary>
        /// Indica si existen ciclos vacios en la base de datos
        /// </summary>
        /// <returns></returns>
        public bool ciclosVacios()
        {
            var lista = new List<ParteCiclo>();
            using (var entidad = new MuestrasHornosEntities())
            {
                var consulta = from c in entidad.ParteCicloes
                               where c.No_Serie.Equals(null)
                                     || c.Piezas_Entrantes.Equals(null)
                                     || c.Piezas_Malas.Equals(null)
                                     || c.Piezas_Rebraze.Equals(null)
                               select c;
                lista = consulta.ToList();
            }
            if (lista.Count < 1 || lista == null)
                return false;
            else
                return true;
        }
    }
}