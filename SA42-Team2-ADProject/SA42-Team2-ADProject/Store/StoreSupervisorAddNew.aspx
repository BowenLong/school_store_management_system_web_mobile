<%@ Page Title="" Language="C#" MasterPageFile="~/StoreSuperviser.Master" AutoEventWireup="true" CodeBehind="StoreSupervisorAddNew.aspx.cs" Inherits="ADProject.StoreSupervisorAddNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

        <div class="col-xs-2">&nbsp</div>
        <div class="col-xs-2">Item ID</div>
        <div class="col-xs-4">
            <asp:TextBox ID="txtItemId" runat="server"></asp:TextBox>
        </div>
        <div class="col-xs-3">&nbsp</div>

        <div class="row">
            <div class="col-xs-12">&nbsp</div>
        </div>
        <div class="col-xs-2">&nbsp</div>
        <div class="col-xs-2">Category</div>
        <div class="col-xs-4">
            <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
        </div>
        <div class="col-xs-3">&nbsp</div>

        <div class="row"></div>
        <div class="col-xs-2">&nbsp</div>
        <div class="col-xs-2">Description</div>
        <div class="col-xs-4">
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        </div>
        <div class="col-xs-4">&nbsp</div>

        <div class="row"></div>
        <div class="col-xs-2">&nbsp</div>
        <div class="col-xs-2">Reorder Level</div>
        <div class="col-xs-4">
            <asp:TextBox ID="txtReorderLevel" runat="server"></asp:TextBox>
        </div>
        <div class="col-xs-4">&nbsp</div>

        <div class="row"></div>
        <div class="col-xs-2">&nbsp</div>
        <div class="col-xs-2">Unit Measure</div>
        <div class="col-xs-4">
            <asp:DropDownList ID="ddlUnitMeasure" runat="server"></asp:DropDownList>
        </div>
        <div class="col-xs-4">&nbsp</div>

        <div class="row"></div>
        <div class="col-xs-2">&nbsp</div>
        <div class="col-xs-2">Bin# </div>
        <div class="col-xs-4">
            <asp:DropDownList ID="ddlBin" runat="server"></asp:DropDownList>
        </div>
        <div class="col-xs-4">&nbsp</div>

        <div class="row">
            <div class="col-xs-12">&nbsp</div>
        </div>
        <div class="row"></div>
        <div class="col-xs-2">&nbsp</div>
        <div class="col-xs-2">1st Supplier</div>
        <div class="col-xs-4">
            <asp:DropDownList ID="ddl1stSupplier" runat="server"></asp:DropDownList>
        </div>
        <div class="col-xs-4">&nbsp</div>

        <div class="row"></div>
        <div class="col-xs-2">&nbsp</div>
        <div class="col-xs-2">Price</div>
        <div class="col-xs-2">
            <asp:TextBox ID="txtPrice1" runat="server"></asp:TextBox>
        </div>
        <div class="col-xs-4">&nbsp</div>

        <div class="row">
            <div class="col-xs-12">&nbsp</div>
        </div>
        <div class="row"></div>
        <div class="col-xs-2">&nbsp</div>
        <div class="col-xs-2">2nd Supplier</div>
        <div class="col-xs-4">
            <asp:DropDownList ID="ddl2ndSupplier" runat="server"></asp:DropDownList>
        </div>
        <div class="col-xs-4">&nbsp</div>

        <div class="row"></div>
        <div class="col-xs-2">&nbsp</div>
        <div class="col-xs-2">Price</div>
        <div class="col-xs-2">
            <asp:TextBox ID="txtPrice2" runat="server"></asp:TextBox>
        </div>
        <div class="col-xs-4">&nbsp</div>

        <div class="row">
            <div class="col-xs-12">&nbsp</div>
        </div>
        <div class="row"></div>
        <div class="col-xs-2">&nbsp</div>
        <div class="col-xs-2">3rd Supplier</div>
        <div class="col-xs-4">
            <asp:DropDownList ID="ddl3rdSupplier" runat="server"></asp:DropDownList>
        </div>
        <div class="col-xs-4">&nbsp</div>

        <div class="row"></div>
        <div class="col-xs-2">&nbsp</div>
        <div class="col-xs-2">Price</div>
        <div class="col-xs-2">
            <asp:TextBox ID="txtPrice3" runat="server"></asp:TextBox>
        </div>
        <div class="col-xs-4">&nbsp</div>
    </div>

    <div class="row">
        <div class="col-xs-12">&nbsp</div>
    </div>

    <div class="row" style="text-align: center">
        <div class="col-xs-12">
            <asp:Button ID="btnSave" runat="server" Text="Save" />

            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />

        </div>
    </div>
</asp:Content>
