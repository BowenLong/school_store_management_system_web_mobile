<%@ Page Title="" Language="C#" MasterPageFile="~/DeptStaff.Master" AutoEventWireup="true" CodeBehind="CancelRequisitionDetail.aspx.cs" Inherits="ADProject.CancelRequisitionDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table class="table ll">
        <tr>
            <td> <div style="text-align: center">
            <asp:Label ID="lblCancelRequisitionDetail" runat="server" Font-Size="Medium" Style="font-weight: 700; text-align: center;" Text="Cancel Requisition"></asp:Label>
       </div></td>
        </tr>
        <tr>
            <td  style="text-align: center">
                 <asp:GridView ID="gvRequisitionDetail" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Stationery.Description" HeaderText="Item Description"></asp:BoundField>
                            <asp:BoundField DataField="Qty" HeaderText="Qutantity"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
            </td>
        </tr>
        <tr>
            <td  style="text-align: center">
                <asp:Button ID="btnCancel" runat="server" Text="Submit" OnClick="btnCancel_Click" />

                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            </td>
        </tr>
    </table>
   

</asp:Content>
