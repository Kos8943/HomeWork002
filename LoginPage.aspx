<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="HomeWork002.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        body {
            width: 100%;
            height: 100%;
            margin: 0;
            background-color: rgb(17,120,216);
            font-family: 'Segoe UI',Arial,'Microsoft Jhenghei',sans-serif;
         

        }

        .MainArea {
            width: 100%;
            height: 100%;
            margin-top: 13%;
            /* transform:translateY(-90%);*/
        }

        .LoginArea {
            text-align: center;
            
        }

        .tittle {
            text-align: center;
            font-size: 30px;
            font-weight: bolder;
            color: rgb(233,233,233);
        }

        .InputArea {
            width: 320px;
            height: 236px;
            margin: auto;
            padding-top:16px;
            background-color:rgba(89,167,225,.6);
            border-radius:5px;
        }

        .account{
            display:flex;
            padding-top:16px;
            padding-left:16px;
            padding-bottom:16px;
        }

        .ImgSize {
            width: 28px;
            height: 28px;
           /* margin: 16px 8px 16px 16px;*/
           margin-right:8px;
        }

        .InputSize {
            width:246px;
            height:28px;
            border:0px;
            background-color:rgba(255,255,255,0);
            font-family: 'Segoe UI',Arial,'Microsoft Jhenghei',sans-serif;
        }

        .InputSize:focus{
            outline:none;
        }

        .Line{
            width:100%;
            border-bottom:1px solid rgb(250,250,250);
            margin-bottom:16px;
            opacity:.3;
        }

        .btnLogin{
            width:278px;
          
            height:38px;
            font-family: 'Segoe UI',Arial,'Microsoft Jhenghei',sans-serif;
            background-color:rgb(5,139,233);
            border:1px solid rgba(0, 0, 0,.1);
            border-radius:5px;
            font-size:20px;
            color:rgba(253,253,253,.8);
            font-weight:bold;
            outline:none;
        }

        
    </style>
</head>
<body>
    <form class="MainArea" id="form1" runat="server">

        <div class="LoginArea">
            <div class="tittle">YUBAY</div>
            <div class="InputArea">
                <div class="account">
                    <asp:Image src="./Imgs/iconfinder_User_5431752.svg" ID="Image1" runat="server" class="ImgSize" />
                    <asp:TextBox ID="account" autocomplete="off" runat="server" CssClass="InputSize"></asp:TextBox>
                </div>
                <div class="Line"></div>
                <div class="account">
                    <asp:Image src="./Imgs/iconfinder_Safety01_928417.svg" ID="Image2" runat="server" class="ImgSize" />
                    <asp:TextBox ID="password" autocomplete="off" TextMode="Password" runat="server" CssClass="InputSize"></asp:TextBox>
                </div>
                <div class="Line"></div>
                <asp:Button ID="Button1" runat="server" Text="登入" CssClass="btnLogin" OnClick="Button1_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
