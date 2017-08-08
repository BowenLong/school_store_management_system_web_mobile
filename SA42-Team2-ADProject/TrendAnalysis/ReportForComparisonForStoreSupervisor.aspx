<%@ Page Title="" Language="C#" MasterPageFile="~/StoreSuperviser.Master" AutoEventWireup="true" CodeBehind="ReportForComparisonForStoreSupervisor.aspx.cs" Inherits="ADProject.ReportForComparisonForStoreSupervisor" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table class="table ll">
        <tr>
            <td colspan="2">
                <h3 class="text-center">Stationery Order Trend Analysis Comparison Report</h3>
            </td>
        </tr>
        <tr>
            <td style="text-align: right"><h5>Month</h5></td>
            <td style="text-align: left">
                <asp:TextBox Width="60%" ID="txtMonth" runat="server" TextMode="Date"></asp:TextBox></td>
           
        </tr>
        <tr>
            <td style="text-align: right">
               <h5>Year</h5></td>
             <td style="text-align: left">
                <asp:TextBox Width="60%" ID="txtYear" runat="server" TextMode="Date"></asp:TextBox></td>
        </tr>
         <tr>
            <td style="text-align: right">
               <h5>Stationery</h5></td>
             <td style="text-align: left">
                 <asp:DropDownList Width="60%" ID="ddlStationery" runat="server"></asp:DropDownList>
                </td>
        </tr>
         <tr>
            <td style="text-align: right">
               <h5>Department</h5></td>
             <td style="text-align: left">
                <asp:DropDownList Width="60%" ID="ddlDepartment" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2" class="text-center">
                <asp:Button ID="btnSearch" runat="server" Text="Search" /></td>
        </tr>
    </table>

    <div class="row">
        <div class="col-lg-12">&nbsp</div>
    </div>
    <CR:CrystalReportViewer ToolPanelView="None" ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
  
</asp:Content>
