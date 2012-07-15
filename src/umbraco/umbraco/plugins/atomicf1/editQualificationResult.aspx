<%@ Page Language="C#" MasterPageFile="../../masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="editQualificationResult.aspx.cs" Inherits="atomicf1.cms.presentation.pages.editQualificationResult" %>
<%@ Register Namespace="umbraco.uicontrols" Assembly="controls" TagPrefix="umb" %>

<asp:Content ID="Content" ContentPlaceHolderID="body" runat="server">
    
    <umb:UmbracoPanel ID="Panel1" runat="server" hasMenu="true" Text="Edut Qualifying Result)">
        
        <umb:Pane ID="Pane1" runat="server">
            
            <umb:PropertyPanel ID="PPanel1" runat="server" Text="Driver">
                <asp:Label ID="Driver" runat="server" CssClass="guiInputText guiInputStandardSize"></asp:Label>                             
            </umb:PropertyPanel>
            
            <umb:PropertyPanel ID="PPanel2" runat="server" Text="Qualifying Time">          
                <asp:TextBox ID="QualifyingTime" runat="server" CssClass="guiInputText guiInputStandardSize" Width="150px" />&nbsp;<span>in seconds (eg 78.543)</span>
            </umb:PropertyPanel>
                        
        </umb:Pane>    
    
    </umb:UmbracoPanel>

</asp:Content>