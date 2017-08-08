<%@ Page Title="" Language="C#" MasterPageFile="~/StoreStaff.Master" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="ADProject.Store.ManageProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Search Block --%>
    <table class="table ll">

        <tr>
            <td colspan="3" style="text-align: center">
                <h3>Manage Stock</h3>
            </td>
        </tr>

        <tr>
            <td>
                <table class="table ll">
                    <tr>
                        <td>
                            <h5 style="text-align: right">Category</h5>
                        </td>
                        <td>
                            <asp:DropDownList Width="80%" ID="ddlSearchCategory" runat="server" OnSelectedIndexChanged="ddlSearchCategory_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h5 style="text-align: right">Item Description</h5>
                        </td>
                        <td>
                            <asp:DropDownList Width="80%" ID="ddlSearchItemCode" runat="server"></asp:DropDownList>

                        </td>
                    </tr>
                    <tr>

                        <td colspan="2" class="text-center">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%-- End Search Block --%>
        <tr>
            <td>
                <table class="table ll">
                    <tr>
                        <td>
                            <h5 style="text-align: right">Item ID</h5>
                        </td>
                        <td>
                            <asp:TextBox ID="txtItemId" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="VLItemId" ControlToValidate="txtItemId" Display="Dynamic" runat="server" ErrorMessage="Can not be blank."></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h5 style="text-align: right">Category</h5>
                        </td>
                        <td>
                            <asp:DropDownList Width="59%" ID="ddlCategory" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h5 style="text-align: right">Description</h5>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="VLDescription" ControlToValidate="txtDescription" Display="Dynamic" runat="server" ErrorMessage="Can not be blank."></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h5 style="text-align: right">Reorder Level</h5>
                        </td>
                        <td>
                            <asp:TextBox ID="txtReorderLevel" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="VLReorderLevel" ControlToValidate="txtReorderLevel" Display="Dynamic" runat="server" ErrorMessage="Can not be blank."></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h5 style="text-align: right">Reorder Qty</h5>
                        </td>
                        <td>
                            <asp:TextBox Width="15%" ID="txtReorderQty" runat="server" TextMode="Number"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="VLReorderQty" ControlToValidate="txtReorderQty" Display="Dynamic" runat="server" ErrorMessage="Can not be blank."></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h5 style="text-align: right">Unit Measure</h5>
                        </td>
                        <td>
                            <asp:DropDownList Width="59%" ID="ddlUnitMeasure" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h5 style="text-align: right">Bin#</h5>
                        </td>
                        <td>
                            <asp:DropDownList Width="59%" ID="ddlBin" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h5 style="text-align: right">1st Supplier</h5>
                        </td>
                        <td>
                            <asp:DropDownList Width="59%" ID="ddl1stSupplier" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h5 style="text-align: right">Price</h5>
                        </td>
                        <td>
                            <asp:TextBox Width="15%" ID="txtPrice1" runat="server" TextMode="Number"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h5 style="text-align: right">2nd Supplier</h5>
                        </td>
                        <td>
                            <asp:DropDownList Width="59%" ID="ddl2ndSupplier" runat="server"></asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h5 style="text-align: right">Price</h5>
                        </td>
                        <td>
                            <asp:TextBox Width="15%" ID="txtPrice2" runat="server" TextMode="Number"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h5 style="text-align: right">3rd Supplier</h5>
                        </td>
                        <td>
                            <asp:DropDownList Width="59%" ID="ddl3rdSupplier" runat="server"></asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h5 style="text-align: right">Price</h5>
                        </td>
                        <td>
                            <asp:TextBox Width="15%" ID="txtPrice3" runat="server" TextMode="Number"></asp:TextBox>

                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" style="text-align: center">

                            <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" />

                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>

                <asp:GridView PagerStyle-CssClass="pagination-ys" ID="gvList" runat="server" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gvList_PageIndexChanging">

                    <Columns>

                        <asp:BoundField DataField="StationeryId" HeaderText="Item Code" />

                        <asp:BoundField DataField="Category.CategoryDescription" HeaderText="Category" />

                        <asp:BoundField DataField="Description" HeaderText="Item Description" />

                        <asp:BoundField DataField="UOM.UOMDescription" HeaderText="UOM" />

                        <asp:BoundField DataField="StorageBin.Bin" HeaderText="Bin" />

                        <asp:BoundField DataField="ReorderLevel" HeaderText="Reorder Level" />

                        <asp:BoundField DataField="ReorderQuantity" HeaderText="Reorder Qty" />
                    </Columns>

                </asp:GridView>

            </td>
        </tr>

    </table>
</asp:Content>
