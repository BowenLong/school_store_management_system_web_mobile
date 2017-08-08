<%@ Page Title="" Language="C#" MasterPageFile="~/DeptHead.Master" AutoEventWireup="true" CodeBehind="CollectionPointrepresentative.aspx.cs" Inherits="ADProject.Department.CollectionPointrepresentative" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table ll">
        <tr>
            <td colspan="2">
                <h3 style="text-align: center">Change Collection Point & Representative</h3>
            </td>
        </tr>
        <tr>
            <td>
                <h5 style="text-align: right">Current Collection:</h5>
            </td>
            <td>
                <asp:TextBox ID="txtCurrentCollection" runat="server"
                    ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <h5 style="text-align: right">Collection Point:</h5>
            </td>
            <td>

                <asp:RadioButtonList ID="rblCollectionPoint" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblCollectionPoint_SelectedIndexChanged">
                    <asp:ListItem Value="1">Stationery Store (9:30am)</asp:ListItem>
                    <asp:ListItem Value="2">Management School (11:00am)</asp:ListItem>
                    <asp:ListItem Value="3">Medical School (9:30am)</asp:ListItem>
                    <asp:ListItem Value="4">Enginnering School (11:00am)</asp:ListItem>
                    <asp:ListItem Value="5">Science School (9:30am)</asp:ListItem>
                    <asp:ListItem Value="6">University Hospital (11:00am)</asp:ListItem>
                </asp:RadioButtonList>

            </td>
        </tr>
        <tr>
            <td>
                <h5 style="text-align: right">Current Representative:</h5>
            </td>
            <td>
                <asp:TextBox ID="txtRepresentative" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <h5 style="text-align: right">Change Representative:</h5>
            </td>
            <td>
                <asp:DropDownList Width="41%" ID="ddlRepresentative" runat="server" OnSelectedIndexChanged="ddlRepresentative_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
            </td>


        </tr>
    </table>

</asp:Content>
