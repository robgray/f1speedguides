<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AchievementsList.ascx.cs" Inherits="atomicf1.controls.AchievementsList" %>
<div class="Achievements">
<asp:Repeater ID="AchievementsRepeater" runat="server">
    <HeaderTemplate>
        <h2>Acheivements</h2>
        <hr />
    </HeaderTemplate>
    <ItemTemplate>
        <div class='Achievement <%# Eval("CssClass") %>'>
            <div class="Name"><%# Eval("Name") %></div>
        </div>
    </ItemTemplate>
</asp:Repeater>
</div>