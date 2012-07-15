<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DriverChampionship.ascx.cs" Inherits="atomicf1.controls.DriverChampionship" %>


<script type="text/javascript">
    $(function () { $('#DriversChampionshipSummary').tabs(); });
</script>

<% if (HasData)
   {%>
<div id="DriversChampionshipSummary" class="Pod StandingsTable">
    <h2>Driver Standings</h2>
    <hr /> 
    
    <asp:Repeater ID="DriverStandingsWlfg" runat="server">
        <HeaderTemplate>        
            <div id="tab-wlfg">
            <table width="100%">
        </HeaderTemplate>
        <ItemTemplate>            
            <tr>
                <td class="name"><a href='/drivers/<%# Eval("Entrant.Driver.Url") %>'><%# Eval("Entrant.Driver.Name") %></a></td>
                <td class="points"><%# Eval("Points") %></td>            
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>           
            </div> 
        </FooterTemplate>    
    </asp:Repeater>
   
    <div style="padding: 10px;">
        <a href="/results/<%=CurrentSeasonUrl%>">&raquo; See Detailed Results</a>
    </div>
</div>
<% } %>