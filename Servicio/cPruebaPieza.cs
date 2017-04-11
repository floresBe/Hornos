using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicio
{
    public class cPruebaPieza
    {
        public void Insertar(string horno, int noCiclo, string posicionHorno, string prueba, string resultado, string defecto, string sello1, string sello2, string observaciones)
        {
            PruebaPieza pruebaPieza = null;
            string[] sfecha = DateTime.Now.ToString().Split();
            string fecha = sfecha[0];
            try
            {
                using (var entidad = new HornosHaltingEntities())
                {
                    pruebaPieza = new PruebaPieza
                    {
                        Prueba = prueba,
                        Horno = horno,
                        No_Ciclo = noCiclo,
                        ResultadoPrueba = resultado,
                        Defecto = defecto,
                        Sello1 = sello1,
                        Sello2 = sello2,
                        ObservacionesPrueba = observaciones
                    };
                    entidad.PruebaPiezas.Add(pruebaPieza);
                    entidad.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al acceder a la base de datos:" + e);
            }
            return;
        }

        public void Firmar(string horno, int noCiclo, string posicionHorno, string prueba, string firma, string observaciones)
        {
            List<PruebaPieza> pruebaPiezas = new List<PruebaPieza>();
            try
            {
                using (var entidad = new HornosHaltingEntities())
                {
                    var consulta = from c in entidad.PruebaPiezas
                                   where c.Horno.Contains(horno)
                                   where c.No_Ciclo == noCiclo
                                   where c.PosicionHorno == posicionHorno
                                   where c.Prueba == prueba
                                   select c;
                    pruebaPiezas = consulta.ToList();
                    if (pruebaPiezas.Count > 0)
                    {
                        foreach (var item in pruebaPiezas)
                        {
                            item.FirmaInspector = firma;
                            item.ObservacionesInspector = observaciones;
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

        public void ObtenerPruebaPorNoSerie(string horno, int noCiclo, string posicionHorno)
        {
            List<PruebaPieza> pruebaPiezas = new List<PruebaPieza>();
            List<string> datosPruebas = new List<string>();
            try
            {
                using (var entidad = new HornosHaltingEntities())
                {
                    var consulta = from c in entidad.PruebaPiezas
                                   where c.Horno.Contains(horno)
                                   where c.No_Ciclo == noCiclo
                                   where c.PosicionHorno == posicionHorno
                                   select c;
                    pruebaPiezas = consulta.ToList();
                    if (pruebaPiezas.Count > 0)
                    {
                        foreach (var item in pruebaPiezas)
                        {
                            datosPruebas.Add(item.Prueba + " " + item.ResultadoPrueba + " " + item.ObservacionesPrueba + " " + item.Sello1 + " " + item.Sello2 + " " + item.FirmaInspector + " "  + item.ObservacionesInspector);
                        }
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
