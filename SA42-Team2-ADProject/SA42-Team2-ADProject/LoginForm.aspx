<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="ADProject.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximun-scale=1, user-scalable=no" />


    <title>Login</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="css/else.css" rel="stylesheet" />
    <link href="css/Signin.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="http://cdn.bootcss.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="http://cdn.bootcss.com/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script src="http://code.jquery.com/jquery.js"></script>
    <script src="<%= Page.ResolveClientUrl("~/js/bootstrap.min.js") %>"></script>

    <script type="text/javascript">
        $(function () {
            $("#btnLogin").removeClass("btn btn-default");
            $("#btnLogin").addClass("btn btn-info btn-lg btn-block");
        });
    </script>

    <style>
        body {
            background: url('Images/bg.jpg');
        }
    </style>

</head>
<body  style="background-size:cover; background-repeat:no-repeat; background-position:center center">
    <div class="container">
        <div class="well" style="width: 35%; margin: auto">
            <form class="form-signin" runat="server">
                <div class="navbar navbar-inverse">
                    <div class="container-fluid">
                        <div class="navbar-header">
                            <a class="navbar-brand">
                                <img alt="logo" src="Images/logo.png" style="height: 30px; width: auto;" /></a>
                            <div class="navbar-brand">Please Login</div>

                        </div>
                    </div>
                </div>


                <asp:TextBox ID="txtUserName" Width="100%" CssClass="form-control" runat="server" placeholder="User Name" AutoCompleteType="Disabled"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtPassword"  Width="100%"   CssClass="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                <br />
                <%--<button id="btnLogin" class="btn btn-info btn-lg btn-block">Login</button><br />--%>
                <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-info btn-lg btn-block" OnClick="btnLogin_Click" />
                
            </form>
        </div>
    </div>
</body>
</html>
