<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3247_T3a.aspx.cs" Inherits="H3247_T3a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <img src="Images/hiihto.gif" alt="Hieno hiihtokuva" />
    <h1>Tervetuloa LadunSuhaajat-sivustolle</h1>

    <p>
        Käyttäjänimi: <asp:textbox ID="textboxUsername" runat="server" /><br />
        Salasana: <asp:textbox ID="textboxPassword" type="password" runat="server" /><br />
        <asp:button ID="buttonLogin" runat="server" text="Kirjaudu" OnClick="buttonLogin_Click" />
    </p>

    <p>
        <asp:Label ID="labelMessages" runat="server" />
    </p>
</asp:Content>

