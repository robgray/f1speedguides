<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="createSeasonRace.ascx.cs" Inherits="atomicf1.cms.presentation.controls.createSeasonRace" %>
<input type="hidden" name="nodeType">
<div style="MARGIN-TOP: 20px">    
    Circuit:<asp:RequiredFieldValidator id="RequiredFieldValidator1" ErrorMessage="*" ControlToValidate="CircuitsList" runat="server">*</asp:RequiredFieldValidator><br />
    <asp:DropDownList ID="CircuitsList" runat="server" CssClass="bigInput" Width="300px"></asp:DropDownList>
    <!-- added to support missing postback on enter in IE -->
    <asp:TextBox runat="server" style="visibility:hidden;display:none;" ID="Textbox1"/>
    <br />
    Race Date:<asp:RequiredFieldValidator id="RequiredFieldValidator2" ErrorMessage="*" ControlToValidate="RaceDateBox" runat="server">*</asp:RequiredFieldValidator><br />
    <asp:TextBox id="RaceDateBox" CssClass="bigInput" Runat="server" width="200px"></asp:TextBox><span>&nbsp;E.G. 20/03/2010 7:00pm</span>

    <br />
    Percent Length:<asp:RequiredFieldValidator id="RequiredFieldValidator3" ErrorMessage="*" ControlToValidate="PercentLength" runat="server">*</asp:RequiredFieldValidator><br />
    <asp:TextBox id="PercentLength" CssClass="bigInput" Runat="server" width="50px" Text="40" ></asp:TextBox>
</div>

<div style="padding-top: 25px;">
	<asp:Button id="sbmt" Runat="server" style="Width:90px" onclick="sbmt_Click" Text="Create"></asp:Button>
	&nbsp; <em>or</em> &nbsp;
  <a href="#" style="color: blue"  onclick="UmbClientMgr.closeModalWindow()">Cancel</a>
</div>