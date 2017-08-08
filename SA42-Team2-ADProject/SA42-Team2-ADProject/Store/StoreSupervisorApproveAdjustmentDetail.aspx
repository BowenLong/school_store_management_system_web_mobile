<%@ Page Title="" Language="C#" MasterPageFile="~/StoreSuperviser.Master" AutoEventWireup="true" CodeBehind="StoreSupervisorApproveAdjustmentDetail.aspx.cs" Inherits="ADProject.Store.StoreSupervisorApproveAdjustmentDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table ll">
        <tr>
            <td colspan="3">
                <h3 style="text-align: center">Details List For Adjustment Voucher</h3>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvReguisitionDetail" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Stationery.Description" HeaderText="Item Description"></asp:BoundField>
                        <asp:BoundField DataField="QtyAdjusted" HeaderText="Qutantity"></asp:BoundField>
                        <asp:BoundField DataField="Value" HeaderText="Value"></asp:BoundField>
                        <asp:BoundField DataField="Reason" HeaderText="Reason"></asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click"/></td>
            <td style="text-align: center">
                <asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click"/></td>
            <td style="text-align: center">
                <asp:Button ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_Click"/></td>
        </tr>
    </table>
</asp:Content>
