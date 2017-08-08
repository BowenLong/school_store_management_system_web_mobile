<%@ Page Title="" Language="C#" MasterPageFile="~/StoreStaff.Master" AutoEventWireup="true" CodeBehind="ReportForTenderForStoreClerk.aspx.cs" Inherits="ADProject.ReportForTenderForStoreClerk" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
   <table class="table ll">
        <tr>
            <td class="text-center"> <h3> Tender Report </h3></td>
        </tr>
        <tr>
            <td> <asp:DropDownList ID="ddlSupplier" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
    </table>
    <div>

                <CR:CrystalReportViewer ToolPanelView="None" ID="Viewer" runat="server" AutoDataBind="true" />
    </div>

</asp:Content>
