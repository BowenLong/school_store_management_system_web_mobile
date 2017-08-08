<%@ Page Title="" Language="C#" MasterPageFile="~/StoreStaff.Master" AutoEventWireup="true" CodeBehind="PurchasingOrder.aspx.cs" Inherits="ADProject.PurchasingOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-xs-12" style="text-align: center">
            <asp:Label ID="lblNewRequisition" runat="server" Text="Purchasing Order" Font-Size="Medium" Style="font-weight: 700"></asp:Label>
        </div>
        <div></div>
        <div class="col-xs-3" style="text-align: right">PO Number :  </div>
        <div class="col-xs-3" style="text-align: left">
            <asp:Label ID="lblPONumber" runat="server" Text="Label"></asp:Label>
        </div>
        </div>
                 <div class="col-xs-4" style="text-align: right">Supplier : </div>
        <div class="col-xs-6" style="text-align: left">
            <asp:DropDownList ID="ddlSupplier" runat="server"></asp:DropDownList>
        </div>

    <div>
        <div class="col-xs-3" style="text-align: right">Expected Delivery Date: </div>
        <div class="col-xs-3" style="text-align: left">
            <asp:TextBox ID="txtDeliveryDate" runat="server" TextMode="Date"></asp:TextBox>
<%--            <asp:Label ID="lbNowDate" runat="server" Text="Label"></asp:Label>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Selected Wrong Date " ControlToValidate="txtDeliveryDate" ControlToCompare="lbNowDate" Operator="GreaterThan"></asp:CompareValidator>--%>
        </div>

        <div class="col-lg-12">&nbsp</div>

        <div class="row"></div>
        </div>

    <div>
          <div class="col-xs-4" style="text-align: right">Category: </div>
        <div class="col-xs-6" style="text-align: left">
            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
            </asp:DropDownList>

   
        </div>
        <div class="col-xs-2"></div>

        <div class="row"></div>

        <div class="col-xs-4" style="text-align: right">Item Description: </div>
        <div class="col-xs-6" style="text-align: left">
            <asp:DropDownList ID="ddlDescription" runat="server">
            </asp:DropDownList>
        </div>
        <div class="col-xs-2"></div>s

        <div class="row"></div>

        <div class="col-xs-4" style="text-align: right">Quantity: </div>
        <div class="col-xs-6" style="text-align: left">
            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="regQuantity" runat="server" ControlToValidate="txtQuantity" Display="Dynamic" ErrorMessage="Please enter a valid Quantity" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
        </div>
        <div class="col-xs-2"></div>

        <div class="col-xs-12">&nbsp</div>
        <div class="col-xs-12">&nbsp</div>

        <div class="col-xs-12" style="text-align: center">
            <asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-xs-12" style="text-align: center">
          <%--  <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" OnRowDeleting="gvList_RowDeleting">
                <Columns>

                    <asp:BoundField DataField="ItemCode" HeaderText="Item Code"
                        SortExpression="ItemCode" />

                    <asp:BoundField DataField="ItemDescription" HeaderText="Description"
                        SortExpression="Description" />

                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQty" runat="server"
                                Text='<%# Eval("Qty") %>' BorderStyle="None"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server"
                                CommandName="Delete"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>--%>

            <asp:GridView ID="gvPurchasingOrder" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvPurchasingOrder_RowDeleting " Font-Size="X-Small">
                      <Columns>

                    <asp:BoundField DataField="ItemCode" HeaderText="Item Code"
                        SortExpression="ItemCode" />

                    <asp:BoundField DataField="ItemDescription" HeaderText="Description"
                        SortExpression="Description" />

                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQty" runat="server"
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
                SelectCommand="SELECT Stationery.Description, Stationery.ReorderLevel AS ReorderQuantity, UOM.UOMDescription, Stationery.Price1 AS Price FROM Reminder INNER JOIN Stationery ON Reminder.StationeryId = Stationery.StationeryId INNER JOIN UOM ON Stationery.UOMId = UOM.UOMId WHERE (Reminder.Status = 1) AND (Reminder.ReminderType = N'reorder')">
            </asp:SqlDataSource>
        </div>

<div style="width: auto; text-align: center">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>

           </div>

        

</asp:Content>
