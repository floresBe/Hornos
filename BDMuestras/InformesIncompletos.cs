using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicio;
using Hornos;

namespace BDMuestras
{
    public partial class InformesIncompletos : Form
    {
        public static int noCiclo;
        public static string horno;
        public static string fecha;
        public static string HORA;

        public static string NOPARTE;
        public static int PZASENTRANTES;
        public static int PZASMALAS;

        string[] vfecha;

        string[] infoCiclo;
        List<string> ciclos;

        cCiclo ciclo = new cCiclo();
        cParteCiclo parteCiclo = new cParteCiclo();

        public InformesIncompletos()
        {
            InitializeComponent();
            listBoxCiclosdelDia.LostFocus += listBoxCiclosdelDia_LostFocus;
        }
        private void InformesIncompletos_Load(object sender, EventArgs e)
        {
            listBoxCiclosdelDia.Items.Clear();
        }

        private void buttonEditarCiclo_Click(object sender, EventArgs e)
        {
            try
            {
                infoCiclo = listBoxCiclosdelDia.SelectedItem.ToString().Split();
                horno = infoCiclo[0];
                noCiclo = Convert.ToInt32(infoCiclo[1]);
                Program.NcicloAuxiliar = noCiclo;
                Program.PkCicloAuxiliar = horno;
                Program.fechaAuxiliar = fecha;
                Program.sesion = 1;
                NumeroParte numeroParte = new NumeroParte(2,horno,noCiclo);
                numeroParte.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha seleccionado ciclo.");
                return;
            }

        }
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            vfecha = dateTimePicker.Value.ToString().Split();
            fecha = vfecha[0];
            labelFecha.Text = fecha;
            listBoxCiclosdelDia.Items.Clear();
            ciclos = null;
            ciclos = parteCiclo.ObtenerCiclosVaciosDeFecha(fecha, Program.horno);
            foreach (var item in ciclos)
            {
                listBoxCiclosdelDia.Items.Add(item);
            }
        }

        private void labelFecha_Click(object sender, EventArgs e)
        {

        }

        private void listBoxCiclosdelDia_SelectedIndexChanged(object sender, EventArgs e)
        {
           ///Algo se me ocurrira con este metodo
        }

        private void listBoxCiclosdelDia_LostFocus(object sender, EventArgs e)
        {           
            ///Algo se me ocurrira con este metodo
        }
    }
}
