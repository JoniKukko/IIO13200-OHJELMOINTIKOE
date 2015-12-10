<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3247_T2a.aspx.cs" Inherits="H3247_T2a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <p>
        Näytä vain: 
        <asp:LinkButton ID="filterVakituset" runat="server" Text="Vakituiset" OnClick="filterVakituset_Click" /> 
        <asp:LinkButton ID="filterMaaraaikaiset" runat="server" Text="Määräaikaiset" OnClick="filterMaaraaikaiset_Click" /> 
        <asp:LinkButton ID="filterMuut" runat="server" Text="Muut" OnClick="filterMuut_Click" />
    </p>
    <asp:GridView ID="gridviewWorkers" runat="server"></asp:GridView>
    <p>
        <asp:Label ID="labelMessages" runat="server"></asp:Label>
    </p>
</asp:Content>

