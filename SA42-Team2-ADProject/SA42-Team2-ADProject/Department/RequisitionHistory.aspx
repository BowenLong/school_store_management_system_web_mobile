<%@ Page Title="" Language="C#" MasterPageFile="~/DeptStaff.Master" AutoEventWireup="true" CodeBehind="RequisitionHistory.aspx.cs" Inherits="ADProject.Department.RequisitionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<table class="table ll">
        <tr>
            <td>
                 <h3 style="text-align:center">Requisition History</h3>
            </td>
        </tr>
        <tr>
            <td> <div class="row">
        <div class="col-xs-12" style="text-align: center">
           
            <div class="col-xs-12">
                &nbsp
            </div>
            <div class="col-xs-12">
                &nbsp
            </div>
        </div>
        <div class="col-xs-2" style="text-align: right">From Date: </div>
        <div class="col-xs-3" style="text-align: left">
            <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-xs-2" style="text-align: right">To Date: </div>
        <div class="col-xs-3" style="text-align: left">
            <asp:TextBox ID="txtToDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-xs-2"></div>
        <div class="row"></div>
        <div class="col-xs-7"></div>
        <div class="col-xs-4">
            <asp:CompareValidator ID="cvDate" runat="server" ControlToCompare="txtToDate" ControlToValidate="txtFromDate" Display="Dynamic" ErrorMessage="Please select the date after the start date" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
        </div>

    </div>
 <div class="row">
        <div class="col-xs-12">
            &nbsp
        </div>
        <div class="col-xs-12" style="text-align: center">
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </div>
        <div class="col-xs-12">
            &nbsp
        </div>
        <div class="col-xs-12">
            &nbsp
        </div>
        </div>

            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                 <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="RequestDate" HeaderText="IssuedDate"></asp:BoundField>
                                <asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>
