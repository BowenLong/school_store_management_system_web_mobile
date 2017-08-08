<%@ Page Title="" Language="C#" MasterPageFile="~/DeptStaff.Master" AutoEventWireup="true" CodeBehind="NewRequisition.aspx.cs" Inherits="ADProject.NewRequisition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table ll">
       <tr>
           <td>
               <h3 class="text-center">New Requisition</h3>
           </td>
       </tr>
       <tr>
           <td>
               <div class="row">
                  
               <div class="col-xs-4" style="text-align: right">Date: </div>
        <div class="col-xs-3" style="text-align: left">
            <asp:Label ID="lblDate" runat="server" Style="text-align: right" Text="xx/xx/xxxx "></asp:Label>
        </div>

        <div class="col-lg-12">&nbsp</div>

        <div class="row"></div>

        <div class="col-xs-4" style="text-align: right">Category: </div>
        <div class="col-xs-6" style="text-align: left">
            <asp:DropDownList  Width="41%" ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="col-xs-2"></div>

        <div class="row"></div>

        <div class="col-xs-4" style="text-align: right">Item Description: </div>
        <div class="col-xs-6" style="text-align: left">
            <asp:DropDownList  Width="41%" ID="ddlItemDescription" runat="server">
            </asp:DropDownList>
        </div>
        <div class="col-xs-2"></div>

        <div class="row"></div>

        <div class="col-xs-4" style="text-align: right">Quantity: </div>
        <div class="col-xs-6" style="text-align: left">
            <asp:TextBox Width="41%" ID="txtQuantity" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            <asp:RegularExpressionValidator ID="regQuantity" runat="server" ControlToValidate="txtQuantity" Display="Dynamic" ErrorMessage="Please enter a valid Quantity" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
        </div>
        <div class="col-xs-2"></div>

        <div class="col-xs-12">&nbsp</div>

        <div class="col-xs-12" style="text-align: center">
            <asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" />
        </div>
        <div class="col-xs-12">&nbsp</div>
    </div>
           </td>
       </tr>

       <tr>
           <td>
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" OnRowDeleting="gvList_RowDeleting">
                        <Columns>

                            <asp:BoundField DataField="ItemCode" HeaderText="Item Code"
                                SortExpression="ItemCode" />

                            <asp:BoundField DataField="ItemDescription" HeaderText="Description"
                                SortExpression="Description" />

                            <asp:TemplateField HeaderText="Qty">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQty" runat="server"
                                        Text='<%# Eval("Qty") %>' BorderStyle="None" CssClass="form-control centered"></asp:TextBox>
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
           <td  style="text-align: center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
           </td>
       </tr>
   </table>
</asp:Content>
