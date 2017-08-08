<%@ Page Title="" Language="C#" MasterPageFile="~/StoreStaff.Master" AutoEventWireup="true" CodeBehind="DisbursementStatus.aspx.cs" Inherits="ADProject.Store.DisbursementStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table ll">
       <tr>
           <td>
                <div class="col-xs-12" style="text-align: center">
            <h3>Disbursement Status </h3>
        </div>
           </td>
       </tr>

   </table>
    

     <div class="row">
       
        <div class="col-xs-2"></div>

        <div class="col-xs-4" style="text-align: right">Collection Point: </div>
        <div class="col-xs-4">
            <asp:Label ID="lblCollectionPoint" runat="server" Style="text-align: center" Text=" Point "></asp:Label>
        </div>
        <div class="col-xs-2"></div>
        
        <div class="row"></div>
        
        <div class="col-xs-2"></div>
        <div class="col-xs-4" style="text-align: right">Representative: </div>
        <div class="col-xs-4">
            <asp:Label ID="lblRepresentative" runat="server"></asp:Label>
        </div>
        <div class="col-xs-2"></div>
        <div class="row"></div>
        <div class="col-xs-2"></div>
        <div class="col-xs-4" style="text-align: right">Representative Signature: </div>
        <div class="col-xs-4">
            <asp:Image ID="imgSignature" runat="server" CssClass="img-size" />
        </div>
        <div class="col-xs-2"></div>
        <div class="row"></div>

      

        
    </div>
    <table class="table ll">
        <tr><td  style="text-align: center">

            <asp:GridView ID="gvDisbursementStatus" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Stationery.Description" HeaderText="Item Description" />
                    <asp:BoundField DataField="RequestQty" HeaderText="Needed" />
                    <asp:BoundField DataField="ReceivedQty" HeaderText="Actual" />
                </Columns>
            </asp:GridView>

            </td></tr>
        <tr><td>
            <div class="col-xs-12" style="text-align: center">
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        </div>
            </td></tr>
    </table>
</asp:Content>
