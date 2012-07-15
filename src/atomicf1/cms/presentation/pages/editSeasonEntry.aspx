<%@ Page Language="C#"  MasterPageFile="../../masterpages/umbracoPage.Master" AutoEventWireup="true" CodeBehind="editSeasonEntry.aspx.cs" Inherits="atomicf1.cms.presentation.pages.editSeasonEntry" %>
<%@ Register Namespace="umbraco.uicontrols" Assembly="controls" TagPrefix="umb" %>

<asp:Content ID="Content" ContentPlaceHolderID="body" runat="server">
    
    <umb:UmbracoPanel ID="Panel1" runat="server" hasMenu="true" Text="View Season Entry (Driver Contract)">
        
        <umb:Pane ID="Pane1" runat="server">
            
            <umb:PropertyPanel ID="PPanel1" runat="server" Text="Driver">
                <asp:Label ID="DriverName" runat="server" CssClass="guiInputText guiInputStandardSize" />
                
            </umb:PropertyPanel>
            
            <umb:PropertyPanel ID="PPanel2" runat="server" Text="Team">                          
                <asp:DropDownList ID="TeamList" runat="server" CssClass="guiInputText guiInputStandardSize" />
            </umb:PropertyPanel>

            <umb:PropertyPanel ID="PropertyPanel2" runat="server" Text="Is Reserve">
                <asp:CheckBox ID="ReserveDriverCheckbox" runat="server" CssClass="guiInputText guiInputStandardSize" />
            </umb:PropertyPanel>
            
            <umb:PropertyPanel ID="PPanel3" runat="server" Text="Contract Signed">
                <asp:Label ID="ContractSigned" runat="server" CssClass="guiInputText guiInputStandardSize" />
            </umb:PropertyPanel>

            <umb:PropertyPanel ID="PropertyPanel1" runat="server" Text="Contract Terminated">
                <asp:Label ID="ContractTerminated" runat="server" CssClass="guiInputText guiInputStandardSize" />
            </umb:PropertyPanel>
            
        </umb:Pane>    
    
    </umb:UmbracoPanel>

</asp:Content>