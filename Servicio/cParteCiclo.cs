﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicio
{
    public class cParteCiclo
    {

        public int InsertarNoParte(int ciclo, string horno, string noParte)
        {
            try
            {
                ParteCiclo parteCiclo = null;
                using (var entidad = new MuestrasHornosEntities())
                {
                    parteCiclo = new ParteCiclo
                    {
                        No_Ciclo = ciclo,
                        Horno = horno,
                        No_Parte = noParte,
                        Piezas_Entrantes = 0,
                        Piezas_Malas = 0,
                        Piezas_Rebraze = 0
                    };
                    entidad.ParteCicloes.Add(parteCiclo);
                    entidad.SaveChanges();
                }
                return parteCiclo.No_Ciclo;
            }
            catch (Exception ex)
            {
                return 0;
            }
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
                        item.No_Parte = parte;
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
        /// Regresa una lista con los ciclos vacios de la fecha ingresada por parametro
        /// </summary>
        /// <param name="fecha">Fecha de busqueda</param>
        /// <returns></returns>
        public List<string> ObtenerCiclosVaciosDeFecha(string fecha, string horno)
        {
            cCiclo Ciclo = new cCiclo();
            List<string> CiclosVacios = new List<string>();
            List<ParteCiclo> ciclosVacios = ObtenerCiclosVacios(horno);
            string nCiclo = string.Empty;
            foreach (ParteCiclo cv in ciclosVacios)
            {
                if (fecha == Ciclo.obtenerFechaDeCiclo(cv.Horno, cv.No_Ciclo))
                {
                    CiclosVacios.Add(cv.Horno + " " + cv.No_Ciclo);
                }

            }
            return CiclosVacios;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreCiclo"></param>
        /// <returns></returns>
        public string ObtenerTodoslosDatos(string horno, int ciclo)
        {
            string info = null;
            List<ParteCiclo> lista = null;

            try
            {
                lista = new List<ParteCiclo>();
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.ParteCicloes
                                   where c.Horno.Equals(horno)
                                   where c.No_Ciclo == ciclo
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
        /// Regresa una lista con las fechas en las que existen ciclos vacíos
        /// </summary>
        /// <returns></returns>
        public List<string> ObtenerFechas(string horno)
        {
            List<ParteCiclo> detalleCiclos = null;
            List<string> listaConsulta = null;
            List<string> fechas = null;
            cCiclo cilco = new cCiclo();

            try
            {
                detalleCiclos = new List<ParteCiclo>();
                detalleCiclos = ObtenerCiclosVacios(horno);
                listaConsulta = new List<string>();

                foreach (var item in detalleCiclos)
                {
                    listaConsulta.Add(item.Horno.ToString() + item.No_Ciclo.ToString());
                }

                foreach (var item in listaConsulta)
                {
                    // fechas.Add(cilco.obtenerFechaDeCiclo(item));
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
        /// Regresa una lista con los ciclos con valores nulos
        /// </summary>
        /// <returns></returns>
        public List<ParteCiclo> ObtenerCiclosVacios(string horno)
        {
            List<ParteCiclo> lista = null;
            try
            {
                lista = new List<ParteCiclo>();
                using (var entidad = new MuestrasHornosEntities())
                {
                    var consulta = from c in entidad.ParteCicloes
                                   where c.Horno.Contains(horno)
                                   where c.Piezas_Entrantes == 0
                                   where c.Piezas_Malas == 0
                                   where c.Piezas_Rebraze == 0
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
        /// Indica si existen ciclos vacios en la base de datos
        /// </summary>
        /// <returns></returns>
        public bool ciclosVacios()
        {
            var lista = new List<ParteCiclo>();
            using (var entidad = new MuestrasHornosEntities())
            {
                var consulta = from c in entidad.ParteCicloes
                               where c.No_Parte.Equals(null)
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