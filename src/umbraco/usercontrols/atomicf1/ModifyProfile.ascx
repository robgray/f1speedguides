<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModifyProfile.ascx.cs" Inherits="atomicf1.controls.ModifyProfile" %>
<%@ Register Assembly="atomicf1" Namespace="atomicf1.controls" TagPrefix="af1" %>

<div class="ProfileForm">
    <div class="Messages grid_11 alpha">
        <af1:MessagePanel runat="server" ID="Messages" />
        <asp:ValidationSummary ID="ValidSummary" runat="server" 
            HeaderText="Profile Errors" CssClass="ValidationSummary" ShowSummary="true" />        
    </div>
    <asp:PlaceHolder runat="server" ID="DataHolder">
        <div class="grid_5 alpha">
            <fieldset>        
                <div class="Field">
                    <label for="<%= GamerTagTextBox.ClientID %>">Gamer Tag</label>
                    <asp:TextBox runat="server" ID="GamerTagTextBox" />
                    <asp:RequiredFieldValidator ID="rfvGamerTag" runat="server" ErrorMessage="You must supply your Games for Windows Live Tag" 
                        ControlToValidate="GamerTagTextBox" Display="None"></asp:RequiredFieldValidator>
                </div>
                <div class="Field">
                    <label for="<%= AtomicUsernameTextBox.ClientID %>">Atomic Username</label>
                    <asp:TextBox runat="server" ID="AtomicUsernameTextBox" />            
                </div>
                <div class="Field">
                    <label for="<%= AtomicUserIdTextBox.ClientID %>">Atomic User Id</label>
                    <asp:TextBox runat="server" ID="AtomicUserIdTextBox" />
                    <asp:RegularExpressionValidator ID="revAtomicId" runat="server" ErrorMessage="Please enter a valid Atomic User Id Number." 
                        ControlToValidate="AtomicUserIdTextBox" ValidationExpression="^[0-9]*$" Display="None"></asp:RegularExpressionValidator>
                </div>        
            </fieldset>
            <fieldset>
                <div class="Field">
                    <label for="<%= ControllerTextBox.ClientID %>">Controller</label>
                    <asp:TextBox runat="server" ID="ControllerTextBox" />            
                </div>
                <div class="Field">
                    <label for="<%= RacingViewTextBox.ClientID %>">Racing View</label>
                    <asp:TextBox runat="server" ID="RacingViewTextBox" />            
                </div>
                <div class="Field">
                    <label for="<%= FavouriteTracksTextBox.ClientID %>">Favourite Tracks</label>
                    <asp:TextBox runat="server" ID="FavouriteTracksTextBox" />            
                </div>
                <div class="Field">
                    <label for="<%= DislikedTracks.ClientID %>">Disliked Tracks</label>
                    <asp:TextBox runat="server" ID="DislikedTracks" />            
                </div>                
            </fieldset>
        </div>
        <div class="grid_5 omega">
            <fieldset>
                <div class="Field">
                    <label for="<%= PCSpecTextBox.ClientID %>">PC Spec</label>
                    <asp:TextBox runat="server" ID="PCSpecTextBox" TextMode="MultiLine" Rows="10" />            
                </div>
            </fieldset>
        </div>
        <div class="grid_11 alpha">
            <fieldset>
                <div class="Field">
                    <label for="<%= AboutTextBox.ClientID %>">About</label>
                    <asp:TextBox runat="server" ID="AboutTextBox" TextMode="MultiLine" Rows="20" />            
                </div>
            </fieldset>
        </div>
        <div class="grid_11 alpha" style="text-align: center">
            <asp:LinkButton runat="server" ID="UpdateProfileButton" Text="Update" CssClass="button" OnClick="UpdateProfileButton_Click" />
        </div>            
    </asp:PlaceHolder>
</div>