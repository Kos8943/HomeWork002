<%@ Page Title="" Language="C#" MasterPageFile="~/MainWebForm.Master" AutoEventWireup="true" CodeBehind="Drone_Customer_Create.aspx.cs" Inherits="HomeWork002.Drone_Customer_Create" %>

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
            padding: 2% 5%;
        }

        .tutleLine {
            width: 100%;
            height: 1px;
            border-bottom: 1px solid black;
            margin-bottom: 3%;
        }

        .inputMargin {
            margin: 0 auto 2% auto;
            width: 60%;
        }

        .bottomArea {
            width: 25%;
            margin: auto;
            margin-top: 6%;
        }

        .errorMsg {
            font-size: 12px;
            color: red;
            /*display:none;*/
        }

        .errorMsgArea {
            width: 100%;
            padding-left: 20%;
            height:24px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="CreateMainArea">
        <div class="CreateArea">

            <h1 class="inputMargin" runat="server" id="title">新增客戶資料</h1>

            <div class="tutleLine"></div>


            <div class="errorMsgArea">
                <span class="errorMsg" runat="server" id="errorMsgName">*請輸入客戶姓名</span>
            </div>
            <div class="inputMargin d-flex justify-content-between">
                <span>客戶姓名:</span>
                <asp:TextBox ID="TextName" runat="server"></asp:TextBox>
            </div>


            <div class="errorMsgArea">
                <span class="errorMsg" runat="server" id="errorMsgTel">*請輸入電話</span>
            </div>
            <div class="inputMargin d-flex justify-content-between">
                <span>電話:</span>
                <asp:TextBox ID="TextTel" runat="server"></asp:TextBox>
            </div>


            <div class="errorMsgArea">
                <span class="errorMsg" runat="server" id="errorMsgAddress">*請輸入地址</span>
            </div>
            <div class="inputMargin d-flex justify-content-between">
                <span>地址:</span>
                <asp:TextBox ID="TextAddress" runat="server"></asp:TextBox>
            </div>


            <div class="errorMsgArea">
                <span class="errorMsg" runat="server" id="errorMsgCrop">*請輸入農作物</span>
            </div>
            <div class="inputMargin d-flex justify-content-between">
                <span>農作物:</span>
                <asp:TextBox ID="TextCrop" runat="server"></asp:TextBox>
            </div>


            <div class="errorMsgArea">
                <span class="errorMsg" runat="server" id="errorMsgArea">*請輸入土地面積</span>
            </div>
            <div class="inputMargin d-flex justify-content-between">
                <span>土地面積:</span>
                <asp:TextBox ID="TextArea" runat="server"></asp:TextBox>
            </div>


            <div class="errorMsgArea">
                <span class="errorMsg" runat="server" id="errorMsgPesticide">*請輸入使用農藥</span>
            </div>
            <div class="inputMargin d-flex justify-content-between">
                <span>使用農藥:</span>
                <asp:TextBox ID="TextPesticide" runat="server"></asp:TextBox>
            </div>

            <div class="errorMsgArea">
                <span class="errorMsg" runat="server" id="errorMsgPesticideDate">*請輸入農藥有效日期</span>
            </div>
            <div class="inputMargin d-flex justify-content-between">
                <span>農藥有效日期:</span>
                <asp:TextBox ID="TextPesticideDate" type="Date" runat="server"></asp:TextBox>
            </div>


            <div class="inputMargin d-flex justify-content-between">
                <span>地號:</span>
                <asp:TextBox ID="TextFarmAddress" runat="server"></asp:TextBox>
            </div>

            <div class="bottomArea d-flex justify-content-between">
                <asp:Button ID="Create" runat="server" Text="確認" OnClick="Create_Click" />
                <asp:Button ID="Cancel" runat="server" Text="取消" OnClick="Cancel_Click" />
            </div>

        </div>
    </div>
</asp:Content>
