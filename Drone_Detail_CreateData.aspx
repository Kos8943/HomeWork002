<%@ Page Title="" Language="C#" MasterPageFile="~/MainWebForm.Master" AutoEventWireup="true" CodeBehind="Drone_Detail_CreateData.aspx.cs" Inherits="HomeWork002.Drone_Detail_CreateData" %>


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
            width:50%;           
        }

        .bottomArea{
            width:25%;
            margin:auto; 
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="CreateMainArea">
        <div class="CreateArea">

            <h1 class="inputMargin" runat="server" id="title">新增植保機</h1>

            <div class="tutleLine"></div>

            <div class="inputMargin d-flex justify-content-between">
                <span>植保機編號:</span>
                <asp:TextBox ID="TextDroneName" runat="server"></asp:TextBox>
            </div>

            <div class="inputMargin d-flex justify-content-between">
                <span>製造商:</span>
                <asp:TextBox ID="TextManufacturer" runat="server"></asp:TextBox>
            </div>

            <div class="inputMargin d-flex justify-content-between">
                <span>起飛總乘載重量:</span>
                <asp:TextBox ID="TextWeightLoad" runat="server"></asp:TextBox>
            </div>

            <div class="inputMargin d-flex justify-content-between">
                <span>使用狀態:</span>
                <asp:TextBox ID="TextStatus" runat="server"></asp:TextBox>
            </div>

            <div class="inputMargin d-flex justify-content-between">
                <span>停用原因:</span>
                <asp:TextBox ID="TextStopReason" runat="server"></asp:TextBox>
            </div>

            <div class="inputMargin d-flex justify-content-between">
                <span>負責人:</span>
                <asp:TextBox ID="TextOperator" runat="server"></asp:TextBox>
            </div>

            <div class="bottomArea d-flex justify-content-between">
                <asp:Button ID="Create" runat="server" Text="確認" OnClick="Create_Click" />
                <asp:Button ID="Cancel" runat="server" Text="取消" OnClick="Cancel_Click" />
            </div>

        </div>
    </div>
</asp:Content>
