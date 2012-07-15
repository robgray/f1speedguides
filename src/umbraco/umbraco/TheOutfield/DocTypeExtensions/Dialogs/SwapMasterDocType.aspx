<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SwapMasterDocType.aspx.cs" 
    Inherits="TheOutfield.UmbExt.DocTypeExtensions.Dialogs.SwapMasterDocType" masterpagefile="~/umbraco/masterpages/umbracoDialog.Master" %>
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
            <h2 class="propertypaneTitel">Swap the master doc type of doc type '<%= DocType.Text %>'</h2>
            <asp:MultiView ID="mvSwitchMasterDocType" runat="server" OnActiveViewChanged="mvSwitchMasterDocType_ActiveViewChanged">
                <asp:View ID="vwSelectTargetDocType" runat="server">
                    <cc1:pane runat="server">
                        <cc1:propertypanel runat="server" text="Select the target master doc type">
                            <asp:DropDownList ID="ddlTargetDocType" runat="server" Width="350px"></asp:DropDownList>
                            <%--<br />
                            <br />
                            <asp:checkbox id="cbMapDeletedProperties" runat="server" text="Move any unmapped properties to the source doc type?" />--%>
                        </cc1:propertypanel>
                    </cc1:pane>
                    <p><asp:Button ID="btnSelectTargetDocType" runat="server" Text="OK" onclick="btnSelectTargetDocType_Click" /> or <a href="#" onclick="UmbClientMgr.closeModalWindow()">Cancel</a></p>
                </asp:View>
                <asp:View ID="vwMapDocTypeProperties" runat="server">
                    <div class="propertypane">
                        <div>
                            <div class="propertyItem">
                            <div class="propertyItemheader">Map properties from doc type '<%= MasterDocType.Text %>' to '<%= TargetMasterDocType.Text %>'</div>
                            <div class="propertyItemContent">
                                <table style="width:100%">
                                    <thead>
                                        <tr>
                                            <th>Source</th>
                                            <th>Destination</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptDocTypeProperties" runat="server" OnItemDataBound="rptDocTypeProperties_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("Name") %></td>
                                                    <td>
                                                        <asp:Literal ID="litDropDown" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
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
                    <p><asp:Button ID="btnConfirm" runat="server" Text="Confirm" onclick="btnConfirm_Click" OnClientClick="return confirm('Continuing may result in a loss of data which cannot be undone. Click OK to continue, or Cancel to go back.');" /> or <a href="#" onclick="UmbClientMgr.closeModalWindow()">Cancel</a></p>
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