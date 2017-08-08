<%@ Page Title="" Language="C#" MasterPageFile="~/StoreSuperviser.Master" AutoEventWireup="true" CodeBehind="StoreSupervisorSupplierList.aspx.cs" Inherits="ADProject.Store.StoreSupervisorSupplierList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table class="table ll">
        <tr>
            <td>
                <h3 class="text-center">Supplier List</h3>
            </td>
        </tr>
        <tr>
            <td>
                    <div class="row">
        <div class="col-xs-12" style="text-align: center">&nbsp</div>
    </div>
                 <div class="row">
        <div class="col-xs-2"></div>
        <div class="col-xs-3" style="text-align:right">Supplier Code:</div>
        <div class="col-xs-3">
            <asp:TextBox ID="txtSupplierCode" runat="server"></asp:TextBox>
        </div>
    </div>


    <div class="row">
        <div class="col-xs-2"></div>
        <div class="col-xs-3" style="text-align:right">Supplier Name:</div>
        <div class="col-xs-3">
            <asp:TextBox ID="txtSupplierName" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-2"></div>
        <div class="col-xs-3" style="text-align:right">Phone No:</div>
        <div class="col-xs-3">
            <asp:TextBox ID="txtPhoneNo" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-2"></div>
        <div class="col-xs-3" style="text-align:right">GST Registration No:</div>
        <div class="col-xs-3">
            <asp:TextBox ID="txtGSTRegistrationNo" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-2"></div>
        <div class="col-xs-3" style="text-align:right">Fax No:</div>
        <div class="col-xs-3">
            <asp:TextBox ID="txtFaxNo" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-2"></div>
        <div class="col-xs-3" style="text-align:right">Contact Name:</div>
        <div class="col-xs-3">
            <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-2"></div>
        <div class="col-xs-3" style="text-align:right">Address:</div>
        <div class="col-xs-3">
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        </div>
    </div>


    <div class="row">
        <div class="col-xs-12" style="text-align: center">&nbsp</div>
    </div>


    <div class="row">
        <div class="row">
            <div class="col-xs-12" style="text-align: center">
                <asp:Button ID="btnAddNew" runat="server" Text="Add New" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
            </div>
        </div>
    </div>
       <div class="row">
        <div class="col-xs-12" style="text-align: center">&nbsp</div>
    </div>
    <div class="row">
        <div class="col-xs-12" style="text-align: center">&nbsp</div>
    </div>
            </td>
        </tr>
        <tr>
            <td>  <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false">
        <%--OnRowDeleting="gvList_RowDeleting">--%>
        <Columns>

            <asp:BoundField DataField="SupplierId" HeaderText="Supplier Code"
                SortExpression="ItemCode" />

            <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name"
                SortExpression="Description" />

            <asp:BoundField DataField="ContactName" HeaderText="Contact Name"
                SortExpression="Description" />

            <asp:BoundField DataField="GST_Registration_No" HeaderText="GST Registration No"
                SortExpression="Description" />

            <asp:BoundField DataField="Phone_No" HeaderText="Phone No"
                SortExpression="Description" />

            <asp:BoundField DataField="Fax_No" HeaderText="Fax No"
                SortExpression="Description" />

            <asp:BoundField DataField="Address" HeaderText="Address"
                SortExpression="Description" />

            <%--                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQty" runat="server"
                                Text='<%# Eval("Qty") %>' BorderStyle="None"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>--%>


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
    </table>


</asp:Content>
