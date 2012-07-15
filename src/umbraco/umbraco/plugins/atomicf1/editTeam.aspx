<%@ Page Language="C#"  MasterPageFile="../../masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="editTeam.aspx.cs" Inherits="atomicf1.cms.presentation.pages.editTeam" %>
<%@ Register Namespace="umbraco.uicontrols" Assembly="controls" TagPrefix="umb" %>

<asp:Content ID="Content" ContentPlaceHolderID="body" runat="server">
    
    <umb:UmbracoPanel ID="Panel1" runat="server" hasMenu="true" Text="Edit Team">
        
        <umb:Pane ID="Pane1" runat="server">
            
            <umb:PropertyPanel ID="PPanel1" runat="server" Text="Team Name">
                <asp:TextBox ID="TeamNameTextBox" runat="server" MaxLength="50" 
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