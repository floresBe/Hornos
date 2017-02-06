using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicio
{
    public class cPieza
    {
        /// <summary>
        /// Inserta una nueva pieza en la base de datos
        /// </summary>
        /// <param name="noSerie">Numero serial de la pieza</param>
        /// <param name="defecto">Tipo de defecto</param>
        public string Insertar(string noSerie, int lote, int defecto, int aprobada, int rebraze)
        {
            Pieza pieza = null;

            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    pieza = new Pieza
                    {
                        No_Serie = noSerie,
                        Lote = lote,
                        PK_Defecto = defecto,
                        Aprobada = aprobada,
                        Rebraze = rebraze

                    };
                    entidad.Piezas.Add(pieza);
                    entidad.SaveChanges();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
            }

            return pieza.No_Serie;
        }
        /// <summary>
        /// Regresa una lista de piezas del lote ingresado por parametro
        /// </summary>
        /// <param name="lote">Llave principal del lote</param>
        /// <returns></returns>
        public List<string> obtenerPiezasDeLote(int lote)
        {
            var lista = new List<string>();
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Piezas
                                   join d in entidad.Lotes on c.Lote equals d.PK_Lote
                                   select c;
                    var listaPiezas = consulta.ToList<Pieza>();
                    foreach (var item in listaPiezas)
                    {
                        lista.Add(item.No_Serie.ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
            }
            return lista;
        }

        public string obtenerPKdeSerie(string serie)
        {
            string pieza = null;

            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Piezas
                                   where c.No_Serie == serie
                                   select c;
                    var listaPiezas = consulta.ToList<Pieza>();
                    foreach (var item in listaPiezas)
                    {
                        pieza = item.No_Serie;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al acceder a la base de datos: " + e);
            }
            return pieza;
        }
    }
}
