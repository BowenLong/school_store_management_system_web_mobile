<%@ Page Title="" Language="C#" MasterPageFile="~/DeptStaff.Master" AutoEventWireup="true" CodeBehind="DisbursementList.aspx.cs" Inherits="ADProject.Department.DisbursementList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-12" style="text-align:center">
            <asp:GridView ID="gvDisbursementList" runat="server"></asp:GridView>
        </div>
    </div>
    <a href="DisbursementStatus.aspx">show DisbursementStatus Page temporary</a>
</asp:Content>
