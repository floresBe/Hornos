using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servidor
{
    class cTipoSensor
    {
        public int Insertar(string magnitud)
        {
            using (var entidad = new MuestrasHornosEntities())
            {
                TipoSensor sensor = null;
                try
                {
                    sensor = new TipoSensor
                    {
                        Magnitud = magnitud
                    };
                    entidad.TipoSensors.Add(sensor);
                    entidad.SaveChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al accedeer a la base de datos: " + e);
                }
                return sensor.PK_TipoSensor;
            }
        }
    }
}
