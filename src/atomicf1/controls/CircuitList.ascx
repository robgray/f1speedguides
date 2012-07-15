<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CircuitList.ascx.cs" Inherits="atomicf1.controls.CircuitList" %>

<asp:Repeater ID="CircuitListRepeater" runat="server">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li><a href='/circuits/<%# Eval("Url") %>'><%# Eval("Name") %></a></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>