<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="createCircuit.ascx.cs" Inherits="atomicf1.cms.presentation.controls.createCircuit" %>
<input type="hidden" name="nodeType">
<div style="MARGIN-TOP: 20px">    
    Circuit Name:<asp:RequiredFieldValidator id="RequiredFieldValidator1" ErrorMessage="*" ControlToValidate="rename" runat="server">*</asp:RequiredFieldValidator><br />
    <asp:TextBox id="rename" CssClass="bigInput" Runat="server" width="350px"></asp:TextBox>
    <!-- added to support missing postback on enter in IE -->
    <asp:TextBox runat="server" style="visibility:hidden;display:none;" ID="Textbox1"/>
    <br />
    Location:<asp:RequiredFieldValidator id="RequiredFieldValidator2" ErrorMessage="*" ControlToValidate="location" runat="server">*</asp:RequiredFieldValidator><br />
    <asp:TextBox id="location" CssClass="bigInput" Runat="server" width="350px"></asp:TextBox>
    <br />
    Country:<asp:RequiredFieldValidator id="RequiredFieldValidator3" ErrorMessage="*" ControlToValidate="country" runat="server">*</asp:RequiredFieldValidator><br />
    <asp:TextBox id="country" CssClass="bigInput" Runat="server" width="350px"></asp:TextBox>    
</div>

<div style="padding-top: 25px;">
	<asp:Button id="sbmt" Runat="server" style="Width:90px" onclick="sbmt_Click" Text="Create"></asp:Button>
	&nbsp; <em>or</em> &nbsp;
  <a href="#" style="color: blue"  onclick="UmbClientMgr.closeModalWindow()">Cancel</a>
</div>
