<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="atomicf1.controls.Membership.WebUserControl1" %>
<asp:Login ID="Login1" runat="server" DestinationPageUrl="/" 
    LoginButtonText="Login" onauthenticate="Login1_Authenticate" 
    VisibleWhenLoggedIn="False">
</asp:Login>
