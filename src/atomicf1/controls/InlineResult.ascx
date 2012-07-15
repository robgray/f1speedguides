<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InlineResult.ascx.cs" Inherits="atomicf1.controls.InlineRaceGrid" %>
<div class="InlineResultBorder">
<div class="InlineResult">
<asp:Repeater ID="InlineResultRepeater" runat="server" 
        onitemdatabound="InlineResultRepeater_ItemDataBound">
    <HeaderTemplate>        
        <table width="100%">                             
        <thead>
            <tr>
                <th colspan="6" class="Title">
                    <%= this.Type %> Results
                </th>
            </tr>
            <tr>
                <th class="col1">Place</th>
                <th class="col2">Driver</th>
                <% if (this.Type == "Race") {%>
                    <th class="col1">Grid Position</th>
                    <th class="col3">Race Time</th>
                    <th class="col3">Fastest Lap</th>
                <%} else { %>
                    <th class="col3">Time</th>
                <% } %>
                <th class="col1">Points</th>
                <% if (this.Type == "Race") {%>
                    <th class="col1">Total Points</th>
                <%}%>
            </tr>
        </thead>           
    </HeaderTemplate>
    <ItemTemplate>
        <tr class='<%# ((bool)Eval("HasFastestLap")) ? "Fastest" : "" %>'>
            <td class="col1"><%# Eval("Position") %></td>
            <td class="col2"><%# Eval("Name") %> <span class="achievementsHolder"><asp:PlaceHolder runat="server" ID="achievementsHolder"></asp:PlaceHolder></span></td>
            <% if (this.Type == "Race") {%>
                <td class="col1"><%# Eval("GridPosition") %></td>                
                <td class="col3"><%# Eval("RaceTime")%></td>
            <%}%>
            <td class="col3"><%# Eval("FormattedTime")%></td>
            <td class="col1"><%# Eval("Points") %></td>
            <% if (this.Type == "Race") {%>
                    <td class="col1"><%# Eval("TotalPoints") %></td>
            <%}%>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
</div>
</div>