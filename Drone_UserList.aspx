<%@ Page Title="" Language="C#" MasterPageFile="~/MainWebForm.Master" AutoEventWireup="true" CodeBehind="Drone_UserList.aspx.cs" Inherits="HomeWork002.Drone_UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .DivtableArea {
            /*height:100%;*/
            width: 100%;
            /*background-color:yellow;*/
            border-radius: 10px;
        }

        .toolArea {
            width: 100%;
            height: 6%;
            background-color: rgb(254,254,254);
        }

        .tableStyle {
            border-spacing: 0px;
            height: 100%;
            width: 100%;
        }

        th {
            height: 50px;
        }

        td {
            height: 50px;
        }


        .feildColor {
            background-color: rgb(238,238,238);
            text-align: left;
            padding-left: 20px;
            font-size: 20px;
        }

        .checkBoxFeild {
            width: 1%;
            /*border-radius:10px 0 0 0;*/
            /*border:1px solid red;*/
        }

        .sidFeild {
            width: 3%;
            /*border:1px solid red;*/
        }

        .BatteryNameFeild {
            width: 3%;
            /*border:1px solid red;*/
        }

        .statusFeild {
            width: 4%;
            /*border:1px solid red;*/
        }

        .stopFeild {
            width: 3%;
            /*border:1px solid red;*/
        }


        .UpdateFeild {
            width: 1%;
            /*border-radius: 0 10px 0 0;*/
            /*border:1px solid red;*/
        }

        .DeleteFeild {
            width: 17%;
        }

        .tdFeild {
            padding-left: 20px;
            height: 61px;
        }

        .Row2 {
            background-color: rgb(156,234,234);
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="toolArea">
        <div class="d-flex justify-content-between" style="display: flex; padding-top: 2px; padding-right: 20px; padding-left: 20px;">
            <asp:Button ID="Button1" runat="server" Text="新增" Style="margin-right: 20px;" OnClick="btnCreate_Click" />

            <div>
                <asp:DropDownList ID="DropDownListSearch" runat="server">
                    <asp:ListItem Value="Account" Text="帳號"></asp:ListItem>
                    <asp:ListItem Value="Name" Text="姓名"></asp:ListItem>

                </asp:DropDownList>
                <asp:TextBox ID="textKeyWord" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" />
            </div>

        </div>
    </div>

    <div class="DivtableArea">

        <table class="tableStyle">
            <tr>
                <%-- <th class="feildColor checkBoxFeild">
                    <asp:CheckBox ID="CheckAllBox" runat="server" />
                </th>--%>
                <%--<th class="feildColor sidFeild">排序</th>--%>
                <th class="feildColor BatteryNameFeild ">帳號</th>
                <th class="feildColor stopFeild">姓名</th>
                <th class="feildColor UpdateFeild">修改</th>
                <th class="feildColor DeleteFeild">刪除</th>
            </tr>
            <asp:Repeater ID="DroneUserListReater" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="DroneBatteryReater_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <%--<td class="tdFeild">
                            <asp:CheckBox ID="CheckBox" runat="server" />
                        </td>--%>
                        <%--<td class="tdFeild"><%# Eval("sid") %></td>--%>
                        <td class="tdFeild"><%# Eval("Account") %></td>
                        <td class="tdFeild"><%# Eval("Name") %></td>
                        <td class="tdFeild">
                            <asp:Button ID="btnUpData" runat="server" Text="修改" CommandName="UpDateItem" CommandArgument='<%# Eval("Sid") %>' />
                        </td>
                        <td class="tdFeild">
                            <asp:Button ID="btnDelData" runat="server" Text="刪除" CommandName="DeleteItem" CommandArgument='<%# Eval("Sid") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr>
                        <%--<td class="tdFeild">
                            <asp:CheckBox ID="CheckBox" runat="server" />
                        </td>--%>
                        <%--<td class="tdFeild"><%# Eval("sid") %></td>--%>
                        <td class="Row2 tdFeild"><%# Eval("Account") %></td>
                        <td class="Row2 tdFeild"><%# Eval("Name") %></td>
                        <td class="Row2 tdFeild">
                            <asp:Button ID="btnUpData" runat="server" Text="修改" CommandName="UpDateItem" CommandArgument='<%# Eval("Sid") %>' />
                        </td>
                        <td class="Row2 tdFeild">
                            <asp:Button ID="btnDelData" runat="server" Text="刪除" CommandName="DeleteItem" CommandArgument='<%# Eval("Sid") %>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:Repeater>


        </table>
    </div>
</asp:Content>
