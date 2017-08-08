<%@ Page Title="" Language="C#" MasterPageFile="~/StoreStaff.Master" AutoEventWireup="true" CodeBehind="ReportForPurchasingForStoreClerk.aspx.cs" Inherits="ADProject.ReportForPurchasingForStoreClerk" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <table class="table ll">
        <tr>
            <td colspan="2" class="text-center"><h3 class="text-center">Re-Order Report</h3></td>
        </tr>
        <tr>
            <td style="text-align:right"><asp:TextBox ID="txtFromDate" runat="server" TextMode="Date"></asp:TextBox></td>
            <td style="text-align:left"><asp:TextBox ID="txtToDate" runat="server" TextMode="Date"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" class="text-center"> <asp:Button ID="btnSearch" runat="server" Text="Search"  OnClick="btnSearch_Click"/></td>
        </tr>
    </table>
   
<div class="row">
        <div class="col-lg-12">&nbsp</div>
    </div>
    <CR:CrystalReportViewer ToolPanelView="None" ID="Viewer" runat="server" AutoDataBind="true" />
</asp:Content>
