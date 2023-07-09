using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Bao_cao
{
    public partial class InHD : Form
    {
        string p;
        public InHD()
        {
            InitializeComponent();
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private string _message;
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            p = _message;
            InHoaDon rtp = new InHoaDon();
            ParameterValues dy = new ParameterValues();
            ParameterDiscreteValue inm = new ParameterDiscreteValue();
            inm.Value = p;
            dy.Add(inm);
            rtp.DataDefinition.ParameterFields[0].ApplyCurrentValues(dy);
            crystalReportViewer1.ReportSource = rtp;
            crystalReportViewer1.Refresh();
        }
    }
}
