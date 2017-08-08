<%@ Page Title="" Language="C#" MasterPageFile="~/DeptStaff.Master" AutoEventWireup="true" CodeBehind="DisbursementListing.aspx.cs" Inherits="ADProject.Department.DisbursementListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table ll">
        <tr>
            <td colspan="2" style="text-align: center">Disbursement List
            </td>
        </tr>

        <tr>
            <td style="text-align:right">From Date:</td>
            <td>
                <asp:TextBox Width="41%" ID="txtFromDate" runat="server" TextMode="Date"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">To Date:</td>
            <td>
                <asp:TextBox Width="41%" ID="txtToDate" runat="server" TextMode="Date"></asp:TextBox>
            </td>
           
        </tr>

        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
            
        </tr>


        <tr>
            <td colspan="3" style="text-align:center">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" OnRowCommand="gvList_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="DisbursementDate" HeaderText="Date" />

                        <%-- Show Image In GridView --%>
                        <%--<asp:TemplateField HeaderText="Thumb Image">
                        <ItemTemplate>
                            <asp:Image ID="imgSignature" runat="server" ImageUrl='<%# Bind("SignatureURL") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>--%>


                        <asp:ButtonField ControlStyle-CssClass="btn btn-default" CommandName="ButtonField" Text="View" ButtonType="Button" />

                    </Columns>
                </asp:GridView>
            </td>
        </tr>

    </table>

</asp:Content>
