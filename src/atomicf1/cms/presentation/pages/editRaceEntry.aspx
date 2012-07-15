<%@ Page Language="C#" MasterPageFile="../../masterpages/umbracoPage.Master" AutoEventWireup="True" CodeBehind="editRaceEntry.aspx.cs" Inherits="atomicf1.cms.presentation.pages.editRaceEntry" %>
<%@ Register Namespace="umbraco.uicontrols" Assembly="controls" TagPrefix="umb" %>

<asp:Content ID="Content" ContentPlaceHolderID="body" runat="server">
    
    <umb:UmbracoPanel ID="Panel1" runat="server" hasMenu="true" Text="Edit Qualifying Result)">
        
        <umb:Pane ID="Pane1" runat="server">
            
            <umb:PropertyPanel ID="PPanel1" runat="server" Text="Driver">
                <asp:Label ID="Driver" runat="server" CssClass="guiInputText guiInputStandardSize"></asp:Label>                             
            </umb:PropertyPanel>
            
            <umb:PropertyPanel ID="PropertyPanel6" runat="server" Text="Qualifying Position">          
                <asp:TextBox ID="QualifyingPosition" runat="server" CssClass="guiInputText guiInputStandardSize" Width="150px" />&nbsp;<span>in number of positions (eg 10)</span>
            </umb:PropertyPanel>

            <umb:PropertyPanel ID="PPanel2" runat="server" Text="Qualifying Time">          
                <asp:TextBox ID="QualifyingTime" runat="server" CssClass="guiInputText guiInputStandardSize" Width="150px" />&nbsp;<span>in seconds (eg 78.543)</span>
            </umb:PropertyPanel>

            <umb:PropertyPanel ID="PropertyPanel3" runat="server" Text="Qualifying Time 2">          
                <asp:TextBox ID="QualifyingTime2" runat="server" CssClass="guiInputText guiInputStandardSize" Width="150px" />
            </umb:PropertyPanel>

            <umb:PropertyPanel ID="PropertyPanel4" runat="server" Text="Qualifying Time 3">          
                <asp:TextBox ID="QualifyingTime3" runat="server" CssClass="guiInputText guiInputStandardSize" Width="150px" />
            </umb:PropertyPanel>

            <umb:PropertyPanel ID="PropertyPanel2" runat="server" Text="Grid Position">          
                <asp:TextBox ID="GridPosition" runat="server" CssClass="guiInputText guiInputStandardSize" Width="150px" />&nbsp;<span>in number of positions (eg 10)</span>
            </umb:PropertyPanel>

            <umb:PropertyPanel ID="PropertyPanel1" runat="server" Text="Fastest Lap">          
                <asp:TextBox ID="FastestLap" runat="server" CssClass="guiInputText guiInputStandardSize" Width="150px" />&nbsp;<span>(eg 78.543)</span>
            </umb:PropertyPanel>

            <umb:PropertyPanel ID="PPanel31" runat="server" Text="Race Place">          
                <asp:TextBox ID="RacePlace" runat="server" CssClass="guiInputText guiInputStandardSize" Width="150px" />&nbsp;<span>(eg 1, 2, 3, 4)</span>
            </umb:PropertyPanel>

            <umb:PropertyPanel ID="PPanel3" runat="server" Text="Race Time">          
                <asp:TextBox ID="RaceTime" runat="server" CssClass="guiInputText guiInputStandardSize" Width="150px" />
            </umb:PropertyPanel>
            
            <umb:PropertyPanel ID="PPanel4" runat="server" Text="DNS">          
                <asp:CheckBox ID="DidNotStart" runat="server" CssClass="guiInputText guiInputStandardSize" Text="" />
            </umb:PropertyPanel>

            <umb:PropertyPanel ID="PropertyPanel5" runat="server" Text="DNQ">          
                <asp:CheckBox ID="DidNotQualify" runat="server" CssClass="guiInputText guiInputStandardSize" Text="" />
            </umb:PropertyPanel>

            <umb:PropertyPanel ID="PPanel5" runat="server" Text="DNF">          
                <asp:CheckBox ID="DidNotFinish" runat="server" CssClass="guiInputText guiInputStandardSize" Text="" />
            </umb:PropertyPanel>

            <umb:PropertyPanel ID="PPanel46" runat="server" Text="Disqualifed">          
                <asp:CheckBox ID="Disqualified" runat="server" CssClass="guiInputText guiInputStandardSize" Text="" />
            </umb:PropertyPanel>
       
        </umb:Pane>    
    
    </umb:UmbracoPanel>

</asp:Content>