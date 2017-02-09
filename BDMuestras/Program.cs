using System;
using System.Windows.Forms;
using Servicio;

namespace BDMuestras
{
    public class Program
    {
        //VAriables
        public static string nombreCiclo;//Indica el numero/nombre del ciclo en ejecucion
        public static int sesion; // se utiliza para indicar el tipo de sesion a iniciar
        public static bool mismociclo;
        public static string horno;
        public static int noCiclo;
        public static bool ciclosVacios;
        public static int tiempoMuestreo;
        public static int usuario;
        public static int ultimo;
        //Variables auxiliares para otras clases
        public static int NcicloAuxiliar;
        public static string PkCicloAuxiliar;
        public static string fechaAuxiliar;
        public static int actualizarCiclo; //Se utiliza para indicar que tipo de actualizacion se le hace al ciclo

        public static cCiclo ciclo;
        public static IniciarSesion VentanaInicio;
        public static MonitoreoContinuo VentanaMonitoreo;
        public static ConfigurarMonitoreo VentanaConfiguracion;
        public static InformesIncompletos VentanaInformesIncompletos;
        public static CapturadeDatos VentanaCapturarDatos;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            sesion = 0;
            noCiclo = 0;
            horno = "A0";
            tiempoMuestreo = 1;
            ObtenerPrimerCiclo();
            VentanaInicio = new IniciarSesion();
            Application.Run(VentanaInicio);
        }

        private static void ObtenerPrimerCiclo()
        {
            
            ciclo = new cCiclo();
            string[] fecha = null;
            string f = string.Empty;
            ultimo = ciclo.ObtenerUltimo(horno);
            if (ultimo != 0)
            {                
                fecha = DateTime.Now.ToString().Split();
                f = fecha[0];
                if (ciclo.obtenerFechaDeUltimoCiclo(horno, ultimo) == f)
                {
                    mismociclo = true;                   
                    noCiclo = ultimo;
                    GenerarNombre();                    
                }
                else
                {
                    noCiclo = ultimo++;
                    GenerarNombre();
                }
            }
            else
            {
                noCiclo = 1;
                GenerarNombre();
            }
            ciclo = null;
        }
        public static void ObtenerNuevoCiclo()
        {
            ciclo = new cCiclo();
            try
            {
                ultimo = ciclo.ObtenerUltimo(horno);
                noCiclo = 1 + ultimo;
                GenerarNombre();
            }
            catch (Exception ex)
            {
                MessageBox.Show("obtenerNuevo");
            }
            ciclo = null;
        }
        public static void GenerarNombre()
        {
            horno = "A0";
            if (noCiclo < 10)
            {
                horno = horno + "00";
            }
            if (noCiclo >= 10 && noCiclo < 100)
            {
                horno = horno + "0";
            }
            nombreCiclo = horno + noCiclo;
        }
      

    }
}