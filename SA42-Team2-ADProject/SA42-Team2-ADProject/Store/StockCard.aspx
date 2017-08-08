<%@ Page Title="" Language="C#" MasterPageFile="~/StoreStaff.Master" AutoEventWireup="true" CodeBehind="StockCard.aspx.cs" Inherits="ADProject.Store.StockCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="table ll">
        <tr>
            <td colspan="3" style="text-align: center">
                <h3>Stock Card</h3>
            </td>
        </tr>
        <tr>
            <td>Item Code:<asp:Label ID="lblItemCode" runat="server" Text="Label"></asp:Label><br />
                Item Description:<asp:Label ID="lblItemDescription" runat="server" Text="Label"></asp:Label><br />
                Bin#:<asp:Label ID="lblBin" runat="server" Text="Label"></asp:Label><br />
                UOM:<asp:Label ID="lblUOM" runat="server" Text="Label"></asp:Label><br />
                1st Supplier:<asp:Label ID="lbl1stSupplier" runat="server" Text="Label"></asp:Label><br />
                2nd Supplier:<asp:Label ID="lbl2ndSupplier" runat="server" Text="Label"></asp:Label><br />
                3rd Supplier:<asp:Label ID="lbl3rdSupplier" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>From Date:</td>
            <td>
                <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date"></asp:TextBox></td>
        </tr>
        <tr>
            <td>To Date:</td>
            <td>
                <asp:TextBox ID="txtToDate" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                <asp:GridView ID="gvStockCardDetail" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="TransactionDate" HeaderText="Date" />

                        <asp:BoundField DataField="Participant" HeaderText="Participant" />

                        <asp:BoundField DataField="Stationery.Description" HeaderText="Item Description" />

                        <asp:BoundField DataField="TransactionQuantity" HeaderText="Transaction Quantity" />

                        <asp:BoundField DataField="Balance" HeaderText="Balance" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
