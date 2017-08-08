<%@ Page Title="" Language="C#" MasterPageFile="~/StoreStaff.Master" AutoEventWireup="true" CodeBehind="DeliveryOrder.aspx.cs" Inherits="ADProject.Store.DeliveryOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="table ll">
        <tr>
            <td colspan="3" style="text-align: center">
                <h3>Delivery Order</h3>
            </td>
        </tr>
        <tr>
            <td>
                <h5 style="text-align: right">PO Number :</h5>
            </td>
            <td>
                <asp:TextBox ID="txtPONumber" runat="server"></asp:TextBox></td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
        </tr>

        <tr>
            <td>
                <h5 style="text-align: right">Supplier :</h5>
            </td>
            <td>
                <asp:Label ID="lblSupplier" runat="server" Text="Label"></asp:Label>
            </td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3">
                <h5 style="text-align: center">
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label></h5>
            </td>
            
        </tr>
        <tr>
            <td style="text-align: right">The following items has been delivered to : Logic University Stationery Store
                On this day :
            </td>
            <td colspan="2">
                <asp:TextBox Width="76%" ID="txtDeliveryDate" runat="server" TextMode="Date"></asp:TextBox>
            </td>

        </tr>

        <tr>
            <td colspan="3">
                <asp:GridView Width="50%" ID="gvList" runat="server" AutoGenerateColumns="false" Font-Size="Small">
                    <Columns>
                        <asp:BoundField DataField="StationeryId" HeaderText="Item Code"
                            SortExpression="Description" />

                        <asp:BoundField DataField="Stationery.Description" HeaderText="Description"
                            SortExpression="Description" />

                        <asp:BoundField DataField="OrderQty" HeaderText="Ordered Qty"
                            SortExpression="Description" />

                        <asp:TemplateField HeaderText="Received Qty">
                            <ItemTemplate>
                                <asp:TextBox Width="70px" ID="txtQty" runat="server"
                                    Text='<%# Eval("ReceivedQty") %>' BorderStyle="None" CssClass="form-control centered"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Remark">
                            <ItemTemplate>
                                <asp:TextBox ID="txtRemark" runat="server"
                                    Text='<%# Eval("Remarks") %>' BorderStyle="None" CssClass="form-control centered"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ControlStyle-CssClass="table table-hover btn btn-default center">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server"
                                    CommandName="Delete"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    Text="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>

        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
            </td>
        </tr>

    </table>

</asp:Content>
