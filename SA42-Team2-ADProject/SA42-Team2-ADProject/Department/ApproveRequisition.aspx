<%@ Page Title="" Language="C#" MasterPageFile="~/DeptStaff.Master" AutoEventWireup="true" CodeBehind="ApproveRequisition.aspx.cs" Inherits="ADProject.Department.ApproveRequisition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table ll">
        <tr>
            <td>
                <h3 style="text-align: center">Stationery Requisition To Approve</h3>
            </td>
        </tr>
        <tr>
            <td>
                <h4 class="text-center"><asp:Label ID="lblNoRequi" runat="server" Text=""></asp:Label></h4>
                <asp:GridView ID="gvRequisitionList" runat="server" AutoGenerateColumns="false" OnRowCommand="gvRequisitionList_RowCommand">
                <Columns>
                    <asp:BoundField DataField="RequisitionId" HeaderText="Voucher No." Visible="false"></asp:BoundField>
                    <asp:BoundField DataField="RequestDate" HeaderText="Request Date" ></asp:BoundField>
                    <asp:BoundField DataField="Employee.EmployeeName" HeaderText="Employee Name" ReadOnly="True" InsertVisible="False" ></asp:BoundField>                    
                    <asp:ButtonField CommandName="ButtonField" Text="View" ButtonType="Button" />
                </Columns>
            </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
