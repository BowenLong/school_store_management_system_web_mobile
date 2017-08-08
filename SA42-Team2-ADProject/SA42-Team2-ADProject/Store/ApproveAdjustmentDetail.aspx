<%@ Page Title="" Language="C#" MasterPageFile="~/StoreManager.Master" AutoEventWireup="true" CodeBehind="ApproveAdjustmentDetail.aspx.cs" Inherits="ADProject.Store.ApproveAdjustmentDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table class="table ll">
        <tr>
            <td colspan="3">
                <h3 style="text-align: center">Stationery Details List For Requisition</h3>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvReguisitionDetail" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Stationery.Description" HeaderText="Item Description"></asp:BoundField>
                        <asp:BoundField DataField="QtyAdjusted" HeaderText="Qutantity"></asp:BoundField>
                        <asp:BoundField DataField="Value" HeaderText="Qutantity"></asp:BoundField>
                        <asp:BoundField DataField="Reason" HeaderText="Qutantity"></asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" /></td>
            <td style="text-align: center">
                <asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click" /></td>
            <td style="text-align: center">
                <asp:Button ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_Click" /></td>
        </tr>
    </table>

    <div class="row">
        <div class="col-md-12">
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
        </div>
    </div>
    <div class="row">
        <div class="col-xs-6" style="text-align: center">
        </div>
        <div class="col-xs-6" style="text-align: center">
        </div>

    </div>
</asp:Content>
