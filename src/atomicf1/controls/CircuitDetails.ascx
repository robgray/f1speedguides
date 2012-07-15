<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CircuitDetails.ascx.cs" Inherits="atomicf1.controls.CircuitDetails" %>
<%@ Import Namespace="atomicf1" %>

<div class="PodBorder">
<div class="Pod">
<asp:Repeater ID="CircuitDetail" runat="server">
    <ItemTemplate>
        <div class="CircuitDetail Statistics">
            <table width="400px">
                <colgroup>
                    <th width="130px"></th>
                    <td></td>
                </colgroup>
                <tr>
                    <td colspan="2"><img src='<%# Eval("CircuitImageUri").ToString().GetImage(400) %>' alt="Circuit Map"/></td>                    
                </tr>                        
                <tr>
                    <th>Circuit</th>
                    <td><%# Eval("CircuitName") %></td>
                </tr>                            
                <tr>
                    <th>Location</th>
                    <td><%# Eval("CircuitLocation") %></td>
                </tr>                            
                <tr>
                    <th>Previous Winner</th>
                    <td><a href='/drivers/<%# Eval("PreviousWinnerUri") %>'><%# Eval("PreviousWinner") %></a></td>
                </tr>
                <tr>
                    <th>Qualifying Record</th>
                    <td><%# Eval("QualifyingRecord") %> (<a href='/drivers/<%# Eval("QualifyingRecordHolderUri") %>'><%# Eval("QualifyingRecordHolder") %></a>)</td>
                </tr>                                                                         
            </table>
        </div>
    </ItemTemplate>
</asp:Repeater>
</div>
</div>