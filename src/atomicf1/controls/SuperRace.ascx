<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="SuperRace.ascx.cs" Inherits="atomicf1.controls.SuperRace" %>

<div class="SuperGrid">
<asp:Repeater ID="SuperRaceRepeater" runat="server">
    <HeaderTemplate>
        <h2>Super Race</h2>
        <hr />
        <table width="100%">
            <colgroup>
                <td width="30px"></td>
                <td></td>
                <td width="40px"></td>
            </colgroup>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Eval("Rank") %></td>
            <td><%# Eval("Name") %> (<%# Eval("Entries") %>)</td>
            <td><%# Eval("Position", "{0:0.00}")%></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
</div>