<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Calendar.ascx.cs" Inherits="atomicf1.controls.Calendar" %>

<asp:Repeater runat="server" ID="CalendarRepeater">
    <HeaderTemplate>
        <div class="CalendarList">
        <h2><%= Name %></h2>        
        <table>
            <tr>
                <th>Date</th>
                <th>Distance</th>
                <th>Race</th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
            <tr>
                <td><%# Eval("Date", "{0:dd-MMM-yyyy}") %></td>
                <td><%# Eval("RaceDistance") %>%</td>
                <td><%# Eval("Description") %></td>
            </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
        </div>
    </FooterTemplate>
</asp:Repeater>