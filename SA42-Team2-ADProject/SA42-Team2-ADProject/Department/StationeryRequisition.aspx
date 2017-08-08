<%@ Page Title="" Language="C#" MasterPageFile="~/DeptHead.Master" AutoEventWireup="true" CodeBehind="StationeryRequisition.aspx.cs" Inherits="ADProject.Department.StationeryRequisition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-12">Stationery Requisition</div>
    </div>
    <div class="row">
        <div class="col-md-12">
            
            <asp:GridView ID="gvReguisition" runat="server" AutoGenerateColumns="False">
<%--            <Columns>
                <asp:BoundField DataField="AdjustmentVCId" HeaderText="AdjustmentVCId" ReadOnly="True" InsertVisible="False" SortExpression="AdjustmentVCId"></asp:BoundField>
                <asp:BoundField DataField="IssuedDate" HeaderText="IssuedDate" SortExpression="IssuedDate"></asp:BoundField>
                <asp:BoundField DataField="ApprovalStatus" HeaderText="ApprovalStatus" SortExpression="ApprovalStatus"></asp:BoundField>
                <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" SortExpression="EmployeeId"></asp:BoundField>
                <asp:BoundField DataField="ApproveDate" HeaderText="ApproveDate" SortExpression="ApproveDate"></asp:BoundField>
                <asp:BoundField DataField="ApproveRole" HeaderText="ApproveRole" SortExpression="ApproveRole"></asp:BoundField>
            </Columns>--%>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SA42-Team2-ADProjectConnectionString %>" SelectCommand="SELECT * FROM [AdjustmentVoucher]"></asp:SqlDataSource>

        </div>
    </div> 
    <div class="row">
        <div class="col-xs-6" style="text-align:center">
            <asp:Button ID="btnApprove" runat="server" Text="Approve" /></div>
        <div class="col-xs-6" style="text-align:center">
            <asp:Button ID="btnReject" runat="server" Text="Reject" /></div>

    </div>

  


        

  

</asp:Content>
