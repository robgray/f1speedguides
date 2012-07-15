<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="createSeasonEntry.ascx.cs" Inherits="atomicf1.cms.presentation.controls.createSeasonEntry" %>
<input type="hidden" name="nodeType">
<div style="MARGIN-TOP: 20px">    
    Driver:<asp:RequiredFieldValidator id="RequiredFieldValidator1" ErrorMessage="*" ControlToValidate="DriverList" runat="server">*</asp:RequiredFieldValidator><br />
    <asp:DropDownList ID="DriverList" runat="server" CssClass="bigInput" Width="300px" />
    <!-- added to support missing postback on enter in IE -->
    <asp:TextBox runat="server" style="visibility:hidden;display:none;" ID="Textbox1"/>
    <br />
    Team:<asp:RequiredFieldValidator id="RequiredFieldValidator2" ErrorMessage="*" ControlToValidate="TeamList" runat="server">*</asp:RequiredFieldValidator><br />
    <asp:DropDownList ID="TeamList" runat="server" CssClass="bigInput" Width="300px" />    
</div>

<div style="padding-top: 25px;">
	<asp:Button id="sbmt" Runat="server" style="Width:90px" onclick="sbmt_Click" Text="Create"></asp:Button>
	&nbsp; <em>or</em> &nbsp;
  <a href="#" style="color: blue"  onclick="UmbClientMgr.closeModalWindow()">Cancel</a>
</div>