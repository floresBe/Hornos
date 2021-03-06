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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ciclo"></param>
        /// <param name="horno"></param>
        /// <param name="noParte"></param>
        /// <returns></returns>
        public int insertar(int ciclo, string horno, string noParte, string aob)
        {
            try
            {
                cCiclo cicl = new cCiclo();
                ParteCiclo parteCiclo = null;
                using (var entidad = new HornosHaltingEntities())
                {
                    parteCiclo = new ParteCiclo
                    {
                        No_Ciclo = ciclo,
                        Horno = horno,
                        No_Parte = noParte,
                        CantidadPiezasEntrantes = 0,
                        CantidadPiezasRebraze = 0,
                        AoB = aob
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
        public void actualizar(string horno, int noCiclo, string parte, int entrantes, int rebraze, string aob)
        {
            List<ParteCiclo> lista = null;
            try
            {
                lista = new List<ParteCiclo>();
                using (var entidad = new HornosHaltingEntities())
                {
                    var consulta = from c in entidad.ParteCicloes
                                   where c.No_Parte == parte
                                   where c.Horno.Contains(horno)
                                   where c.No_Ciclo == noCiclo
                                   select c;
                    lista = consulta.ToList();
                    foreach (var item in lista)
                    {
                        item.CantidadPiezasEntrantes = entrantes;
                        item.CantidadPiezasRebraze = rebraze;
                        item.AoB = aob;
                    }
                    entidad.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
            }
        }
        /// <summary>
        /// Regresa todos los datos del ciclo ingresado por parametros
        /// </summary>
        /// <param name="nombreCiclo"></param>
        /// <returns></returns>
        public string obtenerDatos(string horno, int ciclo, string noParte)
        {
            string info = null;
            List<ParteCiclo> lista = null;
            try
            {
                lista = new List<ParteCiclo>();
                using (var entidad = new HornosHaltingEntities())
                {
                    var consulta = from c in entidad.ParteCicloes
                                   where c.Horno.Equals(horno)
                                   where c.No_Ciclo == ciclo
                                   where c.No_Parte == noParte
                                   orderby c.No_Ciclo
                                   select c;
                    lista = consulta.ToList();
                }
                foreach (var item in lista)
                {
                    info = item.CantidadPiezasEntrantes.ToString() +" "  + item.CantidadPiezasRebraze.ToString() + " " + item.AoB.ToString(); 
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
            }
            return info;
        }
        /// <summary>
        /// Regresa todos los datos del ciclo ingresado por parametros
        /// </summary>
        /// <param name="nombreCiclo"></param>
        /// <returns></returns>
        public List<string> obtenerNumerosPartePorCiclo(string horno, int ciclo)
        {
            List<string> info = new List<string>();
            List<ParteCiclo> lista = null;

            try
            {
                lista = new List<ParteCiclo>();
                using (var entidad = new HornosHaltingEntities())
                {
                    var consulta = from c in entidad.ParteCicloes
                                   where c.Horno.Contains(horno)
                                   where c.No_Ciclo == ciclo
                                   orderby c.No_Ciclo
                                   select c;
                    lista = consulta.ToList();
                }
                foreach (var item in lista)
                {
                    info.Add(item.No_Parte.ToString());
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
        /// Indica si existen ciclos vacios en la base de datos
        /// </summary>
        /// <returns></returns>
        public bool ciclosVacios(string horno)
        {
            List<ParteCiclo> cVacios = ObtenerCiclosVacios(horno);
            int ciclosVacios = cVacios.Count;
            if (ciclosVacios == 0)
                return false;
            else
                return true;
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
            //string nCiclo = string.Empty;
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
                using (var entidad = new HornosHaltingEntities())
                {
                    var consulta = from c in entidad.ParteCicloes
                                   where c.Horno.Contains(horno)
                                   where c.CantidadPiezasEntrantes == 0
                                   where c.AoB == null
                                   where c.CantidadPiezasRebraze == 0
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
        /// <param name="horno"></param>
        /// <param name="ciclo"></param>
        /// <returns></returns>
        public List<string> obtenerNumerosParteVaciosPorCiclo(string horno, int ciclo)
        {
            List<string> info = new List<string>();
            List<ParteCiclo> lista = null;

            try
            {
                lista = new List<ParteCiclo>();
                using (var entidad = new HornosHaltingEntities())
                {
                    var consulta = from c in entidad.ParteCicloes
                                   where c.Horno.Equals(horno)
                                   where c.No_Ciclo == ciclo
                                   where c.CantidadPiezasEntrantes == 0
                                   where c.CantidadPiezasRebraze == 0
                                   orderby c.No_Ciclo
                                   select c;
                    lista = consulta.ToList();

                }
                foreach (var item in lista)
                {
                    info.Add(item.No_Parte.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al acceder a la base de datos.");
                return null;
            }
            return info;
        }
    }
}