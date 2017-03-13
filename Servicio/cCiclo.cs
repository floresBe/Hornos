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
        public void insertar(string horno, int noCiclo, int pkUsuario, string fecha, string hora)
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
                        Hora = hora,
                        vacio = 1
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
        /// Indica que un ciclo ya contiene numero de parte ingresados
        /// </summary>
        /// <param name="horno"></param>
        /// <param name="noCiclo"></param>
        public void llenar(string horno, int noCiclo)
        {
            try
            {
                List<Ciclo> Ciclos = null;
                using (MuestrasHornosEntities entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Ciclos
                                   where c.Horno == horno
                                   where c.No_Ciclo == noCiclo
                                   select c;
                    Ciclos = consulta.ToList();
                    if (Ciclos.Count == 0)
                    {
                        foreach (Ciclo ccl in Ciclos)
                        {
                            ccl.vacio = 0;
                        }
                        entidad.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// regresa el ultimo ciclo ingresado a la base de datos segun el horno seleccionado
        /// </summary>
        /// <param name="horno"></param>
        /// <returns></returns>
        public int obtenerUltimo(string horno)
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
                    if (ciclos.Count > 0)
                    {
                        ultimo = ciclos.Last<int>();
                    }
                    else
                    {
                        return 0;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el ultimo ciclo.");
                MessageBox.Show(ex.ToString());

            }
            return ultimo;
        }
        /// <summary>
        /// Regresa un string con todos los datos del ciclo 
        /// </summary>
        /// <param name="nombreCiclo"></param>
        /// <returns></returns>
        public string obtenerDatos(string horno, int noCiclo)
        {
            string ciclo = null;
            List<Ciclo> lista = obtenerPorNombre(horno, noCiclo);
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
        /// Regresa la fecha del ciclo ingresado por parametro
        /// </summary>
        /// <param name="nombreCiclo"></param>
        /// <returns></returns>
        public string obtenerFechaDeCiclo(string horno, int ciclo)
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
        /// <summary>
        /// Regresa la hora en la que se creo el ciclo ingresado por parametro
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
        /// <summary>
        /// Indica si existen ciclos sin numero de parte agregadas
        /// </summary>
        /// <param name="horno"></param>
        /// <returns></returns>
        public bool ciclosVacios(string horno)
        {
            foreach (Ciclo ciclo in obtenerPorHorno(horno))
            {
                if (ciclo.vacio == 1 || ciclo.vacio == null)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Regresa una lista con los ciclos de la fecha ingresada por parametro
        /// </summary>
        /// <param name="fecha">Fecha de busqueda</param>
        /// <returns></returns>
        public List<string> obtenerPorHornoyFecha(string horno, string fecha)
        {
            var lista = new List<string>();
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Ciclos
                                   where c.Horno.Contains(horno)
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
        /// Regresa una lista con las fechas en las que existen ciclos
        /// </summary>
        /// <returns></returns>
        public List<string> obtenerTodaslasFechas()
        {
            List<Ciclo> listaCiclos = new List<Ciclo>();
            listaCiclos = obtenerTodos();
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
        /// Regresa una lista con todos los ciclos
        /// </summary>
        /// <returns></returns>
        public List<Ciclo> obtenerTodos()
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
        /// Regresa una lista con todos los ciclos del horno ingresadopor parametro
        /// </summary>
        /// <returns></returns>
        public List<Ciclo> obtenerPorHorno(string horno)
        {
            List<Ciclo> lista = null;
            try
            {
                lista = new List<Ciclo>();
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Ciclos
                                   where c.Horno.Contains(horno)
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
        public List<Ciclo> obtenerPorNombre(string horno, int noCiclo)
        {
            string Horno = horno;
            int ciclo = noCiclo;
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
    }
}
