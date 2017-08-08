<%@ Page Title="" Language="C#" MasterPageFile="~/DeptStaff.Master" AutoEventWireup="true" CodeBehind="RequisitionHistoryDetail.aspx.cs" Inherits="ADProject.RequisitionHistoryDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row">
        <div class="col-xs-12" style="text-align:center">
     <asp:Label ID="lblRequisitionHistoryDetail" runat="server" Font-Size="Medium" style="font-weight: 700; text-align: center;" Text="Requisition History Detail"></asp:Label>
        </div>

        <div class="col-xs-12" style="text-align:center">
             <asp:GridView ID="GridView1" runat="server">
         </asp:GridView>
        </div>
        <div class="col-xs-12"> <asp:Label ID="lblApprovedby" runat="server" Text="Approved by :" style="text-align: center"></asp:Label></div>
    </div>
</asp:Content>
