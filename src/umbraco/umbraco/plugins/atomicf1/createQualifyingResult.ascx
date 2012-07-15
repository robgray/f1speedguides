<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="createQualifyingResult.ascx.cs" Inherits="atomicf1.cms.presentation.controls.createQualifyingResult" %>
<input type="hidden" name="nodeType">
<div style="MARGIN-TOP: 20px">    
    Driver:<asp:RequiredFieldValidator id="RequiredFieldValidator1" ErrorMessage="*" ControlToValidate="DriversList" runat="server">*</asp:RequiredFieldValidator><br />
    <asp:DropDownList id="DriversList" CssClass="bigInput" Runat="server" width="300px"></asp:DropDownList>
    <!-- added to support missing postback on enter in IE -->
    <asp:TextBox runat="server" style="visibility:hidden;display:none;" ID="Textbox1" />
    <br />
    Lap Time:<asp:RequiredFieldValidator id="RequiredFieldValidator2" ErrorMessage="*" ControlToValidate="LapTime" runat="server">*</asp:RequiredFieldValidator><br />
    <asp:TextBox id="LapTime" CssClass="bigInput" Runat="server" width="150px"></asp:TextBox>&nbsp;<span>in seconds (eg 78.232)</span>  
</div>

<div style="padding-top: 25px;">
	<asp:Button id="sbmt" Runat="server" style="Width:90px" onclick="sbmt_Click" Text="Create"></asp:Button>
	&nbsp; <em>or</em> &nbsp;
  <a href="#" style="color: blue"  onclick="UmbClientMgr.closeModalWindow()">Cancel</a>
</div>
