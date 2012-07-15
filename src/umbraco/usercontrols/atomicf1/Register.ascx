<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Register.ascx.cs" Inherits="atomicf1.controls.Membership.Register" %>
<asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
    CreateUserButtonText="Join">
    <WizardSteps>
        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" 
            Title="Join atomicf1.com">
        </asp:CreateUserWizardStep>
        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" 
            Title="Registration Complete">
        </asp:CompleteWizardStep>
    </WizardSteps>
</asp:CreateUserWizard>
