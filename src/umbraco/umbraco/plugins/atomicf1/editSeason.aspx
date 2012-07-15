<%@ Page Language="C#"  MasterPageFile="../../masterpages/umbracoPage.Master" AutoEventWireup="True" CodeBehind="editSeason.aspx.cs" Inherits="atomicf1.cms.presentation.pages.editSeason" %>
<%@ Register Namespace="umbraco.uicontrols" Assembly="controls" TagPrefix="umb" %>

<asp:Content ID="Content" ContentPlaceHolderID="body" runat="server">
    
    <umb:UmbracoPanel ID="Panel1" runat="server" hasMenu="true" Text="Edit Circuit">
        
        <umb:Pane ID="Pane1" runat="server">
            
            <umb:PropertyPanel ID="PropertyPanel3" runat="server" Text="Season Id">
                <asp:Label ID="SeasonIdLabel" runat="server"
                CssClass="guiInputStandardSize"></asp:Label>
            </umb:PropertyPanel>

            <umb:PropertyPanel ID="PPanel1" runat="server" Text="Season Name">
                <asp:TextBox ID="SeasonNameTextBox" runat="server" MaxLength="50" 
                CssClass="guiInputText guiInputStandardSize"></asp:TextBox>
            </umb:PropertyPanel>
            
            <umb:PropertyPanel ID="PPanel2" runat="server" Text="Year">                
                <asp:TextBox ID="YearTextBox" runat="server" MaxLength="50" 
                CssClass="guiInputText guiInputStandardSize"></asp:TextBox>
            </umb:PropertyPanel>
            
            <umb:PropertyPanel ID="PPanel3" runat="server" Text="Description">
                <asp:TextBox ID="DescriptionTextBox" runat="server" MAxLength="50"
                CssClass="guiInputText guiInputStandardSize"></asp:TextBox>
            </umb:PropertyPanel>

            <umb:PropertyPanel ID="PPanel4" runat="server" Text="Is Current">
                <asp:CheckBox ID="IsCurrent" runat="server" CssClass="guiInputStandardSize"></asp:CheckBox>
            </umb:PropertyPanel>
            
        </umb:Pane>    
            
        <umb:Pane ID="Pane2" runat="server">
            <umb:PropertyPanel ID="PropertyPanel1" runat="server" Text="Url">
                <asp:TextBox ID="UrlTextBox" runat="server" MaxLength="70"
                CssClass="guiInputText guiInputStandardSize"></asp:TextBox>
            </umb:PropertyPanel>
        </umb:Pane>

        <umb:Pane ID="Pane3" runat="server">
            <umb:PropertyPanel ID="PropertyPanel2" runat="server" Text="PointsSystem">
                <asp:DropDownList ID="PointsSystemList" runat="server" CssClass="guiInputText guiInputStandardSize"></asp:DropDownList>         
            </umb:PropertyPanel>
        </umb:Pane>

    </umb:UmbracoPanel>

</asp:Content>
