<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExtractMasterDocType.aspx.cs" 
    Inherits="TheOutfield.UmbExt.DocTypeExtensions.Dialogs.ExtractMasterDocType" masterpagefile="~/umbraco/masterpages/umbracoDialog.Master" %>
<%@ Register TagPrefix="umb" Namespace="ClientDependency.Core.Controls" Assembly="ClientDependency.Core" %>
<%@ Register TagPrefix="cc1" Namespace="umbraco.uicontrols" Assembly="controls" %>

<asp:Content id="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.propertyItemheader { width: 100% !important; }
	</style>
</asp:Content>

<asp:content contentplaceholderid="body" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2 class="propertypaneTitel">Extract a master doc type from doc type '<%= DocType.Text %>'</h2>
            <asp:MultiView ID="mvExtractMasterDocType" runat="server" OnActiveViewChanged="mvExtractMasterDocType_ActiveViewChanged">
                <asp:View ID="vwEnterMasterDocTypeName" runat="server">
                    <cc1:pane runat="server">
                        <cc1:propertypanel runat="server" text="Enter a name for the new master doc type">
                            <asp:textbox id="txtMasterDocTypeName" runat="server" Width="350px" />
                        </cc1:propertypanel>
                    </cc1:pane>
                    <p><asp:Button ID="btnEnterMasterDocTypeName" runat="server" Text="OK" onclick="btnEnterMasterDocTypeName_Click" /> or <a href="#" onclick="UmbClientMgr.closeModalWindow()">Cancel</a></p>
                </asp:View>
                <asp:View ID="vwMapDocTypeProperties" runat="server">
                    <div class="propertypane">
                        <div>
                            <div class="propertyItem">
                            <div class="propertyItemheader">Select which properties to map to the new master doc type</div>
                            <div class="propertyItemContent">
                                <asp:checkboxlist id="cblProperties" runat="server" />
                            </div>
                            </div>
                            <div class='propertyPaneFooter'>-</div>
                        </div>
                    </div>
                    <p><asp:Button ID="btnMapDocTypeProperties" runat="server" Text="OK" onclick="btnMapDocTypeProperties_Click" /> or <a href="#" onclick="UmbClientMgr.closeModalWindow()">Cancel</a></p>
                </asp:View>
                <asp:View ID="vwConfirm" runat="server">
                    <div class="propertypane">
                        <div>
                            <div class="propertyItem">
                                <div class="propertyItemheader">Please review and confirm your changes</div>
                                <div class="propertyItemContent">
                                    <asp:Label ID="lblConfirmMessage" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class='propertyPaneFooter'>-</div>
                        </div>
                    </div>
                    <p><asp:Button ID="btnConfirm" runat="server" Text="Confirm" onclick="btnConfirm_Click" /> or <a href="#" onclick="UmbClientMgr.closeModalWindow()">Cancel</a></p>
                </asp:View>
                <asp:View ID="vwSuccess" runat="server">
                    <br />
                    <div class="success">
                        <p><asp:Label ID="lblSuccessMessage" runat="server" /></p>
                        <p><a href="#" onclick="UmbClientMgr.closeModalWindow()"><%= umbraco.ui.Text("defaultdialogs", "closeThisWindow")%></a></p>
                    </div>
                </asp:View>
                <asp:View ID="vwError" runat="server">
                    <br />
                    <div class="error">
                        <p><asp:Label ID="lblErrorMessage" runat="server" /></p>
                        <p><a href="#" onclick="UmbClientMgr.closeModalWindow()"><%= umbraco.ui.Text("defaultdialogs", "closeThisWindow")%></a></p>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <img src="/umbraco_client/images/progressbar.gif" width="220" height="19" alt="Processing request..." />
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:content>