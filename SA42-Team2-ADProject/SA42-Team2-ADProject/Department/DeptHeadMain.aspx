<%@ Page Title="" Language="C#" MasterPageFile="~/DeptHead.Master" AutoEventWireup="true" CodeBehind="DeptHeadMain.aspx.cs" Inherits="ADProject.DeptHeadMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
      <h1> <img src="../Images/profile.png" alt="..."class="img-circle" style="height:140px;width:140px"  />
            WELCOME "<asp:Label ID="lblUsername" runat="server" Text="Label"></asp:Label>"
       </h1>
        </div>
</asp:Content>
