<%@ Page Language="C#"  MasterPageFile="../../masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="editDriver.aspx.cs" Inherits="atomicf1.cms.presentation.pages.editDriver" %>
<%@ Register Namespace="umbraco.uicontrols" Assembly="controls" TagPrefix="umb" %>

<asp:Content ID="Content" ContentPlaceHolderID="body" runat="server">
    
    <umb:UmbracoPanel ID="Panel1" runat="server" hasMenu="true" Text="Edit Circuit">
        
        <umb:Pane ID="Pane1" runat="server">
            
            <umb:PropertyPanel ID="PPanel3" runat="server" Text="Atomic Username">
                <asp:TextBox ID="AtomicName" runat="server" MaxLength="50"
                CssClass="guiInputText guiInputStandardSize"></asp:TextBox>
            </umb:PropertyPanel>

            <umb:PropertyPanel ID="PPanel1" runat="server" Text="Driver Name">
                <asp:TextBox ID="DriverNameTextBox" runat="server" MaxLength="50" 
                CssClass="guiInputText guiInputStandardSize"></asp:TextBox>
            </umb:PropertyPanel>
            
            <umb:PropertyPanel ID="PPanel2" runat="server" Text="Nationality">                
                <asp:TextBox ID="NationalityTextBox" runat="server" MaxLength="50" 
                CssClass="guiInputText guiInputStandardSize"></asp:TextBox>
            </umb:PropertyPanel>
            
            <umb:PropertyPanel ID="PPanel4" runat="server" Text="Atomic User ID">
                <asp:TextBox ID="AtomicUserId" runat="server" MaxLength="50"
                CssClass="guiInputText guiInputStandardSize"></asp:TextBox>
            </umb:PropertyPanel>
            
        </umb:Pane>    

        <umb:Pane ID="Pane3" runat="server">
            <umb:PropertyPanel ID="PropertyPanel2" runat="server" Text="Member">
                <asp:DropDownList ID="MemberList" runat="server" CssClass="guiInputText guiInputStandardSize">
                </asp:DropDownList>
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