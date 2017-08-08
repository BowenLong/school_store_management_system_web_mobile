<%@ Page Title="" Language="C#" MasterPageFile="~/DeptHead.Master" AutoEventWireup="true" CodeBehind="DepartmentHeadRequisitionDetail.aspx.cs" Inherits="ADProject.Department.DepartmentHeadRequisitionDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table ll">
        <tr>
            <td>
                  <h3 style="text-align: center">Stationery Details List For Requisition</h3>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:GridView ID="gvReguisitionDetail" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Stationery.Description" HeaderText="Item Description" ></asp:BoundField>
                    <asp:BoundField DataField="Qty" HeaderText="Qutantity" ></asp:BoundField>
                </Columns>
            </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align:center">
                 <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" />
                 <asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
            </td>
        </tr>
    </table>

</asp:Content>
