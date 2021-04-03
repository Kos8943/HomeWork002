<%@ Page Title="" Language="C#" MasterPageFile="~/MainWebForm.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HomeWork002.WebForm1" %>

<%@ Register Src="~/ucTool.ascx" TagPrefix="uc1" TagName="ucTool" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .DivtableArea{
            /*height:100%;*/
            width:100%;
            /*background-color:yellow;*/
            border-radius:10px;
        }

        .toolArea{
            width:100%;
            height:6%;
            background-color:rgb(254,254,254);
            
        }

        .tableStyle {
            border-spacing: 0px;
            height:100%;
            width:100%;
            
        }

        th{
            height:50px;
        }

        td{
            height:50px;
        }
        

        .feildColor{
            background-color:rgb(238,238,238);
            text-align:left;
            padding-left:20px;
            font-size:20px;
            
        }

        .checkBoxFeild{
            width:6%;
            /*border-radius:10px 0 0 0;*/
            /*border:1px solid red;*/
        }

        .sidFeild{
            width:10%;
            /*border:1px solid red;*/
        }

        .DroneNameFeild{
            width:15%;
           /*border:1px solid red;*/
        }

        .makedFeild{
            width:12%;
            /*border:1px solid red;*/
        }

        .weightLoadFeild{
            width:15%;
            /*border:1px solid red;*/
        }

        .statusFeild{
            width:10%;
            /*border:1px solid red;*/
        }

        .stopFeild{
            width:10%;
            /*border:1px solid red;*/
        }

        .operatorFeild{
            width:10%;
            /*border:1px solid red;*/
        }

        .UpdateFeild{
            width:5%;
            /*border-radius: 0 10px 0 0;*/
            /*border:1px solid red;*/
        }

        .DeleteFeild{
            width:10%;
        }

        .tdFeild{
            padding-left:20px;
            height:59px;
        }

    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<uc1:ucTool runat="server" id="ucTool"  />--%>
    <div class="toolArea">
        <div class="d-flex justify-content-between" style="display:flex;padding-top:2px; padding-right:20px;padding-left:20px;">
            <asp:Button ID="btnCreate" runat="server" Text="新增" style="margin-right:20px;" OnClick="btnCreate_Click"/>
            <%--<asp:Button ID="Button2" runat="server" Text="刪除" />--%>
            <div>
                <asp:DropDownList ID="DropDownListSearch" runat="server">
                    <asp:ListItem Value="Drone_ID" Text="無人機編號"></asp:ListItem>
                    <asp:ListItem Value="Manufacturer" Text="製造商"></asp:ListItem>
                    <asp:ListItem Value="WeightLoad" Text="最大起飛重量"></asp:ListItem>
                    <asp:ListItem Value="Status" Text="使用狀態"></asp:ListItem>
                    <asp:ListItem Value="StopReason" Text="停用原因"></asp:ListItem>
                    <asp:ListItem Value="operator" Text="負責人"></asp:ListItem>

                </asp:DropDownList>
                <asp:TextBox ID="textKeyWord" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click"/>
            </div>
        </div>
    </div>

    <div class="DivtableArea">
        
        <table class="tableStyle">
        <tr>
            <%--<th class="feildColor checkBoxFeild">
                <asp:CheckBox ID="CheckAllBox" runat="server" />
            </th>--%>
            <th class="feildColor DroneNameFeild">植保機編號</th>
            <th class="feildColor makedFeild">廠商</th>
            <th class="feildColor weightLoadFeild">起飛總乘載重量</th>
            <th class="feildColor statusFeild">使用狀態</th>
            <th class="feildColor stopFeild">停用原因</th>
            <th class="feildColor operatorFeild">負責人</th>
            <th class="feildColor UpdateFeild">修改</th>
            <th class="feildColor DeleteFeild">刪除</th>
        </tr>


        <asp:Repeater ID="DroneDetailRepeater" runat="server" OnItemDataBound="DroneDetailRepeater_ItemDataBound"  OnItemCommand="DroneDetailRepeater_OnItemCommand">
            <ItemTemplate>
                <tr>
                    <%--<td class="tdFeild">
                        <asp:CheckBox ID="CheckBox" runat="server" />
                    </td>--%>
                    <td class="tdFeild"><%# Eval("Drone_ID") %></td>
                    <td class="tdFeild"><%# Eval("Manufacturer") %></td>
                    <td class="tdFeild"><%# Eval("WeightLoad") %></td>
                    <td class="tdFeild"><%# Eval("Status") %></td>
                    <td class="tdFeild"><%# Eval("StopReason") %></td>
                    <td class="tdFeild"><%# Eval("operator") %></td>
                    <td class="tdFeild">
                        <asp:Button ID="btnUpData" runat="server" Text="修改" CommandName="UpDateItem" CommandArgument='<%# Eval("Drone_ID") %>'/>
                    </td>
                    <td class="tdFeild">
                        <asp:Button ID="btnDelData" runat="server" Text="刪除" CommandName="DeleteItem" CommandArgument='<%# Eval("Drone_ID") %>'/>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>       
    </div>
</asp:Content>
