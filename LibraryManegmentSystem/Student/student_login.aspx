<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student_login.aspx.cs" Inherits="LibraryManegmentSystem.Student.login" %>

<!DOCTYPE html>

<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7" lang=""> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8" lang=""> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9" lang=""> <![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js" lang="en">
<!--<![endif]-->

<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Library Login</title>
    <meta name="description" content="Sufee Admin - HTML5 Admin Template">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="apple-touch-icon" href="apple-icon.png">
    <link rel="shortcut icon" href="favicon.ico">


    <link rel="stylesheet" href="vendors/bootstrap/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="vendors/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="vendors/themify-icons/css/themify-icons.css">
    <link rel="stylesheet" href="vendors/flag-icon-css/css/flag-icon.min.css">
    <link rel="stylesheet" href="vendors/selectFX/css/cs-skin-elastic.css">

    <link rel="stylesheet" href="assets/css/style.css">

    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,600,700,800' rel='stylesheet' type='text/css'>
</head>

<body class="bg-dark">
    <form id="f1" runat="server">


        <div style="text-align: center; text-align-last: center">
            <asp:Button ID="Button2" runat="server" class="btn btn-success" Text="Homepage" OnClick="b2_Click" />

        </div>

        <div class="sufee-login d-flex align-content-center flex-wrap">
            <div class="container">
                <div class="login-content">
                    <div class="login-logo">
                        <a href="index.html">
                            <h1 style="color: white">LOGIN</h1>
                        </a>
                    </div>
                    <div class="login-form">
                        <div class="form-group">
                            <label>User Name</label>
                            <asp:TextBox ID="username" runat="server" class="form-control" placeholder="username"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Password</label>
                            <asp:TextBox ID="password" runat="server" class="form-control" placeholder="passowrd" TextMode="password"></asp:TextBox>
                            <label for="showPassword">
                                <input type="checkbox" id="showPassword" />
                                Show Password</label>

                        </div>

                        <div>
                            <asp:Image ID="imgCaptcha" runat="server" Width="160" Height="40" OnClick="imgCaptcha_Click" />

                            <asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>
                        </div>

                        <div>
                            <asp:Button ID="b1" runat="server" class="btn btn-success btn-flat m-b-30 m-t-30" Text="Login" OnClick="b1_Click"></asp:Button>
                        </div>

                        <div class="alert alert-danger" id="error" runat="server" style="margin-top: 10px; display: none">
                            <strong>Invalid username or password!</strong>
                        </div>
                        <div id="Div1" runat="server" class="alert alert-danger" style="margin-top: 10px; display: none">
                            <strong>Wrong Captcha!</strong>
                        </div>

                        <div class="register-link m-t-15 text-center">
                            <p>Don't have an account? <a href="student_registration.aspx">Sign Up Here</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#showPassword').click(function () {
                $('#password').attr('type', $(this).is(':checked') ? 'text' : 'password');
            });
        });


    </script>


    <script src="vendors/jquery/dist/jquery.min.js"></script>
    <script src="vendors/popper.js/dist/umd/popper.min.js"></script>
    <script src="vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="assets/js/main.js"></script>


</body>

</html>
