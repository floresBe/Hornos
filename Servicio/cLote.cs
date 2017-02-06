using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicio
{
    public class cLote
    {
        /// <summary>
        /// Inserta un nuevo lote a la base de datos
        /// </summary>
        /// <param name="pkCiclo">Llave principal del ciclo en que se creo el lote</param>
        /// <param name="pkUsuario">Llave principal del usuario que da de alta el lote</param>
        /// <param name="fecha">Fecha en que se crea el lote</param>
        /// <param name="hora">Hora en que se crea el lote</param>
        /// <returns>clave principal</returns>
        public int Insertar(string horno, int noCiclo, int pkUsuario, string fecha, string fechaAlta)
        {
            Lote lote = null;
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    lote = new Lote
                    {
                        Horno = horno,
                        No_Ciclo = noCiclo,
                        PK_Usuario = pkUsuario,
                        FechaAlta = fechaAlta
                    };
                    entidad.Lotes.Add(lote);
                    entidad.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al crear Lote.");
            }
            return lote.PK_Lote;
        }
        /// <summary>
        /// Regresa una lista con todos los Lotes
        /// </summary>
        /// <returns></returns>
        public List<Lote> ObtenerTodos()
        {
            List<Lote> lista = null;
            try
            {
                lista = new List<Lote>();
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Lotes
                                   select c;
                    lista = consulta.ToList();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al consultar la base de datos: " + e);
            }
            return lista;
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
        public void ActualizarLote(string horno, int noCiclo, int lote, int pkUsuario)
        {
            List<Lote> lista = null;
            try
            {
                lista = new List<Lote>();
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Lotes
                                   where c.PK_Lote == lote
                                   select c;
                    lista = consulta.ToList();
                    foreach (var item in lista)
                    {
                        item.Horno = horno;
                        item.No_Ciclo = noCiclo;
                        item.PK_Usuario = pkUsuario;
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
        /// Regresa una lista con las fechas en las que existen Lotes
        /// </summary>
        /// <returns></returns>
        public List<string> ObtenerFechas()
        {
            List<string> listaConsulta = null;
            try
            {
                List<Lote> listaLotes = new List<Lote>();
                listaLotes = ObtenerTodos();
                listaConsulta = new List<string>();
                foreach (var item in listaLotes)
                {
                    string[] VfechaAlta = item.FechaAlta.Split();
                    string fechaAlta = VfechaAlta[0];
                    if (!(listaConsulta.Contains(fechaAlta)))
                    {
                        listaConsulta.Add(fechaAlta);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
            }
            return listaConsulta;
        }
        /// <summary>
        /// Regresa una lista con los lotes de la fecha ingresada por parametro
        /// </summary>
        /// <param name="fecha">Fecha de busqueda</param>
        /// <returns></returns>
        public List<string> ObtenerDeFecha(string fecha)
        {
            var lista = new List<string>();
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Lotes
                                   where c.FechaAlta.Contains(fecha)
                                   orderby c.PK_Lote
                                   select c;
                    var listaCiclos = consulta.ToList<Lote>();
                    foreach (var item in listaCiclos)
                    {
                        lista.Add(item.PK_Lote.ToString());
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
        /// <param name="ciclo"></param>
        /// <returns></returns>
        public List<int> ObtenerPorCiclo(string horno, int noCiclo)
        {
            var lista = new List<int>();
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Lotes
                                   where c.No_Ciclo == noCiclo
                                   where c.Horno == horno
                                   orderby c.PK_Lote
                                   select c;
                    var listaLotes = consulta.ToList<Lote>();
                    foreach (var item in listaLotes)
                    {
                        lista.Add(item.PK_Lote);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
            }
            return lista;
        }
    }
}
