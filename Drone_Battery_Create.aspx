<%@ Page Title="" Language="C#" MasterPageFile="~/MainWebForm.Master" AutoEventWireup="true" CodeBehind="Drone_Battery_Create.aspx.cs" Inherits="HomeWork002.WebForm2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .CreateMainArea {
            width: 100%;
            height: 100%;
            background-color: rgb(243,244,248);
        }

        .CreateArea {
            width: 50%;
            height: 100%;
            background-color: rgb(254,254,254);
            margin: auto;
            padding:2% 5%;

        }

        .tutleLine{
            width:100%;
            height:1px;
            border-bottom:1px solid black;
            margin-bottom:3%;
        }

        .inputMargin{
            margin:0 auto 4% auto;
            width:60%;           
        }

        .bottomArea{
            width:25%;
            margin:auto; 
        }

        .errorMsg{
            font-size:12px;
            color:red;
            /*display:none;*/
        }
        

        .errorMsgArea{
            width:100%;
            padding-left:20%;
        }
    </style>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="CreateMainArea">
        <div class="CreateArea">

            <h1 class="inputMargin" runat="server" id="title">新增電池</h1>

            <div class="tutleLine"></div>

            <div class="errorMsgArea">
                <span class="errorMsg" runat="server" id="BatteryIDmsg" visible="false">*請輸入編號</span>
            </div>
            <div class="inputMargin d-flex justify-content-between">
                <span>電池編號:</span>
                <asp:TextBox ID="TextBatteryName" runat="server" Text=""></asp:TextBox>
            </div>

            <div class="errorMsgArea">
                <span class="errorMsg" runat="server" id="BatteryStatus" visible="false">*請狀態</span>
            </div>
            <div class="inputMargin d-flex justify-content-between">
                <span>使用狀態:</span>
                <asp:TextBox ID="TextBatteryStatus" runat="server" Text=""></asp:TextBox>
            </div>

            <div class="inputMargin d-flex justify-content-between">
                <span>故障原因:</span>
                <asp:TextBox ID="TextStop" runat="server" Text=""></asp:TextBox>
            </div>

            

            <div class="bottomArea d-flex justify-content-between">
                <asp:Button ID="btnUpdate" runat="server" Text="確認" OnClick="Create_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click"/>
            </div>

        </div>
    </div>
</asp:Content>
