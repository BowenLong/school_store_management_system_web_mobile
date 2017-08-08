<%@ Page Title="" Language="C#" MasterPageFile="~/StoreStaff.Master" AutoEventWireup="true" CodeBehind="DisbursementList.aspx.cs" Inherits="ADProject.Store.DisbursementList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table ll">
        <tr>
            <td colspan="3" style="text-align: center">Disbursement List
            </td>
        </tr>

        <tr>
            <td>From Date:</td>
            <td>
                <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date"></asp:TextBox></td>
        </tr>
        <tr>
            <td>To Date:</td>
            <td>
                <asp:TextBox ID="txtToDate" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>


        <tr>
            <td>
                     <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </td>
        </tr>

    </table>
   
</asp:Content>
