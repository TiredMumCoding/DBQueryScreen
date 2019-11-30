<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ProfileLogin.aspx.vb" Inherits="ProfileLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <h1 class="headertext">Login or Create a New Profile</h1><br /><br />
 <div class="defaultWrapperTop" id="LoginProfileBtns" runat="server">
<h2>
<asp:LinkButton ID="LoginToSys" CssClass="Btn" runat="server" Text="Login to System" OnClick="LoginForm" />
<asp:LinkButton ID="CreateProfile" CssClass="Btn" runat="server" Text="Create Profile" OnClick="CreateForm"/>
</h2>
</div>
<div id="LoginSection" runat="server">
<h2><asp:Label id="EmailLabel" runat="server" Text="Email Address: " CssClass="inputlabel"/>
<asp:TextBox ID="EmailTextBox" runat="server" cssclass="inputtextbox"/><br /><br />
<asp:Label id="PasswordLabel" runat="server" Text="Password: " CssClass="inputlabel"/>
<asp:TextBox ID="PasswordTextBox" runat="server" CssClass="inputtextbox" /></h2><br /><br />
<asp:button ID="LoginSubmit" runat="server" OnClick="LoginSub" Text="Submit" />
<asp:Button ID="LoginBack" runat="server" OnClick="BackBtn" Text="Back" />
</div>
 <div id="CreateSection" runat="server">
<h2><asp:Label id="FirstName" runat="server" Text="First Name: " CssClass="inputlabel"/>
<asp:TextBox ID="FirstNameTextBox" runat="server" cssclass="inputtextbox"/><br /><br />
<asp:Label id="LastName" runat="server" Text="Last Name: " CssClass="inputlabel"/>
<asp:TextBox ID="LastNameTextBox" runat="server" cssclass="inputtextbox"/><br /><br />
<asp:Label id="CreateEmailLabel" runat="server" Text="Email Address: " CssClass="inputlabel"/>
<asp:TextBox ID="CreateEmailTextBox" runat="server" cssclass="inputtextbox"/><br /><br />
<asp:Label id="Age" runat="server" Text="Age: " CssClass="inputlabel"/>
<asp:TextBox ID="AgeTextBox" runat="server" cssclass="inputtextbox"/><br /><br />
<asp:Label id="Gender" runat="server" Text="Gender: " CssClass="inputlabel"/>
<asp:DropDownList ID="GenderList" runat="server">
    <asp:ListItem Text="Male" />
    <asp:ListItem Text="Female" />
</asp:DropDownList><br /><br />
<asp:Label id="Hours" runat="server" Text="Workout Hours Per Week: " CssClass="inputlabel"/>
<asp:TextBox ID="HoursTextBox" runat="server" cssclass="inputtextbox"/><br /><br />
<asp:Label id="CreatePassword" runat="server" Text="Password: " CssClass="inputlabel"/>
<asp:TextBox ID="CreatePasswordTextBox" runat="server" cssclass="inputtextbox"/><br /><br />
 <asp:button ID="CreateSubmit" runat="server" OnClick="CreateSub" Text="Submit" />
<asp:Button ID="CreateBack" runat="server" OnClick="BackBtn" Text="Back" />
</h2>
      </div>
<div id="ErrorSection" runat="server">
<asp:Label ID="ErrorLabel" runat="server" />
</div>
</asp:Content>

