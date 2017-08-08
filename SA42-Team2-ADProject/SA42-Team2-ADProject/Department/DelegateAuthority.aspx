<%@ Page Title="" Language="C#" MasterPageFile="~/DeptHead.Master" AutoEventWireup="true" CodeBehind="DelegateAuthority.aspx.cs" Inherits="ADProject.Department.DelegateAuthority" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table ll">
        <tr>
            <td colspan="3">
                <h3 class="text-center">Delegate Authority</h3>
            </td>
        </tr>
        <tr>
            <td>&nbsp &nbsp &nbsp &nbsp &nbsp</td>
            <td>
                <h5 style="text-align:right">To Whom:</h5>

            </td>
            <td>
                   <asp:DropDownList  Width="41%" ID="ddlToWhom" runat="server" OnDataBound="ddlToWhom_DataBound" AutoPostBack="True" OnSelectedIndexChanged="ddlToWhom_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align:center">
                            <asp:Button ID="btnDelegate" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            </td>
        </tr>
    </table>
    
</asp:Content>
