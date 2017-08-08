<%@ Page Title="" Language="C#" MasterPageFile="~/StoreStaff.Master" AutoEventWireup="true" CodeBehind="ManageStock.aspx.cs" Inherits="ADProject.Store.ManageStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table ll">
         <tr>
            <td colspan="3" style="text-align: center"><h3>View Stock</h3>
            </td>
        </tr>

        <tr>
            <td>
                <div class="row" style="margin:auto">

        <div class="col-xs-2">Category:</div>
        <div class="col-xs-6">
            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True"></asp:DropDownList></div>
        <div class="col-xs-3">
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </div>
                    </div>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="false" OnRowCommand="gvStock_RowCommand">
        <Columns>

                    <asp:BoundField DataField="StationeryId" HeaderText="Item Code" />

                    <asp:BoundField DataField="Category.CategoryDescription" HeaderText="Category" />

                    <asp:BoundField DataField="Description" HeaderText="Item Description" />

                    <asp:BoundField DataField="UOM.UOMDescription" HeaderText="UOM" />

                    <asp:BoundField DataField="StorageBin.Bin" HeaderText="Bin" />

                    <asp:BoundField DataField="ReorderLevel" HeaderText="Reorder Level" />

                    <asp:BoundField DataField="ReorderQuantity" HeaderText="Reorder Qty" />

                    <asp:ButtonField ControlStyle-CssClass="btn btn-default" CommandName="ButtonField" Text="View" ButtonType="Button" />

                </Columns>
    </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
