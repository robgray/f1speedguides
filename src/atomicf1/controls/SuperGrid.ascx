<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuperGrid.ascx.cs" Inherits="atomicf1.controls.SuperGrid" %>

<div class="SuperGrid">
<asp:Repeater ID="SuperGridRepeater" runat="server">
    <HeaderTemplate>
        <h2>Super Grid</h2>
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
            <td><%# Eval("Position") %></td>
            <td><%# Eval("Name") %> <span class="rate">(<%# Eval("Rank", "{0:0.000}") %>)</span></td>
            <td><%# Eval("CalculatedLapTime") %></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
</div>