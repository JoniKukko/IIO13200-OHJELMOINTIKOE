<%@ Page Title="H3247 Tehtävä 1c" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3247_T1c.aspx.cs" Inherits="H3247_T1c" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <p>
        <asp:textbox ID="textboxString" runat="server" />
        <asp:button ID="buttonCalculate" runat="server" text="Calculate" OnClick="buttonCalculate_Click" />
    </p>
    <p>
        <asp:label ID="labelMessages" runat="server" />
    </p>
    <p>
        <asp:GridView ID="gridviewLetters" runat="server" />
    </p>
</asp:Content>

