<%@ Page Title="" Language="C#" MasterPageFile="~/StoreManager.Master" AutoEventWireup="true" CodeBehind="ApproveAdjustment.aspx.cs" Inherits="ADProject.Store.ApproveAdjustment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <table class="table ll">
        <tr>
            <td>
                <h3 style="text-align: center">Adjustment Voucher To Approve</h3>
            </td>
        </tr>

        <tr>
            <td>
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" OnRowCommand="gvList_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="AdjustmentVCId" HeaderText="Voucher No." Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="IssuedDate" HeaderText="IssuedDate"></asp:BoundField>
                        <asp:BoundField DataField="Employee.EmployeeName" HeaderText="Employee Name" ReadOnly="True" InsertVisible="False"></asp:BoundField>                        
                        <asp:ButtonField ControlStyle-CssClass="btn btn-default" CommandName="ButtonField" Text="View" ButtonType="Button" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
