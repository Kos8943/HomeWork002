<%@ Page Title="" Language="C#" MasterPageFile="~/MainWebForm.Master" AutoEventWireup="true" CodeBehind="Drone_Destination_Create.aspx.cs" Inherits="HomeWork002.Drone_Destination_Create" %>

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
            margin:0 auto 2% auto;
            width:50%;
            /*font-size:18px;*/
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
            padding-left:25%;
            height:30px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="CreateMainArea">
        <div class="CreateArea">

            <h1 class="inputMargin" runat="server" id="title">新增出勤紀錄</h1>

            <div class="tutleLine"></div>


            <div class="errorMsgArea">
                <span class="errorMsg" runat="server" id="errorMsgDate" visible="false">*請選擇日期</span>
            </div>
            <div class="inputMargin d-flex justify-content-between">
                <span>出勤日期:</span>
                <asp:TextBox type="date" ID="TextDate" runat="server"></asp:TextBox>
            </div>


            <div class="errorMsgArea">
                <span class="errorMsg" runat="server" id="errorMsgStaff" visible="false">*請輸入出勤人員</span>
            </div>
            <div class="inputMargin d-flex justify-content-between">
                <span>出勤人員:</span>
                <asp:TextBox ID="TextStaff" runat="server"></asp:TextBox>
            </div>


            <div class="inputMargin d-flex justify-content-between">
                <span>使用無人機:</span>
                <asp:DropDownList ID="DropDownListDroneID" runat="server" style="width:182px;height:30px;"></asp:DropDownList>            
            </div>


            <div class="errorMsgArea">
                <span class="errorMsg" runat="server" id="errorMsgBattery" visible="false">*請輸入攜帶電池數量</span>
            </div>
            <div class="inputMargin d-flex justify-content-between">
                <span>攜帶電池數量:</span>
                <asp:TextBox ID="TextBattery" runat="server"></asp:TextBox>
            </div>


            <div class="errorMsgArea">
                <span class="errorMsg" runat="server" id="errorMsgCustomerName" visible="false">*請輸入客戶名稱</span>
            </div>
            <div class="inputMargin d-flex justify-content-between">
                <span>客戶姓名:</span>
                <asp:TextBox ID="TextCustomerName" runat="server"></asp:TextBox>
            </div>


            <div class="errorMsgArea">
                <span class="errorMsg" runat="server" id="errorMsgCustomerTel" visible="false">*請輸入電話</span>
            </div>
            <div class="inputMargin d-flex justify-content-between">
                <span>客戶電話:</span>
                <asp:TextBox ID="TextCustomerTel" runat="server"></asp:TextBox>
            </div>


            <div class="errorMsgArea">
                <span class="errorMsg" runat="server" id="errorMsgCustomerAddress" visible="false">*請輸入地址</span>
            </div>
            <div class="inputMargin d-flex justify-content-between">
                <span>客戶地址:</span>
                <asp:TextBox ID="TextCustomerAddres" runat="server"></asp:TextBox>
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
