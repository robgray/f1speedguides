<%@ Page Language="C#" MasterPageFile="../../masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="editSeasonRace.aspx.cs" Inherits="atomicf1.cms.presentation.pages.editSeasonRace" %>
<%@ Register Namespace="umbraco.uicontrols" Assembly="controls" TagPrefix="umb" %>

<asp:Content ID="Content" ContentPlaceHolderID="body" runat="server">
    
    <umb:UmbracoPanel ID="Panel1" runat="server" hasMenu="true" Text="View Season Entry (Driver Contract)">
        
        <umb:Pane ID="Pane1" runat="server">

            <umb:PropertyPanel ID="PropertyPanel1" runat="server" Text="Race Id">
                <asp:Label ID="RaceIdLabel" runat="server" CssClass="guiInputStandardSize" />
            </umb:PropertyPanel>

            
            <umb:PropertyPanel ID="PPanel1" runat="server" Text="Circuit">
                <asp:DropDownList ID="CircuitsList" runat="server" CssClass="guiInputText guiInputStandardSize"></asp:DropDownList>                             
            </umb:PropertyPanel>
            
            <umb:PropertyPanel ID="PPanel2" runat="server" Text="Race Date">          
                <asp:TextBox ID="RaceDate" runat="server" CssClass="guiInputText guiInputStandardSize" Width="150px" />&nbsp;<span>E.G. 20/03/2010 7:00pm</span>
            </umb:PropertyPanel>
            
            <umb:PropertyPanel ID="PPanel3" runat="server" Text="Percent Length">
                <asp:TextBox ID="PercentLength" runat="server" CssClass="guiInputText guiInputStandardSize" width="50px"/>
            </umb:PropertyPanel>

        </umb:Pane>    
    
    </umb:UmbracoPanel>

</asp:Content>