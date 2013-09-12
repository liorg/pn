<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="ManageEvacuees.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false" 
        PasswordRequiredErrorMessage="הכנס סיסמא." UserNameRequiredErrorMessage="הכנס שם משתמש" 
        FailureText="שם משתמש או סיסמא שגויים. נסה שוב או פנה למנהל מערכת">
        <LayoutTemplate>
            <div class="accountInfo">
                <fieldset class="login">
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">שם משתמש:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="הכנס שם משתמש." ToolTip="הכנס שם משתמש." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">סיסמא:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="הכנס סיסמא." ToolTip="הכנס סיסמא." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p class="submitButton">
                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="אישור" ValidationGroup="LoginUserValidationGroup"/>
                    </p>
                </fieldset>
            </center>
            </div>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
            <center>
        </LayoutTemplate>
    </asp:Login>



</asp:Content>
