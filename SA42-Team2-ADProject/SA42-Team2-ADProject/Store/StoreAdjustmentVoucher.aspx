<%@ Page Title="" Language="C#" MasterPageFile="~/StoreStaff.Master" AutoEventWireup="true" CodeBehind="StoreAdjustmentVoucher.aspx.cs" Inherits="ADProject.Store.StoreAdjustmentVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table ll">
        <tr>
            <td colspan="3" style="text-align: center"><h3>Adjustment Voucher</h3>
            </td>
        </tr>
        
        <tr>
            <td><h5 style="text-align:right">Category :</h5></td>
            <td>
                <asp:DropDownList Width="60%" ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><h5 style="text-align:right">Item Description :</h5></td>
            <td>
                <asp:DropDownList Width="60%" ID="ddlDescription" runat="server"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td><h5 style="text-align:right">Quantity Adjusted :</h5></td>
            <td>
                <asp:TextBox ID="txtQuantityAdjusted" runat="server"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="regQtyAdjusted" runat="server" ValidationExpression="^[\d]*$" ControlToValidate="txtQuantityAdjusted" ErrorMessage="Please enter the right quantity"></asp:RegularExpressionValidator>
            </td>
        </tr>

               


        <tr>
            <td><h5 style="text-align:right">Reason :</h5></td>
            <td>
                <asp:TextBox ID="txtReason" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" />
            </td>
        </tr>

        <tr>
            <td colspan="3" style="text-align: center">
                <asp:GridView ID="gvAdjustmentVoucherDetail" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvAdjustmentVoucherDetail_RowDeleting" Font-Size="Small">
                    <Columns>

                        <asp:BoundField DataField="ItemCode" HeaderText="Item Code"
                            SortExpression="ItemCode" />

                        <asp:BoundField DataField="ItemDescription" HeaderText="Description"
                            SortExpression="Description" />

                        <asp:BoundField DataField="QtyAdjusted" HeaderText="Quantity Adjusted"
                            SortExpression="QtyAdjusted" />

                        <asp:TemplateField HeaderText="Reason">
                            <ItemTemplate>
                                <asp:TextBox Width="70%" ID="txtReason" runat="server"
                                    Text='<%# Eval("Reason") %>' BorderStyle="None"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="Value" HeaderText="Value"
                            SortExpression="Value" />

                        <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount"
                            SortExpression="TotalAmount" />

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

            </td>
        </tr>

        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
