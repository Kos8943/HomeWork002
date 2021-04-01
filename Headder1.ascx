<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Headder1.ascx.cs" Inherits="HomeWork002.Headder1" %>


<div class="nameArea">
    <div class="namePostion">
        <a href="Drone_Detail.aspx">
            <img src="Imgs/news20171201_001.png" />
        </a>
    </div>
</div>

<div class="tableNameArea d-flex justify-content-between">
    <div runat="server" class="tableNamePosition" id="tableName">
        <asp:Literal ID="txtTableName" runat="server"></asp:Literal>
    </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="登出" />
    </div>



</div>
