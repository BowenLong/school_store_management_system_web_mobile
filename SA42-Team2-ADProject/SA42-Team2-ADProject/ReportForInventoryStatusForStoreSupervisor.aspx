<%@ Page Title="" Language="C#" MasterPageFile="~/StoreSuperviser.Master" AutoEventWireup="true" CodeBehind="ReportForInventoryStatusForStoreSupervisor.aspx.cs" Inherits="ADProject.ReportForInventoryStatusForStoreSupervisor" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="row">
        <h3 class="text-center">Inventory Status Report</h3>
    </div>
    <div class="row">
        <div class="col-lg-12">&nbsp</div>
    </div>
    <div class="row">
        <div class="col-lg-12">&nbsp</div>
    </div>
     <asp:DropDownList  ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                        </asp:DropDownList>
    <div class="row">
        <div class="col-lg-12">&nbsp</div>
    </div>
    <CR:CrystalReportViewer ToolPanelView="None"  ID="ViewerForStoreClerk" runat="server" AutoDataBind="true" />

</asp:Content>