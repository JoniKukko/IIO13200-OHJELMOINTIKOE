<%@ Page Title="" Language="C#" MasterPageFile="~/T3LoggedIn.master" AutoEventWireup="true" CodeFile="H3247_T3a_AddNew.aspx.cs" Inherits="H3247_T3a_AddNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    Nimi: <asp:TextBox ID="textboxName" runat="server" /><br />
    Päivämäärä: <asp:TextBox ID="textboxDate" type="date" runat="server" /><br />
    Kesto: <asp:TextBox ID="textboxHours" type="number" min="0" max="24" runat="server" />h ja <asp:TextBox ID="textboxMinutes" type="number" min="0" max="59" runat="server" />m<br />
    Hiihdetty: <asp:TextBox ID="textboxKilometers" type="number" min="1" runat="server" />km<br />
    <asp:Button ID="buttonSave" runat="server" Text="Tallenna" OnClick="buttonSave_Click" />
</asp:Content>

