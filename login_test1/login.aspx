<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="login_test1.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <style>
        .login-container {
            width: 300px;
            margin: 100px auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            background-color: #f9f9f9;
        }
        .form-group {
            margin-bottom: 15px;
        }
        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 3px;
            box-sizing: border-box;
        }
        .btn-login {
            width: 100%;
            padding: 10px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            font-size: 16px;
        }
        .btn-login:hover {
            background-color: #0056b3;
        }
        .message {
            color: red;
            margin-top: 10px;
            text-align: center;
        }
        h2 {
            text-align: center;
            color: #333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>User Login</h2>
            
            <div class="form-group">
                <asp:Label Text="Username:" runat="server" />
                <asp:TextBox ID="txtUsername" runat="server" placeholder="Enter username" />
            </div>
            
            <div class="form-group">
                <asp:Label Text="Password:" runat="server" />
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" placeholder="Enter password" />
            </div>
            
            <asp:Button ID="btnLogin" Text="Login" CssClass="btn-login" OnClick="btnLogin_Click" runat="server" />
            
            <asp:Label ID="lblMessage" CssClass="message" runat="server" Text="" />
        </div>
    </form>
</body>
</html>