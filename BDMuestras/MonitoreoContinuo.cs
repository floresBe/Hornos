using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using Servicio;

namespace BDMuestras
{
    public partial class MonitoreoContinuo : Form
    {
        static string[] fechaCompleta; //Guarda la fecha y hora en partes
        static string fecha; //Guarda solo fecha
        static string sHora; //Guarda la hora en formato: 00:00:00
        static double hora; //Guarda la hora procesada para utilizar en grafica
        static bool encendido; //Indica si el horno esta encendido o no  
        static string nombreCiclo;//Guarda el nombre del ciclo que esta corriendo 
        static bool datosHornoRecibidos; //Indica que se han recibido los datos por puerto serial del horno
        static bool datosAmbienteRecibidos; //indica que se han recibido los datos por puerto serial del ambiente
        static bool datosHornoDesocupados;//Indica que los datos han sido desocupados
        static bool datosAmbienteDesocupados; //Indica que los datos han sido desocupados
        static string[] valoresHorno; //Guarda los valores recibidos por puerto serial del horno
        static string[] valoresAmbiente; //Guarda los valores recibidos por puerto serial del ambiente
        static string datosHorno; //Se utiliza para almacenar datos provinientes del puerto serial del horno
        static string datosAmbiente; //Se utiliza para almacenar datos provinientes del puerto serial del ambiente
        static int promedio; //Informacion incluida en los datos que vienen del horno
        //static int punto;//Maneja la cantidad de puntos de cada serie de la grafica
        bool puertoHornoAbierto;//Indica si el puerto serial del horno esta abierto
        bool puertoAmbienteAbierto; //Indica si el puerto serial del ambiente esta abierto
        static string temp;//Guarda la temperatura del ambiente
        static string hum;//Guarda la humedad del ambiente

        static cCiclo ciclo;
        static cSensor sensor;
        static cMuestra muestra;
        static cParteCiclo parteCiclo;

        //Constructor
        public MonitoreoContinuo()
        {
            InitializeComponent();
            fechaCompleta = null;
            fecha = string.Empty;
            sHora = string.Empty;
            encendido = false;
            nombreCiclo = Program.nombreCiclo;
            datosHornoRecibidos = false;
            datosAmbienteRecibidos = false;
            datosAmbienteDesocupados = false;
            datosHornoDesocupados = false;
            valoresHorno = null;
            valoresAmbiente = null;
            datosHorno = string.Empty;
            datosAmbiente = string.Empty;
            puertoHornoAbierto = false;
            puertoAmbienteAbierto = false;
            temp = string.Empty;
            hum = string.Empty;
        }

