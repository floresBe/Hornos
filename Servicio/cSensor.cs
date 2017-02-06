using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicio
{
    public class cSensor
    {
        /// <summary>
        /// Inserta un sensor a la BD (regresa la llave primaria del sensor ingresado)  
        /// </summary>
        /// <param name="nomSensor">Nombre del sensor</param>
        /// <param name="tipoSensor">Llave principal de Tipo de sensor</param>
        /// <returns></returns>
        public int Insertar(string nomSensor, int tipoSensor)
        {
            using (var entidad = new MuestrasHornosEntities())
            {
                Sensore sensor = null;
                try
                {
                    sensor = new Sensore
                    {
                        Nombre = nomSensor,
                        PK_Tipo = tipoSensor
                    };
                    entidad.Sensores.Add(sensor);

                    entidad.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return sensor.PK_Sensor;
            }
        }
        /// <summary>
        /// Regresa una lista con todos los nombres de los sensores registrados en la BD
        /// </summary>
        /// <returns></returns>
        public List<string> ObtenerTodos()
        {
            var lista = new List<string>();
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Sensores
                                   orderby c.PK_Sensor
                                   select c;
                    foreach (var item in consulta.ToList())
                    {
                        lista.Add(item.Nombre);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al acceder a la base de datos: " + e);
            }
            return lista;
        }
        /// <summary>
        /// Regresa una lista con las llaves primarias de los sensores
        /// </summary>
        /// <returns></returns>
        public List<int> obtenerPKTodos()
        {
            List<int> lista = new List<int>();
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Sensores
                                   orderby c.PK_Sensor
                                   select c;
                    foreach (var item in consulta.ToList())
                    {
                        lista.Add(item.PK_Sensor);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al acceder a la base de datos: " + e);
            }
            return lista;
        }
        /// <summary>
        /// Cambia el estado del sensor que entra por parametro
        /// </summary>
        /// <param name="pk">Llave principal del sensor</param>
        /// <param name="estado">Estado nuevo</param>
        public void CambiarEstado(int pk, int estado)
        {
            var lista = new List<Sensore>();
            using (var entidad = new MuestrasHornosEntities())
            {
                try
                {
                    var consulta = from c in entidad.Sensores
                                   where c.PK_Sensor == pk
                                   select c;
                    lista = consulta.ToList();
                    foreach (var item in lista)
                    {
                        item.Estado = estado;
                    }

                    entidad.SaveChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al acceder a la base de datos: " + e);
                }
            }
        }
        /// <summary>
        /// Regresa el estado del sensor que entra por parametro
        /// </summary>
        /// <param name="pk">Llave principal del sensor</param>
        /// <returns></returns>
        public int ObtenerEstado(int pk)
        {
            int estado = -1;
            var lista = new List<Sensore>();
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Sensores
                                   where c.PK_Sensor == pk
                                   select c;
                    lista = consulta.ToList();
                    foreach (var item in lista)
                    {
                        estado = item.Estado;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al acceder a la base de datos: " + e);
            }
            return estado;
        }
        /// <summary>
        /// Regresa la llave primaria del sensor que entra por parametro
        /// </summary>
        /// <param name="nombre">nombre del sensor</param>
        /// <returns></returns>
        public int ObtenerPK(string nombre)
        {
            int estado = -1;
            var lista = new List<Sensore>();
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Sensores
                                   where c.Nombre == nombre
                                   select c;
                    lista = consulta.ToList();
                    foreach (var item in lista)
                    {
                        estado = item.PK_Sensor;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al acceder a la base de datos: " + e);
            }
            return estado;
        }
        /// <summary>
        /// Regresa una lista de los nombres de los sensores activos
        /// </summary>
        /// <returns></returns>
        public List<string> ObtenerActivos()
        {
            var lista = new List<Sensore>();
            List<string> lista2 = new List<string>();
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Sensores
                                   where c.Estado == 1
                                   select c;
                    lista = consulta.ToList();
                    foreach (var item in lista)
                    {
                        lista2.Add(item.Nombre);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al acceder a la base de datos: " + e);
            }
            return lista2;
        }
        /// <summary>
        /// Regresa una lista de las llaves primarias de los sensores activos
        /// </summary>
        /// <returns></returns>
        public List<int> ObtenerPKActivos()
        {
            var lista = new List<Sensore>();
            List<int> lista2 = new List<int>();
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.Sensores
                                   where c.Estado == 1
                                   select c;
                    lista = consulta.ToList();
                    foreach (var item in lista)
                    {
                        lista2.Add(item.PK_Sensor);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al acceder a la base de datos: " + e);
            }
            return lista2;
        }
        /// <summary>
        /// Regresa el tipo del sensor ingresado por parametro
        /// </summary>
        /// <param name="nombre">Nombre del sensor</param>
        /// <returns></returns>
        public int ObtenerTipo(string nombre)
        {
            int tipo = 0;
            var lista = new List<Sensore>();
            try
            {
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from sensor in entidad.Sensores
                                   where sensor.Nombre == nombre
                                   select sensor;
                    lista = consulta.ToList();
                    foreach (var item in lista)
                    {
                        tipo = item.PK_Tipo;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
            }
            return tipo;
        }
    }
}
