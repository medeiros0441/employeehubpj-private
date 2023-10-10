<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ListEmpresas.aspx.cs" Inherits="FW.UI.ListEmpresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container px-auto"> 
        
                     <asp:Panel runat="server" ID="Panel1" Visible="true">
                            <div class="alert alert-success alert-dismissible fade show col-12   my-2 mb-4" role="alert">
                                    
                       <svg class="bi  " width="25" height="25" fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#exclamation-triangle-fill"></use></svg>
                                    <asp:Label runat="server" ID="lblMensagem" CssClass="alert p-1 font-monospace col-12" Visible="true" Text="Ops, estamos trabalhando para manter a melhor qualidade no sistema. Tanto na parte opercional e visual pois acreditaos que essas coisas devem andar juntas." />
                                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                                </div>
                         <img src="../imagens/Undraw/undraw_donut_love_kau1.svg"  width="500" height="500" class="img-fluid mx-auto my-4"  /> 
                        </asp:Panel>
        </div>
</asp:Content>
