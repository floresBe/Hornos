using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicio
{
    public class cCiclo
    {
        /// <summary>
        /// Inserta un nuevo ciclo a la base de datos.
        /// </summary>
        /// <param name="noCiclo">Número de ciclo del día</param>
        /// <param name="fecha">Fecha en que se crea el ciclo</param>
        /// <param name="hora">Hora en que se crea el ciclo</param>
        public void Insertar(string horno, int noCiclo, int pkUsuario, string fecha, string hora)
        {
            Ciclo ciclo = null;
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    ciclo = new Ciclo
                    {
                        Horno = horno,
                        No_Ciclo = noCiclo,
                        PK_Usuario = pkUsuario,
                        Fecha = fecha,
                        Hora = hora
                    };
                    entidad.Ciclos.Add(ciclo);
                    entidad.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear ciclo.");
            }
        }
        /// <summary>
        /// Regresa una lista con todos los ciclos
        /// </summary>
        /// <returns></returns>
        public List<Ciclo> ObtenerTodos()
        {
            List<Ciclo> lista = null;
            try
            {
                lista = new List<Ciclo>();
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Ciclos
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
        /// //Regresa la informacion del ciclo ingresado por parametro
        /// </summary>
        /// <param name="nombreCiclo"></param>
        /// <returns></returns>
        public List<Ciclo> ObtenerPorNombre(string nombreCiclo)
        {
            string horno = nombreCiclo.Remove(3);
            int noCiclo = Convert.ToInt32(nombreCiclo.Remove(1, 2));
            List<Ciclo> lista = null;
            try
            {
                lista = new List<Ciclo>();
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Ciclos
                                   where c.Horno == horno
                                   where c.No_Ciclo == noCiclo
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
        /// Regresa un string con todos los datos del ciclo 
        /// </summary>
        /// <param name="nombreCiclo"></param>
        /// <returns></returns>
        public string ObtenerTodoslosDatos(string nombreCiclo)
        {
            string ciclo = null;
            List<Ciclo> lista = ObtenerPorNombre(nombreCiclo);
            try
            {
                foreach (var item in lista)
                {
                    ciclo = item.Horno + " " + item.No_Ciclo + " " + item.Fecha + " " + item.Hora + " " + item.Usuario;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
            }
            return ciclo;

        }
        /// <summary>
        /// Regresa una lista con los ciclos de la fecha ingresada por parametro
        /// </summary>
        /// <param name="fecha">Fecha de busqueda</param>
        /// <returns></returns>
        public List<string> obtenerPorFecha(string fecha)
        {
            var lista = new List<string>();
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Ciclos
                                   where c.Fecha.Contains(fecha)
                                   orderby c.No_Ciclo
                                   select c;

                    var listaCiclos = consulta.ToList<Ciclo>();
                    foreach (var item in listaCiclos)
                    {
                        lista.Add(item.Horno + " " + item.No_Ciclo);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
            }

            return lista;
        }
        /// <summary>
        /// regresa el ultimo ciclo ingresado a la base de datos segun el horno seleccionado
        /// </summary>
        /// <param name="horno"></param>
        /// <returns></returns>
        public int ObtenerUltimo(string horno)
        {

            int ultimo = 0;
            try
            {
                using (MuestrasHornosEntities entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Ciclos
                                   where c.Horno.Contains(horno)
                                   orderby c.No_Ciclo
                                   select c.No_Ciclo;
                    List<int> ciclos = consulta.ToList();
                    if (ciclos.Count > 0) {
                        ultimo = ciclos.Last<int>();
                    }else
                    {
                        return 0;
                    }
                                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el ultimo ciclo.");
                
            }
            return ultimo;
        }

        /// <summary>
        /// Regresa una lista con las fechas en las que existen ciclos
        /// </summary>
        /// <returns></returns>
        public List<string> ObtenerTodaslasFechas()
        {
            List<Ciclo> listaCiclos = new List<Ciclo>();
            listaCiclos = ObtenerTodos();
            List<string> lista = new List<string>();
            try
            {
                foreach (var item in listaCiclos)
                {
                    string fecha = item.Fecha;
                    if (!lista.Contains(fecha))
                    {
                        lista.Add(fecha);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
            }
            return lista;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreCiclo"></param>
        /// <returns></returns>
        public string obtenerFechaDeCiclo(string nombreCiclo)
        {
            string horno = nombreCiclo.Remove(3);
            int noCiclo = Convert.ToInt32(nombreCiclo.Remove(1, 2));
            string fecha = null;
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Ciclos
                                   where c.Horno == horno
                                   where c.No_Ciclo == noCiclo
                                   select c;
                    var listaMuestras = consulta.ToList<Ciclo>();
                    foreach (var item in listaMuestras)
                    {
                        fecha = item.Fecha;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al consultar la base de datos.");
                return null;
            }
            return fecha;


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreCiclo"></param>
        /// <returns></returns>
        public string obtenerHoraDeCiclo(string horno, int ciclo)
        {
            string hora = null;
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Ciclos
                                   where c.Horno == horno
                                   where c.No_Ciclo == ciclo
                                   select c;
                    var listaMuestras = consulta.ToList<Ciclo>();
                    foreach (var item in listaMuestras)
                    {
                        hora = item.Hora;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al consultar la base de datos.");
                return null;
            }
            return hora;


        }
        public string obtenerFechaDeUltimoCiclo(string horno, int ciclo)
        {
            string fecha = null;
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Ciclos
                                   where c.Horno == horno
                                   where c.No_Ciclo == ciclo
                                   select c;
                    var listaMuestras = consulta.ToList<Ciclo>();
                    foreach (var item in listaMuestras)
                    {
                        fecha = item.Fecha;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al consultar la base de datos.");
                return null;
            }
            return fecha;


        }
    }
}
