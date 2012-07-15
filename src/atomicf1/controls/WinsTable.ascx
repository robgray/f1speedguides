<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WinsTable.ascx.cs" Inherits="atomicf1.controls.WinsTable" %>
<div class="InlineResultBorder">
<div class="InlineResult">
<asp:Repeater ID="WinsRepeater" runat="server">
    <HeaderTemplate>
        <table width="100%">
            <tr>
                <th class="col1">Place</th>
                <th class="col2">Driver</th>
                <th class="col3">Wins</th>
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