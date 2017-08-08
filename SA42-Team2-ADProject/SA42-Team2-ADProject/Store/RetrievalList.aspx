<%@ Page Title="" Language="C#" MasterPageFile="~/StoreStaff.Master" AutoEventWireup="true" CodeBehind="RetrievalList.aspx.cs" Inherits="ADProject.Store.RetrievalList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <table class="table ll">
        <tr>
            <td colspan="3" style="text-align: center"><h3>Retrieval List</h3>
            </td>
        </tr>

        <tr>
            <td style="width:20%"></td>
            <td style="text-align:right"><h5>Date: </h5></td>
            <td style="text-align:left">
                <asp:DropDownList Width="60%" ID="ddlRetrievalDate" runat="server">
                </asp:DropDownList>
            </td>
            


        </tr>

        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>

        </tr>

        <tr>
            <td colspan="3">
                <asp:GridView PagerStyle-CssClass="pagination-ys" ID="gvRetrievalList" runat="server" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="gvRetrievalList_PageIndexChanging" PageSize="3">
                    <Columns>
                        <asp:BoundField DataField="Bin" HeaderText="Bin No." />

                        <asp:TemplateField HeaderText="Retrieval List">
                            <ItemTemplate>
                                <asp:GridView PagerStyle-CssClass="pagination-ys" ID="stationery" DataSource='<%# Bind("Stationeries")%>' runat="server" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField DataField="Description" HeaderText="Stationery Description" />
                                        <asp:BoundField DataField="TotalRequest" HeaderText="Needed" />
                                        <asp:TemplateField HeaderText="Breakdown By Dept">
                                            <ItemTemplate>
                                                <asp:GridView ID="list" DataSource='<%# Bind("detailList")%>' runat="server" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:BoundField DataField="DepartmentName" HeaderText="Department" />
                                                        <asp:BoundField DataField="Needed" HeaderText="Needed" />
                                                        <asp:BoundField DataField="Given" HeaderText="Actual" />
                                                    </Columns>
                                                </asp:GridView>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>

    </table>




</asp:Content>
