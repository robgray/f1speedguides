<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RaceResultsLookup.ascx.cs" Inherits="atomicf1.controls.RaceResultsLookup" %>
<%@ Register Src="InlineResult.ascx" TagName="InlineResult" TagPrefix="af1" %>

<div class="RaceResults">
    <div class="Form">
        <div class="Field">
            <label>Season</label>
            <asp:DropDownList ID="SeasonList" runat="server" 
                onselectedindexchanged="SeasonList_SelectedIndexChanged" 
                AutoPostBack="True"></asp:DropDownList>
        </div>
        <div class="Field">        
            <label>Race</label>            
            <asp:DropDownList ID="RaceList" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="TypeList" runat="server">
                <asp:ListItem Value="Qualifying" Text="Qualifying"></asp:ListItem>
                <asp:ListItem Value="Race" Text="Race" Selected="True"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:LinkButton ID="ShowResultsButton" runat="server" Text="Show Results" 
                onclick="ShowResultsButton_Click" />
        </div>
    </div>

    <asp:Panel ID="ResultsPanel" runat="server" Visible="false">
        <af1:InlineResult ID="ResultDisplay" runat="server" />
    </asp:Panel>
</div>
