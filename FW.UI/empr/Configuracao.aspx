<%@ Page Title="" Language="C#" MasterPageFile="~/empr/Default.Master" AutoEventWireup="true" CodeBehind="Configuracao.aspx.cs" Inherits="FW.UI.ConfiguracaoEmpr" %>
<%@ MasterType VirtualPath="~/empr/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="list-group w-auto my-4 font-monospace">
        
  <asp:LinkButton runat="server" PostBackUrl="~/empr/EditarRecrutador.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#person-lines-fill"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0 font-monospace fs-6 my-auto">Editar Recrutador</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>

        <asp:LinkButton runat="server" PostBackUrl="~/empr/EditarEndereco.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#geo-alt"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0 font-monospace fs-6 my-auto">Editar Endereço</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>
        <asp:LinkButton runat="server" PostBackUrl="~/empr/EditarRedeSociais.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#bezier"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0 font-monospace fs-6 my-auto">Editar Rede Sociais</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>
        <asp:LinkButton runat="server" PostBackUrl="~/empr/EditarFoto.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25" fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#camera"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0 font-monospace fs-6 my-auto">Editar Foto</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>
        <asp:LinkButton runat="server" PostBackUrl="~/empr/EditarEmpresa.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#cloud-upload"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0 font-monospace fs-6 my-auto">Editar Empresa</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>
 
</div>

      <%--  <div class="row">
          <div class="col-12 col-sm-6"><asp:HyperLink  runat="server" Text="Sair"> </asp:HyperLink></div>
          <div class="col-12 col-sm-6"><asp:HyperLink runat="server" Text="Configuração"> </asp:HyperLink></div>
      </div>--%>

        
    
  
</asp:Content>
