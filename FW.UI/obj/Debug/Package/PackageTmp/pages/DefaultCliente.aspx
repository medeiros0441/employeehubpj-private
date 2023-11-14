<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="DefaultCliente.aspx.cs" Inherits="FW.UI.pages.DefaultClient" %>
<%@ Register TagName="RptVagas" TagPrefix="uc" Src="../ascx/RptVagas.ascx" %>
<%@ Register TagName="RptCliente" TagPrefix="uc" Src="../ascx/CarroselCliente.ascx" %>
<%@ MasterType VirtualPath="../Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <uc:RptCliente runat="server" ID="RptClienteControl" />
            <uc:RptVagas runat="server" ID="RptVagasControl" />

</asp:Content>
