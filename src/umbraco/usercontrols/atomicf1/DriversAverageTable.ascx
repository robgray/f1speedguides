<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DriversAverageTable.ascx.cs" Inherits="atomicf1.controls.DriversAverageTable" %>
<div class="RaceResults">
    <div class="Form">
        <div class="Field fl" style="padding-left: 30px;">
            <label>Season</label>
            <asp:DropDownList ID="SeasonList" runat="server" 
                onselectedindexchanged="SeasonList_SelectedIndexChanged" 
                AutoPostBack="True"></asp:DropDownList>
        </div>
        <div class="Field fl" style="padding-left: 30px">        
            <label>Type</label>            
            <asp:DropDownList ID="TypeList" runat="server">
                <asp:ListItem Value="Qualifying" Text="Qualifying"></asp:ListItem>
                <asp:ListItem Value="Race" Text="Race" Selected="True"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="fl" style="padding-left: 30px;">
            <asp:LinkButton ID="ShowResultsButton" runat="server" Text="Show Results" 
                onclick="ShowResultsButton_Click" />
        </div>
        <div class="clear"></div>
    </div>
    
    <div class="InlineResultBorder">
    <div class="InlineResult">
        <asp:Repeater ID="AverageTable" runat="server">
            <HeaderTemplate>              
              <table width="100%">                                        
                 <tr>
                    <th colspan="3" style="text-align: center;">Driver Average <%= this.AverageType %> Place</th>
                 </tr>
                 <tr>
                    <th class="col1">Place</th>
                    <th class="col2">Driver</th>
                    <th class="col3">Avg Place</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="col1"><%# Eval("Position") %></td>
                    <td class="col2"><%# Eval("Name") %></td>
                    <td class="col3"><%# Eval("Result") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
              </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </div>
</div>