<%@ Page Language="C#"  MasterPageFile="../../masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="editCircuit.aspx.cs" Inherits="atomicf1.cms.presentation.pages.editCircuit" %>
<%@ Register Namespace="umbraco.uicontrols" Assembly="controls" TagPrefix="umb" %>

<asp:Content ID="Content" ContentPlaceHolderID="body" runat="server">
    
    <umb:UmbracoPanel ID="Panel1" runat="server" hasMenu="true" Text="Edit Circuit">
        
        <umb:Pane ID="Pane1" runat="server">
            
            <umb:PropertyPanel ID="PPanel1" runat="server" Text="Circuit Name">
                <asp:TextBox ID="CircuitNameTextBox" runat="server" MaxLength="50" 
                CssClass="guiInputText guiInputStandardSize"></asp:TextBox>
            </umb:PropertyPanel>
            
            <umb:PropertyPanel ID="PPanel2" runat="server" Text="Location">
                <asp:TextBox ID="LocationTextBox" runat="server" MaxLength="50" 
                CssClass="guiInputText guiInputStandardSize"></asp:TextBox>
            </umb:PropertyPanel>
            
            <umb:PropertyPanel ID="PPanel3" runat="server" Text="Country">
                <asp:TextBox ID="CountryTextBox" runat="server" MAxLength="50"
                CssClass="guiInputText guiInputStandardSize"></asp:TextBox>
            </umb:PropertyPanel>

            <umb:PropertyPanel ID="PPanel4" runat="server" Text="Image Uri">
                <asp:TextBox ID="ImageUri" runat="server" MaxLength="100"
                CssClass="guiInputText guiInputStandardSize"></asp:TextBox>
            </umb:PropertyPanel>

        </umb:Pane>    

        <umb:Pane ID="Pane2" runat="server">
            <umb:PropertyPanel ID="PropertyPanel1" runat="server" Text="Url">
                <asp:TextBox ID="UrlTextBox" runat="server" MaxLength="70"
                CssClass="guiInputText guiInputStandardSize"></asp:TextBox>
            </umb:PropertyPanel>
        </umb:Pane>
    
    </umb:UmbracoPanel>

</asp:Content>