<%@ Page Title="" Language="C#" MasterPageFile="~/MainWebForm.Master" AutoEventWireup="true" CodeBehind="Drone_Fix_CreateData.aspx.cs" Inherits="HomeWork002.Drone_Fix_CreatData" %>

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
            width:52%;
            /*font-size:18px;*/
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

            <h1 class="inputMargin" runat="server" id="title">新增維修紀錄</h1>

            <div class="tutleLine"></div>

            <div class="inputMargin d-flex justify-content-between">
                <span>無人機編號:</span>
                <asp:DropDownList ID="DropDownListDroneID" runat="server" style="width:182px;height:30px;"></asp:DropDownList>            
            </div>

            <div class="inputMargin d-flex justify-content-between">
                <span>維修部件:</span>
                <asp:TextBox ID="TextChange" runat="server"></asp:TextBox>
            </div>

            <div class="inputMargin d-flex justify-content-between">
                <span>故障日期:</span>
                <asp:TextBox ID="TextStopDate" runat="server" type="date" style="width:182px;"></asp:TextBox>
            </div>

            <div class="inputMargin d-flex justify-content-between">
                <span>送修時間:</span>
                <asp:TextBox ID="TextSendDate" runat="server" type="date" style="width:182px;"></asp:TextBox>
            </div>

            <div class="inputMargin d-flex justify-content-between">
                <span>維修廠商:</span>
                <asp:TextBox ID="TextFixVendor" runat="server"></asp:TextBox>
            </div>

            <div class="inputMargin d-flex justify-content-between">
                <span>送修原因:</span>
                <asp:TextBox ID="TextStopReason" runat="server"></asp:TextBox>
            </div>           

            <div class="inputMargin d-flex justify-content-between">
                <span>備註:</span>
                <asp:TextBox ID="TextRemarks" runat="server"></asp:TextBox>
            </div>

            <div class="bottomArea d-flex justify-content-between">
                <asp:Button ID="Create" runat="server" Text="確認" OnClick="Create_Click"/>
                <asp:Button ID="Cancel" runat="server" Text="取消" OnClick="Cancel_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
