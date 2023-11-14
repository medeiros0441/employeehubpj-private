<%@ Page Title="Erro" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Erro.aspx.cs" Inherits="FW.UI.Erro" %>
<%@ MasterType VirtualPath="~/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container px-auto my-5"> 
        
                     <asp:Panel runat="server" ID="Panel1" Visible="true">
                            <div class="  alert-danger alert-dismissible fade show col-12   my-2 mb-4" role="alert">
                       <svg class="bi  " width="30" height="30" fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#exclamation-triangle-fill"></use></svg>
                                    <asp:Label      runat="server"  ID="lblMensagem" CssClass=" p-1 font-monospace col-12" Visible="true"  />
                                </div>
                         <img src="../imagens/Undraw/undraw_server_down_s-4-lk.svg"  width="500" height="500" class="img-fluid mx-auto my-4"  /> 
                        </asp:Panel>
        </div>
</asp:Content>
