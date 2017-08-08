<%@ Page Title="" Language="C#" MasterPageFile="~/StoreStaff.Master" AutoEventWireup="true" CodeBehind="ViewSupplierList.aspx.cs" Inherits="ADProject.Store.ViewSupplierList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table ll">
        <tr>
            <td colspan="3" style="text-align: center">
                <h3>Supplier List</h3>
            </td>
        </tr>
        <tr>
            <td>
                  <asp:GridView ID="gvSupplierList" runat="server" Font-Size="Small"></asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
