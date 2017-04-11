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
        public int Insertar(string horno, int noCiclo, string posicionHorno, string noParte, int rebraze, string empleado, string fecha)
        {
            Pieza pieza = null;
            try
            {
                using (var entidad = new HornosHaltingEntities())
                {
                    pieza = new Pieza
                    {
                        Horno = horno,
                        No_Ciclo = noCiclo,
                        PosicionHorno = posicionHorno,
                        No_Parte = noParte,
                        Rebraze = rebraze,
                        UsuarioAlta = empleado,
                        FechaAlta = fecha
                    };
                    entidad.Piezas.Add(pieza);
                    entidad.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
                return 0;
            }
            return 1;
        }

        public void Aprobar(string horno, int noCiclo, string posicionHorno, string anoMes, string posicionSerie)
        {
            List<Pieza> piezas = new List<Pieza>();
            try
            {
                using (var entidad = new HornosHaltingEntities())
                {
                    var consulta = from c in entidad.Piezas
                                   where c.Horno.Contains(horno)
                                   where c.No_Ciclo == noCiclo
                                   where c.PosicionHorno == posicionHorno
                                   select c;
                    piezas = consulta.ToList();
                    if(piezas.Count > 0)
                    {
                        foreach (var item in piezas)
                        {
                            item.anoMes = anoMes;
                            item.PosicionSerieFinal = posicionSerie;
                        }
                        entidad.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
            }
        }

    }
   
}
