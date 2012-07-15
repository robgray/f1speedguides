<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TeamDrivers.ascx.cs" Inherits="atomicf1.controls.TeamDrivers" %>
<div class="Pod">
      <div class="section">
        <h2>Current Drivers</h2>
        <asp:Repeater id="CurrentDriversRepeater" runat="server">
            <ItemTemplate>
                <li><a href='/drivers/<%# Eval("Driver.Url") %>'><%# Eval("Driver.Name") %></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="section">
        <h2>Past Drivers</h2>
        <asp:Repeater id="PastDriversRepeater" runat="server">
            <HeaderTemplate>
                <table width="100%">                
                    <colgroup>
                        <td width="120px"></td>
                        <td></td>
                    </colgroup>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td><a href='/drivers/<%# Eval("Driver.Url") %>'><%# Eval("Driver.Name") %></a></td>
                        <td><a href='/results/<%# Eval("Season.Url") %>'><%# Eval("Season.Name") %></a></td>
                    </tr>    
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>                    
    </div>
</div>