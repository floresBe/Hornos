using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicio
{
    public class cMuestra
    {
        /// <summary>
        /// Inserta una nueva muestra en la base de datos
        /// </summary>
        /// <param name="pkSensor">Llave principal del sensor</param>
        /// <param name="pkCiclo">Llave principal del ciclo</param>
        /// <param name="hora">Hora de la muestra</param>
        /// <param name="dato">Dato</param>
        public void Insertar(int sensor, string horno, int noCiclo, string hora, int dato)
        {
            using (var entidad = new HornosHaltingEntities())
            {
                try
                {
                    entidad.Muestras.Add(new Muestra
                    {
                        Sensor = sensor,
                        Horno = horno,
                        No_Ciclo = noCiclo,
                        Hora = hora,
                        Dato = dato,
                    });
                    entidad.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al acceder a la base de datos.");
                }
            }
        }
        /// <summary>
        /// Regresa una lista de muestras del ciclo ingresado por parametro
        /// </summary>
        /// <param name="ciclo">Llave principal del ciclo</param>
        /// <returns></returns>
        public List<string> obtenerMuestrasdeCiclo(string horno, int noCiclo)
        {
            var lista = new List<string>();
            try
            {
                using (var entidad = new HornosHaltingEntities())
                {
                    var consulta = from c in entidad.Muestras
                                   join d in entidad.Sensors on c.Sensor equals d.No_Sensor
                                   join e in entidad.TipoSensors on d.Tipo equals e.No_TipoSensor
                                   where c.Horno == horno
                                   where c.No_Ciclo == noCiclo
                                   orderby c.Sensor
                                   select new { d.Nombre, c.Hora, c.Dato, e.Descripcion };
                    var listaMuestras = consulta.ToList();
                    foreach (var item in listaMuestras)
                    {
                        lista.Add(item.Nombre + " " + item.Hora + " " + item.Dato + " " + item.Descripcion);
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
        /// Regresa una lista de muestras del ciclo y sensor ingresados por parametro
        /// </summary>
        /// <param name="ciclo">Llave principal del ciclo</param>
        /// <param name="sensor">Llave principal del sensor</param>
        /// <returns></returns>
        public List<string> obtenerMuestrasDeCicloSensor(string nombreCiclo, int sensor)
        {
            string horno = nombreCiclo.Remove(3);
            int noCiclo = Convert.ToInt32(nombreCiclo.Remove(1, 2));

            var lista = new List<string>();
            try
            {
                using (var entidad = new HornosHaltingEntities())
                {
                    var consulta = from c in entidad.Muestras
                                   where c.Horno == horno
                                   where c.No_Ciclo == noCiclo
                                   where c.Sensor == sensor
                                   orderby c.Hora
                                   select c;
                    var listaMuestras = consulta.ToList<Muestra>();
                    foreach (var item in listaMuestras)
                    {
                        lista.Add(item.Hora);
                    }
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