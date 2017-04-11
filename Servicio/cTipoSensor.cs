using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicio
{
    class cTipoSensor
    {
        public int Insertar(string unidad)
        {
            using (var entidad = new HornosHaltingEntities())
            {
                TipoSensor sensor = null;
                try
                {
                    sensor = new TipoSensor
                    {
                        Unidad = unidad
                    };
                    entidad.TipoSensors.Add(sensor);
                    entidad.SaveChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al accedeer a la base de datos: " + e);
                }
                return sensor.No_TipoSensor;
            }
        }
    }
}
