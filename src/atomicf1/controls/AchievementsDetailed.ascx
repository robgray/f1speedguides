<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AchievementsDetailed.ascx.cs" Inherits="atomicf1.controls.AchievementsDetailed" %>
<asp:Repeater ID="AchievementsRepeater" runat="server" OnItemDataBound="AchievementsRepeater_ItemDataBound">
    <ItemTemplate>
        <h2><%# Eval("Name") %></h2>
        <abbr><%# Eval("Description") %></abbr>
        <asp:Repeater ID="DriversRepeater" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li><%# Eval("Name") %></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </ItemTemplate>
</asp:Repeater>