        //Eventos
        /// <summary>
        /// Evento de cargar la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonitoreoContinuo_Load(object sender, EventArgs e)
        {
            labelCiclo.Text = "Ciclo: " + nombreCiclo;
            TemporizadorHora.Start();
            CargarGrafica();
            abrirPuertos();
            switch (Program.tiempoMuestreo)
            {
                case 1:
                    timerMuestreo.Interval = 2000;
                    break;
                case 3:
                    timerMuestreo.Interval = 180000;
                    break;
                case 5:
                    timerMuestreo.Interval = 300000;
                    break;
                default:
                    timerMuestreo.Interval = 2000;
                    break;
            }
            timerMuestreo.Start();
            timerDatosRecibidos.Start();
        }
        /// <summary>
        /// Evento de recibir datos desde puerto serial del horno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = null;
                try
                {
                    sp = (SerialPort)sender;
                }
                catch (Exception)
                {
                    MessageBox.Show("Al crear el puerto.");
                }
                try
                {
                    // datosHorno += sp.ReadExisting();
                    datosHorno += sp.ReadLine();
                }
                catch (Exception) { MessageBox.Show("Al Leer linea"); }
                try
                {
                    valoresHorno = null;
                    valoresHorno = datosHorno.Split(',');
                }
                catch (Exception)
                {
                    MessageBox.Show("Al dividir cadena");
                    return;
                }
                if (valoresHorno.Length == 32 && datosHornoRecibidos == false)
                {
                    datosHornoRecibidos = true;
                }//Cierra if comprobacion de todos los datos recibidos
                else if (valoresHorno.Length > 33 || datosHornoDesocupados)
                {
                    valoresHorno = null;
                    datosHorno = string.Empty;
                    datosHornoRecibidos = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recibir datos.");
            }
            //  Console.WriteLine(datos);
            //Console.WriteLine(datos.Length); 
        }
        /// <summary>
        /// Evento de recibir datos desde puerto serial del ambiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DataReceivedHandler2(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                //datos += sp.ReadExisting();
                datosAmbiente += sp.ReadLine();
                //Console.WriteLine(datosAmbiente);
                valoresAmbiente = datosAmbiente.Split(',');
                if (valoresAmbiente.Length == 3 && datosAmbienteRecibidos == false)
                {
                    datosAmbienteRecibidos = true;
                }//Cierra if comprobacion de todos los datos recibidos
                else if (datosAmbienteDesocupados || valoresAmbiente.Length > 3)
                {
                    valoresAmbiente = null;
                    datosAmbiente = string.Empty;
                    datosAmbienteDesocupados = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al recibir datos ambiente.");
            }
        }
        /// <summary>
        /// Evento de dar clic al boton de reportes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImprimirInforme_Click(object sender, EventArgs e)
        {
            Imprimir ventanaImprimirReportes = new Imprimir();
            ventanaImprimirReportes.Show();
        }
        /// <summary>
        /// Evento de clic en boton configurar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Program.sesion = 1;            
            this.Close();
        }
        /// <summary>
        /// Evento de dar clic al icono de atención
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IconoAtencion_Click_1(object sender, EventArgs e)
        {
            Atencion alerta = new Atencion();
            alerta.Show();
        }
        /// <summary>
        /// Evento de hora avanzando 
        /// </summary>
        private void TemporizadorHora_Tick(object sender, EventArgs e)
        {
            try
            {
                labelFechaHora.Text = DateTime.Now.ToString();
                labelCiclo.Text = "Ciclo: " + Program.nombreCiclo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al tomar fecha.");
            }
            

            
            if (puertoAmbienteAbierto)
            {
                serialPortAmbiente.Write("1");
            }
        }
        /// <summary>
        /// Evento de pedir muestreo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerMuestreo_Tick(object sender, EventArgs e)
        {
            if (puertoHornoAbierto)
                serialPortMuestras.Write("1");
        }
        private void MonitoreoContinuo_FormClosing(object sender, FormClosingEventArgs e)
        {
            cerrarPuertos();
            Program.VentanaInicio.Show();
        }
        private void MonitoreoContinuo_FormClosed(object sender, FormClosedEventArgs e)
        {
            cerrarPuertos();
            Program.VentanaInicio.Show();
        }

        //Metodos
        /// <summary>
        /// Carga la configuracion, consulta en la base de datos cuales sensores 
        /// se utilizaran y los agrega la grafica.
        /// </summary> 
        private void CargarGrafica()
        {
            sensor = new cSensor();
            List<string> sensores = sensor.ObtenerActivos();
            int noSensores = 0;
            chartMuestras.ChartAreas[0].AxisY.Title = "Temperatura (Fº)";
            chartMuestras.ChartAreas[0].AxisY2.Title = "Vacío (MiliTorrs)";
            chartMuestras.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chartMuestras.ChartAreas[0].AxisX.Title = "Hora";
            chartMuestras.Series.Clear();
            foreach (string snsr in sensores)
            {
                if (snsr != "TempAmbiente" && snsr != "HumAmbiente")
                {
                    chartMuestras.Series.Add(snsr);
                    if (snsr == "Chamber Pirani" || snsr == "Cold Cathode")
                    {
                        chartMuestras.Series[noSensores].YAxisType = AxisType.Secondary;
                    }
                    else
                    {
                        chartMuestras.Series[noSensores].YAxisType = AxisType.Primary;
                    }
                    noSensores++;
                }
            }
            sensor = null;
            // punto = 0;
        }     
        /// <summary>
        /// Procedimiento a seguir despues de recibir los datos por puerto serial del horno
        /// </summary>
        public static void DatosHornoRecibidos()
        {
            ciclo = new cCiclo();
            parteCiclo = new cParteCiclo();
            string status = null;
            Program.ciclosVacios = parteCiclo.ciclosVacios();
            try
            {
                status = valoresHorno[30].ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al tomar status.");
                return;
            }
            if (valoresHorno.Length == 32 && status == "1")//Indica que el horno esta encendido 
            {
                if (encendido == false)//indica que el horno acaba de iniciar un nuevo ciclo
                {
                    try
                    {

                        encendido = true;
                        fechaCompleta = DateTime.Now.ToString().Split();
                        fecha = fechaCompleta[0];                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
                        sHora = string.Format("{0:HH:mm:ss}", DateTime.Now); 
                        if (Program.mismociclo)
                        {
                            nombreCiclo = Program.nombreCiclo;
                            Program.mismociclo = false;
                        }
                        else
                        {
                            Program.ObtenerNuevoCiclo();
                            ciclo.Insertar(Program.horno, Program.noCiclo, Program.usuario, fecha, sHora);
                            nombreCiclo = Program.nombreCiclo;

                            //Recargar grafica
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al correr Ciclo.");
                    }
                }

            }
            else if (valoresHorno != null && valoresHorno.Length == 32 && status == "0")
            {
                try
                {
                    if (encendido)
                    {
                        encendido = false;
                        Program.mismociclo = false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al detener Ciclo.");
                }
            }
            if (valoresHorno != null && valoresHorno.Length == 32)
            {
                GraficarMuestras();
                datosHornoRecibidos = false;
            }
            ciclo = null;
            parteCiclo = null;
            datosHornoDesocupados = true;
        }
        /// <summary>
        /// Procedimiento a seguir despues de recibir los datos por puerto serial del ambiente
        /// </summary>
        public static void DatosAmbienteRecibidos()
        {
            try
            {
                sHora = string.Format("{0:HH:mm:ss}", DateTime.Now);
                string cadenaAmbiente = "Temperatura: " + valoresAmbiente[0] + " Humedad: " + valoresAmbiente[1] + "   Hora: " + sHora;
                listBoxAmbiente.Items.Add(cadenaAmbiente);
                listBoxAmbiente.SelectedItem = cadenaAmbiente;
                temp = valoresAmbiente[0];
                hum = valoresAmbiente[1];

                muestra.Insertar(31, Program.horno, Program.noCiclo, sHora, temp);
                muestra.Insertar(32, Program.horno, Program.noCiclo, sHora, hum);
                datosAmbienteRecibidos = false;
                datosAmbienteDesocupados = true;
            }
            catch (Exception ex)
            {
                ///Desincronizacion momentanea
            }
        }
        /// <summary>
        /// Transforma la hora para utilizarla en la grafica
        /// </summary>
        private static void transformarHora()
        {
            try
            {
                sHora = string.Format("{0:HH:mm:ss}", DateTime.Now);
                String[] parte = sHora.Split(':');
                //Se hacen las operacionespara transformar la hora (1 dia = 1; 1 hora = 0.041666)
                hora = (Int32.Parse(parte[0])) * (0.041666) + (Int32.Parse(parte[1]))
                        * (0.04166667 / 60) + (Int32.Parse(parte[2])) * ((0.04166667 / 60) / 60);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al transformar hora.");
            }
        }
        /// <summary>
        /// Grafica las muestras recibidas por el puerto serial
        /// </summary>
        private static void GraficarMuestras()
        {
            
            sensor = new cSensor();
            muestra = new cMuestra(); 
            string nombreSerie = string.Empty;
            string cadena = string.Empty;
            int tipo;
            int claveSensor;
            string valor;
            try
            {
                foreach (var serie in Program.VentanaMonitoreo.chartMuestras.Series)
                {
                    nombreSerie = serie.Name;
                    tipo = sensor.ObtenerTipo(nombreSerie);
                    claveSensor = sensor.ObtenerPK(nombreSerie) - 1;
                    valor = valoresHorno[claveSensor]; 
                    if (tipo == 1 && valoresHorno.Length == 32)
                    {
                        cadena = nombreSerie + "      " + sHora + "              " + valor;
                        Program.VentanaMonitoreo.listBoxMuestrasTemp.Items.Add(cadena);
                        Program.VentanaMonitoreo.listBoxMuestrasTemp.SelectedItem = cadena;
                    }
                    else if (tipo == 2 && valoresHorno.Length == 32)
                    {
                        cadena = nombreSerie + "      " + sHora + "     " + valor;
                        Program.VentanaMonitoreo.listBoxMuestrasPress.Items.Add(cadena);
                        Program.VentanaMonitoreo.listBoxMuestrasPress.SelectedItem = cadena;
                    }
                    transformarHora();
                    serie.ChartType = SeriesChartType.Line;
                    serie.XValueType = ChartValueType.Time;
                    serie.Points.AddY(valoresHorno[claveSensor]);
                    serie.Points[serie.Points.Count - 1].XValue = hora;
                    if (encendido)
                    {                        
                        muestra.Insertar(claveSensor + 1, Program.horno, Program.noCiclo, sHora, valor);
                    }
                }
                if (encendido)
                {
                    promedio = Convert.ToInt32(valoresHorno[31]);
                    muestra.Insertar(32, Program.horno, Program.noCiclo, sHora, promedio.ToString());
                }                 
                    labelPromedio.Text = promedio.ToString();      
                
            }
            catch (Exception)
            {
                 MessageBox.Show("Error al Graficar Muestras.");
            }
            sensor = null;
            muestra = null;
        }
        /// <summary>
        /// Abre el puerto serial
        /// </summary> 
        private void abrirPuertos()
        {
            serialPortMuestras.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            try
            {
                serialPortMuestras.Open();
                //Thread.Sleep(2000);
                try
                {
                    serialPortMuestras.Write("1");
                    puertoHornoAbierto = true;
                }
                catch (Exception ex) { MessageBox.Show("Error al enviar primer 1 al horno."); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique que el puerto de comunicación con el horno este correctamente conectado. (COM 3)");
                puertoHornoAbierto = false;
                return;
            }
            serialPortAmbiente.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler2);
            try
            {
                serialPortAmbiente.Open();
                //Thread.Sleep(2000);
                try
                {
                    serialPortAmbiente.Write("1");
                    puertoAmbienteAbierto = true;
                }
                catch (Exception ex) { MessageBox.Show("Error al enviar primer 1 al ambiente."); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique que el puerto de comunicación con el ambiente este correctamente conectado. (COM 6)");
                puertoAmbienteAbierto = false;
                return;
            }
        }
        private static void cerrarPuertos() {
            serialPortMuestras.Close();
            serialPortAmbiente.Close();
        }

        private void timerDatosRecibidos_Tick(object sender, EventArgs e)
        {
            if (datosHornoRecibidos)
            {
                DatosHornoRecibidos();
                try
                {
                    if (encendido)
                    {
                        pictureCorriendo.Visible = true;
                        pictureDetenido.Visible = false;
                    }
                    else
                    {
                        pictureCorriendo.Visible = false;
                        pictureDetenido.Visible = true;
                    }
                    if (Program.ciclosVacios)
                        IconoAtencion.Visible = true;
                    else
                        IconoAtencion.Visible = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al cambiar etiquetas.");
                }
                if (datosAmbienteRecibidos)
                {
                    DatosAmbienteRecibidos();
                }
            }
        }
    }
}