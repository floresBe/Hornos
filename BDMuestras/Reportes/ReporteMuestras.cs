using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDMuestras.Reportes
{
    public partial class ReporteMuestras : Form
    {
        public ReporteMuestras()
        {
            InitializeComponent();
        }
        public ReporteMuestras(EntidadReporteMuestra entidad)
        {
            XMuestras reporte = new XMuestras(entidad);
            InitializeComponent();
            this.documentViewer1.DocumentSource = reporte;
            this.documentViewer1.Refresh();
        }
    }
}
