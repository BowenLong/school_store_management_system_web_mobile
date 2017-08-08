<%@ Page Title="" Language="C#" MasterPageFile="~/DeptStaff.Master" AutoEventWireup="true" CodeBehind="CancelRequisition.aspx.cs" Inherits="ADProject.CancelRequisition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="table ll">
        <tr>
            <td>
                <h3 style="text-align: center">Cancel Requisition</h3>
            </td>
        </tr>
        <tr>
            <td>
                <div class="row">
                    <div class="col-xs-12" style="text-align: center">
                    </div>
                    <div class="col-xs-12">&nbsp</div>
                    <div class="col-xs-2" style="text-align: right">
                        <asp:Label ID="lblFromDate" runat="server" Text="From Date :"></asp:Label>
                    </div>
                    <div class="col-xs-3">
                        <asp:TextBox CssClass="form-control" ID="txtFromDate" runat="server" TextMode="Date"></asp:TextBox>

                    </div>
                    <div class="col-xs-2" style="text-align: right">
                        <asp:Label ID="lblToDate" runat="server" Text="To Date :"></asp:Label>

                    </div>
                    <div class="col-xs-3">
                        <asp:TextBox CssClass="form-control" ID="txtToDate" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="row"></div>
                    <div class="col-xs-7"></div>
                    <div class="col-xs-4">
                        <asp:CompareValidator ID="cvDate" runat="server" ControlToCompare="txtToDate" ControlToValidate="txtFromDate" Display="Dynamic" ErrorMessage="Please select the date after the start date" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
                    </div>

                    <div class="col-xs-12">
                        &nbsp
                    </div>
                    <div class="col-xs-12">
                        &nbsp
                    </div>

                    <div class="col-xs-12" style="text-align: center">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    </div>
                    <div class="col-xs-12">
                        &nbsp
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:GridView CssClass="form-control centered" ID="gvRequisitionList" runat="server" OnRowCommand="gvRequisitionList_RowCommand" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="RequestDate" HeaderText="IssuedDate"></asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
                        <asp:ButtonField ControlStyle-CssClass="btn btn-default" CommandName="ButtonField" Text="View" ButtonType="Button" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>
