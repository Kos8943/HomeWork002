<%@ Page Title="" Language="C#" MasterPageFile="~/MainWebForm.Master" AutoEventWireup="true" CodeBehind="Drone_Fixed.aspx.cs" Inherits="HomeWork002.Drone_Fixed" %>


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
            width:6%;
            /*border:1px solid red;*/
        }

        .FixNameFeild{
            width:10%;
           /*border:1px solid red;*/
        }

        .StopDateFeild{
            width:12%;
            /*border:1px solid red;*/
        }

        .SendDateFeild{
            width:12%;
            /*border:1px solid red;*/
        }

        .FixFeild{
            width:10%;
            /*border:1px solid red;*/
        }

        .StopReasonFeild{
            width:10%;
            /*border:1px solid red;*/
        }

        .ChangeFeild{
            width:8%;
            /*border:1px solid red;*/
        }

        .RemarksFeild{
            width:10%;
            /*border:1px solid red;*/
        }

        .UpDateFeild{
            width:2%;
            /*border-radius: 0 10px 0 0;*/
            /*border:1px solid red;*/
        }

        .DeleteFeild{
            width:7%;
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
    <div class="toolArea">
        <div class="d-flex justify-content-between" style="display: flex; padding-top: 2px; padding-right: 20px; padding-left: 20px;">
            <asp:Button ID="CreateDate" runat="server" Text="新增" Style="margin-right: 20px;" OnClick="CreateDate_Click"/>

            <div>
                <asp:DropDownList ID="DropDownListSearch" runat="server">
                    <asp:ListItem Value="Drone_ID" Text="無人機編號"></asp:ListItem>
                    <asp:ListItem Value="FixChange" Text="維修部件"></asp:ListItem>
                    <asp:ListItem Value="StopDate" Text="故障日期"></asp:ListItem>
                    <asp:ListItem Value="SendDate" Text="送修日期"></asp:ListItem>
                    <asp:ListItem Value="FixVendor" Text="維修廠商"></asp:ListItem>
                    <asp:ListItem Value="StopReason" Text="停用原因"></asp:ListItem>
                    <asp:ListItem Value="Remarks" Text="備註"></asp:ListItem>

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
                <th class="feildColor FixNameFeild ">無人機編號</th>
                <th class="feildColor ChangeFeild">維修部件</th>
                <th class="feildColor StopDateFeild">故障日期</th>
                <th class="feildColor SendDateFeild">送修日期</th>
                <th class="feildColor FixFeild">維修廠商</th>
                <th class="feildColor StopReasonFeild">故障原因</th>             
                <th class="feildColor RemarksFeild">備註</th>
                <th class="feildColor UpDateFeild">修改</th>
                <th class="feildColor DeleteFeild">刪除</th>
                
                

            </tr>
            <asp:Repeater ID="DroneFixReater" runat="server"  OnItemDataBound="DroneFixReater_ItemDataBound" OnItemCommand="DroneFixReater_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <%--<td class="tdFeild">
                            <asp:CheckBox ID="CheckBox" runat="server" />
                        </td>--%>
                        <%--<td class="tdFeild"><%# Eval("Sid") %></td>--%>
                        <td class="tdFeild"><%# Eval("Drone_ID") %></td>
                        <td class="tdFeild"><%# Eval("FixChange") %></td>
                        <td class="tdFeild"><%# Eval("StopDate","{0:yyyy-MM-dd}") %></td>
                        <td class="tdFeild"><%# Eval("SendDate","{0:yyyy-MM-dd}") %></td>
                        <td class="tdFeild"><%# Eval("FixVendor") %></td>
                        <td class="tdFeild"><%# Eval("StopReason") %></td>                      
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
                       <%-- <td class="Row2 tdFeild"><%# Eval("Sid") %></td>--%>
                        <td class="Row2 tdFeild"><%# Eval("Drone_ID") %></td>
                        <td class="Row2 tdFeild"><%# Eval("FixChange") %></td>
                        <td class="Row2 tdFeild"><%# Eval("StopDate","{0:yyyy-MM-dd}") %></td>
                        <td class="Row2 tdFeild"><%# Eval("SendDate","{0:yyyy-MM-dd}") %></td>
                        <td class="Row2 tdFeild"><%# Eval("FixVendor") %></td>
                        <td class="Row2 tdFeild"><%# Eval("StopReason") %></td>                      
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
