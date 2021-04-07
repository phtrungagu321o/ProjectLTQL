
namespace ĐỒ_ÁN.GUI
{
    partial class ReportBill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.quanLiPhongKaraokeDataSet = new ĐỒ_ÁN.QuanLiPhongKaraokeDataSet();
            this.uSPGetListBillByDateForReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_GetListBillByDateForReportTableAdapter = new ĐỒ_ÁN.QuanLiPhongKaraokeDataSetTableAdapters.USP_GetListBillByDateForReportTableAdapter();
            this.uSPGetListBillByDateForReportBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.quanLiPhongKaraokeDataSet1 = new ĐỒ_ÁN.QuanLiPhongKaraokeDataSet();
            this.quanLiPhongKaraokeDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSPGetListBillByDateForReportBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.uSPGetListBillByDateForReportBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.USP_GetListBillByDateForReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.quanLiPhongKaraokeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiPhongKaraokeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiPhongKaraokeDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateForReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // quanLiPhongKaraokeDataSet
            // 
            this.quanLiPhongKaraokeDataSet.DataSetName = "QuanLiPhongKaraokeDataSet";
            this.quanLiPhongKaraokeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSPGetListBillByDateForReportBindingSource
            // 
            this.uSPGetListBillByDateForReportBindingSource.DataMember = "USP_GetListBillByDateForReport";
            this.uSPGetListBillByDateForReportBindingSource.DataSource = this.quanLiPhongKaraokeDataSet;
            // 
            // uSP_GetListBillByDateForReportTableAdapter
            // 
            this.uSP_GetListBillByDateForReportTableAdapter.ClearBeforeFill = true;
            // 
            // uSPGetListBillByDateForReportBindingSource1
            // 
            this.uSPGetListBillByDateForReportBindingSource1.DataMember = "USP_GetListBillByDateForReport";
            this.uSPGetListBillByDateForReportBindingSource1.DataSource = this.quanLiPhongKaraokeDataSet;
            // 
            // quanLiPhongKaraokeDataSet1
            // 
            this.quanLiPhongKaraokeDataSet1.DataSetName = "QuanLiPhongKaraokeDataSet";
            this.quanLiPhongKaraokeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quanLiPhongKaraokeDataSet1BindingSource
            // 
            this.quanLiPhongKaraokeDataSet1BindingSource.DataSource = this.quanLiPhongKaraokeDataSet1;
            this.quanLiPhongKaraokeDataSet1BindingSource.Position = 0;
            // 
            // uSPGetListBillByDateForReportBindingSource2
            // 
            this.uSPGetListBillByDateForReportBindingSource2.DataMember = "USP_GetListBillByDateForReport";
            this.uSPGetListBillByDateForReportBindingSource2.DataSource = this.quanLiPhongKaraokeDataSet1;
            // 
            // uSPGetListBillByDateForReportBindingSource3
            // 
            this.uSPGetListBillByDateForReportBindingSource3.DataMember = "USP_GetListBillByDateForReport";
            this.uSPGetListBillByDateForReportBindingSource3.DataSource = this.quanLiPhongKaraokeDataSet1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetGetBill";
            reportDataSource1.Value = this.USP_GetListBillByDateForReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ĐỒ_ÁN.Report.ReportBiLL.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // USP_GetListBillByDateForReportBindingSource
            // 
            this.USP_GetListBillByDateForReportBindingSource.DataMember = "USP_GetListBillByDateForReport";
            this.USP_GetListBillByDateForReportBindingSource.DataSource = this.quanLiPhongKaraokeDataSet;
            // 
            // ReportBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportBill";
            this.Text = "Báo Cáo";
            this.Load += new System.EventHandler(this.ReportBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quanLiPhongKaraokeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiPhongKaraokeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiPhongKaraokeDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateForReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource uSPGetListBillByDateForReportBindingSource;
        private QuanLiPhongKaraokeDataSet quanLiPhongKaraokeDataSet;
        private QuanLiPhongKaraokeDataSetTableAdapters.USP_GetListBillByDateForReportTableAdapter uSP_GetListBillByDateForReportTableAdapter;
        private System.Windows.Forms.BindingSource uSPGetListBillByDateForReportBindingSource1;
        private System.Windows.Forms.BindingSource uSPGetListBillByDateForReportBindingSource2;
        private QuanLiPhongKaraokeDataSet quanLiPhongKaraokeDataSet1;
        private System.Windows.Forms.BindingSource quanLiPhongKaraokeDataSet1BindingSource;
        private System.Windows.Forms.BindingSource uSPGetListBillByDateForReportBindingSource3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_GetListBillByDateForReportBindingSource;
    }
}