<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="Configuracao.aspx.cs" Inherits="FW.UI.Configuracao" %>
<%@ MasterType VirtualPath="../Default.Master" %>
<%@ Register TagName="Configuracoes" TagPrefix="uc" Src="../ascx/Configuracoes.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
     <uc:Configuracoes runat="server" ID="ConfiguracoesControl" />

       
     
</asp:Content>
