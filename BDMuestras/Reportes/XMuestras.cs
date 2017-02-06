using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace BDMuestras.Reportes
{
    public partial class XMuestras : DevExpress.XtraReports.UI.XtraReport
    {
        public XMuestras()
        {
            InitializeComponent();
        }
        public XMuestras(EntidadReporteMuestra datos)
        {
            this.DataSource = datos.Muestras;
            InitializeComponent();
        }

    }
}
