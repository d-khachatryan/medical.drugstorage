<%@ Page Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            var adap = new SqlDataAdapter("dbo.Report08", ConfigurationManager.ConnectionStrings["MedicalDrugStoreConnection"].ConnectionString);
            adap.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            adap.SelectCommand.CommandTimeout = 180;
            adap.SelectCommand.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = Convert.ToDateTime(ViewBag.StartDate);
            adap.SelectCommand.Parameters.Add("@TerminationDate", SqlDbType.DateTime).Value = Convert.ToDateTime(ViewBag.TerminationDate);
            adap.SelectCommand.Parameters.Add("@OrganizationId", SqlDbType.Int).Value = ViewBag.OrganizationId;
            var dt = new DataTable();
            adap.Fill(dt);
            var rds = new ReportDataSource();
            rds.Name = "ReportDataSet";
            rds.Value = dt;
            var prms = new List<ReportParameter>();
            prms.Add(new ReportParameter("StartDate", ViewBag.StartDate));
            prms.Add(new ReportParameter("TerminationDate", ViewBag.StartDate));
            prms.Add(new ReportParameter("OrganizationName", ViewBag.OrganizationName));
            rpv.ProcessingMode = ProcessingMode.Local;
            rpv.Reset();
            rpv.LocalReport.DisplayName = "---";
            rpv.LocalReport.ReportPath = Server.MapPath("~/bin/RDLC/") + "Report08.rdlc";
            rpv.LocalReport.DataSources.Clear();
            rpv.LocalReport.DataSources.Add(rds);
            rpv.DataBind();
            rpv.LocalReport.SetParameters(prms);
            rpv.LocalReport.Refresh();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="rpv" runat="server" ShowBackButton="False" ShowCredentialPrompts="False"
            ShowDocumentMapButton="False" ShowPageNavigationControls="True" ShowParameterPrompts="False"
            ShowPromptAreaButton="False" Width="100%" Height="100%" SizeToReportContent="True"
            ZoomMode="FullPage" ZoomPercent="200" ShowWaitControlCancelLink="False" AsyncRendering="False">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
