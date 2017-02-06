using System;
using System.Windows.Forms;
using Servicio;

namespace BDMuestras
{
    public class Program
    {
        public static string nombreCiclo;//Indica el numero de ciclo en ejecucion del dia
        public static int sesion; // se utiliza para indicar el tipo de sesion a iniciar
        public static int actualizarCiclo; // se utiliza para indicar que tipo de actualizacion se le hace al ciclo
        public static IniciarSesion VentanaInicio;
        public static MonitoreoContinuo VentanaMonitoreo;
        public static ConfigurarMonitoreo VentanaConfiguracion;
        public static InformesIncompletos VentanaInformesIncompletos;
        public static CapturadeDatos VentanaCapturarDatos;
        public static bool mismociclo = false;
        public static string horno;
        public static int noCiclo;
        public static bool ciclosVacios;
        public static int tiempoMuestreo;
        public static int usuario;
        public static int NcicloAuxiliar;
        public static string PkCicloAuxiliar;
        public static string fechaAuxiliar;

        public static cCiclo ciclo = new cCiclo();
        public static int ultimo;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            sesion = 0;
            tiempoMuestreo = 1;
            ObtenerPrimerCiclo();
            VentanaInicio = new IniciarSesion();

            Application.Run(VentanaInicio);
        }

        private static void ObtenerPrimerCiclo()
        {
            horno = "I0";
            ultimo = ciclo.ObtenerUltimo(horno);
            
            if (ultimo != 0)
            {
                if (ultimo < 10)
                {
                    horno = horno + "00";
                }
                else if (ultimo > 10 && ultimo < 100)
                {
                    horno = horno + "0";
                }
               string[] fecha = DateTime.Now.ToString().Split();
                if (ciclo.obtenerFechaDeUltimoCiclo(horno, ultimo) == fecha[0])
                {
                    mismociclo = true;
                    nombreCiclo = horno + ultimo;
                }
                else
                {
                    noCiclo = ultimo++;

                    if (noCiclo < 10)
                    {
                        horno = horno + "00";
                    }
                    else if (noCiclo > 10 && noCiclo < 100)
                    {
                        horno = horno + "0";
                    }
                    nombreCiclo = horno + noCiclo;
                }
            }
            else
            {
                noCiclo = 1;
                nombreCiclo = horno + "00" + noCiclo;
            }
        }
        public static void ObtenerNuevoCiclo()
        {
            horno = "I0";
            ultimo = ciclo.ObtenerUltimo(horno);
            noCiclo = ultimo + 1;
            if (noCiclo < 10)
            {
                horno = horno + "00";
            }
            if (noCiclo > 10 && noCiclo < 100)
            {
                horno = horno + "0";
            }
            nombreCiclo = horno + noCiclo;            
        }

    }
}