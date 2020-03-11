<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HospitalMessenger.Register" MasterPageFile="~/MasterMain.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="server">
    <div class="container">
        <div class="row">
            <div style="text-align: center">
                <h1>REGISTER</h1>
            </div>
            <div style="text-align: left; font-family: 'Courier New'; font-size: medium">
                <div style="float: left; width: 370px; margin-left: 120px">
                    <br />
                    First Name:           
                <asp:TextBox ID="txtFirst" runat="server" Width="170px"></asp:TextBox>
                    <br />
                    Middle Name:           
                <asp:TextBox ID="txtMiddle" runat="server" Width="162px"></asp:TextBox>
                    <br />
                    Last Name:           
                <asp:TextBox ID="txtLast" runat="server" Width="177px"></asp:TextBox>
                    <br />
                    Gender:
                    <asp:DropDownList ID="ddGender" runat="server" Width="217px">
                        <asp:ListItem Text="Male" Value="Male" Selected="True" />
                        <asp:ListItem Text="Female" Value="Female" />
                    </asp:DropDownList>
                    <br />
                    Address:           
                <asp:TextBox ID="txtAddress" runat="server" Width="194px"></asp:TextBox>
                    <br />
                </div>

                <div style="float: right; width: 370px">
                    Username:           
                <asp:TextBox ID="txtUsername" runat="server" Width="170px"></asp:TextBox>
                    <br />
                    Password:
                <asp:TextBox ID="txtPassword" runat="server" Width="170px"></asp:TextBox>
                    <br />
                    Contact:           
                <asp:TextBox ID="txtContact" runat="server" Width="180px"></asp:TextBox>
                    <br />
                    Email:           
                <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
                    <br />
                    Birthday:           
                <asp:TextBox ID="txtBirthday" runat="server" Width="170px"></asp:TextBox>
                    <br />
                </div>
                <br />
                <br />
            </div>
        </div>
        <div style="text-align: center">
            <asp:Button ID="btnLogIn" runat="server" Text="Register" OnClick="Register_Click" />
            <div>
            </div>
        </div>
    </div>
</asp:Content>
