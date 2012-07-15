<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TeamChampionship.ascx.cs" Inherits="atomicf1.controls.TeamChampionship" %>

<asp:Repeater ID="TeamStandings" runat="server">
    <HeaderTemplate>        
        <div class="Pod StandingsTable">
        <h2>Team Standings</h2>
        <hr />
        <table width="100%">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>        
            <td class="name"><a href='/teams/<%# Eval("Entrant.Team.Url") %>'><%# Eval("Entrant.Team.Name") %></a></td>            
            <td class="points"><%# Eval("Points") %></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>        
        </div>
    </FooterTemplate>
</asp:Repeater>