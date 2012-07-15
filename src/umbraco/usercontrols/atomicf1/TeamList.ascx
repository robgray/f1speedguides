<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TeamList.ascx.cs" Inherits="atomicf1.controls.WebUserControl1" %>

<asp:Repeater ID="TeamListRepeater" runat="server">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li><a href='/teams/<%# Eval("Url") %>'><%# Eval("Name") %></a></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
