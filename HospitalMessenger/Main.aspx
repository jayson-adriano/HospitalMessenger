<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" MasterPageFile="~/MasterMain.Master" Inherits="HospitalMessenger.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="server">
    <div class="container" >
        <div class="row">
            <div style="text-align:center; font-family:'Courier New'; font-size:medium">
                <br />
                <br />Username:           
                <asp:TextBox ID="txtUsername" runat="server" Width="150px" ></asp:TextBox>
                <br /><br />Password:
                <asp:TextBox ID="txtPassword" runat="server" Width="150px"></asp:TextBox>
                <br /><br />
                <asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogin_Click" />
            </div>
        </div>
    </div>

</asp:Content>
