using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐỒ_ÁN.GUI
{
    public partial class ReportBill : Form
    {
        private DateTime checkin;
        private DateTime checkOut;
        public ReportBill()
        {
            InitializeComponent();
            

        }

        public DateTime Checkin { get => checkin; set => checkin = value; }
        public DateTime CheckOut { get => checkOut; set => checkOut = value; }

        private void ReportBill_Load(object sender, EventArgs e)
        {
            this.uSP_GetListBillByDateForReportTableAdapter.Fill(this.quanLiPhongKaraokeDataSet.USP_GetListBillByDateForReport,checkin,checkOut);
            
            this.reportViewer1.RefreshReport();
        }
    }
}
