<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TeamDetails.ascx.cs" Inherits="atomicf1.controls.TeamDetails" %>
<div class="TeamDetail Statistics">
    <h2>Statistics</h2>
    <asp:Repeater ID="TeamDetail" runat="server">
        <ItemTemplate>
            <div id="MainStats">
                <table width="100%">                
                    <colgroup>
                        <th width="100px"></th>
                        <td></td>
                    </colgroup>
                    <tr>
                        <th>Team</th>
                        <td><%# Eval("Name") %></td>
                    </tr>                            
                    <tr>
                        <th>&nbsp;</th>
                        <td></td>
                    </tr>
                    <tr>
                        <th>Best Quali Pos</th>
                        <td><%# Eval("BestQualifyingResultString") %></td>
                    </tr>
                    <tr>
                        <th>Best Race Pos</th>
                        <td><%# Eval("BestRaceResultString") %></td>
                    </tr>
                    <tr>
                        <th>Best Title Pos</th>
                        <td><%# Eval("BestChampionshipResult") %></t>d
                    </tr>
                    <tr>
                        <th>&nbsp;</th>
                        <td></td>
                    </tr>                     
                    <tr>
                        <th>Races</th>
                        <td><%# Eval("Races") %></td>
                    </tr>                                                         
                    <tr>
                        <th>Points</th>
                        <td><%# Eval("Points") %> <span class="rate">(<%# Eval("PointsPerRace", "{0:0.00}") %>)</span></td>
                    </tr>                                                         
                    <t>
                        <th>Wins</th>
                        <td><%# Eval("Wins") %> <span class="rate">(<%# Eval("WinsPercent", "{0:0.00}") %>%)</span></td>
                    </tr>
                    <tr>
                        <th>Poles</th>
                        <td><%# Eval("Poles") %> <span class="rate">(<%# Eval("PolesPercent", "{0:0.00}") %>%)</span></td>
                    </tr>                                                         
                    <tr>
                        <th>Podiums</th>
                        <td><%# Eval("Podiums") %> <span class="rate">(<%# Eval("PodiumsPercent", "{0:0.00}") %>%)</span></td>
                    </tr>                                                         
                    <tr>
                        <th>Finishes</th>
                        <td><%# Eval("Finishes") %> <span class="rate">(<%# Eval("FinishesPercent", "{0:0.00}") %>%)</span></td>
                    </tr>                                                         
                </table>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <asp:Repeater ID="AveragesRepeater" runat="server">    
        <HeaderTemplate>
            <hr />
        </HeaderTemplate>
        <ItemTemplate>        
            <div class="AverageStats">
                <a class="dropdown"><h2><%# Eval("Name") %> Averages</h2></a>
			    <div class="contents">
                    <table width="100%">                
                        <colgroup>
                            <th width="100px"></th>
                            <td></td>
                        </colgroup>
                        <tr>
                            <th>Qualifying</th>
                            <td><%# string.Format("{0:0.#0}", Convert.ToDouble(Eval("AverageQualifying"))) %></td>
                        </tr>                            
                        <tr>
                            <th>Race</th>
                            <td><%# string.Format("{0:0.#0}", Convert.ToDouble(Eval("AverageRace"))) %></td>
                        </tr>                                            
                    </table>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>