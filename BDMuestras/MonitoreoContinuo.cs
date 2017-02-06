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
        static string[] fechaR; //Guarda la fecha y hora en partes
        static string fechaReal; //Guarda la pura fecha
        static string horaR; //Guarda la hora real
        static double hora; //Guarda la hora procesada para utilizar en grafica

        static bool encendido = false; //Indica si el horno esta encendido o no  
                                       // static List<String> ciclosVacios = new List<String>();
        static string nombreCiclo;//Guarda la llave primaria del ciclo 

        static bool datosRecibidos = false; //indica que se han recibido los datos por puerto serial
        static bool datosAmbienteRecibidos = false; //indica que se han recibido los datos por puerto serial
        static bool datosCachados = false;
        static string[] valores; //Guarda los valores recibidos por puerto serial
        static string[] valoresAmbiente; //Guarda los valores recibidos por puerto serial
        static string datos = null; //Se utiliza para almacenar datos provinientes del puerto serial
        static string datosAmbiente = null; //Se utiliza para almacenar datos provinientes del puerto serial
        static int promedio = 0;
        static int punto;//Maneja la cantidad de puntos de cada serie de la grafica
        static int noSensores = 0; //Se utiliza guardar la cantidad de sensores activos
        bool puertoHornoAbierto = false;
        string temp = null;
        string hum = null;
        bool puertoAmbienteAbierto = false;

        static cCiclo ciclo = new cCiclo();
        static cSensor sensor = new cSensor();
        static cMuestra muestra = new cMuestra();
        static cParteCiclo parteCiclo = new cParteCiclo();

        //Eventos

        public MonitoreoContinuo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Evento de cargar la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonitoreoContinuo_Load(object sender, EventArgs e)
        {
            labelCiclo.Text = "Ciclo: "; //Se muestra el numero de Ciclo en pantalla
            TemporizadorHora.Start();
            CargarGrafica();
            abrirPuerto();
            //Thread.Sleep(1000);
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

        }
        /// <summary>
        /// Evento de recibir datos desde puerto serial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = null;
                //se crea una instancia del puerto serial
                try
                {
                    sp = (SerialPort)sender;
                }
                catch (Exception)
                {
                    MessageBox.Show("Al crear el puerto.");
                }
                //se guardan datos recibidos en variable

                try
                {
                    datos += sp.ReadExisting();
                    //datos += sp.ReadLine();
                }
                catch (Exception) { MessageBox.Show("Al Leer linea"); }
                try
                {
                    valores = datos.Split(',');
                }
                catch (Exception)
                {
                    MessageBox.Show("Al dividir cadena");
                }

                if (valores.Length == 32 && datosRecibidos == false)
                {
                    datosRecibidos = true;
                }//Cierra if comprobacion de todos los datos recibidos
                else if (valores.Length > 33)
                {
                    valores = null;
                    datos = string.Empty;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al recibir datos.");
            }
            Console.WriteLine(datos);
            //Console.WriteLine(datos.Length); 
        }
        /// <summary>
        /// Evento de recibir datos desde puerto serial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DataReceivedHandler2(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //se crea una instancia del puerto serial
                SerialPort sp = (SerialPort)sender;
                //se guardan datos recibidos en variable
                //datos += sp.ReadExisting();
                datosAmbiente += sp.ReadLine();
                Console.WriteLine(datosAmbiente);
                valoresAmbiente = datosAmbiente.Split(',');
                if (valoresAmbiente.Length == 3 && datosAmbienteRecibidos == false)
                {
                    datosAmbienteRecibidos = true;
                }//Cierra if comprobacion de todos los datos recibidos
                else if (datosCachados || valoresAmbiente.Length > 3)
                {
                    valoresAmbiente = null;
                    datosAmbiente = string.Empty;
                    datosCachados = false;
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
            Imprimir ventana = new Imprimir();
            ventana.Show();
        }
        /// <summary>
        /// Evento de clic en boton configurar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Program.sesion = 1;
            serialPortMuestras.Close();
            serialPortAmbiente.Close();
            this.Close();
            Program.VentanaInicio.Show();
        }
        /// <summary>
        /// Evento de hora avanzando 
        /// </summary>
        private void TemporizadorHora_Tick(object sender, EventArgs e)
        {
            try
            {
                labelFechaHora.Text = DateTime.Now.ToString();//Se muestra fecha/hora en pantalla
                labelCiclo.Text = "Ciclo: " + Program.nombreCiclo;//Se muestra el numero de ciclo que se encuentra corriendo
            }
            catch (Exception)
            {
                MessageBox.Show("Error al tomar fecha.");
            }
            if (datosRecibidos)
            {
                DatosRecibidos();
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
            }
            try
            {
                labelPromedio.Text = promedio.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al mostrar promedio.");
            }
            if (datosAmbienteRecibidos)
            {
                try
                {
                    horaR = string.Format("{0:HH:mm:ss}", DateTime.Now); //se toma la hora actual
                    string datos1 = "Temperatura: " + valoresAmbiente[0] + " Humedad: " + valoresAmbiente[1] + "   Hora: " + horaR;
                    listBoxAmbiente.Items.Add(datos1);
                    listBoxAmbiente.SelectedItem = datos1;
                    temp = valoresAmbiente[0];
                    hum = valoresAmbiente[1];

                    muestra.Insertar(31, Program.horno, Program.noCiclo, horaR, temp);
                    muestra.Insertar(32, Program.horno, Program.noCiclo, horaR, hum);
                    datosAmbienteRecibidos = false;
                    datosCachados = true;
                }
                catch (Exception)
                {
                    ///Desincronizacion momentanea
                }
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

        private void MonitoreoContinuo_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPortMuestras.Close();
            serialPortAmbiente.Close();
            if (Program.sesion == 0)
                Program.VentanaInicio.Show();
        }
        
        //Metodos

        /// <summary>
        /// Consulta en la base de datos cuales sensores se utilizaran en la grafica
        /// </summary> 
        private void CargarGrafica()
        {
            chartMuestras.ChartAreas[0].AxisY.Title = "Temperatura";
            chartMuestras.ChartAreas[0].AxisY2.Title = "Presión";
            chartMuestras.ChartAreas[0].AxisX.Title = "Hora";
            chartMuestras.Series.Clear();//Se limpia la grafica
            List<string> sensores = new List<string>(); //Se crea lista para almacenar el nombre de los sensores
            sensores = sensor.ObtenerActivos(); //Se llama al metodo que devuelve sensores activos
            foreach (var item in sensores) //Procedimiento para llenar la grafica
            {
                if (item != "TempAmbiente" && item != "HumAmbiente")
                {
                    chartMuestras.Series.Add(item); //Se agrega el sensor a la grafica
                    if (item == "Chamber Pirani" || item == "Cold Cathode") //se  diferencian por tipo de sensor
                    {
                        chartMuestras.Series[noSensores].YAxisType = AxisType.Secondary;
                        //labelPresion.Visible = true;
                    }
                    else
                    {
                        chartMuestras.Series[noSensores].YAxisType = AxisType.Primary;
                    }
                    noSensores++; // se incrementa el numero de sensores agregados
                }
            }
            noSensores = 0;
            punto = 0;
        }
        /// <summary>
        /// Abre el puerto serial
        /// </summary> 
        private void abrirPuerto()
        {
            serialPortMuestras.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            try
            {
                serialPortMuestras.Open();
                Thread.Sleep(2000);
                try
                {
                    serialPortMuestras.Write("1");
                    puertoHornoAbierto = true;
                }
                catch (Exception) { MessageBox.Show("Error al enviar primer 1."); }
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique que el puerto de comunicación con horno este correctamente conectado. (COM 3)");
                puertoHornoAbierto = false;
                return;
            }

            serialPortAmbiente.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler2);
            try
            {
                serialPortAmbiente.Open();
                Thread.Sleep(2000);
                serialPortAmbiente.Write("1");
                puertoAmbienteAbierto = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique que el puerto de comunicación con ambiente este correctamente conectado. (COM 6)");
                puertoAmbienteAbierto = false;
                return;
            }
        }
        /// <summary>
        /// Procedimiento a seguir despues de recibir los datos por puerto serial
        /// </summary>
        public static void DatosRecibidos()
        {
            datos = string.Empty;
            string status = null;
            try
            {
                status = valores[30].ToString();
            }
            catch (Exception)
            {
                //MessageBox.Show("Error al tomar status.");
            }
            if (valores.Length == 32 && status == "1")//Indica que el horno esta encendido 
            {
                if (encendido == false)//indica que el horno acaba de iniciar un nuevo ciclo
                {
                    try
                    {
                        encendido = true;//se indica que el horno esta encendido
                        fechaR = DateTime.Now.ToString().Split(); //Se toma la fecha y divide en partes 
                        fechaReal = fechaR[0]; //se guarda la primera parte                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
                        horaR = string.Format("{0:HH:mm:ss}", DateTime.Now); //se toma la hora actual
                        if (Program.mismociclo)
                        {
                            nombreCiclo = Program.nombreCiclo;
                            Program.mismociclo = false;
                        }
                        else
                        {
                            Program.ObtenerNuevoCiclo();
                            ciclo.Insertar(Program.horno, Program.noCiclo, Program.usuario, fechaReal, horaR);//se crea el ciclo y se inserta en la base de datos
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al correr Ciclo.");
                    }
                }
            }
            else if (valores.Length == 32 && status == "0")
            {
                try
                {
                    if (encendido)//indica que se acaba de terminar el ciclo
                    {
                        encendido = false; //se indica que el horno no esta encendido
                        Program.mismociclo = false;
                    }
                    Program.ciclosVacios = parteCiclo.ciclosVacios();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al detener Ciclo.");
                }
            }
            if (valores.Length == 32)
            {
                transformarHora();
                GraficarMuestras();
                datosRecibidos = false;
            }
        }
        /// <summary>
        /// Transforma la hora para utilizarla en la grafica
        /// </summary>
        private static void transformarHora()
        {
            try
            {
                horaR = string.Format("{0:HH:mm:ss}", DateTime.Now);
                String[] parte = horaR.Split(':');
                //Se hacen las operacionespara transformar la hora (1 dia = 1; 1 hora = 0.041666)
                hora = (Int32.Parse(parte[0])) * (0.041666) + (Int32.Parse(parte[1]))
                        * (0.04166667 / 60) + (Int32.Parse(parte[2])) * ((0.04166667 / 60) / 60);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al transformar hora.");
            }
        }
        /// <summary>
        /// Grafica las muestras recibidas por el puerto serial
        /// </summary>
        private static void GraficarMuestras()
        {
            string nombreSerie;
            int tipo;
            int claveSensor;
            try
            {
            foreach (var serie in Program.VentanaMonitoreo.chartMuestras.Series)
            {
                nombreSerie = serie.Name;
                tipo = sensor.ObtenerTipo(nombreSerie);
                claveSensor = sensor.ObtenerPK(nombreSerie) - 1;
                string cadena = null;
                if (tipo == 1 && valores.Length == 32)
                {
                    cadena = nombreSerie + "      " + horaR + "              " + valores[claveSensor];
                    Program.VentanaMonitoreo.listBoxMuestrasTemp.Items.Add(cadena);
                    Program.VentanaMonitoreo.listBoxMuestrasTemp.SelectedItem = cadena;
                }
                else if (tipo == 2 && valores.Length == 32)
                {
                    cadena = nombreSerie + "      " + horaR + "     " + valores[claveSensor];
                    Program.VentanaMonitoreo.listBoxMuestrasPress.Items.Add(cadena);
                    Program.VentanaMonitoreo.listBoxMuestrasPress.SelectedItem = cadena;
                }
                cadena = null;
                //se agregan los datos de la muestra a la grafica
                serie.ChartType = SeriesChartType.Line;
                serie.XValueType = ChartValueType.Time;
                serie.Points.AddY(valores[claveSensor]);
                serie.Points[punto].XValue = hora;
                if (encendido)
                {// se agregan los datos de la muestra a la Base de Datos
                    string valor = valores[claveSensor];
                    muestra.Insertar(claveSensor + 1, Program.horno, Program.noCiclo, horaR, valor);
                }
            }
            punto++;
            if (encendido)
            {// se agregan los datos de la muestra a la Base de Datos
                promedio = Convert.ToInt32(valores[31]);
                muestra.Insertar(32, Program.horno, Program.noCiclo, horaR, promedio.ToString());
            }
            }
            catch (Exception)
            {
            //   MessageBox.Show("Error al Graficar Muestras.");
            }
        }

    }
}