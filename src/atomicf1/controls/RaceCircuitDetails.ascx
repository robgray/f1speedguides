<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RaceCircuitDetails.ascx.cs" Inherits="atomicf1.controls.RaceCircuitDetails" %>
<div class="RaceCircuit">
    <div class="fl">
        <img src="/ImageGen.ashx?image=/images/circuits/<%= CircuitImageUrl %>" alt="Circuit Map" />
    </div>
    <div class="fl">
        <table width="100%">        
            <colgroup>
                <th width="80px"></th>
                <td></td>
            </colgroup>
            <tr>
                <th>Location</th>
                <td><a href="/circuits/<%= CircuitUrl %>"><%= Name %> - <%= Location %></a></td>
            </tr>
            <tr>
                <th>Distance</th>
                <td><%= Distance %></td>
            </tr>
        </table>
    </div>
</div>