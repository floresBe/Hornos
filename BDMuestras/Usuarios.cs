using Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDMuestras
{
    public partial class Usuarios : Form
    {
        string noEmpleado;
        string nombre;
        string aPaterno;
        string aMaterno;
        string turno;
        int nivel;
        string contra;
        cUsuario usuario = null;
        public Usuarios()
        {
            InitializeComponent();
            
        }
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (textBoxNoEmpleado.Text != string.Empty && textBoxNoEmpleado.Text != null)
            {
                noEmpleado = textBoxNoEmpleado.Text;
            }
            else
            {
                MessageBox.Show("Ingresar No. Empleado.");
                return;
            }

            if (textBoxNombre.Text != string.Empty && textBoxNombre.Text != null)
            {
                nombre = textBoxNombre.Text;
            }
            else
            {
                MessageBox.Show("Ingresar Nombre de Empleado.");
                return;
            }

            if (textBoxApaterno.Text != string.Empty && textBoxApaterno.Text != null)
            {
                aPaterno = textBoxApaterno.Text;
            }
            else
            {
                MessageBox.Show("Ingresar Apellido.");
                return;
            }

            if (textBoxaMaterno.Text != string.Empty && textBoxaMaterno.Text != null)
            {
                aMaterno = textBoxaMaterno.Text;
            }
            else
            {
                MessageBox.Show("Ingresar Apellido.");
                return;
            }

            if (comboBoxTurno.SelectedItem != null)
            {
                turno = comboBoxTurno.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Seleccionar turno.");
                return;
            }

            if (comboBoxNivel.SelectedItem != null)
            {
                nivel = Convert.ToInt32(comboBoxTurno.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Seleccionar nivel.");
                return;
            }

            if (textBoxContrasena.Text != null && textBoxContrasena.Text != string.Empty)
            {
                if (textBoxRcontrasena.Text != null && textBoxRcontrasena.Text != string.Empty)
                {
                    if (textBoxContrasena.Text.Equals(textBoxRcontrasena.Text))
                    {
                        contra = textBoxRcontrasena.Text;
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no son iguales.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Repetir la contraseña.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Ingresar contraseña.");
                return;
            }
            usuario.Insertar(noEmpleado, nombre, aPaterno, aMaterno, contra, nivel, turno);
            MessageBox.Show("Usuario Ingresado Satisfactoriamente.");
            this.Close();
            //Program.VentanaInicio.Show();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            usuario = new cUsuario();
            string noEmpleado = dataGridUsuarios.CurrentRow.Cells[0].Value.ToString();
            usuario.desactivarUsuario(noEmpleado);
            usuariosActivos();           
        }

        private void Usuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.VentanaInicio.Show();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'muestrasHornosDataSet.Usuarios' table. You can move, or remove it, as needed.
            this.usuariosTableAdapter.Fill(this.muestrasHornosDataSet.Usuarios);
            usuariosActivos();
        }
        private void usuariosActivosToolStripButton_Click(object sender, EventArgs e)
        {
            usuariosActivos();

        }
        private void usuariosActivos()
        {
            try
            {
                this.usuariosTableAdapter.UsuariosActivos(this.muestrasHornosDataSet.Usuarios);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        
    }
}
