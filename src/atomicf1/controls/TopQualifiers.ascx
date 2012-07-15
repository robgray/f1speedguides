<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopQualifiers.ascx.cs" Inherits="atomicf1.controls.TopQualifiers" %>
<%@ Import Namespace="atomicf1.common" %>

<script>
    $(function () { $('#TopQualifiers').tabs(); });
</script>

<% if (HasData)
   {%>
<div id="TopQualifiers" class="Pod StandingsTable">
    <h2>Top Qualifiers</h2>
    <hr />
        
    <ul>
        <li><a href="#tab-place">position</a></li>        
        <li><a href="#tab-time">lap time</a></li>        
    </ul>
    
    
    <asp:Repeater ID="QualifiersListPosition" runat="server">
        <HeaderTemplate>       
            <div id="tab-place">
            <table width="100%">        
        </HeaderTemplate>
        <ItemTemplate>     
            <tr>
                <td class="name"><%# Eval("Entrant.Driver.Name") %></td>
                <td class="points"><%# string.Format("{0:0.#0}", Convert.ToDouble(Eval("AveragePosition"))) %></td>            
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>            
            </div> 
        </FooterTemplate>
    </asp:Repeater>

    <asp:Repeater ID="QualifiersListTime" runat="server">
        <HeaderTemplate>        
            <div id="tab-time">
            <table width="100%">        
        </HeaderTemplate>
        <ItemTemplate>     
            <tr>
                <td class="name"><%# Eval("Entrant.Driver.Name") %></td>                
                <td class="points"><%# Convert.ToDecimal(Eval("AverageLapTime")).ToLapTime() %></td>            
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table> 
            </div>
        </FooterTemplate>
    </asp:Repeater>
</div>
<% } %>