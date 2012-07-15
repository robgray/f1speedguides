<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NextEvent.ascx.cs" Inherits="atomicf1.controls.NextEvent" %>
<%@ Import Namespace="atomicf1" %>

<asp:Repeater ID="NextEventRepeater" runat="server" 
    onitemdatabound="NextEventRepeater_ItemDataBound">
    <HeaderTemplate>        
    <div class="Calendar">
        <h2>Upcoming Events</h2>        
        <div>
    </HeaderTemplate>    
    <ItemTemplate>                
            <table style="margin-left: 40px">            
            <tr>               
                <td rowspan="5"><a class="lightbox" href='<%# Eval("CircuitImageUri") %>'><img src='<%# Eval("CircuitImageUri").ToString().GetImage(200) %>' alt="Circuit Map"/></a></td>                
                <td>
                    <table>
                        <colgroup>
                            <th width="150px"></th>
                            <td></td>
                        </colgroup>
                        <tr>
                            <th>Location</th>
                            <td><a href='/circuits/<%# Eval("CircuitUri") %>'><%# Eval("Location") %></a></td>
                        </tr>
                        <tr>
                            <th>Race Date</th>
                            <td>
                                <span class='time' utctime='<%# Eval("RaceDateUtc") %>'><%# DateTime.Parse(Eval("RaceDate").ToString()).ToString("dd MMM, HH:mm") %></span>                                
                            </td>
                        </tr>
                        <tr>
                            <th>Race Length</th>
                            <td><%# Eval("RaceLength") %></td>
                        </tr>       
                        <tr>
                            <th>Previous Winner</th>
                            <td><a href='/drivers/<%# Eval("PreviousWinnerUri") %>'><%# Eval("PreviousWinner") %></a></td>
                        </tr>
                        <tr>
                            <th>Qualifying Record</th>
                            <td><%# Eval("QualifyingRecord") %></td>
                        </tr>                           
                    </table>
                </td>                                
            </tr>                
            </table>        
    </ItemTemplate>
    <SeparatorTemplate>        
    </SeparatorTemplate>
    <FooterTemplate>                         
        </div>
            <div class="CalendarLink">
                <a href="/calendar">View full calendar</a>
            </div>
        </div>

    </FooterTemplate>
</asp:Repeater>
<script type="text/javascript">
    ConvertUtcTimeToLocalTime(); 
</script>