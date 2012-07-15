<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="createRaceEntry.ascx.cs" Inherits="atomicf1.cms.presentation.controls.createRaceEntry" %>
<input type="hidden" name="nodeType">
<div style="MARGIN-TOP: 20px">    
    Driver:<asp:RequiredFieldValidator id="RequiredFieldValidator1" ErrorMessage="*" ControlToValidate="DriversList" runat="server">*</asp:RequiredFieldValidator><br />
    <asp:DropDownList id="DriversList" CssClass="bigInput" Runat="server" width="300px"></asp:DropDownList>
    <!-- added to support missing postback on enter in IE -->
    <asp:TextBox runat="server" style="visibility:hidden;display:none;" ID="Textbox1" />    
</div>

<div style="padding-top: 25px;">
	<asp:Button id="sbmt" Runat="server" style="Width:90px" onclick="sbmt_Click" Text="Create"></asp:Button>
	&nbsp; <em>or</em> &nbsp;
  <a href="#" style="color: blue"  onclick="UmbClientMgr.closeModalWindow()">Cancel</a>
</div>
