<%@ Page Title="" Language="C#" MasterPageFile="~/MainWebForm.Master" AutoEventWireup="true" CodeBehind="Drone_Destination.aspx.cs" Inherits="HomeWork002.Drone_Destination" %>

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
            width:10%;
           /*border:1px solid red;*/
        }

        .makedFeild{
            width:10%;
            /*border:1px solid red;*/
        }

        .weightLoadFeild{
            width:13%;
            /*border:1px solid red;*/
        }

        .statusFeild{
            width:10%;
            /*border:1px solid red;*/
        }

        .stopFeild{
            width:8%;
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

        .CustomerNameFeild{
            width:4%;
        }

        .AddressFeild{
            width:20%;
        }

        .DeleteFeild{
            width:10%;
        }

        .tdFeild{
            padding-left:20px;
            height:61px;
        }

        .Row2{
            background-color: rgb(156,234,234);
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
                    <asp:ListItem Value="Date" Text="出勤日期"></asp:ListItem>
                    <asp:ListItem Value="Staff" Text="出勤人員"></asp:ListItem>
                    <asp:ListItem Value="Drone_ID" Text="使用無人機"></asp:ListItem>
                    <asp:ListItem Value="Battery_Count" Text="攜帶電池數量"></asp:ListItem>
                    <asp:ListItem Value="Cumstomer_Name" Text="客戶名稱"></asp:ListItem>
                    <asp:ListItem Value="Tel" Text="客戶電話"></asp:ListItem>
                    <asp:ListItem Value="Address" Text="客戶地址"></asp:ListItem>

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
            <th class="feildColor DroneNameFeild">出勤日期</th>
            <th class="feildColor weightLoadFeild">出勤人員</th>
            <th class="feildColor makedFeild">使用無人機</th>
            <th class="feildColor statusFeild">攜帶電池數量</th>
            <th class="feildColor stopFeild">客戶名稱</th>
            <th class="feildColor CustomerNameFeild">客戶電話</th>
            <th class="feildColor AddressFeild">客戶地址</th>
            <th class="feildColor operatorFeild">備註</th>
            <th class="feildColor UpdateFeild">修改</th>
            <th class="feildColor DeleteFeild">刪除</th>
        </tr>


        <asp:Repeater ID="DroneDetailRepeater" runat="server" OnItemDataBound="DroneDetailRepeater_ItemDataBound"  OnItemCommand="DroneDetailRepeater_OnItemCommand">
            <ItemTemplate>
                <tr>
                    <%--<td class="tdFeild">
                        <asp:CheckBox ID="CheckBox" runat="server" />
                    </td>--%>
                    <td class="tdFeild"><%# Eval("Date","{0: yyyy-MM-dd}") %></td>
                    <td class="tdFeild"><%# Eval("Staff") %></td>
                    <td class="tdFeild"><%# Eval("Drone_ID") %></td>               
                    <td class="tdFeild"><%# Eval("Battery_Count") %></td>
                    <td class="tdFeild"><%# Eval("Cumstomer_Name") %></td>
                    <td class="tdFeild"><%# Eval("Tel") %></td>
                    <td class="tdFeild"><%# Eval("Address") %></td>
                    <td class="tdFeild"><%# Eval("Remarks") %></td>
                    <td class="tdFeild">
                        <asp:Button ID="btnUpData" runat="server" Text="修改" CommandName="UpDateItem" CommandArgument='<%# Eval("Sid") %>'/>
                    </td>
                    <td class="tdFeild">
                        <asp:Button ID="btnDelData" runat="server" Text="刪除" CommandName="DeleteItem" CommandArgument='<%# Eval("Sid") %>'/>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                    <%--<td class="tdFeild">
                        <asp:CheckBox ID="CheckBox" runat="server" />
                    </td>--%>
                    <td class="Row2 tdFeild"><%# Eval("Date","{0: yyyy-MM-dd}") %></td>
                    <td class="Row2 tdFeild"><%# Eval("Staff") %></td>
                    <td class="Row2 tdFeild"><%# Eval("Drone_ID") %></td>               
                    <td class="Row2 tdFeild"><%# Eval("Battery_Count") %></td>
                    <td class="Row2 tdFeild"><%# Eval("Cumstomer_Name") %></td>
                    <td class="Row2 tdFeild"><%# Eval("Tel") %></td>
                    <td class="Row2 tdFeild"><%# Eval("Address") %></td>
                    <td class="Row2 tdFeild"><%# Eval("Remarks") %></td>
                    <td class="Row2 tdFeild">
                        <asp:Button ID="btnUpData" runat="server" Text="修改" CommandName="UpDateItem" CommandArgument='<%# Eval("Sid") %>'/>
                    </td>
                    <td class="Row2 tdFeild">
                        <asp:Button ID="btnDelData" runat="server" Text="刪除" CommandName="DeleteItem" CommandArgument='<%# Eval("Sid") %>'/>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:Repeater>
    </table>       
    </div>
</asp:Content>
