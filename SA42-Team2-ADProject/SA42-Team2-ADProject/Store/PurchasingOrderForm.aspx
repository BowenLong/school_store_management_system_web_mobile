<%@ Page Title="" Language="C#" MasterPageFile="~/StoreStaff.Master" AutoEventWireup="true" CodeBehind="PurchasingOrderForm.aspx.cs" Inherits="ADProject.PurchasingOrderForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table class="table ll">
        <tr>
            <td>
                <div style="text-align: center">
                    <h3>Purchase Order</h3>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="row">
                    <div class="col-xs-4" style="text-align: right">Supplier : </div>
                    <div class="col-xs-6" style="text-align: left">
                        <asp:DropDownList ID="ddlSupplier" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-4" style="text-align: right">Expected Delivery Date: </div>
                    <div class="col-xs-6" style="text-align: left">
                        <asp:TextBox ID="txtDeliveryDate" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-4" style="text-align: right">Category: </div>
                    <div class="col-xs-6" style="text-align: left">
                        <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-4" style="text-align: right">Item Description: </div>
                    <div class="col-xs-6" style="text-align: left">
                        <asp:DropDownList ID="ddlDescription" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                    <div class="row">
                        <div class="col-xs-12">&nbsp</div>
                        <div class="col-xs-4" style="text-align: right">Quantity: </div>
                        <div class="col-xs-6" style="text-align: left">
                            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regQuantity" runat="server" ControlToValidate="txtQuantity" Display="Dynamic" ErrorMessage="Please enter a valid Quantity" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        </div>
                    </div>
            </td>
        </tr>

        <tr>
            <td style="text-align:center"><asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" /></td>
        </tr>

        <tr>
            <td>
                

                <asp:GridView ID="gvPurchasingOrder" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvPurchasingOrder_RowDeleting " Font-Size="Small">
                    <Columns>

                        <asp:BoundField DataField="ItemCode" HeaderText="Item Code"
                            SortExpression="ItemCode" />

                        <asp:BoundField DataField="ItemDescription" HeaderText="Description"
                            SortExpression="Description" />

                        <asp:TemplateField HeaderText="Qty">
                            <ItemTemplate>
                                <asp:TextBox Width="80%" ID="txtQty" runat="server"
                                    Text='<%# Eval("Qty") %>' BorderStyle="None"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="Price" HeaderText="Price"
                            SortExpression="Price" />

                        <asp:BoundField DataField="UOM" HeaderText="UOM"
                            SortExpression="UOM" />

                        <asp:BoundField DataField="Amount" HeaderText="Total Amount"
                            SortExpression="Amount" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server"
                                    CommandName="Delete"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    Text="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>


                </asp:GridView>

                <asp:SqlDataSource ID="dsPurchasingOrder" runat="server"
                    ConnectionString='<%$ ConnectionStrings:SA42-Team2-ADProjectConnectionString %>'
                    SelectCommand="SELECT Stationery.Description, Stationery.ReorderLevel AS ReorderQuantity, UOM.UOMDescription, Stationery.Price1 AS Price FROM Reminder INNER JOIN Stationery ON Reminder.StationeryId = Stationery.StationeryId INNER JOIN UOM ON Stationery.UOMId = UOM.UOMId WHERE (Reminder.Status = 1) AND (Reminder.ReminderType = N'reorder')"></asp:SqlDataSource>
          
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
            </td>
        </tr>
    </table>

</asp:Content>
