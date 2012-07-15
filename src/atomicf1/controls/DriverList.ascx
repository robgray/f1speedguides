<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DriverList.ascx.cs" Inherits="atomicf1.controls.DriverList" %>

<asp:Repeater ID="DriverListRepeater" runat="server">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li><a href='/drivers/<%# Eval("Url") %>'><%# Eval("Name") %></a></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>