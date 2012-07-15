<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Champions.ascx.cs" Inherits="atomicf1.controls.Champions" %>

<div class="Pod StandingsTable">
<div class="champions">
    <asp:Repeater ID="ChampionsList" runat="server">
        <HeaderTemplate>
            <h2>Our Past Champions</h2>
            <hr />
            <table width="100%">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="medal"></td>
                <td><%# Eval("Entrant.Driver.Name") %></td>
                <td><%# Eval("Season") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
</div>