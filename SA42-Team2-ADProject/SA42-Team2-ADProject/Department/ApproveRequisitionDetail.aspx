<%@ Page Title="" Language="C#" MasterPageFile="~/DeptStaff.Master" AutoEventWireup="true" CodeBehind="ApproveRequisitionDetail.aspx.cs" Inherits="ADProject.Department.ApproveRequisitionDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table class="table ll">
        <tr>
            <td colspan="3"> <h3 style="text-align: center">Stationery Details List For Requisition</h3></td>
        </tr>
        <tr>
            <td colspan="3"><asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Stationery.Description" HeaderText="Item Description" ></asp:BoundField>
                    <asp:BoundField DataField="Qty" HeaderText="Qutantity" ></asp:BoundField>
                </Columns>
            </asp:GridView></td>
        </tr>
        <tr>
            <td style="text-align:center"> <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click"/></td>
            <td style="text-align:center"><asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click"/></td>
             <td style="text-align:center"><asp:Button ID="btnCancel" runat="server" Text="Back"/></td>
        </tr>
    </table>
</asp:Content>
