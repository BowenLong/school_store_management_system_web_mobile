<%@ Page Title="" Language="C#" MasterPageFile="~/StoreStaff.Master" AutoEventWireup="true" CodeBehind="ReportForComparisonForStoreClerk.aspx.cs" Inherits="ADProject.ReportForComparisonForStoreClerk" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table ll">
        <tr>
           <asp:Button ID="btnAddStationery" runat="server" Text="Generate" OnClick="btnAddStationery_Click" />
        </tr>
    </table>

    <div class="row">
        <div class="col-lg-12">&nbsp</div>
    </div>
    <CR:CrystalReportViewer ToolPanelView="None" ID="ViewerForStoreClerk" runat="server" AutoDataBind="true" />

</asp:Content>
