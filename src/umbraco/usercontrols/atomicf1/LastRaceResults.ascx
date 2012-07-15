<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LastRaceResults.ascx.cs" Inherits="atomicf1.controls.LastRaceResults" %>
<div class="LastRaceResults">
<asp:DataList ID="LastRaceRepeater" runat="server">
    <HeaderTemplate>
        <h2><%= RaceName %></h2>
        <table>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td class="col1"><%# Eval("Position") %></td>
            <td class="col2"><%# Eval("Entrant.Driver.Name")%></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:DataList>
</div>